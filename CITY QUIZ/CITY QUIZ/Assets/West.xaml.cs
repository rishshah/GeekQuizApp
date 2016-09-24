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
        class wbase
        {

            public string question;
            public string[] options = new string[4];
            public string answer;
            public bool played_once = false;
            public wbase(string q, string o1, string o2, string o3, string o4)
            {
                question = q;
                options[0] = o1;
                options[1] = o2;
                options[2] = o3;
                options[3] = o4;
                answer = o4;
            }
        }
        public sealed partial class West : Page
        {
            static int i = 0;
            wbase[] wdata = new wbase[23];
            public West()
            {
                this.InitializeComponent();
                wdata[0] = new wbase("The capital of Goa is ?", "Calangute ", "Vasco Da Gama ","Mormugao ","Panaji");
                wdata[1] = new wbase("North Goa's largest beach is located in ?", "Panaji", "Mormugao", "Vasco Da Gama", "Calangute");
                wdata[2] = new wbase("Goa's oldest church is ?", "Church of St. Francis Assisi", "Immaculate Conception Church", "St. Jerome's Church", "Basilica of Bom Jesus");
                wdata[3] = new wbase("Panaji means ?", " Land of Foreigners", " Land of beaches", " Land of Coconuts", "Land that never floods");
                wdata[4] = new wbase("Silavassa is the capital of ?", "Daman & Diu", "Vishakhapatnam", "Chandigarh", "Dadra and Nagar Haveli");
                wdata[5] = new wbase("Which union territory has twin towns in Portugal ?", "Dadra and Nagar Haveli", "Chandigarh", "Vishakhapatnam", "Daman and Diu");
                wdata[6] = new wbase("Which is the largest park in Asia?", "Tum Tum Park", "Sonali Park", "Central Avenue,Hiranandani", "Central Park,Khargar");
                wdata[7] = new wbase("Which city has comercial and defence airport operating from same strip?", "Mumbai", "Thriuvanathpuram", "Bangalore", "Pune");
                wdata[8] = new wbase("India's first textile mill was started at ?", "Pune", "Mumbai", "Surat", "Nagpur");
                wdata[9] = new wbase("Taj mahal of south ?", "Taj mahal hotel,Mumbai", "Taj mahal hotel,Hyderabad", "Mysore palace", "Bibi ka Maqbara");
                wdata[10] = new wbase("India's largest theme park?", " Essel World ", "  Crystal World ", "  Magic City ", "  Adlabs Imagica ");
                wdata[11] = new wbase("Which city has highest no of two wheelers vehicles in the world?", "  Bangalore ", " Chennai ", " Hyderabad ", " Pune ");
                wdata[12] = new wbase("Who inaugurated empress mill ?", " Queen Of Jhansi ", " Jodha bai ", " Queen Elizabeth ", " Queen Victoria ");
                wdata[13] = new wbase("Bibi Ka Maqbara was built in year ?", "1888", "20B.C", "1900", "1678");
                wdata[14] = new wbase("Name the caves near mumbai? ", " Ajanta ", " Ellora ", " Badami  ", "Elephanta");
                wdata[15] = new wbase("Bibi ka Maqbara was built by ?", "Shah Jahan", "Aurangzeb", "Bahadus Shah Jafar", "Azam Shah");
                wdata[16] = new wbase("City of lakes?", "Madurai", "Pudducherri", "Damann Diu", "Bhopal");
                wdata[17] = new wbase("Food capital of india?", "Punjab", "Delhi", "Bhopal", "Indore");
                wdata[18] = new wbase("Worlds worst industrial tragedy was occured in year:","1960","1982","1993","1984");
                wdata[19] = new wbase("Which city is india's largest manufacturer of edible oil ?", "Bhopal", "Panji", "Surat", "Indore");
                wdata[20] = new wbase("Taj Ul Masjid is situated in which city?", "Indore", "Ujjain", "Ratlam", "Bhopal");
                wdata[21] = new wbase("Pink City ?", "Ahmedabad", "Aurangabad", "Udaipur", "Jaipur" );
                wdata[22] = new wbase("Which Version of Maharaja Sawai Jai Singh founded Jaipur?", "Maharaja Sawai Jai Singh III", "Maharaja Sawai Jai Singh IV", "Maharaja Sawai Jai Singh I", "Maharaja Sawai Jai Singh II");
                extend();
                display(wdata);
            }
            int s;
            DispatcherTimer dt = new DispatcherTimer();
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                s = (int)e.Parameter;
            }
            private void extend()
            {
                dt.Interval = new TimeSpan(0, 0, 1);
                dt.Tick += dt_Tick;
                dt.Start();

            }
            void dt_Tick(object sender, object e)
            {
                wtimer.Text = "" + --s;
                if (s <= -1)
                {
                    dt.Stop();
                    wo1.Visibility = Visibility.Collapsed;
                    wo2.Visibility = Visibility.Collapsed;
                    wo3.Visibility = Visibility.Collapsed;
                    wo4.Visibility = Visibility.Collapsed;
                    wbutt1.Visibility = Visibility.Collapsed;
                    wbutt2.Visibility = Visibility.Collapsed;
                    wbutt3.Visibility = Visibility.Collapsed;
                    wbutt4.Visibility = Visibility.Collapsed;
                    wtimer.Visibility = Visibility.Collapsed;
                    score.Visibility = Visibility.Collapsed;
                    wquestion.FontSize = 90;
                    wquestion.Text = "GAME OVER\n Your Final Score is  " + sco;
                }
            }
            static Random r = new Random();
            int x = r.Next(0, 23);
            int sco = 0;
            void display(wbase[] wdata)
            {
                i++;
                while (wdata[x].played_once)
                {
                    x = r.Next(0, 23);
                    if (i >= 11)
                    {
                        i = 0;
                        this.Frame.Navigate(typeof(Assets.Fast), sco);
                    }
                }
                wdata[x].played_once = true;
                wquestion.Text = wdata[x].question;
                int a1, a2, a3, a4;
                Random rng = new Random();
                a1 = Genran(rng);
                wo1.Text = wdata[x].options[a1];
                a2 = Genran(rng);
                while (a2 == a1) a2 = Genran(rng);
                wo2.Text = wdata[x].options[a2];
                a3 = Genran(rng);
                while (a3 == a1 || a3 == a2) a3 = Genran(rng);
                wo3.Text = wdata[x].options[a3];
                a4 = 6 - a1 - a2 - a3;
                wo4.Text = wdata[x].options[a4];
                score.Text = sco.ToString();

            }
            static int Genran(Random rng)
            {
                return rng.Next(4);
            }

            private void wbutt1_Click(object sender, RoutedEventArgs e)
            {
            if (wo1.Text == wdata[x].answer)
            {
                sco += 100;
                //wbutt1.Background=s
            }
            else sco -= 50;
                display(wdata);
            }
            private void wbutt2_Click(object sender, RoutedEventArgs e)
            {
                if (wo2.Text == wdata[x].answer) sco += 100;
                else sco -= 50;
                display(wdata);
            }
            private void wbutt3_Click(object sender, RoutedEventArgs e)
            {
                if (wo3.Text == wdata[x].answer) sco += 100;
                else sco -= 50;
                display(wdata);
            }
            private void wbutt4_Click_1(object sender, RoutedEventArgs e)
            {
                if (wo4.Text == wdata[x].answer) sco += 100;
                else sco -= 50;
                display(wdata);
            }

        private void wreplay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 23; i++)
            {
                wdata[i].played_once = false;
            }
            i = 0;
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
    }

