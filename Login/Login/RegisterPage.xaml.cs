using Mysqlx.Connection;
using SQLite;
using System;
using System.IO;
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

        public class users
        {
            [PrimaryKey, AutoIncrement]
            public string User { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string Email { get; set; }
        }


        //clase para registrarse
        private async void SignUpButtonClicked(object sender, EventArgs e)
        {
            // guardar campos
            string user = txtUser.Text;
            string password = txtPassword.Text;
            string repPassword = txtRepPassword.Text;
            string firstName = txtFName.Text;
            string secondName = txtSName.Text;
            string email = txtEmail.Text;

            // crear conexión SQLite
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "usersPasswords.db");
            var conn = new SQLiteConnection(dbPath);

            // crear objeto de tu modelo
            users tabla = new users();
            tabla.User = user;
            tabla.Password = password;
            tabla.FirstName = firstName;
            tabla.SecondName = secondName;
            tabla.Email = email;

            // insertar objeto en tabla
            conn.Insert(tabla);

            // cerrar conexión
            conn.Close();

            DisplayAlert("", "Registration successful", "OK");

            // volver a página inicial
            Navigation.PushModalAsync(new Login());
        }


    }
}