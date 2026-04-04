namespace Laboratory_20260323.Presentation.Faculties
{
    partial class ManageFacultyForm
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
            lbIdentifier = new Label();
            tbIdentifier = new TextBox();
            gbInternal = new GroupBox();
            gbBasicInformation = new GroupBox();
            lbName = new Label();
            tbFacultyName = new TextBox();
            gbAddress = new GroupBox();
            mtbPostalCode = new MaskedTextBox();
            lbBuilding = new Label();
            tbBuilding = new TextBox();
            lbStreet = new Label();
            tbStreet = new TextBox();
            lbPostalCode = new Label();
            lbCity = new Label();
            tbCity = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            gbInternal.SuspendLayout();
            gbBasicInformation.SuspendLayout();
            gbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
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
            // gbInternal
            // 
            gbInternal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInternal.Controls.Add(lbIdentifier);
            gbInternal.Controls.Add(tbIdentifier);
            gbInternal.Location = new Point(12, 12);
            gbInternal.Name = "gbInternal";
            gbInternal.Size = new Size(324, 52);
            gbInternal.TabIndex = 0;
            gbInternal.TabStop = false;
            gbInternal.Text = "Internal";
            // 
            // gbBasicInformation
            // 
            gbBasicInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbBasicInformation.Controls.Add(lbName);
            gbBasicInformation.Controls.Add(tbFacultyName);
            gbBasicInformation.Location = new Point(12, 70);
            gbBasicInformation.Name = "gbBasicInformation";
            gbBasicInformation.Size = new Size(324, 53);
            gbBasicInformation.TabIndex = 1;
            gbBasicInformation.TabStop = false;
            gbBasicInformation.Text = "Basic information";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(6, 25);
            lbName.Name = "lbName";
            lbName.Size = new Size(39, 15);
            lbName.TabIndex = 0;
            lbName.Text = "Name";
            // 
            // tbFacultyName
            // 
            tbFacultyName.Location = new Point(86, 22);
            tbFacultyName.Name = "tbFacultyName";
            tbFacultyName.Size = new Size(121, 23);
            tbFacultyName.TabIndex = 1;
            // 
            // gbAddress
            // 
            gbAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbAddress.Controls.Add(mtbPostalCode);
            gbAddress.Controls.Add(lbBuilding);
            gbAddress.Controls.Add(tbBuilding);
            gbAddress.Controls.Add(lbStreet);
            gbAddress.Controls.Add(tbStreet);
            gbAddress.Controls.Add(lbPostalCode);
            gbAddress.Controls.Add(lbCity);
            gbAddress.Controls.Add(tbCity);
            gbAddress.Location = new Point(12, 129);
            gbAddress.Name = "gbAddress";
            gbAddress.Size = new Size(324, 141);
            gbAddress.TabIndex = 2;
            gbAddress.TabStop = false;
            gbAddress.Text = "Address";
            // 
            // mtbPostalCode
            // 
            mtbPostalCode.Location = new Point(86, 51);
            mtbPostalCode.Mask = "00-000";
            mtbPostalCode.Name = "mtbPostalCode";
            mtbPostalCode.Size = new Size(53, 23);
            mtbPostalCode.TabIndex = 3;
            // 
            // lbBuilding
            // 
            lbBuilding.AutoSize = true;
            lbBuilding.Location = new Point(6, 112);
            lbBuilding.Name = "lbBuilding";
            lbBuilding.Size = new Size(51, 15);
            lbBuilding.TabIndex = 6;
            lbBuilding.Text = "Building";
            // 
            // tbBuilding
            // 
            tbBuilding.Location = new Point(86, 109);
            tbBuilding.Name = "tbBuilding";
            tbBuilding.Size = new Size(121, 23);
            tbBuilding.TabIndex = 7;
            // 
            // lbStreet
            // 
            lbStreet.AutoSize = true;
            lbStreet.Location = new Point(6, 83);
            lbStreet.Name = "lbStreet";
            lbStreet.Size = new Size(37, 15);
            lbStreet.TabIndex = 4;
            lbStreet.Text = "Street";
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(86, 80);
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(121, 23);
            tbStreet.TabIndex = 5;
            // 
            // lbPostalCode
            // 
            lbPostalCode.AutoSize = true;
            lbPostalCode.Location = new Point(6, 54);
            lbPostalCode.Name = "lbPostalCode";
            lbPostalCode.Size = new Size(68, 15);
            lbPostalCode.TabIndex = 2;
            lbPostalCode.Text = "Postal code";
            // 
            // lbCity
            // 
            lbCity.AutoSize = true;
            lbCity.Location = new Point(6, 25);
            lbCity.Name = "lbCity";
            lbCity.Size = new Size(28, 15);
            lbCity.TabIndex = 0;
            lbCity.Text = "City";
            // 
            // tbCity
            // 
            tbCity.Location = new Point(86, 22);
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(121, 23);
            tbCity.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(182, 284);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(261, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // ManageFacultyForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(348, 319);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(gbAddress);
            Controls.Add(gbBasicInformation);
            Controls.Add(gbInternal);
            MinimumSize = new Size(364, 240);
            Name = "ManageFacultyForm";
            Text = "Edit faculty";
            gbInternal.ResumeLayout(false);
            gbInternal.PerformLayout();
            gbBasicInformation.ResumeLayout(false);
            gbBasicInformation.PerformLayout();
            gbAddress.ResumeLayout(false);
            gbAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbIdentifier;
        private TextBox tbIdentifier;
        private GroupBox gbInternal;
        private GroupBox gbBasicInformation;
        private Label lbName;
        private TextBox tbFacultyName;
        private GroupBox gbAddress;
        private Label lbCity;
        private TextBox tbCity;
        private Button btnOk;
        private Button btnCancel;
        private Label lbBuilding;
        private TextBox tbBuilding;
        private Label lbStreet;
        private TextBox tbStreet;
        private Label lbPostalCode;
        private MaskedTextBox mtbPostalCode;
        private ErrorProvider errorProvider;
    }
}