using Laboratory_20260323.Presentation.Main.Interfaces;

namespace Laboratory_20260323.Presentation.Main;

public class MainPresenter : IMainPresenter
{
    private readonly IMainView _view;
    private readonly IWindowService _windowService;

    public MainPresenter(IMainView view, IWindowService windowService)
    {
        _view = view;
        _windowService = windowService;

        _view.InflateTabs(_windowService);

        _view.ExitClicked += OnExitClicked;
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }
}
