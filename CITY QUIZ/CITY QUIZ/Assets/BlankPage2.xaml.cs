using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CITY_QUIZ.Assets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        int sw;
        public BlankPage2()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sw = (int)e.Parameter;
        }
        private void n_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.North), sw);
        }

        private void ne_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.NorthEast),sw );
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.East), sw);
        }

        private void w_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.West), sw);
        }

        private void s_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.South), sw);
        }
    }
}
