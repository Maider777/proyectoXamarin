using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopMenuPage : ContentPage
    {
        //variables
        public List<Producto> Productos { get; set; }
        public static List<Producto> CestaProductos { get; set; }
        public static int numProductos=0;
        public static float total;
        public static Label numProductosLabel { get; set; }

        public ShopMenuPage()
        {
            InitializeComponent();
            //crear lista de productos
            Productos = new List<Producto>();
            //crear lista de productos de la cesta
            CestaProductos = new List<Producto>();
            BindingContext = this;
            numProductosLabel = NumProductosLabel;
            mysqlConnection();
        }

        //crear producto
        public class Producto
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Precio { get; set; }
            public byte[] Imagen { get; set; }
            public string Descripcion { get; set; }
            public ImageSource ImagenSource { get; set; }
            public int ImageButtonId { get; set; }
        }


        //crear conexion y mostrar productos
        public void mysqlConnection()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "productosSqLite.db");
                var conn = new SQLiteConnection(dbPath);

                // Consulta SQL para seleccionar todos los productos
                var productos = conn.Query<Producto>("SELECT * FROM productos");

                // Iterar sobre los resultados de la consulta
                int i = 0;
                foreach (var producto in productos)
                {
                    // Aquí puedes hacer lo que quieras con cada producto, por ejemplo mostrarlo en una lista
                    Console.WriteLine(producto.Nombre);
                    Console.WriteLine(producto.Precio);
                    Console.WriteLine(producto.Imagen);
                    Console.WriteLine(producto.Descripcion);

                    // Convert Byte[] to Base64
                    string imageBase64 = Convert.ToBase64String(producto.Imagen);
                    // Convert Base64string to Stream  
                    byte[] bytes = System.Convert.FromBase64String(imageBase64);
                    //ImageSource.FromStream(() => new MemoryStream(bytes));
                    producto.ImagenSource = ImageSource.FromStream(() => new MemoryStream(bytes));
                    Productos.Add(producto);

                    // Asignar un id único a cada ImageButton
                    producto.ImageButtonId = i++;

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
            //boton de cerrar sesion
            Navigation.PushModalAsync(new Login());
            numProductos = 0;
            numProductosLabel.Text = "0";
            CestaProductos.Clear();
        }

        public static void ImageButton_Clicked2(object sender, EventArgs e)
        {
            //boton de añadir a la cesta

            // Obtener el producto correspondiente al botón pulsado
            var button = (ImageButton)sender;
            var producto = (Producto)button.BindingContext;

            // Incrementa el contador de productos
            numProductos++;

            // Actualiza el texto del Label y muestra el Label
            numProductosLabel.Text = numProductos.ToString();
            numProductosLabel.IsVisible = true;

            //añadir producto a la cesta
            CestaProductos.Add(producto);
        }


        private void ImageButton_Clicked_Cesta(object sender, EventArgs e)
        {
            foreach(Producto producto in CestaProductos)
            {
                string sPrecio = producto.Precio.Replace("€", "");
                total = total + float.Parse(sPrecio);
            }
            //abrir pantalla de cesta, llevar lista de productos de la cesta
            Navigation.PushModalAsync(new Cesta(CestaProductos,total));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //boton de Ver más
            //mostrar la imagen, boton de comprar opcional, descripcion
            var button = (Button)sender;
            var producto = (Producto)button.BindingContext;
            Prod_VerMas.mostrarProducto(producto);
            Navigation.PushModalAsync(new Prod_VerMas(producto));
        }

    }
}