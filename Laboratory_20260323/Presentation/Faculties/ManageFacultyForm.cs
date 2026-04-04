using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Faculties.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Faculties;

public partial class ManageFacultyForm : Form, IManageFacultyView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IManageFacultyPresenter Presenter { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Identifier { get => tbIdentifier.Text; set => tbIdentifier.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string FacultyName { get => tbFacultyName.Text; set => tbFacultyName.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string City { get => tbCity.Text; set => tbCity.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string PostalCode { get => mtbPostalCode.Text; set => mtbPostalCode.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Street { get => tbStreet.Text; set => tbStreet.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Building { get => tbBuilding.Text; set => tbBuilding.Text = value; }

    public event EventHandler SubmitClicked;
    public event EventHandler CancelClicked;

    public ManageFacultyForm()
    {
        InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        OnSubmitClicked();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        OnCancelClicked();
    }

    private void OnSubmitClicked()
    {
        SubmitClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnCancelClicked()
    {
        CancelClicked?.Invoke(this, EventArgs.Empty);
    }

    public void SetErrors(IReadOnlyDictionary<string, string>? errors)
    {
        errorProvider.Clear();

        if (errors is null)
        {
            return;
        }

        foreach ((string key, string message) in errors)
        {
            SetError(key, message);
        }
    }

    private void SetError(string key, string message)
    {
        if (FindControl(key) is not { } control)
        {
            return;
        }
        errorProvider.SetError(control, message);
    }

    private Control? FindControl(string key)
    {
        return key switch
        {
            nameof(Faculty.Name) => tbFacultyName,
            nameof(Faculty.Address.City) => tbCity,
            nameof(Faculty.Address.PostalCode) => mtbPostalCode,
            nameof(Faculty.Address.Street) => tbStreet,
            nameof(Faculty.Address.Building) => tbBuilding,
            _ => null
        };
    }
}
