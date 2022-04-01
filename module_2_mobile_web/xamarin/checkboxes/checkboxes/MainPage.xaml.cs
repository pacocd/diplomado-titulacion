using Xamarin.Forms;

namespace checkboxes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void operationButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (isNull(firstValueInput) || isNull(secondValueInput))
            {
                resultLabel.Text = "Valores no válidos";
                return;
            }
            float firstValue = float.Parse(firstValueInput.Text);
            float secondValue = float.Parse(secondValueInput.Text);
            resultLabel.Text = "";
            if (additionCheck.IsChecked)
            {
                resultLabel.Text = string.Format("Resultado: {0} + {1} = {2}\n",
                    firstValue,
                    secondValue,
                    firstValue + secondValue);
            }
            if (substractionCheck.IsChecked)
            {
                resultLabel.Text += string.Format("Resultado: {0} - {1} = {2}",
                    firstValue,
                    secondValue,
                    firstValue - secondValue);
            }
        }

        bool isNull(Entry input)
        {
            return string.IsNullOrEmpty(input.Text);
        }
    }
}
