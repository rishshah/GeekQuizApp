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
    class ebase
    {
        public string question;
        public string[] options = new string[4];
        public string answer;
        public bool played_once = false;
        public ebase(string q, string o1, string o2, string o3, string o4)
        {
            question = q;
            options[0] = o1;
            options[1] = o2;
            options[2] = o3;
            options[3] = o4;
            answer = o4;
        }
    }
    public sealed partial class East : Page
    {
        static int i = 0;
        ebase[] sdata = new ebase[21];
        public East()
        {
            this.InitializeComponent();
            sdata[0] = new ebase("Capital of Odhisa ? ", "Ranchi ", "Jodhpur ", "Cuttack ", "bhubaneshwar");
            sdata[1] = new ebase("City of temple ? ", "Haridwar ", "Mathura", " Puri", " Bhubaneshwar");
            sdata[2] = new ebase(" Deraaj water reservoir is situated in which city ? ", "Cuttack", " Hyderabad ", "Puri ", "Bhubaneshwar");
            sdata[3] = new ebase("Jagannath Temple is situated in ? ", "Dehradun ", "Mathura ", "Shirdi", " Puri");
            sdata[4] = new ebase("Steel city of india ?", " Mumbai ", "Surat", " Muzzafanagar", " Jamshedpur");
            sdata[5] = new ebase("Priyanka chopra was born in which city? ", " Jabalpur ", "Jaipur", " Agra ", "Jamshedpur ");
            sdata[6] = new ebase("R.Madhvan was Bor in which city ? ", "Jabalpur ", "Jaipur ", "Agra", " Jamshedpur");
            sdata[7] = new ebase("River flowing through Dhanbad ?", " Ganga", " Satluj", " Chambal", " Damodar");
            sdata[8] = new ebase("Maithon dam is located in ? ", "Amritsar", " Puri", " Chembur", " Dhanbad");
            sdata[9] = new ebase("Hometown of famous cricketer MS Dhoni ?", " Hyderabad", " Dhanbad", " Capetown", " Ranchi");
            sdata[10] = new ebase("Mother land of Birsa Munda? ", " Jhansi", " Marwara ", "Maharahtra ", "Ranchi");
            sdata[11] = new ebase("Which of these City is situated at highest alltitude above sea level?", " Roorkee ", "Haridwar", " Mumbai", " Ranchi");
            sdata[12] = new ebase("After independence which of these city became a part of barar and central provinces?", "Chembur", "Vasco da Gama", " Calangute", " Raipur");
            sdata[13] = new ebase("National park in Raipur ?", "Corbett", " Rajaji", " Kanha", " Indravati");
            sdata[14] = new ebase("Main River of Bhilai District?", " Godavari", " Kaveri", " Mahanadi", "Sheonath River");
            sdata[15] = new ebase("City famous for its'Doobraj Rice'?", "Raipur", "Panipat", " Durg", "Bilaspur");
            sdata[16] = new ebase("City famous for 'Koosa Silk saree' ? ", "  Chandigarh", " Surat", " Mumbai ", "Bilaspur");
            sdata[17] = new ebase("Mahananda National Park is situated in ?", "Darjelling", "Kolkata", "Mizzoram", "Siliguri");
            sdata[18] = new ebase("Famous bridge of kolkata", "lakshman jhulla", "Centurian bridge", "Sea Link", "Howrah Bridge");
            sdata[19] = new ebase("City of joy?", "Mumbai", "Delhi", "Chennai", "Kolkata");
            sdata[20] = new ebase("Busiest railway station of india", "Delhi junction", "Mumbai CST", "Chennai", "Howrah station");
            extend();
            display(sdata);
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
           etimer.Text = "" + --s;
            if (s <= -2)
            {
                dt.Stop();
                eo1.Visibility = Visibility.Collapsed;
                eo2.Visibility = Visibility.Collapsed;
                eo3.Visibility = Visibility.Collapsed;
                eo4.Visibility = Visibility.Collapsed;
                ebutt1.Visibility = Visibility.Collapsed;
                ebutt2.Visibility = Visibility.Collapsed;
                ebutt3.Visibility = Visibility.Collapsed;
                ebutt4.Visibility = Visibility.Collapsed;
                etimer.Visibility = Visibility.Collapsed;
                score.Visibility = Visibility.Collapsed;
                equestion.FontSize = 90;
                equestion.Text = "GAME OVER\n Your Final Score is  " + sco;
            }
        }
        static Random r = new Random();
        int x = r.Next(0, 21);
        int sco = 0;
        void display(ebase[] data)
        {

            i++;
            while (data[x].played_once)
            {
                x = r.Next(0, 21);
                if (i >= 11)
                {
                    i = 0;
                    this.Frame.Navigate(typeof(Assets.Fast), sco);
                }
            }
            data[x].played_once = true;
            equestion.Text = data[x].question;
            int a1, a2, a3, a4;
            Random rng = new Random();
            a1 = Genran(rng);
            eo1.Text = data[x].options[a1];
            a2 = Genran(rng);
            while (a2 == a1) a2 = Genran(rng);
            eo2.Text = data[x].options[a2];
            a3 = Genran(rng);
            while (a3 == a1 || a3 == a2) a3 = Genran(rng);
            eo3.Text = data[x].options[a3];
            a4 = 6 - a1 - a2 - a3;
            eo4.Text = data[x].options[a4];
            score.Text = sco.ToString();

        }
        static int Genran(Random rng)
        {
            return rng.Next(4);
        }

        private void ebutt1_Click(object sender, RoutedEventArgs e)
        {
            if (eo1.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void ebutt2_Click(object sender, RoutedEventArgs e)
        {
            if (eo2.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void ebutt3_Click(object sender, RoutedEventArgs e)
        {
            if (eo3.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void ebutt4_Click(object sender, RoutedEventArgs e)
        {
            if (eo4.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }

        private void ereplay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <21; i++)
            {
                sdata[i].played_once = false;
            }
            i = 0;
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
}