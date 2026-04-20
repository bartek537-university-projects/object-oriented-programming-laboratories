using System.ComponentModel;

namespace Laboratory_20260412.Presentation.Main;

public partial class WeatherWidget : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Label { get => lbTitle.Text; set => lbTitle.Text = value; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Value { get => lbValue.Text; set => lbValue.Text = value; }

    public WeatherWidget()
    {
        InitializeComponent();
    }
}
