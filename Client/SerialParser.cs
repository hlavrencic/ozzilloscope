using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Scopeduino
{
    public class SerialParser : IDisposable
    {
        private readonly SerialPort serialPort;
        private readonly IValueParserAdd valueParserAdd;

        private StringBuilder valueBuilder;
        

        public SerialParser(byte portNumber, int baudRate, IValueParserAdd valueParserAdd)
            : this(new SerialPort(), valueParserAdd)
        {
            this.serialPort.BaudRate = baudRate;
            this.serialPort.PortName = "COM" + portNumber;
            this.serialPort.Open();
        }

        public SerialParser(SerialPort serial, IValueParserAdd valueParserAdd )
        {
            this.valueParserAdd = valueParserAdd;
            this.serialPort = serial;
            this.serialPort.DataReceived += Serial_DataReceived;
            this.serialPort.ErrorReceived += SerialPort_ErrorReceived;
            this.serialPort.Disposed += SerialPort_Disposed;
            
            valueBuilder = new StringBuilder();
        }

        public char ParseChar { get; set; } = '\n';

        public void Dispose()
        {
            serialPort.Close();
            valueParserAdd.AddException(null);
        }

        private void SerialPort_Disposed(object sender, System.EventArgs e)
        {
            valueParserAdd.AddException(new IOException("Connection closed!"));
        }

        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            valueParserAdd.AddException(new IOException("Error!"));
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }

            try
            {
                var allLines = serialPort.ReadExisting();
                ReadExisting(allLines);
            }
            catch (IOException ex)
            {
                valueParserAdd.AddException(ex);
            }
        }

        private void ReadExisting(string allLines)
        {
            if (string.IsNullOrEmpty(allLines))
            {
                return;
            }

            var chars = allLines.AsEnumerable().Where(c => c != '\r');

            foreach (var c in chars)
            {
                if (c == ParseChar)
                {
                    valueParserAdd.AddValue(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    valueBuilder.Append(c);
                }
            }
        }


    }
}
