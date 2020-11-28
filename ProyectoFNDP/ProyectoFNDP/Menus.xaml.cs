using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menus : ContentPage
    {
        public Menus()
        {
            InitializeComponent();
        }

        private async void btnpersona_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLPersona());
        }

        private async void btnficha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLFicha());
        }

        /*private async void btnreporte_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmReporte());
        }*/

        private async void btncatalogo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLCatalogo());
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}