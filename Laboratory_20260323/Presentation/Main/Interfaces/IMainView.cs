namespace Laboratory_20260323.Presentation.Main.Interfaces;

public interface IMainView
{
    event EventHandler<string> SaveToFileClicked;
    event EventHandler<string> LoadFromFileClicked;
    event EventHandler ExitClicked;

    void InflateTabs(IWindowService windows);
    void Close();
}
