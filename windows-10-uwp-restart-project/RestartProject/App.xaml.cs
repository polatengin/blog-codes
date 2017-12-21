using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RestartProject
{
  sealed partial class App : Application
  {
    public App()
    {
      this.InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      Frame rootFrame = Window.Current.Content as Frame;

      if (rootFrame == null)
      {
        rootFrame = new Frame();

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
        }

        Window.Current.Content = rootFrame;
      }

      if (e.PrelaunchActivated == false)
      {
        if (rootFrame.Content == null)
        {
          rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        Window.Current.Activate();
      }
    }

    protected override void OnActivated(IActivatedEventArgs args)
    {
      if (args.Kind == ActivationKind.Launch)
      {
        var cityName = (args as LaunchActivatedEventArgs).Arguments;

        var rootFrame = Window.Current.Content as Frame;

        if (rootFrame == null)
        {
          rootFrame = new Frame();
          Window.Current.Content = rootFrame;
        }

        rootFrame.Navigate(typeof(MainPage), cityName);

        Window.Current.Activate();
      }
    }
  }
}