using Laboratory_20260412.Infrastructure.OpenWeatherMap;
using Laboratory_20260412.Presentation.Main;
using Microsoft.Extensions.Configuration;

namespace Laboratory_20260412;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

        IConfiguration configuration = GetConfiguration();

        OpenWeatherMapOptions openWeatherMapOptions = GetOpenWeatherMapOptions(configuration);

            MainForm view = new();
            MainPresenter presenter = new(view);

            view.Presenter = presenter;

            System.Windows.Forms.Application.Run(view);
        }

    private static IConfiguration GetConfiguration()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appconfig.json", optional: false);

        return builder.Build();
    }

    private static OpenWeatherMapOptions GetOpenWeatherMapOptions(IConfiguration configuration)
    {
        OpenWeatherMapOptions? options = configuration
            .GetSection(OpenWeatherMapOptions.Section)
            .Get<OpenWeatherMapOptions>();

        if (options is not null)
        {
            return options;
        }

        throw new ArgumentException($"Failed to read configuration for section {OpenWeatherMapOptions.Section}.");
    }
}