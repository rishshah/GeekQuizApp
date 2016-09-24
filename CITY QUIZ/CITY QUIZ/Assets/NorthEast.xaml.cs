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
    class nebase
    {

        public string question;
        public string[] options = new string[4];
        public string answer;
        public bool played_once;
        public nebase(string q, string o1, string o2, string o3, string o4)
        {
            question = q;
            options[0] = o1;
            options[1] = o2;
            options[2] = o3;
            options[3] = o4;
            answer = o4;
            played_once=false;
        }
    }
    public sealed partial class NorthEast : Page
    {
        static int i = 0;
        nebase[] data = new nebase[20];
        public NorthEast()
        {
            this.InitializeComponent();
            data[0] = new nebase("Which mountain forms the backdrop of darjeeling ?", " Mt everest", "K2", "Annamalai", "Kanchenjunga");
            data[1] = new nebase("Gangtok is the capital of ? ", "Nagaland  ", " Assam ", " Odisha ", "Sikkim");
            data[2] = new nebase("Darjeeling is famous for ?", "Coffee ", "Honey", "Apple", "Tea ");
            data[3] = new nebase("Enchey Monastry was built in ?", "1770","1740","1870", "1840");
            data[4] = new nebase("St. andrews church in darjeeling was built in ?", "1873 ", "1743", "1773", "1843 ");
            data[5] = new nebase("India's Highest waterfalls are present in which state ?", "Mizoram ", "Assam ", "Karnataka ", "Meghalaya");
            data[6] = new nebase("Which state of india is darjeeling in ? ", " Sikkim  ", "Assam","  Himachal Pradesh ", "West Bengal");
            data[7] = new nebase("Which of the following is in darjeeling ? ", " Himalayan Mountaineering Institute* ", " Indian Tea School ", "Indian Institute of Technology ", " National Institute of Design");
            data[8] = new nebase("Which IIT has the most beautiful campus ?", " IIT B", " IIT D", " IIT BHU", " IIT G");
            data[9] = new nebase("Largest inhabited river island in the world ? ", "Umananda ", "Lakshadweep ", "Andaman ", "Majuli");
            data[10] = new nebase("Which is the prominent dance form of Assam ?", " Bharatnatyam ", "Kathak", " Hajgiri", " Bihu");
            data[11] = new nebase("India's largest road and rail bridge is located in which state ?", " Maharshtra ", "West Bengal", " Arunachal Pradesh", " Assam");
            data[12] = new nebase("M C Mary Kom, the very accomplished boxer hails from the state of ________.", " Assam", " Mizoram", " Sikkim", " Manipur");
            data[13] = new nebase("Bollywood movies are banned in which state ? ", "Tamil Nadu", " Sikkim", " Assam ", "Manipur");
            data[14] = new nebase("Which is the wettest place on Earth ?", " Tripura", " Gangtok", " Meghalaya", " Mawsynram");
            data[15] = new nebase("Which of the following state is not a part of the 'Seven Sisters' ? ", "Meghalaya", "Arunachal Pradesh", "Mizoram", " Sikkim");
            data[16] = new nebase("Which city is known as 'Scotland of the East' ?" , "Imphal", "Gangtok", "Dispur", " Shillong");
            data[17] = new nebase("Baichung Bhutia hails from the state of ?", " Assam", "Mizoram", "Nagaland", "Sikkim");
            data[18] = new nebase("Kaziranga National Park is famous for ?", "Bengal Tiger", " Nilgai ", "White Tiger", "One Horned Rhinoceros");
            data[19] = new nebase("The earliest oil wells in India were dug in ? ", "Mumbai", "Godavari Delta" ,"Ganga delta" ," Assam");
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
            netimer.Text = "" + --s;
            if (s <= -1)
            {
                dt.Stop();
                neo1.Visibility = Visibility.Collapsed;
                neo2.Visibility = Visibility.Collapsed;
                neo3.Visibility = Visibility.Collapsed;
                neo4.Visibility = Visibility.Collapsed;
                nebutt1.Visibility = Visibility.Collapsed;
                nebutt2.Visibility = Visibility.Collapsed;
                nebutt3.Visibility = Visibility.Collapsed;
                nebutt4.Visibility = Visibility.Collapsed;
                netimer.Visibility = Visibility.Collapsed;
                score.Visibility = Visibility.Collapsed;
                nequestion.FontSize = 90;
                nequestion.Text = "GAME OVER\n Your Final Score is  " + sco;
            }
        }
        static Random r = new Random();
        int x = r.Next(0, 20);
        int sco = 0;
        void display(nebase[] data)
        {
            i++;
            while (data[x].played_once)
            {
                x = r.Next(0, 20);
                if (i >= 11)
                {
                    i = 0;
                    this.Frame.Navigate(typeof(Assets.Fast), sco);
                }
            }
            data[x].played_once = true;
            nequestion.Text = data[x].question;
            int a1, a2, a3, a4;
            Random rng = new Random();
            a1 = Genran(rng);
            neo1.Text = data[x].options[a1];
            a2 = Genran(rng);
            while (a2 == a1) a2 = Genran(rng);
            neo2.Text = data[x].options[a2];
            a3 = Genran(rng);
            while (a3 == a1 || a3 == a2) a3 = Genran(rng);
            neo3.Text = data[x].options[a3];
            a4 = 6 - a1 - a2 - a3;
            neo4.Text = data[x].options[a4];
            score.Text = sco.ToString();

        }
        static int Genran(Random rng)
        {
            return rng.Next(4);
        }

        private void nebutt1_Click(object sender, RoutedEventArgs e)
        {
            if (neo1.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nebutt2_Click(object sender, RoutedEventArgs e)
        {
            if (neo2.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nebutt3_Click(object sender, RoutedEventArgs e)
        {
            if (neo3.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }
        private void nebutt4_Click(object sender, RoutedEventArgs e)
        {
            if (neo4.Text == data[x].answer) sco += 100;
            else sco -= 50;
            display(data);
        }

        private void nereplay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                data[i].played_once = false;
            }
            i = 0;
            this.Frame.Navigate(typeof(Assets.BlankPage1), null);
        }
    }
}


