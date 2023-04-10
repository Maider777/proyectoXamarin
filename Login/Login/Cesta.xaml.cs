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
    public partial class Cesta : ContentPage
    {
        public Cesta(List<Producto> productos)
        {
            InitializeComponent();
            //mostrar productos
            foreach (var producto in productos)
            {
                DisplayAlert("", producto.Nombre, "OK");
            }
        }

    }
}