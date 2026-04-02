using Laboratory_20260323.Presentation.Main.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Main;

public partial class MainForm : Form, IMainView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IMainPresenter? Presenter { get; set; } = null;

    public event EventHandler? SaveToFileClicked;
    public event EventHandler? LoadFromFileClicked;
    public event EventHandler? ExitClicked;

    public MainForm()
    {
        InitializeComponent();
    }

    private void tsmiSaveToFile_Click(object sender, EventArgs e)
    {
        OnSaveToFileClicked();
    }

    private void tsmiLoadFromFile_Click(object sender, EventArgs e)
    {
        OnLoadFromFileClicked();
    }

    private void tsmiExit_Click(object sender, EventArgs e)
    {
        OnExitClicked();
    }

    private void OnSaveToFileClicked()
    {
        SaveToFileClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnLoadFromFileClicked()
    {
        LoadFromFileClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnExitClicked()
    {
        ExitClicked?.Invoke(this, EventArgs.Empty);
    }

    public void CreateTabs(IWindowService windows)
    {
        AddEmployeeTab(windows);
    }

    private void AddEmployeeTab(IWindowService windows)
    {
        UserControl employeeFragment = windows.CreateEmployeeListFragment();
        employeeFragment.Dock = DockStyle.Fill;

        tpEmployees.Controls.Add(employeeFragment);
    }
}
