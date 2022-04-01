using System;
using Xamarin.Forms;

namespace radio_buttons
{
    public partial class MainPage : ContentPage
    {
        OperationType operationType = OperationType.Addition;

        public MainPage()
        {
            InitializeComponent();
        }

        void RadioButton_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.IsChecked)
            {
                operationType = (OperationType)int.Parse(rb.Value.ToString());
                Console.WriteLine(operationType);
            }
        }

        void operationButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(firstValueInput.Text) || string.IsNullOrEmpty(secondValueInput.Text))
            {
                resultLabel.Text = "Los valores no son válidos";
                return;
            }
            float firstValue = float.Parse(firstValueInput.Text);
            float secondValue = float.Parse(secondValueInput.Text);
            string symbol = operationSymbol(operationType);
            float result = operationResult(operationType, firstValue, secondValue);

            resultLabel.Text = string.Format("Resultado: {0} {1} {2} = {3}", firstValue, symbol, secondValue, result);
        }

        private string operationSymbol(OperationType type)
        {
            switch(type)
            {
                case OperationType.Addition:
                    return "+";
                case OperationType.Substraction:
                    return "-";
                case OperationType.Multiplication:
                    return "*";
                case OperationType.Division:
                    return "/";
                default:
                    return "";
            }
        }

        private float operationResult(OperationType type, float firstValue, float secondValue)
        {
            switch(type)
            {
                case OperationType.Addition:
                    return firstValue + secondValue;
                case OperationType.Substraction:
                    return firstValue - secondValue;
                case OperationType.Multiplication:
                    return firstValue * secondValue;
                case OperationType.Division:
                    return firstValue / secondValue;
                default:
                    return float.NaN;
            }
        }
    }

    enum OperationType: int
    {
        Addition = 0,
        Substraction,
        Multiplication,
        Division
    }
}
