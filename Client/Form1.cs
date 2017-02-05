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

namespace Scopeduino
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            port.BaudRate = 57600;
            port.ReadTimeout = 1000;
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
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericComPort_ValueChanged(object sender, EventArgs e)
        {
            if (port != null && !port.IsOpen) port.PortName = "COM" + numericComPort.Value;
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "read " + numericReadChannel.Value.ToString();
                port.WriteLine(cmd);
                //Thread.Sleep(10);
                string r = port.ReadLine();
                double p = double.Parse(r);
                chart.Series[0].Points.AddY(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            try
            {
                port.WriteLine("ping");
                string r = port.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSetWait_Click(object sender, EventArgs e)
        {
            try
            {
                port.WriteLine("wait " + numericWait.Value.ToString());
                port.WriteLine("wait?");
                string r = port.ReadLine();
                int w = int.Parse(r);
                if (w != (int)numericWait.Value) throw new Exception("Send " + numericWait.Value.ToString() + " but wait? got " + w);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int[] vals = null;
        ulong[] times = null;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int nump = (int)numPoints.Value;
                vals = new int[nump];
                times = new ulong[nump];

                port.ReadTimeout = 30000;

                string cmd = "rec " + numericReadChannel.Value.ToString() + " " + nump.ToString();
                port.WriteLine(cmd);

                chart.Series[0].Points.Clear();
                for (int i = 0; i < nump; i++)
                {
                    string r = port.ReadLine();
                    string[] parts = r.Split(',');
                    int val = int.Parse(parts[0]);
                    ulong time = ulong.Parse(parts[1]);

                    vals[i] = val;
                    times[i] = time;

                    chart.Series[0].Points.AddXY(time, val);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (times == null) return;
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                DialogResult sfr = sf.ShowDialog();

                if (sfr == DialogResult.OK)
                {
                    using (StreamWriter w = new StreamWriter(sf.FileName))
                    {
                        for (int i = 0; i < times.Length; i++)
                        {
                            w.WriteLine(vals[i] + "," + times[i]);
                        }
                        w.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
