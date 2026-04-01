using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Presentation.EmployeeEdit;

namespace Laboratory_20260323;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        IAddEmployeeHandler addEmployeeHandler = new AddEmployee.Handler();

        EmployeeEditForm view = new();
        EmployeeAddPresenter presenter = new(view, addEmployeeHandler);

        view.Presenter = presenter;

        _ = view.ShowDialog(this);
    }
}
