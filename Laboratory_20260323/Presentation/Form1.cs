using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Presentation.EmployeeEdit;

namespace Laboratory_20260323;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        IValidator<IEmployeeData> employeeDataValidator = new EmployeeDataValidator();
        IEmployeeRepository employeeRepository = null!;

        IAddEmployeeHandler addEmployeeHandler = new AddEmployee.Handler(employeeDataValidator, employeeRepository);

        EmployeeEditForm view = new();
        EmployeeAddPresenter presenter = new(view, addEmployeeHandler);

        view.Presenter = presenter;

        _ = view.ShowDialog(this);
    }
}
