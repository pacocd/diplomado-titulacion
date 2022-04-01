using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace picker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (IsNull(firstValueInput) || IsNull(secondValueInput) || IsNull(operationPicker))
            {
                resultLabel.Text = "Valores no válidos";
                return;
            }
            float firstValue = Float(firstValueInput);
            float secondValue = Float(secondValueInput);
            switch (operationPicker.SelectedItem.ToString())
            {
                case "Suma":
                    resultLabel.Text = string.Format("{0} + {1} = {2}",
                        firstValue,
                        secondValue,
                        firstValue + secondValue);
                    break;
                case "Resta":
                    resultLabel.Text = string.Format("{0} - {1} = {2}",
                        firstValue,
                        secondValue,
                        firstValue - secondValue);
                    break;
            }
        }

        private bool IsNull(Entry field)
        {
            return string.IsNullOrEmpty(field.Text);
        }

        private bool IsNull(Picker picker)
        {
            return picker.IsSet(Picker.SelectedItemProperty) && string.IsNullOrEmpty(picker.SelectedItem.ToString());
        }

        private float Float(Entry field)
        {
            return float.Parse(field.Text);
        }
    }
}
