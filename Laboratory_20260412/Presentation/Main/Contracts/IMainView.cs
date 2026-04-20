using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Presentation.Main.Contracts;

internal interface IMainView
{
    string SearchPhrase { get; set; }
    City? SelectedCity { get; set; }
    IReadOnlyList<City> SearchResults { set; }

    Forecast? Forecast { set; }

    event Action FormLoaded;

    event Action<string> SearchPhraseChanged;
    event Action<City> CitySelected;
}
