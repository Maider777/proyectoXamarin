using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Login.ShopMenuPage;

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
                    DisplayAlert("Alert", producto.Precio.ToString(), "OK");
                    Productos.Add(producto);
                }

            }
            catch (Exception e)
            {
                DisplayAlert("Alert", e.Message, "OK");
                Console.WriteLine(e.Message);
            }
        }

    }
}