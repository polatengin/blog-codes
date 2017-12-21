using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CommandLineActivationProject
{
  public sealed partial class MessagePage : Page
  {
    public MessagePage()
    {
      this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      this.lblMessage.Text = e.Parameter as string;
    }
  }
}
