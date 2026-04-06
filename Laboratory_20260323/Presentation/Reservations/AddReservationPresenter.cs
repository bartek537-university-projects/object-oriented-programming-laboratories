using Laboratory_20260323.Presentation.Reservations.Interfaces;

namespace Laboratory_20260323.Presentation.Reservations;

public class AddReservationPresenter : IManageReservationPresenter
{
    private readonly IManageReservationView _view;

    public AddReservationPresenter(IManageReservationView view)
    {
        _view = view;
    }
}
