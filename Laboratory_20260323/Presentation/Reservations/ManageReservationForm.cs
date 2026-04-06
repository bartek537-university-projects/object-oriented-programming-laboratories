using Laboratory_20260323.Presentation.Reservations.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Reservations;

public partial class ManageReservationForm : Form, IManageReservationView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IManageReservationPresenter? Presenter { get; set; }

    public ManageReservationForm()
    {
        InitializeComponent();
    }
}
