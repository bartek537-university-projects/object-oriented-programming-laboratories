using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Employees;
using Laboratory_20260323.Presentation.Main;

namespace Laboratory_20260323.Presentation;

public class WindowService(
    IAddEmployeeHandler addEmployeeHandler,
    IGetEmployeesHandler getEmployeesHandler,
    IUpdateEmployeeHandler updateEmployeeHandler,
    IDeleteEmployeeHandler deleteEmployeeHandler)
    : IWindowService
{
    public Form CreateMainWindow()
    {
        MainForm form = new();
        MainPresenter presenter = new(form, this);
        form.Presenter = presenter;

        return form;
    }

    public void ShowMainWindow()
    {
        CreateMainWindow().Show();
    }

    public UserControl CreateEmployeeListFragment()
    {
        EmployeeListControl control = new();
        EmployeeListPresenter presenter = new(control, this,
            getEmployeesHandler, deleteEmployeeHandler);
        control.Presenter = presenter;

        return control;
    }

    public Form CreateAddEmployeeDialog()
    {
        ManageEmployeeForm form = new();
        AddEmployeePresenter presenter = new(form, addEmployeeHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowAddEmployeeDialog()
    {
        _ = CreateAddEmployeeDialog().ShowDialog();
    }

    public Form CreateEditEmployeeDialog(Employee employee)
    {
        ManageEmployeeForm form = new();
        EditEmployeePresenter presenter = new(employee, form, updateEmployeeHandler);
        form.Presenter = presenter;

        return form;
    }

    public void ShowEditEmployeeDialog(Employee employee)
    {
        _ = CreateEditEmployeeDialog(employee).ShowDialog();
    }
}
