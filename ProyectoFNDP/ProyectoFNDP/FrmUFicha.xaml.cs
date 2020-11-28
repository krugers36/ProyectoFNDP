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
    public partial class FrmUFicha : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/ficha.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> post;

        public FrmUFicha(int idficha, int idpersonaf, string resultado, string enfermedad, string medicamentos, string alergias, string antecedentes)
        {
            InitializeComponent();
            txtcodigo.Text = idficha.ToString();
            txtpaciente.Text = idpersonaf.ToString();
            txtresultado.Text = resultado.ToString();
            txtenfermedad.Text = enfermedad.ToString();
            txtmedicamentos.Text = medicamentos.ToString();
            txtalergias.Text = alergias.ToString();
            txtantecedentes.Text = antecedentes.ToString();



            if (txtcodigo.Text == "")
            {
                DisplayAlert("Alerta", "Es necesario Seleccionar un Usuario para realizar una operacion", "OK");
            }

        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLFicha());
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient ficha = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idficha", txtcodigo.Text);
                    parametros.Add("idpersonaf", txtpaciente.Text);
                    parametros.Add("resultado", txtresultado.Text);
                    parametros.Add("enfermedad", txtenfermedad.Text);
                    parametros.Add("medicamentos", txtmedicamentos.Text);
                    parametros.Add("alergias", txtalergias.Text);
                    parametros.Add("antecedentes", txtantecedentes.Text);
                    parametros.Add("estadof", 1.ToString());
                    ficha.UploadValues(Url, "PUT", ficha.QueryString = parametros);
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
                using (WebClient ficha = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idficha", txtcodigo.Text);
                    ficha.UploadValues(Url, "DELETE", ficha.QueryString = parametros);
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