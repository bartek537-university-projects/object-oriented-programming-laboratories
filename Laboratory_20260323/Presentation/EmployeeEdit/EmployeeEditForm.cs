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
}
