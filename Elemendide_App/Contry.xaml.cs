using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contry : ContentPage
    {
        public ObservableCollection<Country> Countrys { get; set; }
        Label lbl_list;
        ListView List;
        Button lisa, kustuta;
        Entry en;
        MediaFile file;
        string imageName;
        string filePath;
        public Contry()
        {
            Countrys = new ObservableCollection<Country>
            {
                new Country {Nimetus="Eesti", Pealinn="Tallinn",Elanikearv="1 367 716", lipp="eesti1.jpg"},
                new Country {Nimetus="Luksemburg", Pealinn="Luksemburg",Elanikearv="632 275", lipp="luksem.jpg"},
                new Country {Nimetus="Rootsi", Pealinn="Stockholm",Elanikearv="10 409 248 ", lipp="rootsi.jpg"},
                new Country {Nimetus="Saksamaa", Pealinn="Berliin",Elanikearv="83 149 300", lipp="saksamaa.jpg"}


            };
            lbl_list = new Label
            {
                Text = "Riikide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            List = new ListView
            {
                SeparatorColor = Color.AliceBlue,
                Header = "Riik",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = Countrys,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.White, DetailColor = Color.White };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = " {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    Binding a = new Binding { Path = "Elanikkearv", StringFormat = "Elanikkonnast: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, a);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "lipp");
                    return imageCell;

                })
            };
            lisa = new Button { Text = "Lisa riik" };
            kustuta = new Button { Text = "Kustuta riik" };
            List.ItemTapped += List_ItemTapped;
            kustuta.Clicked += Kustuta_Clicked;
            lisa.Clicked += Lisa_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, List, lisa, kustuta } };
        }
        public List<string> Uris;
        private ObservableCollection<MediaFile> _images;
        public ObservableCollection<MediaFile> Images {
            get { return _images ?? (_images = new ObservableCollection<MediaFile>()); }
            set {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged();
                }
            }
        }

 
        public async Task<string> PickPictureAsync()
        {

            file = null;
            filePath = string.Empty;
            imageName = string.Empty;

            try
            {
                file = await CrossMedia.Current.PickPhotoAsync();

                #region Null Check

                if (file == null) { return null; }                                                                                 //Not returning false here so we do not show an error if they simply hit cancel from the device image picker

                #endregion

                imageName = "SomeImageName.jpg";

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\nIn PictureViewModel.PickPictureAsync() - Exception:\n{0}\n", ex);                          
                return null;
            }
            finally { if (file != null) { file.Dispose(); } }



            return imageName;
        }
        private async void Lisa_Clicked(object sender, EventArgs e)
        {

            //telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
            string site = await DisplayPromptAsync("Millise riigi soovite lisada?", "Kirjuta see ules", keyboard: Keyboard.Text);

            string site2 = await DisplayPromptAsync("Mis on selle pealinn?", "Kirjuta see ules", keyboard: Keyboard.Text);

            string site3 = await DisplayPromptAsync("Kui palju inimesi see elab?", "Kirjuta see ules", keyboard: Keyboard.Numeric);
            PickPictureAsync();
            var site4 = Images;

            Countrys.Add(item: new Country { Nimetus = site, Pealinn = site2, Elanikearv = site3, lipp = site4.ToString() });

        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Country country = List.SelectedItem as Country;
            if (country != null)
            {
                Countrys.Remove(country);
                List.SelectedItem = null;
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Country selectedPhone = e.Item as Country;
            if (selectedPhone != null)
                await DisplayAlert("Riik", $"{selectedPhone.Pealinn}-{selectedPhone.Nimetus}", "OK");
        }


    }
}