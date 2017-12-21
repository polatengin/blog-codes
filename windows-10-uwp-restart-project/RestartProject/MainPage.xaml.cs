using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace RestartProject
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();

      this.lvCities.ItemsSource = new ObservableCollection<KeyValuePair<string, string>>()
      {
        new KeyValuePair<string, string>("İstanbul", "/Assets/istanbul.jpg"),
        new KeyValuePair<string, string>("İzmir", "/Assets/izmir.jpg"),
        new KeyValuePair<string, string>("Ankara", "/Assets/ankara.jpg"),
        new KeyValuePair<string, string>("Bursa", "/Assets/bursa.jpg")
      };
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      var cityName = e.Parameter as string;

      if (!string.IsNullOrEmpty(cityName))
      {
        this.selected = (this.lvCities.ItemsSource as ObservableCollection<KeyValuePair<string, string>>).FirstOrDefault(c => c.Key == cityName);

        this.lvCities.SelectedItem = this.selected;
        this.imgSelected.Source = new BitmapImage(new Uri("ms-appx://" + this.selected.Value));
      }
    }

    private KeyValuePair<string, string> selected;

    private void lvCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.selected = (KeyValuePair<string, string>)e.AddedItems[0];
      this.imgSelected.Source = new BitmapImage(new Uri("ms-appx://" + this.selected.Value));
    }

    private async void btnRestart_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      await CoreApplication.RequestRestartAsync(selected.Key ?? string.Empty);
    }
  }
}
