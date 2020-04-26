using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scopeduino
{
    public class OsciSwap : IOsci
    {
        private readonly Osci osci1;
        private readonly Osci osci2;

        public OsciSwap(Chart chart1, Chart chart2)
            : this(chart1, chart2, new AvgCalculator())
        {
        }

        public OsciSwap(Chart chart1, Chart chart2, IAvgCalculator avgCalculator)
            :this(new Osci(chart1, avgCalculator), new Osci(chart2, avgCalculator))
        {
        }

        public OsciSwap(Osci osci1, Osci osci2)
        {
            this.osci1 = osci1;
            this.osci2 = osci2;
        }

        public void Draw(IList<double> values, double max)
        {
            Osci chartInvisible;
            Osci chartVisible;
            if (osci1.Visible)
            {
                chartInvisible = osci2;
                chartVisible = osci1;
            }
            else
            {
                chartInvisible = osci1;
                chartVisible = osci2;
            }

            chartInvisible.Draw(values, max);

            chartInvisible.Visible = true;
            chartVisible.Visible = false;
        }
    }
}
