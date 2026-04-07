using Laboratory_20260323.Presentation.Main.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Main;

public partial class MainForm : Form, IMainView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IMainPresenter? Presenter { get; set; } = null;

    public event EventHandler<string>? SaveToFileClicked;
    public event EventHandler<string>? LoadFromFileClicked;
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
        if (sfdSaveState.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        SaveToFileClicked?.Invoke(this, sfdSaveState.FileName);
    }

    private void OnLoadFromFileClicked()
    {
        if (ofdLoadState.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        LoadFromFileClicked?.Invoke(this, ofdLoadState.FileName);
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
        InflateReservationsTab(windows);
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

    private void InflateReservationsTab(IWindowService windows)
    {
        UserControl reservationsFragment = windows.CreateReservationListFragment();
        InflateTab(tpReservations, reservationsFragment);
    }

    private static void InflateTab(TabPage tab, Control control)
    {
        tab.Controls.Clear();
        tab.Controls.Add(control);

        control.Dock = DockStyle.Fill;
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
