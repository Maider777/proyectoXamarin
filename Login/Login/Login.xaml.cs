using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Login.ShopMenuPage;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public class users
        {
            [PrimaryKey, AutoIncrement]
            public string User { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string Email { get; set; }
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "usersPasswords.db");
                var conn = new SQLiteConnection(dbPath);

                // Consulta SQL para seleccionar todos los productos
                var users = conn.Query<users>("SELECT * FROM users");

                bool userFound = false;

                foreach (var user in users)
                {
                    var firstName = user.FirstName;
                    var password = user.Password;

                    if (txtUsername.Text.Equals(firstName))
                    {
                        if (txtPassword.Text.Equals(password))
                        {
                            DisplayAlert("", "Username and password correct", "OK");
                            Navigation.PushModalAsync(new ShopMenuPage());
                            Console.WriteLine("CORRECT");
                            userFound = true;
                            break;
                        }
                    }
                }

                if (!userFound)
                {
                    DisplayAlert("", "Incorrect username or password", "OK");
                }
            }
            catch (Exception e2)
            {
                DisplayAlert("", "Something went wrong", "OK");
                Console.WriteLine(e2.Message);
            }
        }


        private void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }

    }
}