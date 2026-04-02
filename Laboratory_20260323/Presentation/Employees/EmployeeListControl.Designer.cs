namespace Laboratory_20260323.Presentation.Employees
{
    partial class EmployeeListControl
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
            mlcEmployees = new ManagedListControl();
            SuspendLayout();
            // 
            // mlcEmployees
            // 
            mlcEmployees.AutoSize = true;
            mlcEmployees.Dock = DockStyle.Fill;
            mlcEmployees.Location = new Point(0, 0);
            mlcEmployees.MinimumSize = new Size(256, 96);
            mlcEmployees.Name = "mlcEmployees";
            mlcEmployees.Size = new Size(300, 192);
            mlcEmployees.TabIndex = 0;
            // 
            // EmployeeListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mlcEmployees);
            MinimumSize = new Size(256, 128);
            Name = "EmployeeListControl";
            Size = new Size(300, 192);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ManagedListControl mlcEmployees;
    }
}
