using HAF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;

namespace HAF.DesignTime {

  [Export(typeof(IThemesService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class ThemesService : Service, IThemesService {

    public LinkedDependency MayChangeTheme { get; private set; } = new LinkedDependency();

    public LinkedEvent OnActiveThemeChanged { get; private set; } = new LinkedEvent(nameof(OnActiveThemeChanged));

    public IObservableCollection<Theme> AvailableThemes { get; private set; } = new ObservableCollection<Theme>() {
      new Theme() {
        Name = "Light",
        AccentColor = (Color)ColorConverter.ConvertFromString("#FF0B70BB"),
        BackgroundColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
        LightColor = (Color)ColorConverter.ConvertFromString("#FFDFDFDF"),
        StrongColor = (Color)ColorConverter.ConvertFromString("#FF7E7E7E"),
        TextColor = (Color)ColorConverter.ConvertFromString("#FF000000"),
      },
      new Theme() {
        Name = "Dark",
        AccentColor = (Color)ColorConverter.ConvertFromString("#FFB6C8F7"),
        BackgroundColor = (Color)ColorConverter.ConvertFromString("#FF1E1E1E"),
        LightColor = (Color)ColorConverter.ConvertFromString("#FF535353"),
        StrongColor = (Color)ColorConverter.ConvertFromString("#FFC0C0C0"),
        TextColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
      }
    };

    public Theme ActiveTheme { get; set; }

    public RelayCommand<Theme> DoSetTheme { get; private set; }

    public Color BackgroundColor {
      get => this.ActiveTheme.BackgroundColor;
    }

    public Brush BackgroundBrush {
      get => new SolidColorBrush(this.ActiveTheme.BackgroundColor);
    }

    public Color TextColor {
      get => this.ActiveTheme.TextColor;
    }

    public Brush TextBrush {
      get => new SolidColorBrush(this.ActiveTheme.TextColor);
    }

    public Color AccentColor {
      get => this.ActiveTheme.AccentColor;
    }
    public Brush AccentBrush {
      get => new SolidColorBrush(this.ActiveTheme.AccentColor);
    }

    public Color LightColor {
      get => this.ActiveTheme.LightColor;
    }

    public Brush LightBrush {
      get => new SolidColorBrush(this.ActiveTheme.LightColor);
    }

    public Color StrongColor {
      get => this.ActiveTheme.StrongColor;
    }

    public Brush StrongBrush {
      get => new SolidColorBrush(this.ActiveTheme.StrongColor);
    }

    public Color InfoColor {
      get => this.ActiveTheme.InfoColor;
    }

    public Brush InfoBrush {
      get => new SolidColorBrush(this.ActiveTheme.InfoColor);
    }

    public Color WarningColor {
      get => this.ActiveTheme.WarningColor;
    }

    public Brush WarningBrush {
      get => new SolidColorBrush(this.ActiveTheme.WarningColor);
    }

    public Color ErrorColor {
      get => this.ActiveTheme.ErrorColor;
    }

    public Brush ErrorBrush {
      get => new SolidColorBrush(this.ActiveTheme.ErrorColor);
    }

    public ThemesService() {
      this.ActiveTheme = this.AvailableThemes.FirstOrDefault();
    }

    public Theme DefaultLightTheme { get; private set; } = new Theme() {
      Name = "Light",
      AccentColor = (Color)ColorConverter.ConvertFromString("#FF0B70BB"),
      BackgroundColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
      LightColor = (Color)ColorConverter.ConvertFromString("#FFDFDFDF"),
      StrongColor = (Color)ColorConverter.ConvertFromString("#FF7E7E7E"),
      TextColor = (Color)ColorConverter.ConvertFromString("#FF000000"),
      InfoColor = (Color)ColorConverter.ConvertFromString("#FFD3EBFC"),
      WarningColor = (Color)ColorConverter.ConvertFromString("#FFFFFAC3"),
      ErrorColor = (Color)ColorConverter.ConvertFromString("#FFFFD2D2"),
    };

    public Theme DefaultDarkTheme { get; private set; } = new Theme() {
      Name = "Dark",
      AccentColor = (Color)ColorConverter.ConvertFromString("#FFB6C8F7"),
      BackgroundColor = (Color)ColorConverter.ConvertFromString("#FF1E1E1E"),
      LightColor = (Color)ColorConverter.ConvertFromString("#FF535353"),
      StrongColor = (Color)ColorConverter.ConvertFromString("#FFC0C0C0"),
      TextColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
      InfoColor = (Color)ColorConverter.ConvertFromString("#FF49555E"),
      WarningColor = (Color)ColorConverter.ConvertFromString("#FF7D7840"),
      ErrorColor = (Color)ColorConverter.ConvertFromString("#FF901818"),
    };

    public Color GetColor(ThemeKey key) {
      switch (key) {
        case ThemeKey.Accent: return this.AccentColor;
        case ThemeKey.Background: return this.BackgroundColor;
        case ThemeKey.Light: return this.LightColor;
        case ThemeKey.Strong: return this.StrongColor;
        case ThemeKey.Warning: return this.WarningColor;
        case ThemeKey.Info: return this.InfoColor;
        case ThemeKey.Error: return this.ErrorColor;
        default: return this.TextColor;
      }
    }

    public Brush GetBrush(ThemeKey key) {
      switch (key) {
        case ThemeKey.Accent: return this.AccentBrush;
        case ThemeKey.Background: return this.BackgroundBrush;
        case ThemeKey.Light: return this.LightBrush;
        case ThemeKey.Strong: return this.StrongBrush;
        case ThemeKey.Warning: return this.WarningBrush;
        case ThemeKey.Info: return this.InfoBrush;
        case ThemeKey.Error: return this.ErrorBrush;
        default: return this.TextBrush;
      }
    }
  }
}
