using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopMenuPage : ContentPage
    {
        public List<Producto> Productos { get; set; }
        public ShopMenuPage()
        {
            InitializeComponent();
            Productos = new List<Producto>();
            BindingContext = this;
            mysqlConnection();
        }

        public class Producto
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nombre { get; set; }
            public float Precio { get; set; }
            public byte[] Imagen { get; set; }
            public ImageSource ImagenSource { get; set; }
        }


        public void mysqlConnection()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "productosSqLite.db");
                var conn = new SQLiteConnection(dbPath);

                // Consulta SQL para seleccionar todos los productos
                var productos = conn.Query<Producto>("SELECT * FROM productos");

                // Iterar sobre los resultados de la consulta
                foreach (var producto in productos)
                {
                    // Aquí puedes hacer lo que quieras con cada producto, por ejemplo mostrarlo en una lista
                    Console.WriteLine(producto.Nombre);
                    Console.WriteLine(producto.Precio);
                    Console.WriteLine(producto.Imagen);

                    // Convert Byte[] to Base64
                    string imageBase64 = Convert.ToBase64String(producto.Imagen);
                    // Convert Base64string to Stream  
                    byte[] bytes = System.Convert.FromBase64String(imageBase64);
                    //ImageSource.FromStream(() => new MemoryStream(bytes));
                    producto.ImagenSource = ImageSource.FromStream(() => new MemoryStream(bytes));
                    Productos.Add(producto);
                }

            }
            catch (Exception e)
            {
                DisplayAlert("Alert", e.Message, "OK");
                Console.WriteLine(e.Message);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //al clickar boton de usuario
            //opciones:lista de deseos, ajustes de la cuenta, cerrar sesion
            Navigation.PushModalAsync(new Login());
        }

        int numProductos = 0;

        private void ImageButton_Clicked2(object sender, EventArgs e)
        {
            // Incrementa el contador de productos
            numProductos++;

            // Actualiza el texto del Label y muestra el Label
            NumProductosLabel.Text = numProductos.ToString();
            NumProductosLabel.IsVisible = true;
        }

    }
}