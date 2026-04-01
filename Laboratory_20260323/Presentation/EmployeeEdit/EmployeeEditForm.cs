using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.EmployeeEdit.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.EmployeeEdit;

public partial class EmployeeEditForm : Form, IEmployeeEditView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEmployeeEditPresenter? Presenter { get; set; } = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Identifier { set => tbIdentifier.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string FirstName { get => tbFirstName.Text; set => tbFirstName.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string LastName { get => tbLastName.Text; set => tbLastName.Text = value; }

    public event EventHandler? SubmitClicked;
    public event EventHandler? CancelClicked;

    public EmployeeEditForm()
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

        foreach (var (key, message) in errors)
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

    private TextBox? FindControl(string key)
    {
        return key switch
        {
            nameof(Employee.FirstName) => tbFirstName,
            nameof(Employee.LastName) => tbLastName,
            _ => null
        };
    }
}
