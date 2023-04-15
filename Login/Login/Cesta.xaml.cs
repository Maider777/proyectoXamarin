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

    public partial class Cesta : ContentPage
    {
        public List<Producto> Productos { get; set; }

        public Cesta(List<Producto> productos)
        {
            InitializeComponent();

            Productos = productos;
            BindingContext = this;
        }

        public void mostrarImagen()
        {
            Productos = new List<Producto>();
            foreach (var item in Productos)
            {
                // Convert Byte[] to Base64
                string imageBase64 = Convert.ToBase64String(item.Imagen);
                // Convert Base64string to Stream  
                byte[] bytes = System.Convert.FromBase64String(imageBase64);
                //ImageSource.FromStream(() => new MemoryStream(bytes));
                item.ImagenSource = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //boton de eliminar objeto de la cesta
            var button = (ImageButton)sender;
            var product = (Producto)button.BindingContext;
            Productos.Remove(product);
            miListView.ItemsSource = null;
            miListView.ItemsSource = Productos;
            numProductos--;
            ShopMenuPage.NumProductosLabel.Text = numProductos.ToString();
            ShopMenuPage.NumProductosLabel.IsVisible = true;
        }

    }
}
