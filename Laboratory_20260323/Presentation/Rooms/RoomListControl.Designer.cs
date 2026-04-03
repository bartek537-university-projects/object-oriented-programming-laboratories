namespace Laboratory_20260323.Presentation.Rooms
{
    partial class RoomListControl
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
            mlcRooms = new ManagedListControl();
            SuspendLayout();
            // 
            // mlcRooms
            // 
            mlcRooms.Dock = DockStyle.Fill;
            mlcRooms.Location = new Point(0, 0);
            mlcRooms.MinimumSize = new Size(256, 96);
            mlcRooms.Name = "mlcRooms";
            mlcRooms.Size = new Size(300, 192);
            mlcRooms.TabIndex = 0;
            // 
            // RoomListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mlcRooms);
            MinimumSize = new Size(256, 128);
            Name = "RoomListControl";
            Size = new Size(300, 192);
            ResumeLayout(false);
        }

        #endregion

        private ManagedListControl mlcRooms;
    }
}
