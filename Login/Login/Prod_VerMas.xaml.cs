using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Login.ShopMenuPage;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prod_VerMas : ContentPage
    {
        public Producto Producto { get; set; }
        public Prod_VerMas(Producto producto)
        {
            InitializeComponent();
            Producto = producto;
            this.BindingContext = this;
        }

        public static void mostrarProducto(Producto producto)
        {
            string nombre=producto.Nombre;
            var imagen=producto.ImagenSource;
            var precio=producto.Precio;
            string descripcion = producto.Descripcion;
            Console.WriteLine(nombre+imagen+precio+descripcion);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //boton de añadir a la cesta

            // Obtener el producto correspondiente al botón pulsado

            // Incrementa el contador de productos
            numProductos++;

            // Actualiza el texto del Label y muestra el Label
            numProductosLabel.Text = numProductos.ToString();
            numProductosLabel.IsVisible = true;



            //añadir producto a la cesta
            ShopMenuPage.CestaProductos.Add(Producto);
        }
    }
}