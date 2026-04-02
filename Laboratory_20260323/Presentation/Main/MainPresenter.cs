using Laboratory_20260323.Presentation.Main.Interfaces;

namespace Laboratory_20260323.Presentation.Main;

public class MainPresenter : IMainPresenter
{
    private readonly IMainView _view;

    public MainPresenter(IMainView view)
    {
        _view = view;

        _view.ExitClicked += OnExitClicked;
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
