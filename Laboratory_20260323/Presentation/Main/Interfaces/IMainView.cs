namespace Laboratory_20260323.Presentation.Main.Interfaces;

public interface IMainView
{
    event EventHandler SaveToFileClicked;
    event EventHandler LoadFromFileClicked;
    event EventHandler ExitClicked;

    void Close();
}
