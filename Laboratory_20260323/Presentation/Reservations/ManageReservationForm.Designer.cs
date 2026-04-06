namespace Laboratory_20260323.Presentation.Reservations
{
    partial class ManageReservationForm
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
            components = new System.ComponentModel.Container();
            gbBasicInformation = new GroupBox();
            lbDuration = new Label();
            dtpEndTime = new DateTimePicker();
            lbTimeEnd = new Label();
            dtpStartTime = new DateTimePicker();
            lbTimeStart = new Label();
            cbEmployee = new ComboBox();
            cbRoom = new ComboBox();
            lbEmployee = new Label();
            lbRoom = new Label();
            gbInternal = new GroupBox();
            lbIdentifier = new Label();
            tbIdentifier = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            gbBasicInformation.SuspendLayout();
            gbInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // gbBasicInformation
            // 
            gbBasicInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbBasicInformation.Controls.Add(lbDuration);
            gbBasicInformation.Controls.Add(dtpEndTime);
            gbBasicInformation.Controls.Add(lbTimeEnd);
            gbBasicInformation.Controls.Add(dtpStartTime);
            gbBasicInformation.Controls.Add(lbTimeStart);
            gbBasicInformation.Controls.Add(cbEmployee);
            gbBasicInformation.Controls.Add(cbRoom);
            gbBasicInformation.Controls.Add(lbEmployee);
            gbBasicInformation.Controls.Add(lbRoom);
            gbBasicInformation.Location = new Point(12, 70);
            gbBasicInformation.Name = "gbBasicInformation";
            gbBasicInformation.Size = new Size(324, 155);
            gbBasicInformation.TabIndex = 3;
            gbBasicInformation.TabStop = false;
            gbBasicInformation.Text = "Basic information";
            // 
            // lbDuration
            // 
            lbDuration.AutoSize = true;
            lbDuration.Location = new Point(86, 135);
            lbDuration.Name = "lbDuration";
            lbDuration.Size = new Size(48, 15);
            lbDuration.TabIndex = 9;
            lbDuration.Text = "- 0h 0m";
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(86, 109);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(159, 23);
            dtpEndTime.TabIndex = 8;
            dtpEndTime.ValueChanged += dtpEndTime_ValueChanged;
            // 
            // lbTimeEnd
            // 
            lbTimeEnd.AutoSize = true;
            lbTimeEnd.Location = new Point(6, 115);
            lbTimeEnd.Name = "lbTimeEnd";
            lbTimeEnd.Size = new Size(54, 15);
            lbTimeEnd.TabIndex = 7;
            lbTimeEnd.Text = "End time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Checked = false;
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(86, 80);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(159, 23);
            dtpStartTime.TabIndex = 6;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            // 
            // lbTimeStart
            // 
            lbTimeStart.AutoSize = true;
            lbTimeStart.Location = new Point(6, 86);
            lbTimeStart.Name = "lbTimeStart";
            lbTimeStart.Size = new Size(58, 15);
            lbTimeStart.TabIndex = 5;
            lbTimeStart.Text = "Start time";
            // 
            // cbEmployee
            // 
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.FormattingEnabled = true;
            cbEmployee.Location = new Point(86, 51);
            cbEmployee.Name = "cbEmployee";
            cbEmployee.Size = new Size(121, 23);
            cbEmployee.TabIndex = 4;
            // 
            // cbRoom
            // 
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoom.FormattingEnabled = true;
            cbRoom.Location = new Point(86, 22);
            cbRoom.Name = "cbRoom";
            cbRoom.Size = new Size(121, 23);
            cbRoom.TabIndex = 3;
            // 
            // lbEmployee
            // 
            lbEmployee.AutoSize = true;
            lbEmployee.Location = new Point(6, 54);
            lbEmployee.Name = "lbEmployee";
            lbEmployee.Size = new Size(59, 15);
            lbEmployee.TabIndex = 2;
            lbEmployee.Text = "Employee";
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.Location = new Point(6, 25);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new Size(39, 15);
            lbRoom.TabIndex = 0;
            lbRoom.Text = "Room";
            // 
            // gbInternal
            // 
            gbInternal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInternal.Controls.Add(lbIdentifier);
            gbInternal.Controls.Add(tbIdentifier);
            gbInternal.Location = new Point(12, 12);
            gbInternal.Name = "gbInternal";
            gbInternal.Size = new Size(324, 52);
            gbInternal.TabIndex = 2;
            gbInternal.TabStop = false;
            gbInternal.Text = "Internal";
            // 
            // lbIdentifier
            // 
            lbIdentifier.AutoSize = true;
            lbIdentifier.Location = new Point(6, 25);
            lbIdentifier.Name = "lbIdentifier";
            lbIdentifier.Size = new Size(54, 15);
            lbIdentifier.TabIndex = 0;
            lbIdentifier.Text = "Identifier";
            // 
            // tbIdentifier
            // 
            tbIdentifier.Enabled = false;
            tbIdentifier.Location = new Point(86, 22);
            tbIdentifier.Name = "tbIdentifier";
            tbIdentifier.Size = new Size(229, 23);
            tbIdentifier.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(182, 242);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(261, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // ManageReservationForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(348, 277);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(gbBasicInformation);
            Controls.Add(gbInternal);
            MinimumSize = new Size(364, 316);
            Name = "ManageReservationForm";
            Text = "Edit reservation";
            gbBasicInformation.ResumeLayout(false);
            gbBasicInformation.PerformLayout();
            gbInternal.ResumeLayout(false);
            gbInternal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBasicInformation;
        private Label lbRoom;
        private GroupBox gbInternal;
        private Label lbIdentifier;
        private TextBox tbIdentifier;
        private Button btnOk;
        private Button btnCancel;
        private ComboBox cbRoom;
        private Label lbEmployee;
        private ComboBox cbEmployee;
        private DateTimePicker dtpEndTime;
        private Label lbTimeEnd;
        private DateTimePicker dtpStartTime;
        private Label lbTimeStart;
        private ErrorProvider errorProvider;
        private Label lbDuration;
    }
}