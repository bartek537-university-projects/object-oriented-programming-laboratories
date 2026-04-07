using Laboratory_20260309.Data.Sources;
using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Presentation.StudentForm;
using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309;

public partial class StudentForm : Form, IStudentFormView
{
    private readonly IStudentFormPresenter _presenter;

    public event EventHandler<StudentInput>? AddStudentClicked;
    public event EventHandler<StudentInput>? EditStudentClicked;
    public event EventHandler? DeleteStudentClicked;
    public event EventHandler<string>? SaveStudentListClicked;
    public event EventHandler<string>? LoadStudentListClicked;

    public event EventHandler<Student?>? StudentSelected;

    public StudentForm()
    {
        InitializeComponent();
        cbCollegeLevel.DataSource = Enum.GetValues<RokStudiow>();

        InMemoryStudentRepository studentRepository = new();
        _presenter = new StudentFormPresenter(this, studentRepository);
    }

    public void SetFormErorrs(Dictionary<string, string> errors)
    {
        List<Control> controls = new[] { gbBasicDetails, gbAddressDetails }
            .SelectMany(group => group.Controls.Cast<Control>())
            .ToList();

        foreach (Control control in controls)
        {
            if (control.Tag is not string tag)
            {
                continue;
            }

            _ = errors.TryGetValue(tag, out string? message);
            errorProvider.SetError(control, message);
        }
    }

    public void PopulateForm(Student student)
    {
        tbFirstName.Text = student.Imie;
        tbLastName.Text = student.Nazwisko;
        dtpBirthDate.Value = student.DataUrodzenia;
        cbCollegeLevel.SelectedIndex = (int)student.RokStudiow - 1;
        tbCity.Text = student.AdresZamieszkania.Miasto;
        mtbPostalCode.Text = student.AdresZamieszkania.KodPocztowy;
        tbStreet.Text = student.AdresZamieszkania.lica;
        nudBuildingNumber.Value = student.AdresZamieszkania.NumerBudynku;
        chkFlatNumberEnabled.Checked = student.AdresZamieszkania.NumerMieszkania != null;
        nudFlatNumber.Value = student.AdresZamieszkania.NumerMieszkania ?? 1;
        errorProvider.Clear();

        _ = tbFirstName.Focus();
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
        errorProvider.Clear();

        lstStudents.ClearSelected();
    }

    public void SetStudents(IReadOnlyList<Student> students)
    {
        lstStudents.DataSource = students;
    }

    private void chkFlatNumberEnabled_CheckedChanged(object sender, EventArgs e)
    {
        ToggleFlatNumberVisibility();
    }

    private void ToggleFlatNumberVisibility()
    {
        nudFlatNumber.Enabled = chkFlatNumberEnabled.Checked;
    }

    private void btnAddStudent_Click(object sender, EventArgs e)
    {
        OnAddStudentClicked();
    }

    private void OnAddStudentClicked()
    {
        StudentInput student = GetStudent();
        AddStudentClicked?.Invoke(this, student);
    }

    private StudentInput GetStudent()
    {
        return new()
        {
            FirstName = tbFirstName.Text,
            LastName = tbLastName.Text,
            BirthDate = dtpBirthDate.Value,
            CollegeLevel = (RokStudiow)cbCollegeLevel.SelectedValue!,
            City = tbCity.Text,
            PostalCode = mtbPostalCode.Text,
            Street = tbStreet.Text,
            BuildingNumber = (int)nudBuildingNumber.Value,
            FlatNumber = chkFlatNumberEnabled.Checked ? (int)nudFlatNumber.Value : null,
        };
    }

    private void btnEditStudent_Click(object sender, EventArgs e)
    {
        OnEditStudentClicked();
    }

    private void OnEditStudentClicked()
    {
        StudentInput student = GetStudent();
        EditStudentClicked?.Invoke(this, student);
    }

    private void btnDeleteStudent_Click(object sender, EventArgs e)
    {
        OnDeleteStudentClicked();
    }

    private void OnDeleteStudentClicked()
    {
        DeleteStudentClicked?.Invoke(this, EventArgs.Empty);
    }

    private void lstStudents_SelectedValueChanged(object sender, EventArgs e)
    {
        if (lstStudents.SelectedItem is not Student student)
        {
            return;
        }
        OnStudentSelected(student);
    }

    private void lstStudents_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            ClearStudentSelection();
        }
    }

    private void lstStudents_MouseDown(object sender, MouseEventArgs mouse)
    {
        if (lstStudents.SelectedItem is null)
        {
            return;
        }

        if (IsWhiteSpaceClick(lstStudents, mouse))
        {
            ClearStudentSelection();
        }
    }

    private void ClearStudentSelection()
    {
        lstStudents.ClearSelected();
        OnStudentSelected(null);
    }

    private void OnStudentSelected(Student? student)
    {
        StudentSelected?.Invoke(this, student);
    }

    private static bool IsWhiteSpaceClick(ListBox list, MouseEventArgs mouse)
    {
        int selection = list.IndexFromPoint(mouse.Location);
        return selection == ListBox.NoMatches;
    }

    private void btnSaveStudentList_Click(object sender, EventArgs e)
    {
        OnSaveStudentListClicked();
    }

    private void OnSaveStudentListClicked()
    {
        if (saveStudentFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        SaveStudentListClicked?.Invoke(this, saveStudentFileDialog.FileName);
    }

    private void btnLoadStudentList_Click(object sender, EventArgs e)
    {
        OnLoadStudentListClicked();
    }

    private void OnLoadStudentListClicked()
    {
        if (openStudentFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        LoadStudentListClicked?.Invoke(this, openStudentFileDialog.FileName);
    }
}
