using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmFichad : ContentPage
    {
        public FrmFichad()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient ficha = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idficha", txtcodigo.Text);
                parametros.Add("idpersonaf", txtpaciente.Text);
                parametros.Add("resultado", txtresultado.Text);
                parametros.Add("enfermedad", txtenfermedad.Text);
                parametros.Add("medicamentos", txtmedicamentos.Text);
                parametros.Add("alergias", txtalergias.Text);
                parametros.Add("antecedentes", txtantedecentes.Text);
                parametros.Add("estadof", 1.ToString());
                ficha.UploadValues("http://192.168.100.8:8080/PROYECTO/ficha.php", "POST", parametros);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLFicha());
        }
    }
}