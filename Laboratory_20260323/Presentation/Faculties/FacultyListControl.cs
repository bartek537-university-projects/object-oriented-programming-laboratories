using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Faculties.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Faculties;

public partial class FacultyListControl : UserControl, IFacultyListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IFacultyListPresenter? Presenter { get; set; }

    public event EventHandler? AddFacultyClicked;
    public event EventHandler<Faculty>? EditFacultyClicked;
    public event EventHandler<Faculty>? RemoveFacultyClicked;

    public FacultyListControl()
    {
        InitializeComponent();

        mlcFaculties.AddColumn("Name", nameof(Faculty.Name));
        mlcFaculties.AddColumn("Address", nameof(Faculty.Address));

        mlcFaculties.AddClicked += OnAddFacultyClicked;
        mlcFaculties.EditClicked += OnEditFacultyClicked;
        mlcFaculties.RemoveClicked += OnRemoveFacultyClicked;
    }

    private void OnAddFacultyClicked(object? sender, EventArgs e)
    {
        AddFacultyClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditFacultyClicked(object? sender, object item)
    {
        if (item is Faculty faculty)
        {
            EditFacultyClicked?.Invoke(this, faculty);
        }
    }

    private void OnRemoveFacultyClicked(object? sender, object item)
    {
        if (item is Faculty faculty)
        {
            RemoveFacultyClicked?.Invoke(this, faculty);
        }
    }

    public void SetFaculties(IReadOnlyList<Faculty> faculties)
    {
        mlcFaculties.DataSource = faculties;
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
