using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFNDP;


namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmLPersona : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/persona.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> _post;

        public FrmLPersona()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<ProyectoFNDP.Ws.Datos> posts = JsonConvert.DeserializeObject<List<ProyectoFNDP.Ws.Datos>>(content);
                _post = new ObservableCollection<ProyectoFNDP.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }
      
        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (ProyectoFNDP.Ws.Datos)e.SelectedItem;
            var item = Obj.idpersona.ToString();
            var item1 = Obj.nombre.ToString();
            var item2 = Obj.cedula.ToString();
            var item3 = Obj.fechanaci.ToString();
            var item4 = Obj.edad.ToString();
            var item5 = Obj.direccion.ToString();
            var item6 = Obj.telefono.ToString();
            var item7 = Obj.celular.ToString();
            var item8 = Obj.correo.ToString();
            var item9 = Obj.usuario.ToString();
            var item10 = Obj.clave.ToString();
            int idpersona = Convert.ToInt32(item);
            string nombre = item1;
            string cedula = item2;
            DateTime fechanaci = Convert.ToDateTime(item3);
            int edad = Convert.ToInt32(item4);
            string direccion= item5;
            string telefono = item6;
            string celular = item7;
            string correo = item8;
            string usuario = item9;
            string clave = item10;
            try
            {
                Navigation.PushAsync(new FrmUPersona(idpersona, nombre, cedula,fechanaci ,edad, direccion, telefono, celular, correo, usuario, clave));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btnRegreser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menus());
        }

        private async void btnNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmPersona());
        }

    }
}