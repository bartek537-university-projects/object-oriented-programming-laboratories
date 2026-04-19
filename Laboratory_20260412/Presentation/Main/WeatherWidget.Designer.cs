namespace Laboratory_20260412.Presentation.Main
{
    partial class WeatherWidget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbValue = new Label();
            lbTitle = new Label();
            SuspendLayout();
            // 
            // lbValue
            // 
            lbValue.AutoSize = true;
            lbValue.Font = new Font("Segoe UI", 12F);
            lbValue.Location = new Point(0, 17);
            lbValue.Name = "lbValue";
            lbValue.Size = new Size(41, 21);
            lbValue.TabIndex = 12;
            lbValue.Text = "80%";
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Location = new Point(2, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(57, 15);
            lbTitle.TabIndex = 11;
            lbTitle.Text = "Humidity";
            // 
            // WeatherWidget
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(lbValue);
            Controls.Add(lbTitle);
            Name = "WeatherWidget";
            Size = new Size(62, 38);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbValue;
        private Label lbTitle;
    }
}
