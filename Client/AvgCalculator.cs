using System.Collections.Generic;
using System.Linq;

namespace Scopeduino
{
    public class AvgCalculator : IAvgCalculator
    {
        private IList<double> avgAcum = new List<double>();

        public IList<double> Calculate(IList<double> values)
        {
            var i = 0;
            foreach (var val in values)
            {
                var avg = avgAcum.ElementAtOrDefault(i);
                if (avg < val)
                {
                    avg = val;
                }
                else if (avg > 0)
                {
                    avg -= avg / 20;
                }

                if (avgAcum.Count > i)
                {
                    avgAcum[i] = avg;
                }
                else
                {
                    avgAcum.Add(avg);
                }

                i++;
            }

            if(avgAcum.Count > values.Count)
            {
                avgAcum = avgAcum.Take(values.Count).ToList();
            }

            return avgAcum;
        }
    }
}
