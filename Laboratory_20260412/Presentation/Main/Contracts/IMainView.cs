using Laboratory_20260412.Domain.Entities;

namespace Laboratory_20260412.Presentation.Main.Contracts;

internal interface IMainView
{
    string Search { get; set; }
    City? City { get; set; }
    IReadOnlyList<City> Suggestions { set; }

    Forecast? Forecast { set; }

    event Action Loaded;
    event Action CitySelected;
}
