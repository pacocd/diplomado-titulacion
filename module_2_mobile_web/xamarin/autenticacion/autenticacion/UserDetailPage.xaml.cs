using Xamarin.Forms;

namespace autenticacion
{
    public partial class UserDetailPage : ContentPage
    {
        User user;
        public UserDetailPage(User user)
        {
            this.user = user;
            InitializeComponent();
            welcomeLabel.Text = string.Format("Bienvenido {0}({1})",
                user.Name,
                user.Username);
        }
    }
}
