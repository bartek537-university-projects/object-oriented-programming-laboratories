using Laboratory_20260323.Presentation.Reservations.Interfaces;

namespace Laboratory_20260323.Presentation.Reservations;

public class EditReservationPresenter : IManageReservationPresenter
{
    private readonly IManageReservationView _view;

    public EditReservationPresenter(IManageReservationView view)
    {
        _view = view;
    }
}
