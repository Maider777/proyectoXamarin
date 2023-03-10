using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void buttonClicked(object sender, EventArgs e)
        {
            //verificar datos login
            string username = "maider";
            try
            {
                if (!txtUsername.Text.Equals(username) || (txtUsername == null))
                {
                    DisplayAlert("Alert", "username not correct", "OK");
                    Console.WriteLine("Error, username not correct");
                }
                else
                {
                    //if username OK
                    string password = "a";
                    if (!txtPassword.Text.Equals(password) || txtPassword == null)
                    {
                        DisplayAlert("Alert", "password not correct", "OK");
                        Console.WriteLine("Error, password not correct");
                    }
                    else
                    {
                        //if is OK
                        //open shop menu page
                        DisplayAlert("", "username and password corrects", "OK");
                        Navigation.PushModalAsync(new ShopMenuPage());
                        Console.WriteLine("CORRECT");
                    }
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
            //abrir tienda en linea
        }
    }
}