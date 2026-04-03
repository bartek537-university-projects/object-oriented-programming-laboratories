namespace Laboratory_20260323.Presentation.Main
{
    partial class MainForm
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
            msMainMenu = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiSaveToFile = new ToolStripMenuItem();
            tsmiLoadFromFile = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            tpEmployees = new TabPage();
            tcMain = new TabControl();
            tpFaculties = new TabPage();
            tpRooms = new TabPage();
            tpReservations = new TabPage();
            msMainMenu.SuspendLayout();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.BackColor = SystemColors.Control;
            msMainMenu.Items.AddRange(new ToolStripItem[] { tsmiFile });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Size = new Size(496, 24);
            msMainMenu.TabIndex = 0;
            msMainMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiSaveToFile, tsmiLoadFromFile, toolStripSeparator1, tsmiExit });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(37, 20);
            tsmiFile.Text = "File";
            // 
            // tsmiSaveToFile
            // 
            tsmiSaveToFile.Name = "tsmiSaveToFile";
            tsmiSaveToFile.Size = new Size(121, 22);
            tsmiSaveToFile.Text = "Save as...";
            tsmiSaveToFile.Click += tsmiSaveToFile_Click;
            // 
            // tsmiLoadFromFile
            // 
            tsmiLoadFromFile.Name = "tsmiLoadFromFile";
            tsmiLoadFromFile.Size = new Size(121, 22);
            tsmiLoadFromFile.Text = "Open...";
            tsmiLoadFromFile.Click += tsmiLoadFromFile_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(118, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(121, 22);
            tsmiExit.Text = "Exit";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // tpEmployees
            // 
            tpEmployees.Location = new Point(4, 24);
            tpEmployees.Name = "tpEmployees";
            tpEmployees.Padding = new Padding(3);
            tpEmployees.Size = new Size(488, 273);
            tpEmployees.TabIndex = 0;
            tpEmployees.Text = "Employees";
            tpEmployees.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tpEmployees);
            tcMain.Controls.Add(tpFaculties);
            tcMain.Controls.Add(tpRooms);
            tcMain.Controls.Add(tpReservations);
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(0, 24);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(496, 301);
            tcMain.TabIndex = 1;
            // 
            // tpFaculties
            // 
            tpFaculties.Location = new Point(4, 24);
            tpFaculties.Name = "tpFaculties";
            tpFaculties.Padding = new Padding(3);
            tpFaculties.Size = new Size(488, 273);
            tpFaculties.TabIndex = 1;
            tpFaculties.Text = "Faculties";
            tpFaculties.UseVisualStyleBackColor = true;
            // 
            // tpRooms
            // 
            tpRooms.Location = new Point(4, 24);
            tpRooms.Name = "tpRooms";
            tpRooms.Padding = new Padding(3);
            tpRooms.Size = new Size(488, 273);
            tpRooms.TabIndex = 2;
            tpRooms.Text = "Rooms";
            tpRooms.UseVisualStyleBackColor = true;
            // 
            // tpReservations
            // 
            tpReservations.Location = new Point(4, 24);
            tpReservations.Name = "tpReservations";
            tpReservations.Padding = new Padding(3);
            tpReservations.Size = new Size(488, 273);
            tpReservations.TabIndex = 3;
            tpReservations.Text = "Reservations";
            tpReservations.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 325);
            Controls.Add(tcMain);
            Controls.Add(msMainMenu);
            MainMenuStrip = msMainMenu;
            MinimumSize = new Size(300, 256);
            Name = "MainForm";
            Text = "Reservations";
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainMenu;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiSaveToFile;
        private ToolStripMenuItem tsmiLoadFromFile;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiExit;
        private TabPage tpEmployees;
        private TabControl tcMain;
        private TabPage tpFaculties;
        private TabPage tpRooms;
        private TabPage tpReservations;
    }
}