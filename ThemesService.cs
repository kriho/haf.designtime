using HAF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;

namespace HAF.DesignTime {

  [Export(typeof(IThemesService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class ThemesService : Service, IThemesService {

    public ServiceDependency CanChangeTheme { get; private set; } = new ServiceDependency();

    public ServiceEvent OnActiveThemeChanged { get; private set; } = new ServiceEvent();

    public ObservableCollection<Theme> AvailableThemes { get; private set; } = new ObservableCollection<Theme>() {
      new Theme() {
        Name = "Light",
        AccentColor = (Color)ColorConverter.ConvertFromString("#FF0B70BB"),
        MainColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
        BasicColor = (Color)ColorConverter.ConvertFromString("#FFDFDFDF"),
        StrongColor = (Color)ColorConverter.ConvertFromString("#FF7E7E7E"),
        MarkerColor = (Color)ColorConverter.ConvertFromString("#FF000000"),
      },
      new Theme() {
        Name = "Dark",
        AccentColor = (Color)ColorConverter.ConvertFromString("#FFB6C8F7"),
        MainColor = (Color)ColorConverter.ConvertFromString("#FF1E1E1E"),
        BasicColor = (Color)ColorConverter.ConvertFromString("#FF535353"),
        StrongColor = (Color)ColorConverter.ConvertFromString("#FFC0C0C0"),
        MarkerColor = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"),
      }
    };

    public Theme ActiveTheme { get; set; }

    public Color AccentColor {
      get { return this.ActiveTheme.AccentColor; }
    }

    public Color MainColor {
      get { return this.ActiveTheme.MainColor; }
    }

    public Color BasicColor {
      get { return this.ActiveTheme.BasicColor; }
    }

    public Color StrongColor {
      get { return this.ActiveTheme.StrongColor; }
    }

    public Color MarkerColor {
      get { return this.ActiveTheme.MarkerColor; }
    }

    public RelayCommand<Theme> _SetTheme { get; private set; }

    public ThemesService() {
      this.ActiveTheme = this.AvailableThemes.FirstOrDefault();
    }
  }
}
