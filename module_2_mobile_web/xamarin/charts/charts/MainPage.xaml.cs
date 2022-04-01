using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace charts
{
    public partial class MainPage : ContentPage
    {
        readonly List<Microcharts.ChartEntry> entries = new List<Microcharts.ChartEntry>()
        {
            new Microcharts.ChartEntry(200)
            {
                Label = "January",
                ValueLabel = "200",
                Color = SKColor.Parse("#FF0033"),
            },
            new Microcharts.ChartEntry(400)
            {
                Label = "February",
                ValueLabel = "400",
                Color = SKColor.Parse("#FF8000"),
            },
            new Microcharts.ChartEntry(300)
            {
                Label = "March",
                ValueLabel = "300",
                Color = SKColor.Parse("#FFE600"),
            },
            new Microcharts.ChartEntry(250)
            {
                Label = "April",
                ValueLabel = "250",
                Color = SKColor.Parse("#1AB34D"),
            },
            new Microcharts.ChartEntry(650)
            {
                Label = "May",
                ValueLabel = "650",
                Color = SKColor.Parse("#1A66FF"),
            },
            new Microcharts.ChartEntry(500)
            {
                Label = "June",
                ValueLabel = "500",
                Color = SKColor.Parse("#801AB3"),
            },
        };
        public MainPage()
        {
            InitializeComponent();
            MyDonutChart.Chart = new DonutChart { Entries = entries };
            MyBarChart.Chart = new BarChart { Entries = entries };
            MyPointChart.Chart = new PointChart { Entries = entries };
            MyRadialGaugeChart.Chart = new RadialGaugeChart { Entries = entries };
            MyLineChart.Chart = new LineChart { Entries = entries };
        }
    }
}
