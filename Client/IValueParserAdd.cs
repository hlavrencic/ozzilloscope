using System;

namespace Scopeduino
{
    public interface IValueParserAdd
    {
        void AddValue(string value);

        void AddException(Exception ex);
    }
}