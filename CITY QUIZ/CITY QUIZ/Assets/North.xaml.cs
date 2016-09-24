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
    class nbase
    {
        
        public string question;
        public string[] options = new string[4];
        public string answer;
        public bool played_once = false;
        public nbase(string q, string o1, string o2, string o3, string o4)
        {
            question = q;
            options[0] = o1;
            options[1] = o2;
            options[2] = o3;
            options[3] = o4;
            answer = o4;
        }
    }
    public sealed partial class North : Page
    {
        static int i = 0;
        nbase[] data = new nbase[22];
        public North()
        {
            this.InitializeComponent();
            data[0] = new nbase("Jammu is capital of j&k in which season ?", " Summer", " Autmn", "Spring", " Winter");
            data[1] = new nbase("Kashmir is capital of j&k in which season ?", "Autumn", "Winter", "Spring", "Summer");
            data[2] = new nbase("Leh is the capital of ?", " Jammu ", "Kashmir", "Pehelgam", "Ladakh");
            data[3] = new nbase("Which is India's oldest engineering college ?", "Quantum Global Campus ", "College of Engineering Roorkee ", "IIT Roorkee ", "Thomson Civil Engineering College");
            data[4] = new nbase("Union territory is also the capital of two states ?", "Delhi", "Daman and Diu", "Pudducheri", "Chandigarh");
            data[5] = new nbase("Dehradun is capital of ?", "Himachal Pradesh ", "Haryana ", "Uttar Pradesh", "Uttarakhand");
            data[6] = new nbase("Shimla is the capital city of ? ", "Haryana", "Uttarakhand", "Uttar Pradesh", " Himachal Pradesh");
            data[7] = new nbase("Hidimba devi temple is located in ?", "Kullu ", "Shimla", "Nainital", "Manali");
            data[8] = new nbase("Nainital is surrounded by Deopatha, Ayarpatha and ________ ?", "Mt Everest", " Kanchenjunga", "Rohtang Pass", "Naini");
            data[9] = new nbase("Which is the only city in india with population larger than delhi ?", "Chennai", "Kolkata", "Bangalore", "Mumbai");
            data[10] = new nbase("MahaKumbh Mela is not held in ?", "Haridwar", "Varanasi", "Ujjain", "Kanpur");
            data[11] = new nbase("which is the tallest mountain of j&k ? ", " Mt Everest ", " Mt Kanchenjunga", " Annamalai", " K2");
            data[12] = new nbase("Largest city in the Kashmir valley is ? ", " Srinagar", " Anantnag ", " Kupwara", " Baramulla");
            data[13] = new nbase("Loc passes through which lake ? ", " Chilka lake", " Cholamoo lake", " Wular lake", " Pyangyong lake");
            data[14] = new nbase("Which is the only Indian Tourist Destination to have all around 4g wifi ?", " Dehradun ", "Nainital ", "Kashmir", "Shimla");
            data[15] = new nbase("which city is known as the spiritual capital of india ?", "Haridwar", " Ujjain", " Mathura", " Varanasi");
            data[16] = new nbase("Delhi's Red Fort was biult by ?", "Aurangzeb ", " Akbar", "Babur", "Shah Jahan");
            data[17] = new nbase("Which Jantar Mantar is equipped with equatorial sundial ?", "Delhi ", " Jaipur", "Kanpur", " Varanasi ");
            data[18] = new nbase("Who created the rock garden in Chandigarh ? ", " Birbal ", " Dayanand Swami", "Lala Lajpat Rai", "Nek Chand");
            data[19] = new nbase("Delhi is situated along which river ?", " Ganga", " Indus ", " Narmada", " Yamuna");
            data[20] = new nbase("Rashtrapati Bhavan is the residence of ?", "Prime Minister ", "Chief Justice of India ", "Vice President", "President");
            data[21] = new nbase("Where was the first Jantar Mantar created ? ", " Banares", " Mathura ", " Jaipur", " Delhi");
            extend();
            display(data);
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
            ntimer.Text = "" + --s;
            if (s <= -1)
            {
                dt.Stop();
                no1.Visibility = Visibility.Collapsed;
                no2.Visibility = Visibility.Collapsed;
                no3.Visibility = Visibility.Collapsed;
                no4.Visibility = Visibility.Collapsed;
                nbutt1.Visibility = Visibility.Collapsed;
                nbutt2.Visibility = Visibility.Collapsed;
                nbutt3.Visibility = Visibility.Collapsed;
                nbutt4.Visibility = Visibility.Collapsed;
                ntimer.Visibility = Visibility.Collapsed;
                score.Visibility = Visibility.Collapsed;
                nquestion.FontSize = 90;
                nquestion.Text = "GAME OVER\n Your Final Score is  " + sco;
            }
        }
        static Random r = new Random();
        int x = r.Next(0, 22);
        int sco = 0;
        void display(nbase[] data)
        {
            i++;
            while (data[x].played_once)
            {
                x = r.Next(0, 22);
                if (i >= 11)
                {
                    i = 0;
                    this.Frame.Navigate(typeof(Assets.Fast), sco);
                }
            }
            data[x].played_once = true;
            nquestion.Text = data[x].question;
            int a1, a2, a3, a4;
            Random rng = new Random();
            a1 = Genran(rng);
            no1.Text = data[x].options[a1];
            a2 = Genran(rng);
            while (a2 == a1) a2 = Genran(rng);
            no2.Text = data[x].options[a2];
            a3 = Genran(rng);
            while (a3 == a1 || a3 == a2) a3 = Genran(rng);
            no3.Text = data[x].options[a3];
            a4 = 6 - a1 - a2 - a3;
            no4.Text = data[x].options[a4];
            score.Text = sco.ToString();

        }
        static int Genran(Random rng)
        {
            return rng.Next(4);
        }

        private void nbutt1_Click(object sender, RoutedEventArgs e)
        {
            if (no1.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nbutt2_Click(object sender, RoutedEventArgs e)
        {
            if (no2.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nbutt3_Click(object sender, RoutedEventArgs e)
        {
            if (no3.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nbutt4_Click(object sender, RoutedEventArgs e)
        {
            if (no4.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }

        private void nreplay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 21; i++)
            {
                data[i].played_once = false;
            }
            i = 0;
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
}
