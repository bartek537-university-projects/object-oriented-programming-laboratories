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

    public void InflateTabs(IWindowService windows)
    {
        InflateEmployeeTab(windows);
        InflateFacultyTab(windows);
        InflateRoomTab(windows);
    }

    private static void InflateTab(TabPage tab, Control control)
    {
        control.Dock = DockStyle.Fill;
        tab.Controls.Add(control);
    }

    private void InflateEmployeeTab(IWindowService windows)
    {
        UserControl employeeFragment = windows.CreateEmployeeListFragment();
        InflateTab(tpEmployees, employeeFragment);
    }

    private void InflateFacultyTab(IWindowService windows)
    {
        UserControl facultyFragment = windows.CreateFacultyListFragment();
        InflateTab(tpFaculties, facultyFragment);
    }

    private void InflateRoomTab(IWindowService windows)
    {
        UserControl roomFragment = windows.CreateRoomListFragment();
        InflateTab(tpRooms, roomFragment);
    }
}
