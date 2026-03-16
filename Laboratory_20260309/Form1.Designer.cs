namespace Laboratory_20260309
{
    partial class ManageStudentsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lbAddStudent = new Label();
            gbBasicDetails = new GroupBox();
            cbCollegeLevel = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            lbCollegeLevel = new Label();
            lbBirthDate = new Label();
            tbLastName = new TextBox();
            lbLastName = new Label();
            lbFirstName = new Label();
            tbFirstName = new TextBox();
            gbAddressDetails = new GroupBox();
            chkFlatNumberEnabled = new CheckBox();
            nudFlatNumber = new NumericUpDown();
            nudBuildingNumber = new NumericUpDown();
            mtbPostalCode = new MaskedTextBox();
            lbFlatNumber = new Label();
            lbBuildingNumber = new Label();
            lbStreet = new Label();
            tbStreet = new TextBox();
            lbPostalCode = new Label();
            lbCity = new Label();
            tbCity = new TextBox();
            lbStudentList = new Label();
            btnAddStudent = new Button();
            btnEditStudent = new Button();
            btnDeleteStudent = new Button();
            btnSaveStudentList = new Button();
            btnLoadStudentList = new Button();
            lstStudents = new ListBox();
            errorProvider = new ErrorProvider(components);
            openStudentFileDialog = new OpenFileDialog();
            saveStudentFileDialog = new SaveFileDialog();
            gbBasicDetails.SuspendLayout();
            gbAddressDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFlatNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBuildingNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lbAddStudent
            // 
            lbAddStudent.AutoSize = true;
            lbAddStudent.Font = new Font("Segoe UI", 12F);
            lbAddStudent.Location = new Point(22, 32);
            lbAddStudent.Margin = new Padding(6, 0, 6, 0);
            lbAddStudent.Name = "lbAddStudent";
            lbAddStudent.Size = new Size(349, 45);
            lbAddStudent.TabIndex = 0;
            lbAddStudent.Text = "Dodaj studenta do listy";
            // 
            // gbBasicDetails
            // 
            gbBasicDetails.Controls.Add(cbCollegeLevel);
            gbBasicDetails.Controls.Add(dtpBirthDate);
            gbBasicDetails.Controls.Add(lbCollegeLevel);
            gbBasicDetails.Controls.Add(lbBirthDate);
            gbBasicDetails.Controls.Add(tbLastName);
            gbBasicDetails.Controls.Add(lbLastName);
            gbBasicDetails.Controls.Add(lbFirstName);
            gbBasicDetails.Controls.Add(tbFirstName);
            gbBasicDetails.Location = new Point(22, 111);
            gbBasicDetails.Margin = new Padding(6);
            gbBasicDetails.Name = "gbBasicDetails";
            gbBasicDetails.Padding = new Padding(6);
            gbBasicDetails.Size = new Size(591, 322);
            gbBasicDetails.TabIndex = 1;
            gbBasicDetails.TabStop = false;
            gbBasicDetails.Text = "Dane podstawowe";
            // 
            // cbCollegeLevel
            // 
            cbCollegeLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCollegeLevel.Location = new Point(253, 239);
            cbCollegeLevel.Margin = new Padding(6);
            cbCollegeLevel.Name = "cbCollegeLevel";
            cbCollegeLevel.Size = new Size(141, 40);
            cbCollegeLevel.TabIndex = 7;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Checked = false;
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(253, 177);
            dtpBirthDate.Margin = new Padding(6);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(257, 39);
            dtpBirthDate.TabIndex = 5;
            dtpBirthDate.Validating += dtpBirthDate_Validating;
            // 
            // lbCollegeLevel
            // 
            lbCollegeLevel.AutoSize = true;
            lbCollegeLevel.Location = new Point(11, 245);
            lbCollegeLevel.Margin = new Padding(6, 0, 6, 0);
            lbCollegeLevel.Name = "lbCollegeLevel";
            lbCollegeLevel.Size = new Size(143, 32);
            lbCollegeLevel.TabIndex = 6;
            lbCollegeLevel.Text = "Rok studiów";
            // 
            // lbBirthDate
            // 
            lbBirthDate.AutoSize = true;
            lbBirthDate.Location = new Point(11, 183);
            lbBirthDate.Margin = new Padding(6, 0, 6, 0);
            lbBirthDate.Name = "lbBirthDate";
            lbBirthDate.Size = new Size(176, 32);
            lbBirthDate.TabIndex = 4;
            lbBirthDate.Text = "Data urodzenia";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(253, 115);
            tbLastName.Margin = new Padding(6);
            tbLastName.MaxLength = 64;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(292, 39);
            tbLastName.TabIndex = 3;
            tbLastName.KeyPress += BlockInvalidTextCharacters;
            tbLastName.Validating += tbLastName_Validating;
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Location = new Point(11, 122);
            lbLastName.Margin = new Padding(6, 0, 6, 0);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(114, 32);
            lbLastName.TabIndex = 2;
            lbLastName.Text = "Nazwisko";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Location = new Point(11, 60);
            lbFirstName.Margin = new Padding(6, 0, 6, 0);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(60, 32);
            lbFirstName.TabIndex = 0;
            lbFirstName.Text = "Imię";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(253, 53);
            tbFirstName.Margin = new Padding(6);
            tbFirstName.MaxLength = 32;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(292, 39);
            tbFirstName.TabIndex = 1;
            tbFirstName.KeyPress += BlockInvalidTextCharacters;
            tbFirstName.Validating += tbFirstName_Validating;
            // 
            // gbAddressDetails
            // 
            gbAddressDetails.Controls.Add(chkFlatNumberEnabled);
            gbAddressDetails.Controls.Add(nudFlatNumber);
            gbAddressDetails.Controls.Add(nudBuildingNumber);
            gbAddressDetails.Controls.Add(mtbPostalCode);
            gbAddressDetails.Controls.Add(lbFlatNumber);
            gbAddressDetails.Controls.Add(lbBuildingNumber);
            gbAddressDetails.Controls.Add(lbStreet);
            gbAddressDetails.Controls.Add(tbStreet);
            gbAddressDetails.Controls.Add(lbPostalCode);
            gbAddressDetails.Controls.Add(lbCity);
            gbAddressDetails.Controls.Add(tbCity);
            gbAddressDetails.Location = new Point(22, 446);
            gbAddressDetails.Margin = new Padding(6);
            gbAddressDetails.Name = "gbAddressDetails";
            gbAddressDetails.Padding = new Padding(6);
            gbAddressDetails.Size = new Size(591, 388);
            gbAddressDetails.TabIndex = 2;
            gbAddressDetails.TabStop = false;
            gbAddressDetails.Text = "Dane adresowe";
            // 
            // chkFlatNumberEnabled
            // 
            chkFlatNumberEnabled.AutoSize = true;
            chkFlatNumberEnabled.Location = new Point(423, 314);
            chkFlatNumberEnabled.Margin = new Padding(6);
            chkFlatNumberEnabled.Name = "chkFlatNumberEnabled";
            chkFlatNumberEnabled.Size = new Size(126, 36);
            chkFlatNumberEnabled.TabIndex = 9;
            chkFlatNumberEnabled.Text = "Posiada";
            chkFlatNumberEnabled.UseVisualStyleBackColor = true;
            chkFlatNumberEnabled.CheckedChanged += chkFlatNumberEnabled_CheckedChanged;
            // 
            // nudFlatNumber
            // 
            nudFlatNumber.Enabled = false;
            nudFlatNumber.Location = new Point(253, 305);
            nudFlatNumber.Margin = new Padding(6);
            nudFlatNumber.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudFlatNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFlatNumber.Name = "nudFlatNumber";
            nudFlatNumber.Size = new Size(145, 39);
            nudFlatNumber.TabIndex = 10;
            nudFlatNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudBuildingNumber
            // 
            nudBuildingNumber.Location = new Point(253, 243);
            nudBuildingNumber.Margin = new Padding(6);
            nudBuildingNumber.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudBuildingNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBuildingNumber.Name = "nudBuildingNumber";
            nudBuildingNumber.Size = new Size(145, 39);
            nudBuildingNumber.TabIndex = 7;
            nudBuildingNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // mtbPostalCode
            // 
            mtbPostalCode.Location = new Point(253, 117);
            mtbPostalCode.Margin = new Padding(6);
            mtbPostalCode.Mask = "00-000";
            mtbPostalCode.Name = "mtbPostalCode";
            mtbPostalCode.Size = new Size(91, 39);
            mtbPostalCode.TabIndex = 3;
            mtbPostalCode.Validating += mtbPostalCode_Validating;
            // 
            // lbFlatNumber
            // 
            lbFlatNumber.AutoSize = true;
            lbFlatNumber.Location = new Point(11, 309);
            lbFlatNumber.Margin = new Padding(6, 0, 6, 0);
            lbFlatNumber.Name = "lbFlatNumber";
            lbFlatNumber.Size = new Size(212, 32);
            lbFlatNumber.TabIndex = 8;
            lbFlatNumber.Text = "Numer mieszkania";
            // 
            // lbBuildingNumber
            // 
            lbBuildingNumber.AutoSize = true;
            lbBuildingNumber.Location = new Point(11, 247);
            lbBuildingNumber.Margin = new Padding(6, 0, 6, 0);
            lbBuildingNumber.Name = "lbBuildingNumber";
            lbBuildingNumber.Size = new Size(189, 32);
            lbBuildingNumber.TabIndex = 6;
            lbBuildingNumber.Text = "Numer budynku";
            // 
            // lbStreet
            // 
            lbStreet.AutoSize = true;
            lbStreet.Location = new Point(11, 186);
            lbStreet.Margin = new Padding(6, 0, 6, 0);
            lbStreet.Name = "lbStreet";
            lbStreet.Size = new Size(65, 32);
            lbStreet.TabIndex = 4;
            lbStreet.Text = "Ulica";
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(253, 179);
            tbStreet.Margin = new Padding(6);
            tbStreet.MaxLength = 80;
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(292, 39);
            tbStreet.TabIndex = 5;
            tbStreet.KeyPress += BlockInvalidTextCharacters;
            tbStreet.Validating += tbStreet_Validating;
            // 
            // lbPostalCode
            // 
            lbPostalCode.AutoSize = true;
            lbPostalCode.Location = new Point(11, 124);
            lbPostalCode.Margin = new Padding(6, 0, 6, 0);
            lbPostalCode.Name = "lbPostalCode";
            lbPostalCode.Size = new Size(163, 32);
            lbPostalCode.TabIndex = 2;
            lbPostalCode.Text = "Kod pocztowy";
            // 
            // lbCity
            // 
            lbCity.AutoSize = true;
            lbCity.Location = new Point(11, 62);
            lbCity.Margin = new Padding(6, 0, 6, 0);
            lbCity.Name = "lbCity";
            lbCity.Size = new Size(148, 32);
            lbCity.TabIndex = 0;
            lbCity.Text = "Miejscowość";
            // 
            // tbCity
            // 
            tbCity.Location = new Point(253, 55);
            tbCity.Margin = new Padding(6);
            tbCity.MaxLength = 64;
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(292, 39);
            tbCity.TabIndex = 1;
            tbCity.KeyPress += BlockInvalidTextCharacters;
            tbCity.Validating += tbCity_Validating;
            // 
            // lbStudentList
            // 
            lbStudentList.AutoSize = true;
            lbStudentList.Font = new Font("Segoe UI", 12F);
            lbStudentList.Location = new Point(635, 32);
            lbStudentList.Margin = new Padding(6, 0, 6, 0);
            lbStudentList.Name = "lbStudentList";
            lbStudentList.Size = new Size(243, 45);
            lbStudentList.TabIndex = 6;
            lbStudentList.Text = "Lista studentów";
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Green;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(22, 847);
            btnAddStudent.Margin = new Padding(6);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(591, 49);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "Dodaj studenta";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnEditStudent
            // 
            btnEditStudent.BackColor = Color.Blue;
            btnEditStudent.ForeColor = Color.White;
            btnEditStudent.Location = new Point(22, 909);
            btnEditStudent.Margin = new Padding(6);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(591, 49);
            btnEditStudent.TabIndex = 4;
            btnEditStudent.Text = "Edytuj dane studenta";
            btnEditStudent.UseVisualStyleBackColor = false;
            btnEditStudent.Click += btnEditStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.BackColor = Color.Sienna;
            btnDeleteStudent.ForeColor = Color.White;
            btnDeleteStudent.Location = new Point(22, 971);
            btnDeleteStudent.Margin = new Padding(6);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(591, 49);
            btnDeleteStudent.TabIndex = 5;
            btnDeleteStudent.Text = "Usuń studenta";
            btnDeleteStudent.UseVisualStyleBackColor = false;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // btnSaveStudentList
            // 
            btnSaveStudentList.BackColor = Color.DodgerBlue;
            btnSaveStudentList.ForeColor = Color.White;
            btnSaveStudentList.Location = new Point(635, 847);
            btnSaveStudentList.Margin = new Padding(6);
            btnSaveStudentList.Name = "btnSaveStudentList";
            btnSaveStudentList.Size = new Size(591, 49);
            btnSaveStudentList.TabIndex = 8;
            btnSaveStudentList.Text = "Zapisz listę studentów";
            btnSaveStudentList.UseVisualStyleBackColor = false;
            btnSaveStudentList.Click += btnSaveStudentList_Click;
            // 
            // btnLoadStudentList
            // 
            btnLoadStudentList.BackColor = Color.Navy;
            btnLoadStudentList.ForeColor = Color.White;
            btnLoadStudentList.Location = new Point(635, 909);
            btnLoadStudentList.Margin = new Padding(6);
            btnLoadStudentList.Name = "btnLoadStudentList";
            btnLoadStudentList.Size = new Size(591, 49);
            btnLoadStudentList.TabIndex = 9;
            btnLoadStudentList.Text = "Wczytaj listę studentów";
            btnLoadStudentList.UseVisualStyleBackColor = false;
            btnLoadStudentList.Click += btnLoadStudentList_Click;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.Location = new Point(635, 111);
            lstStudents.Margin = new Padding(6);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(587, 708);
            lstStudents.TabIndex = 7;
            lstStudents.SelectedIndexChanged += lstStudents_SelectedIndexChanged;
            lstStudents.MouseDown += lstStudents_MouseDown;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // openStudentFileDialog
            // 
            openStudentFileDialog.FileName = "students.json";
            openStudentFileDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // saveStudentFileDialog
            // 
            saveStudentFileDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // ManageStudentsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 1045);
            Controls.Add(lstStudents);
            Controls.Add(btnLoadStudentList);
            Controls.Add(btnSaveStudentList);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnEditStudent);
            Controls.Add(btnAddStudent);
            Controls.Add(lbStudentList);
            Controls.Add(gbAddressDetails);
            Controls.Add(gbBasicDetails);
            Controls.Add(lbAddStudent);
            DoubleBuffered = true;
            Margin = new Padding(6);
            Name = "ManageStudentsForm";
            Text = "Zarządzaj studentami";
            gbBasicDetails.ResumeLayout(false);
            gbBasicDetails.PerformLayout();
            gbAddressDetails.ResumeLayout(false);
            gbAddressDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFlatNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBuildingNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbAddStudent;
        private GroupBox gbBasicDetails;
        private GroupBox gbAddressDetails;
        private Label lbLastName;
        private Label lbFirstName;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private Label lbCollegeLevel;
        private Label lbBirthDate;
        private DateTimePicker dtpBirthDate;
        private ComboBox cbCollegeLevel;
        private Label lbFlatNumber;
        private Label lbBuildingNumber;
        private Label lbStreet;
        private TextBox tbStreet;
        private Label lbPostalCode;
        private Label lbCity;
        private TextBox tbCity;
        private MaskedTextBox mtbPostalCode;
        private NumericUpDown nudFlatNumber;
        private NumericUpDown nudBuildingNumber;
        private CheckBox chkFlatNumberEnabled;
        private Label lbStudentList;
        private Button btnAddStudent;
        private Button btnEditStudent;
        private Button btnDeleteStudent;
        private Button btnSaveStudentList;
        private Button btnLoadStudentList;
        private ListBox lstStudents;
        private ErrorProvider errorProvider;
        private OpenFileDialog openStudentFileDialog;
        private SaveFileDialog saveStudentFileDialog;
    }
}
