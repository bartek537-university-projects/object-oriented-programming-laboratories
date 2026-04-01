using Laboratory_20260323.Presentation.EmployeeEdit;

namespace Laboratory_20260323;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        EmployeeEditForm view = new();
        EmployeeEditPresenter presenter = new(view);

        view.Presenter = presenter;

        _ = view.ShowDialog(this);
    }
}
