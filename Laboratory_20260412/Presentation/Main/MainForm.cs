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
    public string SearchPhrase { get => cbSearch.Text; set => cbSearch.Text = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public City? SelectedCity { get => cbSearch.SelectedItem as City; set => UpdateSelectedCity(value); }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<City> SearchResults { set => UpdateSearchResults(value); }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Forecast? Forecast { set => SetForecast(value); }

    public event Action? FormLoaded;

    public event Action<string>? SearchPhraseChanged;
    public event Action<City>? CitySelected;

    public MainForm()
    {
        InitializeComponent();
    }

    private void OnFormLoaded()
    {
        FormLoaded?.Invoke();
    }

    private void UpdateSelectedCity(City? city)
    {
        timSearchDebounce.Stop();
        cbSearch.SelectedItem = city;
        Text = city is null ? "Weather" : $"{city.Name} Weather";
    }

    private void UpdateSearchResults(IReadOnlyList<City> cities)
    {
        string query = cbSearch.Text;
        int selectionStart = cbSearch.SelectionStart;
        int selectionLength = cbSearch.SelectionLength;

        cbSearch.DataSource = null;
        cbSearch.DataSource = cities;

        // Prevent overwriting user input and collapsing suggestion list
        // when updating cbSearch.DataSource.
        if (!string.IsNullOrWhiteSpace(query))
        {
            cbSearch.Text = query;
            cbSearch.DroppedDown = true;
        }

        cbSearch.SelectionStart = selectionStart;
        cbSearch.SelectionLength = selectionLength;
    }

    private void OnSearchPhraseChanged()
    {
        timSearchDebounce.Stop();
        timSearchDebounce.Start();
    }

    private void OnSearchDebounceFired()
    {
        timSearchDebounce.Stop();

        string query = cbSearch.Text;
        SearchPhraseChanged?.Invoke(query);
    }

    private void OnSearchResultSelected()
    {
        if (cbSearch.SelectedItem is City city)
        {
            CitySelected?.Invoke(city);
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        OnFormLoaded();
    }
    private void cbSearch_TextUpdate(object sender, EventArgs e)
    {
        OnSearchPhraseChanged();
    }

    private void timSearchDebounce_Tick(object sender, EventArgs e)
    {
        OnSearchDebounceFired();
    }

    private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
    {
        OnSearchResultSelected();
    }

    private void cbSearch_Format(object sender, ListControlConvertEventArgs e)
    {
        if (e.ListItem is not City city)
        {
            return;
        }

        Geolocation location = city.Location;
        e.Value = $"{city.Name}, {city.CountryCode} ({location.Latitude}, {location.Longitude})";
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
        lbTemperatureRange.Text = $"↑ {FormatTemperature(temperature.Minimum)} ↓ {FormatTemperature(temperature.Maximum)}";
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

        string direction = GetWindDirectionForAngle(wind.Angle);
        wWind.Text = $"{wind.Speed} km/h {direction}";
    }

    private static string GetWindDirectionForAngle(double angle)
    {
        return ((angle + (45.0 / 2)) % 360) switch
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
    }

    private void SetRain(RainConditions? rain)
    {
        if (rain is null)
        {
            wRain.Text = "Unknown";
            return;
        }

        wRain.Text = $"{rain.NextHour} mm/h";
    }

    private static void OpenLink(string link)
    {
        ProcessStartInfo process = new()
        {
            FileName = link,
            UseShellExecute = true
        };

        _ = Process.Start(process);
    }

    private void llOpenWeatherMapAttribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (e.Link?.LinkData is string link)
        {
            OpenLink(link);
        }
    }
}
