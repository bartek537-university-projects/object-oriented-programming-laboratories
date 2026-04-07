using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Persistence;
using Laboratory_20260323.Presentation.Main.Interfaces;

namespace Laboratory_20260323.Presentation.Main;

public class MainPresenter : IMainPresenter
{
    private readonly IMainView _view;
    private readonly IWindowService _windows;

    private readonly IRequestHandler<SaveToFile.Command, SaveToFile.Response> _saveToFileHandler;
    private readonly IRequestHandler<LoadFromFile.Command, LoadFromFile.Response> _loadFromFileHandler;

    public MainPresenter(IMainView view, IWindowService windows,
        IRequestHandler<SaveToFile.Command, SaveToFile.Response> saveToFileHandler,
        IRequestHandler<LoadFromFile.Command, LoadFromFile.Response> loadFromFileHandler)
    {
        _view = view;
        _windows = windows;

        _saveToFileHandler = saveToFileHandler;
        _loadFromFileHandler = loadFromFileHandler;
        _view.InflateTabs(_windows);

        _view.SaveToFileClicked += OnSaveToFileClicked;
        _view.LoadFromFileClicked += OnLoadFromFileClicked;
        _view.ExitClicked += OnExitClicked;
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        _view.Close();
    }

    private void OnSaveToFileClicked(object? sender, string path)
    {
        _ = _saveToFileHandler.Handle(new(path));
    }

    private void OnLoadFromFileClicked(object? sender, string path)
    {
        _ = _loadFromFileHandler.Handle(new(path));
        _view.InflateTabs(_windows);
    }
}
