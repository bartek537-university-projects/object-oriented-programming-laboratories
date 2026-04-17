using Laboratory_20260412.Presentation.Main;

namespace Laboratory_20260412
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            MainForm view = new();
            MainPresenter presenter = new(view);

            view.Presenter = presenter;

            System.Windows.Forms.Application.Run(view);
        }
    }
}