using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Login.ShopMenuPage;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopMenuPage : ContentPage
    {
        public ShopMenuPage()
        {
            InitializeComponent();
            mysqlConnection();
        }

        public class Producto
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nombre { get; set; }
            public float Precio { get; set; }
        }


        public void mysqlConnection()
        {
            try
            {
                //crear conexion de la bbdd
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "productos.db3");

                Console.WriteLine(dbPath);
                var conn = new SQLiteConnection(dbPath);

                conn.CreateTable<Producto>();

                // Insertar un nuevo registro en la tabla
                var nuevoProducto = new Producto { Nombre = "Ergometro", Precio = 100 };
                conn.Insert(nuevoProducto);

                // Leer todos los registros de la tabla
                List<Producto> productos = conn.Table<Producto>().ToList();
            }
            catch (Exception e)
            {
                DisplayAlert("Alert", e.Message, "OK");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}