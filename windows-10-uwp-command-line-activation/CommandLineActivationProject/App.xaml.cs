using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CommandLineActivationProject
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
      if (args.Kind == ActivationKind.CommandLineLaunch)
      {
        var operation = (args as CommandLineActivatedEventArgs).Operation;
        var arguments = operation.Arguments;

        var rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
          rootFrame = new Frame();
          Window.Current.Content = rootFrame;
        }

        if (arguments.ToLower().Contains("about"))
        {
          rootFrame.Navigate(typeof(AboutPage));
        }
        else if (arguments.ToLower().Contains("help"))
        {
          rootFrame.Navigate(typeof(HelpPage));
        }
        else if (arguments.ToLower().Contains("message"))
        {
          rootFrame.Navigate(typeof(MessagePage), arguments.Substring(9).Trim());
        }
        else
        {
          rootFrame.Navigate(typeof(MainPage));
        }

        Window.Current.Activate();
      }
    }
  }
}
