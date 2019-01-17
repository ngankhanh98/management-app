using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Shapes;

namespace management_app
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : Window
    {
        // typedt: PRODUCT, SALE(VND)
        // typetime: DAY, MONTH, YEAR, PERIOD
        // typedt = PRODUCT, use column chart,
        // typedt = SALE, typetime = DAY, use pie chart,
        // typedt = SALE, typetime = MONTH or YEAR or PERIOD, use pie chart and line chart

        public Chart(List<Data> resultQry, List<Data> data2, int typedt, int typetime)
        {
            InitializeComponent();
            int[] values = resultQry.Select(x => x.value).ToArray();
            string[] labels = resultQry.Select(x => x.title).ToArray();

            // Column Chart
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Sold",
                    Values = new ChartValues<int> (values)
                }
            };

            // Pie Chart
            foreach (var item in resultQry)
            {
                pieChart.Series.Add(new PieSeries() { LabelPoint = chartPoint =>
                   string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation), DataLabels = true, Title = item.title, Values = new ChartValues<int> { item.value } });
            }


            if (typedt == (int)typeOfData.PRODUCT)
                columnChart.Visibility = Visibility.Visible;

            if (typedt == (int)typeOfData.SALE)
            {
                if (typetime == (int)typeOfTime.DAY)
                {
                    gvpieChart.Width = this.Width;
                    pieChart.Visibility = Visibility.Visible;
                }
                else
                {
                    pieChart.Visibility = Visibility.Visible;

                }
            }


            Labels = labels;
            if (values.Max() < 100)
                Y.Separator.Step = 1;

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection PSeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

    }
}
