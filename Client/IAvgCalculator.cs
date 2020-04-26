using System.Collections.Generic;

namespace Scopeduino
{
    public interface IAvgCalculator
    {
        IList<double> Calculate(IList<double> values);
    }
}