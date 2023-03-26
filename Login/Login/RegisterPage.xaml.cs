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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //clase para registrarse
        private async void SignUpButtonClicked(object sender, EventArgs e)
        {
            //guardar campos
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string repPassword = txtRepPassword.Text;
            string firstName = txtFName.Text;
            string secondName = txtSName.Text;
            string email = txtEmail.Text;

            //guardar en sql

            //volver a pagina inicial
            await Navigation.PopToRootAsync();
        }

    }
}