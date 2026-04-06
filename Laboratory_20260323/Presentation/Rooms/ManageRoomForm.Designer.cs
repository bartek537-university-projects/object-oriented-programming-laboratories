namespace Laboratory_20260323.Presentation.Rooms
{
    partial class ManageRoomForm
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
            cbFaculty = new ComboBox();
            lbFaculty = new Label();
            lbType = new Label();
            cbType = new ComboBox();
            nudCapacity = new NumericUpDown();
            lbCapacity = new Label();
            lbNumber = new Label();
            tbRoomNumber = new TextBox();
            gbInternal = new GroupBox();
            lbIdentifier = new Label();
            tbIdentifier = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            gbBasicInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            gbInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // gbBasicInformation
            // 
            gbBasicInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbBasicInformation.Controls.Add(cbFaculty);
            gbBasicInformation.Controls.Add(lbFaculty);
            gbBasicInformation.Controls.Add(lbType);
            gbBasicInformation.Controls.Add(cbType);
            gbBasicInformation.Controls.Add(nudCapacity);
            gbBasicInformation.Controls.Add(lbCapacity);
            gbBasicInformation.Controls.Add(lbNumber);
            gbBasicInformation.Controls.Add(tbRoomNumber);
            gbBasicInformation.Location = new Point(12, 70);
            gbBasicInformation.Name = "gbBasicInformation";
            gbBasicInformation.Size = new Size(324, 141);
            gbBasicInformation.TabIndex = 3;
            gbBasicInformation.TabStop = false;
            gbBasicInformation.Text = "Basic information";
            // 
            // cbFaculty
            // 
            cbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFaculty.FormattingEnabled = true;
            cbFaculty.Location = new Point(86, 110);
            cbFaculty.Name = "cbFaculty";
            cbFaculty.Size = new Size(121, 23);
            cbFaculty.TabIndex = 7;
            // 
            // lbFaculty
            // 
            lbFaculty.AutoSize = true;
            lbFaculty.Location = new Point(6, 113);
            lbFaculty.Name = "lbFaculty";
            lbFaculty.Size = new Size(45, 15);
            lbFaculty.TabIndex = 6;
            lbFaculty.Text = "Faculty";
            // 
            // lbType
            // 
            lbType.AutoSize = true;
            lbType.Location = new Point(6, 84);
            lbType.Name = "lbType";
            lbType.Size = new Size(32, 15);
            lbType.TabIndex = 5;
            lbType.Text = "Type";
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(86, 81);
            cbType.Name = "cbType";
            cbType.Size = new Size(121, 23);
            cbType.TabIndex = 4;
            // 
            // nudCapacity
            // 
            nudCapacity.Location = new Point(86, 52);
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(121, 23);
            nudCapacity.TabIndex = 3;
            nudCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbCapacity
            // 
            lbCapacity.AutoSize = true;
            lbCapacity.Location = new Point(6, 54);
            lbCapacity.Name = "lbCapacity";
            lbCapacity.Size = new Size(53, 15);
            lbCapacity.TabIndex = 2;
            lbCapacity.Text = "Capacity";
            // 
            // lbNumber
            // 
            lbNumber.AutoSize = true;
            lbNumber.Location = new Point(6, 25);
            lbNumber.Name = "lbNumber";
            lbNumber.Size = new Size(51, 15);
            lbNumber.TabIndex = 0;
            lbNumber.Text = "Number";
            // 
            // tbRoomNumber
            // 
            tbRoomNumber.Location = new Point(86, 22);
            tbRoomNumber.MaxLength = 24;
            tbRoomNumber.Name = "tbRoomNumber";
            tbRoomNumber.Size = new Size(121, 23);
            tbRoomNumber.TabIndex = 1;
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
            btnOk.Location = new Point(182, 226);
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
            btnCancel.Location = new Point(261, 226);
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
            // ManageRoomForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(348, 261);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(gbBasicInformation);
            Controls.Add(gbInternal);
            MinimumSize = new Size(364, 300);
            Name = "ManageRoomForm";
            Text = "Edit room";
            gbBasicInformation.ResumeLayout(false);
            gbBasicInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            gbInternal.ResumeLayout(false);
            gbInternal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBasicInformation;
        private Label lbNumber;
        private TextBox tbRoomNumber;
        private GroupBox gbInternal;
        private Label lbIdentifier;
        private TextBox tbIdentifier;
        private NumericUpDown nudCapacity;
        private Label lbCapacity;
        private Label lbType;
        private ComboBox cbType;
        private ComboBox cbFaculty;
        private Label lbFaculty;
        private Button btnOk;
        private Button btnCancel;
        private ErrorProvider errorProvider;
    }
}