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
    class sbase
    {
        public string question;
        public string[] options = new string[4];
        public string answer;
        public bool played_once = false;
        public sbase(string q, string o1, string o2, string o3, string o4)
        {
            question = q;
            options[0] = o1;
            options[1] = o2;
            options[2] = o3;
            options[3] = o4;
            answer = o4;
        }
    }
    public sealed partial class South : Page
    {
        static int i = 0;
        sbase[] sdata = new sbase[31];
        public South()
        {
            this.InitializeComponent();
            sdata[0] = new sbase("Pondicherri is now known as ? ", "Pundamcheri", "Pudducheriam", "Padmacheri", "Pudducherry");
            sdata[1] = new sbase("Where was Veer Sawarkar sent to exile during the British Raj ?", "Mandalay", "Vietnam", "Nainital", "Andaman and Nicobar");
            sdata[2] = new sbase("Kavaratti is the capital of ?", "Kerala", "Andaman & Nicobar Islands", "Mizoram", "Lakshadweep");
            sdata[3] = new sbase("Asia's Largest beach is ?", "Calangute beach", "Juhu beach", "Thekkumbhagam-Kappil Beach", "Marina Beach");
            sdata[4] = new sbase("India's first reptile park is located in ?", "Bangalore", "Mangalore", "Hyderabad", "Chennai");
            sdata[5] = new sbase("The largest port in the Bay of Bengal is ? ", "Kolkata", "Vishakhapatnam", "Pondicherry", "Chennai");
            sdata[6] = new sbase("Kanyakumari is also known as ?", "Cape of good hope", "Cape Town", "Cape Verde", "Cape Comorin");
            sdata[7] = new sbase("Which of the following memorials is not present in Kanyakumari ?", "Mahtma Gandhi", "Tsunami", "Vivekananda", "Jayalalitha");
            sdata[8] = new sbase("Which of the following is the icon of Madurai ?", "Charminar", "Aiyappa Temple", " Rameshwar Temple", "Meenakshi Amman Temple");
            sdata[9] = new sbase("Which city is also called the city that never sleeps ?", "Mumbai", "Chennai", "Bangalore", "Madurai");
            sdata[10] = new sbase("In which city was rava idli born ?", "Chennai", "Hyderabad", "Thiruvananthapuram", "Bangalore");
            sdata[11] = new sbase("Maximum number of Nobel Prize nominations have come from which city ?", "Chennai", " Mumbai", "Hyderabad", "Bangalore");
            sdata[12] = new sbase("Which city is called as the Silicon Valley of India ? ", "Pune", "Mumbai", "Hyderabad", "Bangalore");
            sdata[13] = new sbase("One of world's largest rock the Lal Baugh Rock is in which city ? ", "Chennai ", "Delhi ", "Hyderabad ", "Banalore");
            sdata[14] = new sbase("Neer dosa, Kori rotti, and Kori Sukka are dishes from ? ", "Chennai", " Hyderabad ", "Bangalore", " Mangalore");
            sdata[15] = new sbase("Kambala, the buffalo race is associated with which city ?", "Bangalore", "Madurai", "Kanyakumari", "Mangalore");
            sdata[16] = new sbase("Biggest 'walk through' aviary of India is ?", "Chilka Lake", "Bharatpur Lake", "Wular Lake", "Karangi Lake");
            sdata[17] = new sbase("First City to undertake planned developement ?", "Chennai", "Madurai", "Bangalore", "Mysore");
            sdata[18] = new sbase("Which of the following is located on the banks of Penna river ?", "Vizag", "Vijaywada", "Hyderabad", "Nellore");
            sdata[19] = new sbase("Satish Dhavan Space Center is located in which city ?", "Bhubaneshwar", "Mysore", "Vishakhapatnam", "Nellore");
            sdata[20] = new sbase("The only submarine museum of Asia is in ?", "Nellore", "Hyderabad", "Chennai", "Vishakhapatnam");
            sdata[21] = new sbase("The commercial capital of Odisha is ?", "Bhubaneshwar", "Puri", "Rourkela", "Cuttack");
            sdata[22] = new sbase("The capital of Telangana is ?", "Vijaywada", "Amravati", "Secundrabad", "Hyderabad");
            sdata[23] = new sbase("Hyderabad is fomous for ?", "Qutub Minar", " Chand minar", "Jhulta Minar", "Char Minar");
            sdata[24] = new sbase("Which city is also known as 'the city carved out of single stone' ? ", "Hyderabad", "Nellore", "Kochi", "Warangal");
            sdata[25] = new sbase("Asia's second biggest grain market is in ?", "Chennai", " Kochi", "Vishakhapatnam", "Warangal");
            sdata[26] = new sbase("What was the previous name of Thiruvananthapuram ?", "Panaji", "Vishnupuram", "Tripuram", "Trivendrum");
            sdata[27] = new sbase("Which city was called as'Evergreen city' by Mahatma Gandhi ?", "Hyderabad", "Nilgiri", "Kozhikode", "Thiruvananthapuram");
            sdata[28] = new sbase("Which city is also known as 'Queen of Arabian Sea' ? ", "Mumbai ", "Mangalore", " Panaji", " Kochi");
            sdata[29] = new sbase("The oldest European church in India is in ?", "Panaji", "Kozhikode", "Vishakhapatnam", "Kochi");
            sdata[30] = new sbase("Kozhikode is also known as ?", "Cochin", "Madras", "Cuddappa", "Calicut");
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
            stimer.Text = "" + --s;
            if (s <= -2)
            {
                dt.Stop();
                so1.Visibility = Visibility.Collapsed;
                so2.Visibility = Visibility.Collapsed;
                so3.Visibility = Visibility.Collapsed;
                so4.Visibility = Visibility.Collapsed;
                sbutt1.Visibility = Visibility.Collapsed;
                sbutt2.Visibility = Visibility.Collapsed;
                sbutt3.Visibility = Visibility.Collapsed;
                sbutt4.Visibility = Visibility.Collapsed;
                stimer.Visibility = Visibility.Collapsed;
                score.Visibility = Visibility.Collapsed;
                squestion.FontSize = 90;
                squestion.Text = "GAME OVER\n Your Final Score is  " + sco;
            }
        }
        static Random r = new Random();
        int x = r.Next(0, 31);
        int sco = 0;
        void display(sbase[] data)
        {
            i++;
            while (sdata[x].played_once)
            {
                x = r.Next(0, 31);
                if (i >= 11)
                {
                    i = 0;
                    this.Frame.Navigate(typeof(Assets.Fast), sco);
                }
            }
            sdata[x].played_once = true;
            squestion.Text = sdata[x].question;
            int a1, a2, a3, a4;
            Random rng = new Random();
            a1 = Genran(rng);
            so1.Text = data[x].options[a1];
            a2 = Genran(rng);
            while (a2 == a1) a2 = Genran(rng);
            so2.Text = data[x].options[a2];
            a3 = Genran(rng);
            while (a3 == a1 || a3 == a2) a3 = Genran(rng);
            so3.Text = data[x].options[a3];
            a4 = 6 - a1 - a2 - a3;
            so4.Text = data[x].options[a4];
            score.Text = sco.ToString();

        }
        static int Genran(Random rng)
        {
            return rng.Next(4);
        }

        private void sbutt1_Click(object sender, RoutedEventArgs e)
        {
            if (so1.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void sbutt2_Click(object sender, RoutedEventArgs e)
        {
            if (so2.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void sbutt3_Click(object sender, RoutedEventArgs e)
        {
            if (so3.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }
        private void sbutt4_Click(object sender, RoutedEventArgs e)
        {
            if (so4.Text == sdata[x].answer) sco += 100;
            else sco -= 50;
            display(sdata);
        }

        private void sreplay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                sdata[i].played_once = false;
            }
            i = 0;
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
}
