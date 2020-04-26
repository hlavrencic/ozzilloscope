using System;
using System.Collections.Concurrent;

namespace Scopeduino
{
    public class ValueParser : IValueParserAdd
    {
        private readonly ConcurrentQueue<double> buffer;
        private Exception ex;

        public ValueParser()
        {
            buffer = new ConcurrentQueue<double>();
        }

        public int BufferLoad => buffer.Count;

        public double? Get()
        {
            if (ex != null)
            {
                throw ex;
            }

            if (buffer.TryDequeue(out var value))
            {
                return value;
            }

            return null;
        }

        public void AddException(Exception ex)
        {
            this.ex = ex;
        }

        public void AddValue(string value)
        {
            ex = null;
            if (double.TryParse(value, out double val))
            {
                buffer.Enqueue(val);
            }
        }
    }
}
