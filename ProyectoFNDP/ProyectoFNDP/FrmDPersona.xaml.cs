using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmDPersona : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/persona.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> post;

        public FrmDPersona()
        {
            InitializeComponent();
        }


        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLPersona());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idpersona", txtEliminar.Text);
                    cliente.UploadValues(Url, "DELETE", cliente.QueryString = parametros);
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