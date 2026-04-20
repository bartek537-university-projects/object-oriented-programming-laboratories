using Laboratory_20260412.Application.Abstractions.Interfaces;
using Laboratory_20260412.Application.Queries;
using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Presentation.Main.Contracts;

namespace Laboratory_20260412.Presentation.Main;

internal class MainPresenter : IMainPresenter
{
    private readonly IMainView _view;
    private readonly IRequestHandler<GetLargestEuropeanCapitals.Query, GetLargestEuropeanCapitals.Response> _getLargestEuropeanCapitalsHandler;
    private readonly IRequestHandler<GetCurrentWeather.Query, GetCurrentWeather.Response> _getCurrentWeatherHandler;

    public MainPresenter(IMainView view,
        IRequestHandler<GetLargestEuropeanCapitals.Query, GetLargestEuropeanCapitals.Response> getLargestEuropeanCapitalsHandler,
        IRequestHandler<GetCurrentWeather.Query, GetCurrentWeather.Response> getCurrentWeatherHandler
    )
    {
        _view = view;
        _getLargestEuropeanCapitalsHandler = getLargestEuropeanCapitalsHandler;
        _getCurrentWeatherHandler = getCurrentWeatherHandler;

        _view.Loaded += OnFormLoaded;
        _view.CitySelected += OnCitySelected;
    }

    private async void OnFormLoaded()
    {
        _view.Suggestions = await GetCapitals();
        OnCitySelected();
    }

    private async Task<IReadOnlyList<City>> GetCapitals()
    {
        GetLargestEuropeanCapitals.Response capitals = await _getLargestEuropeanCapitalsHandler.HandleAsync(new());
        return capitals.Cities;
    }

    private async void OnCitySelected()
    {
        _view.Forecast = null;

        if (_view.City is not { } city)
        {
            return;
        }

        GetCurrentWeather.Response weather = await _getCurrentWeatherHandler.HandleAsync(new(city.Location));

        if (weather?.Forecast is not { } forecast)
        {
            return;
        }

        _view.City = city;
        _view.Forecast = forecast;
    }
}
