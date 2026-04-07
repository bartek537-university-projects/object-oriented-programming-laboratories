using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Employees;

public partial class EmployeeListControl : UserControl, IEmployeeListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEmployeeListPresenter? Presenter { get; set; } = null;

    public event EventHandler? AddEmployeeClicked;
    public event EventHandler<Employee>? EditEmployeeClicked;
    public event EventHandler<Employee>? RemoveEmployeeClicked;

    public EmployeeListControl()
    {
        InitializeComponent();

        mlcEmployees.AddColumn("First name", nameof(Employee.FirstName));
        mlcEmployees.AddColumn("Last name", nameof(Employee.LastName));

        mlcEmployees.AddClicked += OnAddEmployeeClicked;
        mlcEmployees.EditClicked += OnEditEmployeeClicked;
        mlcEmployees.RemoveClicked += OnRemoveEmployeeClicked;
    }

    private void OnAddEmployeeClicked(object? sender, EventArgs e)
    {
        AddEmployeeClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditEmployeeClicked(object? sender, object item)
    {
        if (item is Employee employee)
        {
            EditEmployeeClicked?.Invoke(this, employee);
        }
    }

    private void OnRemoveEmployeeClicked(object? sender, object item)
    {
        if (item is Employee employee)
        {
            RemoveEmployeeClicked?.Invoke(this, employee);
        }
    }

    public void SetEmployees(IReadOnlyList<Employee> employees)
    {
        mlcEmployees.DataSource = employees;
    }

    public void ShowError(string message)
    {
        _ = MessageBox.Show(this, message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
