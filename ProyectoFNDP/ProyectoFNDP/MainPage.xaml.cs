using Newtonsoft.Json;
using ProyectoFNDP.Ws;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFNDP
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/persona.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> _view;
        public MainPage()
        {
            InitializeComponent();
        }


        public async Task<bool> checkLogin(string usuario, string clave)
        {
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(_view + "usuario=" + usuario + "/" + "clave=" + clave);

            return response.IsSuccessStatusCode; // return either true or false
        }

        private async void btnabrir_Clicked(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            if (txtUser.Text == "Admin" && txtclave.Text == "admin")
            {
                await Navigation.PushAsync(new Menus());
            }
            else
            {
                DisplayAlert("Mensaje de Alerta", "Usuario o Clave Incorrectos", "Intente de Nuevo");
            }
        }

            



    }
}
