namespace Scopeduino
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.numericComPort = new System.Windows.Forms.NumericUpDown();
            this.buttonRead = new System.Windows.Forms.Button();
            this.numericReadChannel = new System.Windows.Forms.NumericUpDown();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonPing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.numericWait = new System.Windows.Forms.NumericUpDown();
            this.buttonSetWait = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWait)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // numericComPort
            // 
            this.numericComPort.Location = new System.Drawing.Point(93, 15);
            this.numericComPort.Name = "numericComPort";
            this.numericComPort.Size = new System.Drawing.Size(99, 20);
            this.numericComPort.TabIndex = 1;
            this.numericComPort.ValueChanged += new System.EventHandler(this.numericComPort_ValueChanged);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(12, 60);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 2;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // numericReadChannel
            // 
            this.numericReadChannel.Location = new System.Drawing.Point(93, 63);
            this.numericReadChannel.Name = "numericReadChannel";
            this.numericReadChannel.Size = new System.Drawing.Size(99, 20);
            this.numericReadChannel.TabIndex = 3;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 107);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(696, 461);
            this.chart.TabIndex = 4;
            this.chart.Text = "chart1";
            // 
            // buttonPing
            // 
            this.buttonPing.Location = new System.Drawing.Point(308, 12);
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.Size = new System.Drawing.Size(75, 23);
            this.buttonPing.TabIndex = 5;
            this.buttonPing.Text = "Ping";
            this.buttonPing.UseVisualStyleBackColor = true;
            this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numPoints
            // 
            this.numPoints.Location = new System.Drawing.Point(353, 66);
            this.numPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(99, 20);
            this.numPoints.TabIndex = 7;
            // 
            // numericWait
            // 
            this.numericWait.Location = new System.Drawing.Point(561, 53);
            this.numericWait.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericWait.Name = "numericWait";
            this.numericWait.Size = new System.Drawing.Size(75, 20);
            this.numericWait.TabIndex = 8;
            // 
            // buttonSetWait
            // 
            this.buttonSetWait.Location = new System.Drawing.Point(561, 24);
            this.buttonSetWait.Name = "buttonSetWait";
            this.buttonSetWait.Size = new System.Drawing.Size(75, 23);
            this.buttonSetWait.TabIndex = 9;
            this.buttonSetWait.Text = "Set Wait";
            this.buttonSetWait.UseVisualStyleBackColor = true;
            this.buttonSetWait.Click += new System.EventHandler(this.buttonSetWait_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(468, 63);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 580);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonSetWait);
            this.Controls.Add(this.numericWait);
            this.Controls.Add(this.numPoints);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPing);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.numericReadChannel);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.numericComPort);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.NumericUpDown numericComPort;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.NumericUpDown numericReadChannel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonPing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.NumericUpDown numericWait;
        private System.Windows.Forms.Button buttonSetWait;
        private System.Windows.Forms.Button buttonSave;
    }
}

