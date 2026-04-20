using Laboratory_20260412.Domain.Entities;
using Laboratory_20260412.Presentation.Main.Contracts;
using System.ComponentModel;
using System.Diagnostics;
using static Laboratory_20260412.Domain.Entities.WeatherConditions;

namespace Laboratory_20260412.Presentation.Main;

internal partial class MainForm : Form, IMainView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal IMainPresenter? Presenter { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Search { get => cbSearch.Text; set => cbSearch.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<City> Suggestions { set => SetSuggestions(value); }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public City? City { get => cbSearch.SelectedItem as City; set => SetCity(value); }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Forecast? Forecast { set => SetForecast(value); }

    public event Action? Loaded;
    public event Action? CitySelected;

    public MainForm()
    {
        InitializeComponent();

        cbSearch.DisplayMember = nameof(City.Name);
        llOpenWeatherMapAttribution.Links.Add(25, 11, "https://openweathermap.org/");

        SetCity(null);
        SetForecast(null);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Loaded?.Invoke();
    }

    private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
    {
        CitySelected?.Invoke();
    }

    private void SetSuggestions(IReadOnlyList<City> cities)
    {
        cbSearch.DataSource = null;
        cbSearch.DataSource = Sorted(cities, (a, b) => a.Name.CompareTo(b.Name));
    }

    private static List<T> Sorted<T>(IReadOnlyList<T> values, Comparison<T> comparison)
    {
        var list = values.ToList();
        list.Sort(comparison);
        return list;
    }

    private void SetCity(City? city)
    {
        Text = "Weather";

        if (city is not null)
        {
            var location = $"{city?.Name}, {city?.CountryCode}";
            Text = $"{location} Weather";
        }

        cbSearch.SelectedItem = city;
    }

    private void SetForecast(Forecast? forecast)
    {
        SetWeatherIcon(forecast?.Weather);
        SetTemperature(forecast?.Temperature);
        SetAtmospheric(forecast?.Atmospheric);
        SetWind(forecast?.Wind);
        SetRain(forecast?.Rain);
    }

    private void SetWeatherIcon(WeatherConditions? weather)
    {
        Bitmap? icon = GetWeatherIconForConditions(weather);
        picWeatherIcon.Image = icon;
    }

    private static Bitmap? GetWeatherIconForConditions(WeatherConditions? weather)
    {
        return weather switch
        {
            Thunderstorm => Properties.Resources.clear,
            Drizzle => Properties.Resources.shower_rain,
            Rain => Properties.Resources.rain,
            Snow => Properties.Resources.snow,
            Mist => Properties.Resources.mist,
            Clear => Properties.Resources.clear,
            Clouds => Properties.Resources.scattered_clouds,
            _ => null,
        };
    }

    private void SetTemperature(TemperatureConditions? temperature)
    {
        if (temperature is null)
        {
            lbCurrentTemperature.Text = "Unknown";
            lbTemperatureRange.Text = "↑ Unknown ↓ Unknown";
            return;
        }

        lbCurrentTemperature.Text = FormatTemperature(temperature.Current);
        lbTemperatureRange.Text = $"↑ {FormatTemperature(temperature.Minimum)} ↓ {FormatTemperature(temperature.Minimum)}";
    }

    private static string FormatTemperature(double temperature)
    {
        return $"{temperature:F1}°C";
    }

    private void SetAtmospheric(AtmosphericConditions? atmospheric)
    {
        if (atmospheric is null)
        {
            wHumidity.Text = "Unknown";
            wPressure.Text = "Unknown";
            return;
        }

        wHumidity.Text = $"{atmospheric.Humidity:F0}%";
        wPressure.Text = $"{atmospheric.Pressure:F0} hPa";
    }

    private void SetWind(WindConditions? wind)
    {
        if (wind is null)
        {
            wWind.Text = "Unknown";
            return;
        }

        var direction = GetWindDirectionForAngle(wind.Angle);
        wWind.Text = $"{wind.Speed} km/h {direction}";
    }

    private static string GetWindDirectionForAngle(double angle) => ((angle + 45.0 / 2) % 360) switch
    {
        < 45 => "N",
        < 90 => "NE",
        < 135 => "E",
        < 180 => "SE",
        < 225 => "S",
        < 270 => "SW",
        < 315 => "W",
        _ => "NW",
    };

    private void SetRain(RainConditions? rain)
    {
        if (rain is null)
        {
            wRain.Text = "Unknown";
            return;
        }

        wRain.Text = $"{rain.NextHour} mm/h";
    }

    private void llOpenWeatherMapAttribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (e.Link?.LinkData is string link)
        {
            OpenLink(link);
        }

    }

    private void OpenLink(string link)
    {
        var process = new ProcessStartInfo
        {
            FileName = link,
            UseShellExecute = true
        };

        Process.Start(process);
    }
}
