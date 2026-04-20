using Laboratory_20260412.Application.Abstractions.Interfaces;
using Laboratory_20260412.Application.Queries;
using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Presentation.Main.Contracts;

namespace Laboratory_20260412.Presentation.Main;

internal class MainPresenter : IMainPresenter
{
    private readonly IMainView _view;
    private readonly IRequestHandler<GetLargestEuropeanCapitals.Query, GetLargestEuropeanCapitals.Response> _getLargestEuropeanCapitalsHandler;
    private readonly IRequestHandler<SearchCities.Query, SearchCities.Response> _searchCitiesHandler;
    private readonly IRequestHandler<GetCurrentWeather.Query, GetCurrentWeather.Response> _getCurrentWeatherHandler;

    public MainPresenter(IMainView view,
        IRequestHandler<GetLargestEuropeanCapitals.Query, GetLargestEuropeanCapitals.Response> getLargestEuropeanCapitalsHandler,
        IRequestHandler<SearchCities.Query, SearchCities.Response> searchCitiesHandler,
        IRequestHandler<GetCurrentWeather.Query, GetCurrentWeather.Response> getCurrentWeatherHandler
    )
    {
        _view = view;

        _getLargestEuropeanCapitalsHandler = getLargestEuropeanCapitalsHandler;
        _searchCitiesHandler = searchCitiesHandler;
        _getCurrentWeatherHandler = getCurrentWeatherHandler;

        _view.FormLoaded += OnFormLoaded;
        _view.SearchPhraseChanged += OnSearchPhraseChanged;
        _view.CitySelected += OnCitySelected;

        _view.Forecast = null;
    }

    private async void OnFormLoaded()
    {
        if (await GetCapitalsAsync() is not { Count: > 0 } results)
        {
            return;
        }

        _view.SearchResults = results;
        OnCitySelected(results[0]);
    }

    private async Task<IReadOnlyList<City>> GetCapitalsAsync()
    {
        return (await _getLargestEuropeanCapitalsHandler.HandleAsync(new())).Cities;
    }

    private async void OnSearchPhraseChanged(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            _view.SearchResults = await GetCapitalsAsync();
            return;
        }

        query = query.TrimStart();
        _view.SearchResults = await SearchCitiesAsync(query);
    }

    private async Task<IReadOnlyList<City>> SearchCitiesAsync(string query)
    {
        return (await _searchCitiesHandler.HandleAsync(new(query))).Cities;
    }

    private async void OnCitySelected(City city)
    {
        _view.Forecast = null;
        _view.SelectedCity = city;

        if (await GetCurrentWeatherAsync(city) is not { } forecast)
        {
            return;
        }

        _view.Forecast = forecast;
    }

    private async Task<Forecast?> GetCurrentWeatherAsync(City city)
    {
        return (await _getCurrentWeatherHandler.HandleAsync(new(city.Location))).Forecast;
    }
}
