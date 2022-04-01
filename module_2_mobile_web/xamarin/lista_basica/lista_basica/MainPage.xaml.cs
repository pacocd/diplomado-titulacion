using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace lista_basica
{
    public partial class MainPage : ContentPage
    {
        public class Fruit
        {
            public string name { get; set; }
            public string url { get; set; }
        }
        ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = fruits;
        }

        async void listView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var selectedItem = (Fruit)listView.SelectedItem;
            int index = fruits.IndexOf(selectedItem);
            string action = await DisplayActionSheet("Acciones:", "Cancelar",
            null, "Eliminar", "Editar");
            if (action == "Eliminar")
            {
                fruits.RemoveAt(index);
                await DisplayAlert("Eliminar elemento", "Se elimino el lemento no:"
                + index, "OK");
                listView.ItemsSource = null;
                listView.ItemsSource = fruits;
            }
            if (action == "Editar")
            {
                await DisplayAlert("Mensaje", "", "editar", "ok");
            }
        }

        void MenuItem_Show(System.Object sender, System.EventArgs e)
        {
            var selectedItem = (Fruit)listView.SelectedItem;

            DisplayAlert("Mensaje", selectedItem.name, "ok");
        }

        void MenuItem_Delete(System.Object sender, System.EventArgs e)
        {
            var item = ((MenuItem)sender);
            DisplayAlert("Fruta seleccioada",
                "Fruta:" + item.CommandParameter.ToString(),
                "ok");
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            fruits.Add(new Fruit { name = nameInput.Text, url = urlInput.Text });
        }
    }
}
