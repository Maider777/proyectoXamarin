using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}