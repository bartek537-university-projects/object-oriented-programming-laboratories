namespace Laboratory_20260323.Presentation.Reservations
{
    partial class ReservationListControl
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
            mlcReservations = new ManagedListControl();
            SuspendLayout();
            // 
            // mlcReservations
            // 
            mlcReservations.Dock = DockStyle.Fill;
            mlcReservations.Location = new Point(0, 0);
            mlcReservations.MinimumSize = new Size(256, 96);
            mlcReservations.Name = "mlcReservations";
            mlcReservations.Size = new Size(300, 192);
            mlcReservations.TabIndex = 0;
            // 
            // ReservationListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mlcReservations);
            MinimumSize = new Size(256, 128);
            Name = "ReservationListControl";
            Size = new Size(300, 192);
            ResumeLayout(false);
        }

        #endregion

        private ManagedListControl mlcReservations;
    }
}
