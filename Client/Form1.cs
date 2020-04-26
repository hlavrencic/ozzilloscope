using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Scopeduino
{
    public partial class Form1 : Form
    {

        private readonly ValuesRepo valueRepo;
        private readonly ValueParser valueParser;
        private readonly OsciSwap osciSwap;
        private SerialParser serialParser;
        private Stopwatch sw = new Stopwatch();

        public Form1()
        {
            //hScrollBar1
            InitializeComponent();
            valueRepo = new ValuesRepo();
            osciSwap = new OsciSwap(chart1, chart2);
            valueParser = new ValueParser();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ReadSerial();
            }
            catch (Exception ex)
            {
                
                Disconnect();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            btnConnect();
        }

        private void btnConnect()
        {
            try
            {
                if (buttonConnect.Text == "Connect")
                {
                    valueRepo.SetGroupCount((int)numSamples.Value);
                    serialParser = new SerialParser((byte)numericComPort.Value, (int)numericUpDown1.Value, valueParser);
                    buttonConnect.Text = "Disconnect";
                    buttonConnect.BackColor = System.Drawing.Color.Red;
                    configBox.Enabled = false;
                    hScrollBar1.Enabled = false;
                    timer1.Enabled = true;
                    sw.Start();
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Disconnect()
        {
            timer1.Enabled = false;
            if (serialParser != null)
            {
                serialParser.Dispose();
            }

            buttonConnect.Text = "Connect";
            buttonConnect.BackColor = System.Drawing.Color.Green;
            configBox.Enabled = true;
            hScrollBar1.Enabled = true;
            sw.Stop();
        }

        private void HScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            var pos = hScrollBar1.Value;
            var lista = valueRepo.Get(pos);
            osciSwap.Draw(lista, (int)numMaxValue.Value);
        }

        private void ReadSerial()
        {
            double? valor;
            IList<double> lista = null;

            do
            {
                valor = valueParser.Get();

                if(valor == null)
                {
                    break;
                }

                lista = valueRepo.Add(valor.Value);
            } while (valor != null && lista == null);

            if(lista == null)
            {
                return;
            }

            var max = Convert.ToDouble( numMaxValue.Value);

            var curMax = lista.Max();
            max = max < curMax ? curMax : max;

            numMaxValue.Value = Convert.ToDecimal(max);

            
            osciSwap.Draw(lista, max);

            hScrollBar1.Maximum = valueRepo.BddCount - 1;

            lblFps.Text = "FPS: " + Math.Round(1000 / sw.Elapsed.TotalMilliseconds);   
            sw.Restart();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!chkSampleAuto.Checked)
            {
                return;
            }

            const int BAUD = 230400;

            var num = (NumericUpDown)sender;
            if(num.Value <= 0)
            {
                return;
            }

            numSamples.Value = num.Value / (BAUD / 200);
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void NumSamples_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void ChkSampleAuto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
