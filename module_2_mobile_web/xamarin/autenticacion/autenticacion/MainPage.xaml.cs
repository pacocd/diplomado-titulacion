using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace autenticacion
{
    public partial class MainPage : ContentPage
    {
        bool ShouldRemember = true;
        public class PostContent
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
            RestoreSessionIfNeeded();
        }

        void SignIn(System.Object sender, System.EventArgs e)
        {
            if (IsNull(usernameInput) || IsNull(passwordInput))
            {
                ShowAlert("Error", "Ningún campo debe estar vacío");
                return;
            }
            RequestSignIn(usernameInput.Text, passwordInput.Text);
        }

        private Task<HttpResponseMessage> Post(Uri uri, PostContent postContent)
        {
            HttpClient client = new HttpClient(); client.MaxResponseContentBufferSize = 256000;
            string jsonString = JsonConvert.SerializeObject(postContent);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return client.PostAsync(uri, content);
        }

        public async void RequestSignIn(string username, string password)
        {
            Uri uri = new Uri("https://super-simple-api.herokuapp.com/api/v1/users/login");
            PostContent jsonObject = new PostContent()
            {
                username = username,
                password = password
            };
            HttpResponseMessage response = await Post(uri, jsonObject);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(content);
                SaveSessionIfNeeded(user);
                await Navigation.PushModalAsync(new NavigationPage(new UserDetailPage(user)));
            }
            else
            {
                ShowAlert("Error", "Los datos son incorrectos");
            }
        }

        private void ShowAlert(String title, String message)
        {
            DisplayAlert(title, message, "Aceptar");
        }

        private async void SaveSessionIfNeeded(User user)
        {
            if (rememberMeSwitch.IsToggled)
            {
                Application.Current.Properties["username"] = user.Username;
                Application.Current.Properties["password"] = user.Password;
                await Application.Current.SavePropertiesAsync();
            }
        }

        private void RestoreSessionIfNeeded()
        {
            if (HasStoredSession())
            {
                RequestSignIn(StoredValue("username"), StoredValue("password"));
            }
        }

        private bool HasStoredSession()
        {
            return HasStoredValue("username") && HasStoredValue("password");
        }

        private bool HasStoredValue(string key)
        {
            return string.IsNullOrEmpty(StoredValue(key)) == false;
        }

        private string StoredValue(string key)
        {
            try
            {
                return Application.Current.Properties[key].ToString();
            } catch
            {
                return "";
            }           
        }

        private bool IsNull(Entry field)
        {
            return string.IsNullOrEmpty(field.Text);
        }
    }
}
