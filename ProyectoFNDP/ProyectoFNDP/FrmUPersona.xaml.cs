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
    public partial class FrmUPersona : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/persona.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> post;
 

        public FrmUPersona(int idpersona, string nombre, string cedula, DateTime fechanaci ,int edad, string direccion, string telefono, string celular, string correo, string usuario, string clave)
        {
            InitializeComponent();

            txtcodigo.Text = idpersona.ToString();
            txtnombres.Text = nombre.ToString();
            txtcedula.Text = cedula.ToString();
            txtfecha.Text = fechanaci.ToString("yyyy-MM-dd");
            txtedad.Text = edad.ToString();
            txtdireccion.Text = direccion.ToString();
            txttelefono.Text = telefono.ToString();
            txtcelular.Text = celular.ToString();
            txtcorreo.Text = correo.ToString();
            txtusuario.Text = usuario.ToString();
            txtclave.Text = clave.ToString();
            if (txtcodigo.Text == "") 
            {
                DisplayAlert("Alerta", "Es necesario Seleccionar un Usuario para realizar una operacion", "OK");
            }

        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLPersona());
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idpersona", txtcodigo.Text);
                    parametros.Add("nombre", txtnombres.Text);
                    parametros.Add("cedula", txtcedula.Text);
                    parametros.Add("fechanaci", txtfecha.Text);
                    parametros.Add("edad", txtedad.Text);
                    parametros.Add("direccion", txtdireccion.Text);
                    parametros.Add("telefono", txttelefono.Text);
                    parametros.Add("celular", txtcelular.Text);
                    parametros.Add("correo", txtcorreo.Text);
                    parametros.Add("usuario", txtusuario.Text);
                    parametros.Add("clave", txtclave.Text);
                    parametros.Add("estadop", 1.ToString());
                    cliente.UploadValues(Url, "PUT", cliente.QueryString = parametros);
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
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idpersona", txtcodigo.Text);
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