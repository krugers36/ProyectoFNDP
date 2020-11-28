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
    public partial class FrmPersona : ContentPage
    {
        #region VALIDAR CEDULA
        private async void validarCedula()
        {
            string cedula = txtcedula.Text;
            char[] vector = cedula.ToArray();
            int sumatotal = 0;
            int num = 0;
            if (vector.Length == 10)
            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    int numero = Convert.ToInt32(vector[i].ToString());
                    if ((i + 1) % 2 == 1)
                    {
                        numero = Convert.ToInt32(vector[i].ToString()) * 2;
                        if (numero > 9)
                        {
                            numero = numero - 9;
                        }
                    }
                    sumatotal += numero;
                }
                sumatotal = 10 - (sumatotal % 10);
                if (sumatotal > 9)
                {
                    num = 0;
                }
                else
                {
                    num = sumatotal;
                }
                if (num == Convert.ToInt32(vector[9].ToString()))
                {
                }
                else
                {

                    await DisplayAlert("Alerta", "Cedula Incorrecta","OK");
                    txtcedula.Text = "";
                    txtcedula.Focus();
                }
            }
        }
        #endregion

        public FrmPersona()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
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
                parametros.Add("usuario", 1.ToString());
                parametros.Add("clave", 1.ToString());
                parametros.Add("estadop", 1.ToString());
                cliente.UploadValues("http://192.168.100.8:8080/PROYECTO/persona.php", "POST", parametros);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR: " + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmLPersona());
        }

        /*private void Txtcedula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtcedula.Text.Length == 10)
            {
                validarCedula();
            }
            /*else if (txtcedula.Text.Length !=10)
            {
                await DisplayAlert("Alerta", "Cedula Incorrecta", "OK");
                txtcedula.Text = "";
            }
        }*/
    }
}