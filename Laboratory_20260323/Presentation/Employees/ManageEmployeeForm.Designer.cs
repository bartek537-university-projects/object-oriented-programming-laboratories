namespace Laboratory_20260323.Presentation.Employees
{
    partial class ManageEmployeeForm
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
            gbInternal = new GroupBox();
            lbIdentifier = new Label();
            tbIdentifier = new TextBox();
            gbBasicInformation = new GroupBox();
            lbLastName = new Label();
            tbLastName = new TextBox();
            lbFirstName = new Label();
            tbFirstName = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            errorProvider = new ErrorProvider(components);
            gbInternal.SuspendLayout();
            gbBasicInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
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
            // gbBasicInformation
            // 
            gbBasicInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbBasicInformation.Controls.Add(lbLastName);
            gbBasicInformation.Controls.Add(tbLastName);
            gbBasicInformation.Controls.Add(lbFirstName);
            gbBasicInformation.Controls.Add(tbFirstName);
            gbBasicInformation.Location = new Point(12, 70);
            gbBasicInformation.Name = "gbBasicInformation";
            gbBasicInformation.Size = new Size(324, 82);
            gbBasicInformation.TabIndex = 1;
            gbBasicInformation.TabStop = false;
            gbBasicInformation.Text = "Basic information";
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Location = new Point(6, 54);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(61, 15);
            lbLastName.TabIndex = 2;
            lbLastName.Text = "Last name";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(86, 51);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(121, 23);
            tbLastName.TabIndex = 3;
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Location = new Point(6, 25);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(62, 15);
            lbFirstName.TabIndex = 0;
            lbFirstName.Text = "First name";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(86, 22);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(121, 23);
            tbFirstName.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(261, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(182, 242);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // ManageEmployeeForm
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
            MinimumSize = new Size(364, 240);
            Name = "ManageEmployeeForm";
            Text = "Edit employee";
            gbInternal.ResumeLayout(false);
            gbInternal.PerformLayout();
            gbBasicInformation.ResumeLayout(false);
            gbBasicInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbInternal;
        private Label lbIdentifier;
        private TextBox tbIdentifier;
        private GroupBox gbBasicInformation;
        private Label lbFirstName;
        private TextBox tbFirstName;
        private Label lbLastName;
        private TextBox tbLastName;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProvider;
    }
}