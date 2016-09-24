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
    public sealed partial class Fast : Page
    {
        int s;
        public Fast()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            s = (int)e.Parameter;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if(s>400) textBlock.Text = "WOAH DUDE!!\n You are awesomely perfect.\n Your total score is " + s.ToString();
            else if (s > 100) textBlock.Text = "WOAH DUDE!!\n You were pretty fast.\n Your total score is " + s.ToString();
            else textBlock.Text = "OOPS!!\n You should have been more accurate .\n Your total score is " + s.ToString();
        }

        private void playagain_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
}
