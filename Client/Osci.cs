using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scopeduino
{
    public class Osci : IOsci
    {
        private readonly Chart chart;
        private readonly IAvgCalculator avgCalculator;

        private readonly Series currentSeries;
        private readonly Series avgSeries;
        private readonly Series topSeries;

        public Osci(Chart chart, IAvgCalculator avgCalculator)
        {
            this.chart = chart;
            this.avgCalculator = avgCalculator;
            {
                var serie = new Series();
                serie.ChartType = SeriesChartType.FastLine;
                chart.Series.Add(serie);
                currentSeries = serie;
            }
            {
                var serie = new Series();
                serie.ChartType = SeriesChartType.FastLine;
                chart.Series.Add(serie);
                avgSeries = serie;
            }
            {
                var serie = new Series();
                serie.ChartType = SeriesChartType.FastLine;
                chart.Series.Add(serie);
                topSeries = serie;
            }

            
        }

        public void Draw(IList<double> values, double max)
        {
            avgSeries.Points.Clear();
            currentSeries.Points.Clear();
            topSeries.Points.Clear();

            topSeries.Points.AddY(max);

            int i;

            i = 0;
            foreach (var v in values)
            {
                i++;
                currentSeries.Points.AddXY(i, v);
            }

            var ppp = avgCalculator.Calculate(values);
            i = 0;
            foreach (var item in ppp)
            {
                i++;
                avgSeries.Points.AddXY(i, item);
            }
        }

        public bool Visible
        {
            get
            {
                return chart.Visible;
            }
            set
            {
                chart.Visible = value;
            }
        }
    }
}
