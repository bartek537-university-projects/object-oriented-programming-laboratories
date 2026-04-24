namespace Laboratory_20260412.Presentation.Main
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cbSearch = new ComboBox();
            lbCurrentTemperature = new Label();
            picWeatherIcon = new PictureBox();
            lbTemperatureRange = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            wRain = new WeatherWidget();
            wWind = new WeatherWidget();
            wPressure = new WeatherWidget();
            wHumidity = new WeatherWidget();
            llOpenWeatherMapAttribution = new LinkLabel();
            timSearchDebounce = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbSearch
            // 
            cbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbSearch.FormattingEnabled = true;
            cbSearch.Location = new Point(12, 12);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(260, 23);
            cbSearch.TabIndex = 1;
            cbSearch.SelectionChangeCommitted += cbSearch_SelectionChangeCommitted;
            cbSearch.TextUpdate += cbSearch_TextUpdate;
            cbSearch.Format += cbSearch_Format;
            // 
            // lbCurrentTemperature
            // 
            lbCurrentTemperature.AutoSize = true;
            lbCurrentTemperature.Font = new Font("Segoe UI", 16F);
            lbCurrentTemperature.Location = new Point(80, 55);
            lbCurrentTemperature.Name = "lbCurrentTemperature";
            lbCurrentTemperature.Size = new Size(47, 30);
            lbCurrentTemperature.TabIndex = 3;
            lbCurrentTemperature.Text = "0°C";
            // 
            // picWeatherIcon
            // 
            picWeatherIcon.Image = Properties.Resources.clear;
            picWeatherIcon.Location = new Point(12, 48);
            picWeatherIcon.Name = "picWeatherIcon";
            picWeatherIcon.Size = new Size(64, 64);
            picWeatherIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picWeatherIcon.TabIndex = 5;
            picWeatherIcon.TabStop = false;
            // 
            // lbTemperatureRange
            // 
            lbTemperatureRange.AutoSize = true;
            lbTemperatureRange.Location = new Point(82, 85);
            lbTemperatureRange.Name = "lbTemperatureRange";
            lbTemperatureRange.Size = new Size(66, 15);
            lbTemperatureRange.TabIndex = 6;
            lbTemperatureRange.Text = "↑ 0*C ↓ 0*C";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(wRain, 1, 1);
            tableLayoutPanel1.Controls.Add(wWind, 0, 1);
            tableLayoutPanel1.Controls.Add(wPressure, 1, 0);
            tableLayoutPanel1.Controls.Add(wHumidity, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 118);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(260, 98);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // wRain
            // 
            wRain.AutoSize = true;
            wRain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wRain.Label = "Rain";
            wRain.Location = new Point(133, 52);
            wRain.Margin = new Padding(3, 3, 3, 8);
            wRain.Name = "wRain";
            wRain.Size = new Size(69, 38);
            wRain.TabIndex = 3;
            wRain.Text = "0 mm/h";
            // 
            // wWind
            // 
            wWind.AutoSize = true;
            wWind.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wWind.Label = "Wind";
            wWind.Location = new Point(3, 52);
            wWind.Margin = new Padding(3, 3, 3, 8);
            wWind.Name = "wWind";
            wWind.Size = new Size(79, 38);
            wWind.TabIndex = 2;
            wWind.Text = "0 km/h N";
            // 
            // wPressure
            // 
            wPressure.AutoSize = true;
            wPressure.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wPressure.Label = "Pressure";
            wPressure.Location = new Point(133, 3);
            wPressure.Margin = new Padding(3, 3, 3, 8);
            wPressure.Name = "wPressure";
            wPressure.Size = new Size(56, 38);
            wPressure.TabIndex = 1;
            wPressure.Text = "0 hPa";
            // 
            // wHumidity
            // 
            wHumidity.AutoSize = true;
            wHumidity.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wHumidity.Label = "Humidity";
            wHumidity.Location = new Point(3, 3);
            wHumidity.Margin = new Padding(3, 3, 3, 8);
            wHumidity.Name = "wHumidity";
            wHumidity.Size = new Size(62, 38);
            wHumidity.TabIndex = 0;
            wHumidity.Text = "0%";
            // 
            // llOpenWeatherMapAttribution
            // 
            llOpenWeatherMapAttribution.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            llOpenWeatherMapAttribution.AutoSize = true;
            llOpenWeatherMapAttribution.Location = new Point(12, 297);
            llOpenWeatherMapAttribution.Name = "llOpenWeatherMapAttribution";
            llOpenWeatherMapAttribution.Size = new Size(219, 15);
            llOpenWeatherMapAttribution.TabIndex = 8;
            llOpenWeatherMapAttribution.TabStop = true;
            llOpenWeatherMapAttribution.Text = "Weather data provided by OpenWeather";
            // 
            // timSearchDebounce
            // 
            timSearchDebounce.Interval = 1000;
            timSearchDebounce.Tick += timSearchDebounce_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(284, 321);
            Controls.Add(llOpenWeatherMapAttribution);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lbTemperatureRange);
            Controls.Add(picWeatherIcon);
            Controls.Add(lbCurrentTemperature);
            Controls.Add(cbSearch);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Weather";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbSearch;
        private Label lbCurrentTemperature;
        private PictureBox picWeatherIcon;
        private Label lbTemperatureRange;
        private TableLayoutPanel tableLayoutPanel1;
        private WeatherWidget wWind;
        private WeatherWidget wPressure;
        private WeatherWidget wHumidity;
        private WeatherWidget wRain;
        private LinkLabel llOpenWeatherMapAttribution;
        private System.Windows.Forms.Timer timSearchDebounce;
    }
}
