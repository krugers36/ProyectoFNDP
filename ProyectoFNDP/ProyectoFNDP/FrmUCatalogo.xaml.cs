using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmUCatalogo : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/catalogo.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> post;

        public FrmUCatalogo(int idcatalogo)
        {
            InitializeComponent();
            txtidpadre.Text = idcatalogo.ToString();

            if (txtidpadre.Text == "")
            {
                DisplayAlert("Alerta", "Es necesario Seleccionar un Usuario para realizar una operacion", "OK");
            }

        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLCatalogo());
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient catalogo = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idcatalogo", txtidpadre.Text);
                    parametros.Add("idhijo", txtidhijo.Text);
                    parametros.Add("nombrec", txtnombre.Text);
                    parametros.Add("valor", txtvalor.Text);
                    parametros.Add("estadoc", 1.ToString());
                    catalogo.UploadValues(Url, "PUT", catalogo.QueryString = parametros);
                }
                await DisplayAlert("Alerta", "Dato Actualizado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient catalogo = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idcatalogo", txtidpadre.Text);
                    catalogo.UploadValues(Url, "DELETE", catalogo.QueryString = parametros);
                }
                await DisplayAlert("Alerta", "Dato Eliminado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }
    }
}