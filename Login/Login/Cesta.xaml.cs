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

        public Cesta(List<Producto> productos, float total)
        {
            InitializeComponent();
            Total.Text = total.ToString();
            Productos = productos;
            BindingContext = this;
        }


        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var product = (Producto)button.BindingContext;
            Productos.Remove(product);

            miListView.ItemsSource = null;
            miListView.ItemsSource = Productos;

            string sPrecio = product.Precio.Replace("€", "");
            float fPrecio = float.Parse(sPrecio);
            float fTotal = float.Parse(Total.Text.Replace("€", ""));

            fTotal -= fPrecio;

            Total.Text = $"{fTotal.ToString()}€";

            numProductos--;
            numProductosLabel.Text = numProductos.ToString();
            numProductosLabel.IsVisible = true;
        }


    }

}