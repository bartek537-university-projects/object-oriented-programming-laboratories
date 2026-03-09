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
            cbFlatNumberEnabled = new CheckBox();
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
            lbAddStudent.Location = new Point(12, 15);
            lbAddStudent.Name = "lbAddStudent";
            lbAddStudent.Size = new Size(169, 21);
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
            gbBasicDetails.Location = new Point(12, 52);
            gbBasicDetails.Name = "gbBasicDetails";
            gbBasicDetails.Size = new Size(318, 151);
            gbBasicDetails.TabIndex = 1;
            gbBasicDetails.TabStop = false;
            gbBasicDetails.Text = "Dane podstawowe";
            // 
            // cbStudyLevel
            // 
            cbCollegeLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCollegeLevel.Location = new Point(136, 112);
            cbCollegeLevel.Name = "cbStudyLevel";
            cbCollegeLevel.Size = new Size(78, 23);
            cbCollegeLevel.TabIndex = 7;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Checked = false;
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(136, 83);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(140, 23);
            dtpBirthDate.TabIndex = 5;
            dtpBirthDate.Validating += dtpBirthDate_Validating;
            // 
            // lbStudyLevel
            // 
            lbCollegeLevel.AutoSize = true;
            lbCollegeLevel.Location = new Point(6, 115);
            lbCollegeLevel.Name = "lbStudyLevel";
            lbCollegeLevel.Size = new Size(72, 15);
            lbCollegeLevel.TabIndex = 6;
            lbCollegeLevel.Text = "Rok studiów";
            // 
            // lbBirthDate
            // 
            lbBirthDate.AutoSize = true;
            lbBirthDate.Location = new Point(6, 86);
            lbBirthDate.Name = "lbBirthDate";
            lbBirthDate.Size = new Size(86, 15);
            lbBirthDate.TabIndex = 4;
            lbBirthDate.Text = "Data urodzenia";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(136, 54);
            tbLastName.MaxLength = 64;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(159, 23);
            tbLastName.TabIndex = 3;
            tbLastName.Validating += tbLastName_Validating;
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Location = new Point(6, 57);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(57, 15);
            lbLastName.TabIndex = 2;
            lbLastName.Text = "Nazwisko";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Location = new Point(6, 28);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(30, 15);
            lbFirstName.TabIndex = 0;
            lbFirstName.Text = "Imię";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(136, 25);
            tbFirstName.MaxLength = 32;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(159, 23);
            tbFirstName.TabIndex = 1;
            tbFirstName.Validating += tbFirstName_Validating;
            // 
            // gbAddressDetails
            // 
            gbAddressDetails.Controls.Add(cbFlatNumberEnabled);
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
            gbAddressDetails.Location = new Point(12, 209);
            gbAddressDetails.Name = "gbAddressDetails";
            gbAddressDetails.Size = new Size(318, 182);
            gbAddressDetails.TabIndex = 2;
            gbAddressDetails.TabStop = false;
            gbAddressDetails.Text = "Dane adresowe";
            // 
            // cbFlatNumberEnabled
            // 
            cbFlatNumberEnabled.AutoSize = true;
            cbFlatNumberEnabled.Location = new Point(228, 147);
            cbFlatNumberEnabled.Name = "cbFlatNumberEnabled";
            cbFlatNumberEnabled.Size = new Size(67, 19);
            cbFlatNumberEnabled.TabIndex = 9;
            cbFlatNumberEnabled.Text = "Posiada";
            cbFlatNumberEnabled.UseVisualStyleBackColor = true;
            cbFlatNumberEnabled.CheckedChanged += cbFlatNumberEnabled_CheckedChanged;
            // 
            // nudFlatNumber
            // 
            nudFlatNumber.Enabled = false;
            nudFlatNumber.Location = new Point(136, 143);
            nudFlatNumber.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudFlatNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFlatNumber.Name = "nudFlatNumber";
            nudFlatNumber.Size = new Size(78, 23);
            nudFlatNumber.TabIndex = 10;
            nudFlatNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudBuildingNumber
            // 
            nudBuildingNumber.Location = new Point(136, 114);
            nudBuildingNumber.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudBuildingNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBuildingNumber.Name = "nudBuildingNumber";
            nudBuildingNumber.Size = new Size(78, 23);
            nudBuildingNumber.TabIndex = 7;
            nudBuildingNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // mtbPostalCode
            // 
            mtbPostalCode.Location = new Point(136, 55);
            mtbPostalCode.Mask = "00-000";
            mtbPostalCode.Name = "mtbPostalCode";
            mtbPostalCode.Size = new Size(51, 23);
            mtbPostalCode.TabIndex = 3;
            mtbPostalCode.Validating += mtbPostalCode_Validating;
            // 
            // lbFlatNumber
            // 
            lbFlatNumber.AutoSize = true;
            lbFlatNumber.Location = new Point(6, 145);
            lbFlatNumber.Name = "lbFlatNumber";
            lbFlatNumber.Size = new Size(105, 15);
            lbFlatNumber.TabIndex = 8;
            lbFlatNumber.Text = "Numer mieszkania";
            // 
            // lbBuildingNumber
            // 
            lbBuildingNumber.AutoSize = true;
            lbBuildingNumber.Location = new Point(6, 116);
            lbBuildingNumber.Name = "lbBuildingNumber";
            lbBuildingNumber.Size = new Size(94, 15);
            lbBuildingNumber.TabIndex = 6;
            lbBuildingNumber.Text = "Numer budynku";
            // 
            // lbStreet
            // 
            lbStreet.AutoSize = true;
            lbStreet.Location = new Point(6, 87);
            lbStreet.Name = "lbStreet";
            lbStreet.Size = new Size(33, 15);
            lbStreet.TabIndex = 4;
            lbStreet.Text = "Ulica";
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(136, 84);
            tbStreet.MaxLength = 80;
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(159, 23);
            tbStreet.TabIndex = 5;
            tbStreet.Validating += tbStreet_Validating;
            // 
            // lbPostalCode
            // 
            lbPostalCode.AutoSize = true;
            lbPostalCode.Location = new Point(6, 58);
            lbPostalCode.Name = "lbPostalCode";
            lbPostalCode.Size = new Size(82, 15);
            lbPostalCode.TabIndex = 2;
            lbPostalCode.Text = "Kod pocztowy";
            // 
            // lbCity
            // 
            lbCity.AutoSize = true;
            lbCity.Location = new Point(6, 29);
            lbCity.Name = "lbCity";
            lbCity.Size = new Size(75, 15);
            lbCity.TabIndex = 0;
            lbCity.Text = "Miejscowość";
            // 
            // tbCity
            // 
            tbCity.Location = new Point(136, 26);
            tbCity.MaxLength = 64;
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(159, 23);
            tbCity.TabIndex = 1;
            tbCity.Validating += tbCity_Validating;
            // 
            // lbStudentList
            // 
            lbStudentList.AutoSize = true;
            lbStudentList.Font = new Font("Segoe UI", 12F);
            lbStudentList.Location = new Point(342, 15);
            lbStudentList.Name = "lbStudentList";
            lbStudentList.Size = new Size(119, 21);
            lbStudentList.TabIndex = 6;
            lbStudentList.Text = "Lista studentów";
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Green;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(12, 397);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(318, 23);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "Dodaj studenta";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnEditStudent
            // 
            btnEditStudent.BackColor = Color.Blue;
            btnEditStudent.ForeColor = Color.White;
            btnEditStudent.Location = new Point(12, 426);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(318, 23);
            btnEditStudent.TabIndex = 4;
            btnEditStudent.Text = "Edytuj dane studenta";
            btnEditStudent.UseVisualStyleBackColor = false;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.BackColor = Color.Sienna;
            btnDeleteStudent.ForeColor = Color.White;
            btnDeleteStudent.Location = new Point(12, 455);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(318, 23);
            btnDeleteStudent.TabIndex = 5;
            btnDeleteStudent.Text = "Usuń studenta";
            btnDeleteStudent.UseVisualStyleBackColor = false;
            // 
            // btnSaveStudentList
            // 
            btnSaveStudentList.BackColor = Color.DodgerBlue;
            btnSaveStudentList.ForeColor = Color.White;
            btnSaveStudentList.Location = new Point(342, 397);
            btnSaveStudentList.Name = "btnSaveStudentList";
            btnSaveStudentList.Size = new Size(318, 23);
            btnSaveStudentList.TabIndex = 8;
            btnSaveStudentList.Text = "Zapisz listę studentów";
            btnSaveStudentList.UseVisualStyleBackColor = false;
            // 
            // btnLoadStudentList
            // 
            btnLoadStudentList.BackColor = Color.Navy;
            btnLoadStudentList.ForeColor = Color.White;
            btnLoadStudentList.Location = new Point(342, 426);
            btnLoadStudentList.Name = "btnLoadStudentList";
            btnLoadStudentList.Size = new Size(318, 23);
            btnLoadStudentList.TabIndex = 9;
            btnLoadStudentList.Text = "Wczytaj listę studentów";
            btnLoadStudentList.UseVisualStyleBackColor = false;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.Location = new Point(342, 52);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(318, 334);
            lstStudents.TabIndex = 7;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ManageStudentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 490);
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
        private CheckBox cbFlatNumberEnabled;
        private Label lbStudentList;
        private Button btnAddStudent;
        private Button btnEditStudent;
        private Button btnDeleteStudent;
        private Button btnSaveStudentList;
        private Button btnLoadStudentList;
        private ListBox lstStudents;
        private ErrorProvider errorProvider;
    }
}
