using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elemendide_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //InitializeComponent();

            Button Ent_btn = new Button()
            {
                Text = "Entry",
                BackgroundColor = Color.LightBlue,
            };

            Button Timer_btn = new Button()
            {
                Text = "Timer",
                BackgroundColor = Color.LightBlue,
            };
            Button cliker = new Button()
            {
                Text = "Clicker",
                BackgroundColor = Color.LightBlue,
            };
            Button Date_btn = new Button()
            {
                Text = "Date/Time",
                BackgroundColor = Color.LightBlue,
            };
            Button SS_btn = new Button()
            {
                Text = "Stepper/Slider",
                BackgroundColor = Color.LightBlue,
            };
            Button frame_btn = new Button()
            {
                Text = "Frame_Page",
                BackgroundColor = Color.LightBlue,
            };
            frame_btn.Clicked += Frame_btn_Clicked;
            Button image_btn = new Button()
            {
                Text = "Image",
                BackgroundColor = Color.LightBlue,
            };
            image_btn.Clicked += Image_btn_Clicked;
            Button Valgusfoor_btn = new Button()
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.LightBlue,
            };
            Button RGB_Btn = new Button()
            {
                Text = "RGB colors",
                BackgroundColor = Color.LightBlue,
            };
            Button TTT = new Button()
            {
                Text = "Trips Traps Trull",
                BackgroundColor = Color.LightBlue,
            };
            Button PP = new Button()
            {
                Text = "Picker Page",
                BackgroundColor = Color.LightBlue,
            };
            Button TP = new Button()
            {
                Text = "TablePage",
                BackgroundColor = Color.LightBlue,
            };
            Button H = new Button()
            {
                Text = "Maakondad Page",
                BackgroundColor = Color.LightBlue,
            };
            Button horos = new Button()
            {
                Text = "Horoskop Page",
                BackgroundColor = Color.LightBlue,
            };
            Button listViev = new Button()
            {
                Text = "ListView",
                BackgroundColor = Color.LightBlue,
            };
            Button Country = new Button()
            {
                Text = "Riigid",
                BackgroundColor = Color.LightBlue,
            };
            listViev.Clicked += ListViev_Clicked;
            RGB_Btn.Clicked += RGB_Btn_Clicked;
            Valgusfoor_btn.Clicked += Valgusfoor_btn_Clicked;
            TTT.Clicked += TTT_Clicked;
            PP.Clicked += PP_Clicked;
            TP.Clicked += TP_Clicked;
            Country.Clicked += Country_Clicked;
            StackLayout st = new StackLayout()
            {
                Children = { Ent_btn , Timer_btn , cliker , Date_btn , SS_btn , frame_btn , image_btn, Valgusfoor_btn, RGB_Btn, TTT, PP, TP, H, horos, listViev, Country }
            };
            ScrollView scrollView = new ScrollView { Content = st };
            st.BackgroundColor = Color.AntiqueWhite;
            
            Ent_btn.Clicked += Ent_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            cliker.Clicked += Cliker_Clicked;
            Date_btn.Clicked += Date_btn_Clicked;
            SS_btn.Clicked += SS_btn_Clicked;
            H.Clicked += H_Clicked;
            horos.Clicked += Horos_Clicked;
            Content = scrollView;
        }

        private async void Country_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contry());
        }

        private async void ListViev_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List_Page());
        }

        private async void Horos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Horoskop());
        }

        private async void H_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Harjatus());
        }

        private async void TP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page());
        }

        private async void PP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Page());
        }

        private async void TTT_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TTT_Start());
        }

        private async void RGB_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RGB());
        }

        private async void Valgusfoor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }

        private async void Image_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Image_page());
        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Frame_Page());
        }

        private async void SS_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_page());
        }

        private async void Date_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Date_Time());
        }

        private async void Cliker_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new cliker());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ent_page());
        }
    }
    
}
