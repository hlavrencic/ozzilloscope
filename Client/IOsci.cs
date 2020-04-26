using System.Collections.Generic;

namespace Scopeduino
{
    public interface IOsci
    {
        void Draw(IList<double> values, double max);
    }
}