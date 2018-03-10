using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DomainAvailabilityChecker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var domainName = txtDomainName.Text;

            var client = new HttpClient();
            var json = await client.GetStringAsync("http://api.freedomainapi.com/?domain=" + domainName + "&r=taken&apikey={YOUR-API-KEY}");

            var result = JsonConvert.DeserializeObject<JObject>(json)["taken"].Value<int>();

            lblResult.Text = "Bu domain müsait" + (result == 1 ? " değil!" : "!");
        }
    }
}
