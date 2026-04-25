using Laboratory_20260412.Application.Queries;
using Laboratory_20260412.Infrastructure.OpenDataSoft;
using Laboratory_20260412.Infrastructure.OpenDataSoft.Mappers;
using Laboratory_20260412.Infrastructure.OpenWeatherMap;
using Laboratory_20260412.Infrastructure.OpenWeatherMap.Mappers;
using Laboratory_20260412.Presentation.Main;
using Microsoft.Extensions.Configuration;

namespace Laboratory_20260412;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        IConfiguration configuration = GetConfiguration("appconfig.json");
        OpenDataSoftOptions openDataSoftOptions = configuration.GetOptions<OpenDataSoftOptions>(OpenDataSoftOptions.Section);
        OpenWeatherMapOptions openWeatherMapOptions = configuration.GetOptions<OpenWeatherMapOptions>(OpenWeatherMapOptions.Section);

        HttpClient openDataSoftHttpClient = new() { BaseAddress = openDataSoftOptions.BaseUrl };
        HttpClient openWeatherMapHttpClient = new() { BaseAddress = openWeatherMapOptions.BaseUrl };

        GeonameResponseMapper geonameResponseMapper = new();
        CurrentWeatherResponseMapper currentWeatherResponseMapper = new();

        HttpOpenDataSoftGeonamesRepository geonamesRepository = new(openDataSoftHttpClient, geonameResponseMapper);
        HttpOpenWeatherMapForecastRepository forecastRepository = new(openWeatherMapHttpClient, openWeatherMapOptions, currentWeatherResponseMapper);

        GetLargestEuropeanCapitals.Handler getLargestEuropeanCapitalsHandler = new(geonamesRepository);
        GetCurrentWeather.Handler getCurrentWeatherHandler = new(forecastRepository);
        GetCitiesByName.Handler getCitiesByNameHandler = new(geonamesRepository);

        MainForm view = new();
        MainPresenter presenter = new(view, getLargestEuropeanCapitalsHandler, getCitiesByNameHandler, getCurrentWeatherHandler);

        view.Presenter = presenter;

        System.Windows.Forms.Application.Run(view);
    }

    private static IConfiguration GetConfiguration(string path)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(path, optional: false);

        return builder.Build();
    }

    private static T GetOptions<T>(this IConfiguration configuration, string section)
    {
        if (configuration.GetSection(section).Get<T>() is not { } options)
        {
            throw new ArgumentException($"Failed to read configuration for section {section}.");
        }
        return options;
    }
}