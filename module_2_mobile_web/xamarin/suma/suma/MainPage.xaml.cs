using Xamarin.Forms;

namespace suma
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void ActionButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (firstValueInput.Text.Trim() == "" || secondValueInput.Text.Trim() == "")
            {
                resultLabel.Text = "Los valores no son válidos";
                return;
            }
            float firstValue = float.Parse(firstValueInput.Text);
            float secondValue = float.Parse(secondValueInput.Text);

            resultLabel.Text = string.Format("Resultado: {0}", firstValue + secondValue);
        }
    }
}
