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

namespace ProyectoFNDP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmLCatalogo : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/catalogo.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> _post;
        public FrmLCatalogo()
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

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmCatalogoc());
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (ProyectoFNDP.Ws.Datos)e.SelectedItem;
            var item = Obj.idcatalogo.ToString();
            int idcatalogo = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new FrmUCatalogo(idcatalogo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menus());
        }
    }
}