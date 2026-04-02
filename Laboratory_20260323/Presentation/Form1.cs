using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Infrastructure.Repositories;
using Laboratory_20260323.Presentation.Employees;

namespace Laboratory_20260323;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private readonly IEmployeeRepository employeeRepository = new InMemoryEmployeeRepository();

    private void button1_Click(object sender, EventArgs e)
    {
        // Add

        IValidator<IEmployeeData> employeeDataValidator = new EmployeeDataValidator();

        IAddEmployeeHandler addEmployeeHandler = new AddEmployee.Handler(employeeDataValidator, employeeRepository);

        ManageEmployeeForm view = new();
        AddEmployeePresenter presenter = new(view, addEmployeeHandler);

        view.Presenter = presenter;

        _ = view.ShowDialog(this);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        // Edit

        IValidator<IEmployeeData> employeeDataValidator = new EmployeeDataValidator();

        if (listBox1.SelectedItem is not Employee selectedEmployee)
        {
            return;
        }

        IUpdateEmployeeHandler addEmployeeHandler = new UpdateEmployee.Handler(employeeDataValidator, employeeRepository);

        ManageEmployeeForm view = new();
        EditEmployeePresenter presenter = new(selectedEmployee, view, addEmployeeHandler);

        view.Presenter = presenter;

        _ = view.ShowDialog(this);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        // Remove

        IDeleteEmployeeHandler deleteEmployeeHandler = new DeleteEmployee.Handler(employeeRepository);

        Employee? selectedEmployee = listBox1.SelectedItem as Employee;

        if (selectedEmployee is not null)
        {
            Guid id = selectedEmployee.Id;
            _ = deleteEmployeeHandler.Handle(new DeleteEmployee.Command(id));
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        // Refresh

        listBox1.DataSource = employeeRepository.GetAll().ToList();
    }
}
