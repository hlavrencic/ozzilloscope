using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scopeduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            try
            {
                if (port == null || !port.IsOpen)
                {
                    port.Open();
                    buttonConnect.Text = "Disconnect";
                    numericComPort.Enabled = false;
                }
                else
                {
                    port.Close();
                    buttonConnect.Text = "Connect";
                    numericComPort.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericComPort_ValueChanged(object sender, EventArgs e)
        {
            if (port != null && !port.IsOpen) port.PortName = "COM" + numericComPort.Value;
        }

        private string message;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!port.IsOpen)
            {
                return;
            }

            var allLines = port.ReadExisting();

            if (string.IsNullOrEmpty(allLines))
            {
                return;
            }

            var chars = allLines.AsEnumerable().Where(c => c != '\r');

            foreach (var c in chars)
            {
                if ( c == '\n')
                {
                    ProcessInput(message);
                    message = string.Empty;
                }
                else
                {
                    message += c;
                }
            }
        }

        private IList<double> values = new List<double>();
        private void ProcessInput(string line)
        {
            switch (line)
            {
                case "FIN":

                    Draw(values);
                    txtSerialCant.Text = values.Count.ToString();
                    values.Clear();
                    listBox1.Items.Clear();
                    
                    break;
                default:
                    double val;
                    if (double.TryParse(line, out val))
                    {
                        listBox1.Items.Add(val);
                        values.Add(val);
                    }
                    break;
            }
        }

        private void BtnTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            ((Button)sender).Text = timer1.Enabled ? "ON" : "OFF";
        }

        private void Draw(IList<double> values)
        {
            Chart chartInvisible;
            Chart chartVisible;
            if (chart1.Visible)
            {
                chartInvisible = chart2;
                chartVisible = chart1;
            }
            else
            {
                chartInvisible = chart1;
                chartVisible = chart2;
            }

            chartInvisible.Series[0].Points.Clear();

            var i = 0;
            foreach (var v in values)
            {
                i++;
                chartInvisible.Series[0].Points.AddXY(i, v);
            }
            chartInvisible.Visible = true;
            chartVisible.Visible = false;
        }
    }
}
