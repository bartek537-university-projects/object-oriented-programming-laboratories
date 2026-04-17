using Laboratory_20260412.Presentation.Main.Contracts;
using System.ComponentModel;

namespace Laboratory_20260412.Presentation.Main;

internal partial class MainForm : Form, IMainView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal IMainPresenter? Presenter { get; set; }

    public MainForm()
    {
        InitializeComponent();
    }
}
