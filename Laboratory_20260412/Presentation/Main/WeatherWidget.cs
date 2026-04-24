using System.ComponentModel;

namespace Laboratory_20260412.Presentation.Main;

public partial class WeatherWidget : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Label { get => lbTitle.Text; set => lbTitle.Text = value; }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text { get => lbValue.Text; set => lbValue.Text = value; }

    public WeatherWidget()
    {
        InitializeComponent();
    }
}
