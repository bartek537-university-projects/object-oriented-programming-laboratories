using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Presentation.StudentForm;
using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309;

public partial class StudentForm : Form, IStudentFormView
{
    private readonly IStudentFormPresenter _presenter;

    public event EventHandler? SaveStudentClicked;
    public event EventHandler<Student?>? StudentSelected;

    public StudentForm()
    {
        InitializeComponent();
        cbCollegeLevel.DataSource = Enum.GetValues<CollegeLevel>();

        _presenter = new StudentFormPresenter(this);
    }

    public StudentFormDto GetStudent() => new()
    {
        FirstName = tbFirstName.Text,
        LastName = tbLastName.Text,
        BirthDate = dtpBirthDate.Value,
        CollegeLevel = (CollegeLevel)cbCollegeLevel.SelectedValue!,
        City = tbCity.Text,
        PostalCode = mtbPostalCode.Text,
        Street = tbStreet.Text,
        BuildingNumber = (int)nudBuildingNumber.Value,
        FlatNumber = chkFlatNumberEnabled.Enabled ? (int)nudFlatNumber.Value : null,
    };

    public void SetErrors(Dictionary<string, string> errors)
    {
        var controls = new[] { gbBasicDetails, gbAddressDetails }
            .SelectMany(group => group.Controls.Cast<Control>())
            .ToList();

        foreach (var control in controls)
        {
            if (control.Tag is not string tag)
            {
                continue;
            }

            errors.TryGetValue(tag, out string? message);
            errorProvider.SetError(control, message);
        }
    }

    public void ClearForm()
    {
        tbFirstName.Clear();
        tbLastName.Clear();
        dtpBirthDate.Value = DateTime.Now;
        cbCollegeLevel.SelectedIndex = 0;
        tbCity.Clear();
        mtbPostalCode.Clear();
        tbStreet.Clear();
        nudBuildingNumber.Value = 1;
        chkFlatNumberEnabled.Checked = false;
        nudFlatNumber.Value = 1;

        lstStudents.ClearSelected();
        errorProvider.Clear();
    }

    public void LoadStudent(Student student)
    {
        tbFirstName.Text = student.FirstName;
        tbLastName.Text = student.LastName;
        dtpBirthDate.Value = student.BirthDate;
        cbCollegeLevel.SelectedIndex = (int)student.CollegeLevel - 1;
        tbCity.Text = student.HomeAddress.City;
        mtbPostalCode.Text = student.HomeAddress.PostalCode;
        tbStreet.Text = student.HomeAddress.Street;
        nudBuildingNumber.Value = student.HomeAddress.BuildingNumber;
        chkFlatNumberEnabled.Checked = student.HomeAddress.FlatNumber != null;
        nudFlatNumber.Value = student.HomeAddress.FlatNumber ?? 1;

        tbFirstName.Focus();
        errorProvider.Clear();
    }

    public void SetStudents(IReadOnlyList<Student> students)
    {
        lstStudents.DataSource = students;
    }

    private void ClearStudentSelection()
    {
        lstStudents.ClearSelected();
        OnStudentSelected(null);
    }

    private void OnSaveStudentClicked(EventArgs e)
    {
        SaveStudentClicked?.Invoke(this, e);
    }

    private void OnStudentSelected(Student? student)
    {
        StudentSelected?.Invoke(this, student);
    }

    private void btnAddStudent_Click(object sender, EventArgs e)
    {
        OnSaveStudentClicked(EventArgs.Empty);
    }

    private void lstStudents_SelectedValueChanged(object sender, EventArgs e)
    {
        if (lstStudents.SelectedItem is Student student)
        {
            OnStudentSelected(student);
        }
    }

    private void lstStudents_MouseDown(object sender, MouseEventArgs e)
    {
        if (lstStudents.SelectedItem is null)
        {
            return;
        }

        var selectedIndex = lstStudents
            .IndexFromPoint(e.Location);

        if (selectedIndex == ListBox.NoMatches)
        {
            ClearStudentSelection();
        }
    }

    private void lstStudents_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            ClearStudentSelection();
        }
    }

    //private void EditSelectedStudent()
    //{
    //    if (lstStudents.SelectedItem is not Student student)
    //    {
    //        MessageBox.Show("Nie wybrano żadnego studenta.");
    //        return;
    //    }

    //    ValidateChildren();

    //    if (errorProvider.HasErrors)
    //    {
    //        MessageBox.Show("Formularz zawiera błędy.");
    //        return;
    //    }

    //    UpdateStudent(student);
    //    lstStudents.DataSource = null;
    //    lstStudents.DataSource = _studentRegistry.Students;

    //    ClearForm();
    //}

    //private void UpdateStudent(Student student)
    //{
    //    student.FirstName = tbFirstName.Text.Trim();
    //    student.LastName = tbLastName.Text.Trim();
    //    student.CollegeLevel = (CollegeLevel)cbCollegeLevel.SelectedValue!;
    //    student.HomeAddress = new()
    //    {
    //        City = tbCity.Text.Trim(),
    //        PostalCode = mtbPostalCode.Text.Trim(),
    //        Street = tbStreet.Text.Trim(),
    //        BuildingNumber = (int)nudBuildingNumber.Value,
    //        FlatNumber = chkFlatNumberEnabled.Checked ? (int)nudFlatNumber.Value : null
    //    };
    //}

    //private void DeleteSelectedStudent()
    //{
    //    if (lstStudents.SelectedItem is not Student student)
    //    {
    //        MessageBox.Show("Nie wybrano żadnego studenta.");
    //        return;
    //    }

    //    _studentRegistry.RemoveStudent(student);
    //    lstStudents.ClearSelected();
    //}

    //private void SaveStudentList()
    //{
    //    if (saveStudentFileDialog.ShowDialog(this) != DialogResult.OK)
    //    {
    //        return;
    //    }

    //    var outputFilePath = saveStudentFileDialog.FileName;
    //    var students = _studentRegistry.Students;

    //    try
    //    {
    //        _studentJsonHelper.SaveStudents(students, outputFilePath);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, "Failed to save student list", ex.Message);
    //        return;
    //    }
    //}

    //private void LoadStudentList()
    //{
    //    if (openStudentFileDialog.ShowDialog(this) != DialogResult.OK)
    //    {
    //        return;
    //    }

    //    var inputFilePath = saveStudentFileDialog.FileName;
    //    IEnumerable<Student> students;

    //    try
    //    {
    //        students = _studentJsonHelper.ReadStudents(inputFilePath);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, "Failed to read student list", ex.Message);
    //        return;
    //    }

    //    _studentRegistry.Students.Clear();

    //    foreach (var student in students)
    //    {
    //        _studentRegistry.Students.Add(student);
    //    }
    //}

    //private void ValidateTextBoxLength(TextBox textBox, int min, int max)
    //{
    //    var text = textBox.Text.Trim();

    //    if (text.Length >= min && text.Length <= max)
    //    {
    //        errorProvider.SetError(textBox, null);
    //        return;
    //    }

    //    var message = $"Pole musi zawierać między {min} a {max} znaki (nie wliczając białych znaków z obydwu końców).";
    //    errorProvider.SetError(textBox, message);
    //}

    //private void ToggleFlatNumberEnabledState()
    //{
    //    nudFlatNumber.Enabled = chkFlatNumberEnabled.Checked;
    //}

    //private void BlockInvalidTextCharacters(object sender, KeyPressEventArgs e)
    //{
    //    if (!IsLetterOrSpace(e.KeyChar))
    //    {
    //        e.Handled = true;
    //    }
    //}
}
