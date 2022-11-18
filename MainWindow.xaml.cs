using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    using System;

    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Series;

    public class MainViewModel
    {
        public MainViewModel()
        {
            this.TwoColorModel = TwoColorLineSeries();
            this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));

            double X = 0.0D;
            double Y = 0.87825D;

            LineAnnotation Line = new LineAnnotation()
            {
                StrokeThickness = 1,
                Color = OxyColors.Green,
                Type = LineAnnotationType.Horizontal,
                Text = (Y).ToString(),
                TextColor = OxyColors.White,
                X = X,
                Y = Y
            };

            this.MyModel.Annotations.Add(Line);
        }

        public static PlotModel TwoColorLineSeries()
        {
            var model = new PlotModel { Title = "TwoColorLineSeries" };
            var twoColorLineSeries = new TwoColorLineSeries
            {
                Color = OxyColors.Red,
                Color2 = OxyColors.Blue,
                LineStyle = LineStyle.Solid,
                LineStyle2 = LineStyle.Dot
            };
            twoColorLineSeries.Points.Add(new DataPoint(0, -6));
            twoColorLineSeries.Points.Add(new DataPoint(10, 4));
            twoColorLineSeries.Points.Add(new DataPoint(30, -2));
            twoColorLineSeries.Points.Add(new DataPoint(40, 8));
            model.Series.Add(twoColorLineSeries);
            return model;
        }

        public PlotModel TwoColorModel { get; private set; }
        public PlotModel MyModel { get; private set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account
            {
                Name = "John Doe",
                Email = "john@microsoft.com",
                DOB = new DateTime(1980, 2, 20, 0, 0, 0, DateTimeKind.Utc),
            };
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            TextBlock.Text = json;
        }
    }
}

public class Account
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DOB { get; set; }
}

