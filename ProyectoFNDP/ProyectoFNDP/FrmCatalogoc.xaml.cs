using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmCatalogoc : ContentPage
    {
        public FrmCatalogoc()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idcatalogo", txtidpadre.Text);
                parametros.Add("idhijo", txtidhijo.Text);
                parametros.Add("nombrec", txtnombre.Text);
                parametros.Add("valor", txtvalor.Text);
                parametros.Add("estadoc", 1.ToString());
                cliente.UploadValues("http://192.168.100.8:8080/PROYECTO/catalogo.php", "POST", parametros);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLCatalogo());
        }
    }
}

