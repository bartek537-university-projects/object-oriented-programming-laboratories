namespace Laboratory_20260323.Presentation.Faculties
{
    partial class FacultyListControl
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
            mlcFaculties = new ManagedListControl();
            SuspendLayout();
            // 
            // mlcFaculties
            // 
            mlcFaculties.Dock = DockStyle.Fill;
            mlcFaculties.Location = new Point(0, 0);
            mlcFaculties.MinimumSize = new Size(256, 96);
            mlcFaculties.Name = "mlcFaculties";
            mlcFaculties.Size = new Size(300, 192);
            mlcFaculties.TabIndex = 0;
            // 
            // FacultyListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mlcFaculties);
            MinimumSize = new Size(256, 128);
            Name = "FacultyListControl";
            Size = new Size(300, 192);
            ResumeLayout(false);
        }

        #endregion

        private ManagedListControl mlcFaculties;
    }
}
