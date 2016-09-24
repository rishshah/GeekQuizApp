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



    public sealed partial class BlankPage1 : Page
    {

        int i;
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            i = 60;
            this.Frame.Navigate(typeof(BlankPage2), i);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            i = 45;
            this.Frame.Navigate(typeof(BlankPage2), i);
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.HowToPlay), null);
        }
    }
}
