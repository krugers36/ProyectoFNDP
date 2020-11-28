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
    public partial class FrmLFicha : ContentPage
    {
        private const string Url = "http://192.168.100.8:8080/PROYECTO/ficha.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ProyectoFNDP.Ws.Datos> _post;
        public FrmLFicha()
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
            await Navigation.PushAsync(new FrmFichad());
        }
        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (ProyectoFNDP.Ws.Datos)e.SelectedItem;
            var item = Obj.idficha.ToString();
            var item1 = Obj.idpersonaf.ToString();
            var item2 = Obj.resultado.ToString();
            var item3 = Obj.enfermedad.ToString();
            var item4 = Obj.medicamentos.ToString();
            var item5 = Obj.alergias.ToString();
            var item6 = Obj.antecedentes.ToString();
            int idficha = Convert.ToInt32(item);
            int idpersonaf = Convert.ToInt32(item1);
            string resultado = item2;
            string enfermedad = item3;
            string medicamentos = item4;
            string alergias = item5;
            string antecedentes = item6;
            try
            {
                Navigation.PushAsync(new FrmUFicha(idficha, idpersonaf, resultado, enfermedad, medicamentos, alergias, antecedentes));
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