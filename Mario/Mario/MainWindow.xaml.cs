using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.IO;
using System.Windows.Threading;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace Mario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
        }
        public static int marioX = 8;
        public static int marioY = 5;
        public static int teknos1X = 8;
        public static int teknos1Y = 7;
        public static int teknos2X = 7;
        public static int teknos2Y = 3;
        public static int teknos3X = 12;
        public static int teknos3Y = 7;
        public static int x = 0;
        public static int y = 0;
        public static char[,] palya = new char[9, 18];
        public static int szamlalo = 0;
        public static int mt = -200;
        public static int mb = 30;
        public static int ml = -1200;
        public static int mr = 0;
        Label lab2 = new Label();
        //SoundPlayer player;
        TextBlock lab = new TextBlock();
        Image mario = new Image();
        public async void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            marioXX.Height = 0;
            DispatcherTimer _timer3;
            int d = 0;
            if (input.Text == "d")
            {
                marioX++;
                _timer3 = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (d < 10)
                    {
                        Thickness t = mario.Margin;
                        t.Left += 7;
                        t.Right -= 7;
                        mario.Margin = t;
                    }
                    d++;
                }, Application.Current.Dispatcher);
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\mario11.png");
                mario.Source = myBitmapImage;
                myBitmapImage.EndInit();
            }
            int c = 0;
            if (input.Text == "a")
            {
                marioX--;

                _timer3 = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (c < 10)
                    {
                        Thickness t = mario.Margin;
                        t.Left -= 7;
                        t.Right += 7;
                        mario.Margin = t;
                    }
                    c++;
                }, Application.Current.Dispatcher);
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\mario22.png");
                mario.Source = myBitmapImage;
                myBitmapImage.EndInit();
            }
            int z = 0;
            int zs = 0;
            if (input.Text == "w")
            {
                TimeSpan _time;

                Thickness t = mario.Margin;
                if (palya[marioY - 1, marioX] == ' ')
                {
                    _timer3 = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                    {
                        if (z < 10)
                        {
                            t = mario.Margin;
                            t.Top -= 14;
                            t.Bottom += 14;
                            mario.Margin = t;
                        }
                        if (z >= 10 && z < 20)
                        {
                            t = mario.Margin;
                            t.Top += 14;
                            t.Bottom -= 14;
                            mario.Margin = t;
                        }
                        z++;
                    }, Application.Current.Dispatcher);
                }

                if (palya[marioY - 1, marioX] != ' ')
                {
                    marioY -= 2;

                    _timer3 = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                    {
                        if (z < 10)
                        {
                            t = mario.Margin;
                            t.Top -= 14;
                            t.Bottom += 14;
                            mario.Margin = t;
                        }
                        z++;
                    }, Application.Current.Dispatcher);
                }
            }
            //visszaesik
            if (palya[marioY + 1, marioX] == ' ')
            {
                marioY += 2;
                //if (palya[marioY - 1, marioX] != ' ')
                {
                    DispatcherTimer _timer;
                    //_time = new TimeSpan(0, 0, 6);
                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                    {
                        if (zs < 10)
                        {
                            Thickness t2 = mario.Margin;

                            t2 = mario.Margin;
                            t2.Top += 14;
                            t2.Bottom -= 14;
                            mario.Margin = t2;
                        }
                        zs++;
                    }, Application.Current.Dispatcher);
                }
                //z++;
            }
            int zsz = 0;
            if (input.Text == "s")
            {
                marioY += 2;

                DispatcherTimer _timer;
                //_time = new TimeSpan(0, 0, 6);
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (zsz < 10)
                    {
                        Thickness t = mario.Margin;
                        t.Top += 14;
                        t.Bottom -= 14;
                        mario.Margin = t;
                    }
                    zsz++;
                }, Application.Current.Dispatcher);
            }
            input.Text = "";
            lab.Text = "";
            for (int k = 0; k < 9; k++)
            {
                for (int l = 0; l < 18; l++)
                {
                    if (k == marioY)
                    {
                        if (l == marioX)
                            lab.Text += "O";
                        if (l != marioX)
                            lab.Text += palya[k, l].ToString();
                    }
                    if (k != marioY) lab.Text += palya[k, l].ToString();
                }
                lab.Text += "\r\n";
            }
            szamlalo++;
        }
        private void Beolvas()
        {
            StreamReader olvas = new StreamReader(@"C:\Users\rbarn\source\repos\Mario\src\palya.txt");
            string elemek = "";

            int i = 0;
            int j = 0;
            y = 0;
            x = 0;
            while (!olvas.EndOfStream)
            {
                elemek = olvas.ReadLine();
                x = 0;
                foreach (char elem in elemek)
                {
                    palya[y, x] = elem;
                    if (elem == 'W')
                    {
                        Image image = new Image();
                        stp.Children.Add(image);
                        image.Height = 70;
                        image.Width = 70;
                        Thickness thickness = image.Margin;
                        thickness.Left = ml;
                        thickness.Top = mt;
                        thickness.Right = mr;
                        thickness.Bottom = mb;
                        image.Margin = thickness;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\tegla.png");
                        image.Source = myBitmapImage;
                        myBitmapImage.EndInit();
                        //image.Name = "tegla" + i;
                        i++;
                    }
                    if (elem == 'M')
                    {
                        Image image = new Image();
                        stp.Children.Add(image);
                        image.Height = 70;
                        image.Width = 70;
                        Thickness thickness = image.Margin;
                        thickness.Left = ml;
                        thickness.Top = mt;
                        thickness.Right = mr;
                        thickness.Bottom = mb;
                        image.Margin = thickness;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\tegla2.png");
                        image.Source = myBitmapImage;
                        myBitmapImage.EndInit();
                        //image.Name = "teglaM" + i;
                        i++;
                    }
                    if (elem == '?')
                    {
                        Image image = new Image();
                        stp.Children.Add(image);
                        image.Height = 70;
                        image.Width = 70;
                        Thickness thickness = image.Margin;
                        thickness.Left = ml;
                        thickness.Top = mt;
                        thickness.Right = mr;
                        thickness.Bottom = mb;
                        image.Margin = thickness;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\kerdojel.png");
                        image.Source = myBitmapImage;
                        myBitmapImage.EndInit();
                        //image.Name = "kerdojel" + j;

                        j++;
                    }
                    ml += 140;

                    x++;
                }
                mb -= 140;
                ml = -1200;

                y++;
            }
            olvas.Close();
        }
        private void play_Click(object sender, RoutedEventArgs e)
        {
            _ = TeknosMozgasa();
            marioXX.Height = 70;
            play.Height = 0;
            teknos.Height = 70;
            teknos2.Height = 70;
            teknos3.Height = 70;
            input.Focus();
            Beolvas();
            stp.Children.Add(mario);
            mario.Height = 70;
            BitmapImage myBitmapImage2 = new BitmapImage();
            myBitmapImage2.BeginInit();
            myBitmapImage2.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\mario11.png");
            mario.Source = myBitmapImage2;
            Thickness marioMargo = mario.Margin;
            marioMargo.Left = 0;
            marioMargo.Top = -280;
            marioMargo.Right = 70;
            marioMargo.Bottom = -755;
            mario.Margin = marioMargo;
            //player = new SoundPlayer(@"E:\repos\Mario's World Game\Sources\Super Mario Bros. Theme Song.wav");
            //player.Play();
            stp.Children.Add(lab);
            stp.Children.Add(lab2);
            //kep.Height = 0;
            lab.FontFamily = new FontFamily("Courier New");
            lab.FontSize = 10;
            lab.MaxHeight = 115;
            lab.Width = 115;
            lab.Background = Brushes.White;
            Thickness labm = lab.Margin;
            labm.Left = -1250;
            labm.Top = -280;
            lab.Margin = labm;
            for (int k = 0; k < 9; k++)
            {
                for (int l = 0; l < 18; l++)
                {
                    if (k == marioY)
                    {
                        if (l == marioX)
                            lab.Text += "O";
                        if (l != marioX)
                            lab.Text += palya[k, l].ToString();
                    }
                    if (k != marioY) lab.Text += palya[k, l].ToString();
                }
                lab.Text += "\r\n";
            }
        }
        public int i = 0;
        public async Task TeknosMozgasa()
        {
            //for (int i = 0; i < 10; i++)
            {
                DispatcherTimer _timer;

                TimeSpan _time;
                _time = new TimeSpan(0, 0, 6);
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    Thickness m = teknos.Margin;
                    Thickness m2 = teknos2.Margin;
                    Thickness m3 = teknos3.Margin;
                    if (i < 301)
                    {
                        m.Left -= 1;
                        m.Right += 1;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos.png");
                        teknos.Source = myBitmapImage;
                        myBitmapImage.EndInit();
                        m2.Left += 1;
                        m2.Right -= 1;
                        if (m2.Left % 70 == 0)
                        {
                            teknos2X++;
                            teknos1X--;
                            teknos3X--;
                        }
                        BitmapImage myBitmapImage2 = new BitmapImage();
                        myBitmapImage2.BeginInit();
                        myBitmapImage2.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos2.png");
                        teknos2.Source = myBitmapImage2;
                        myBitmapImage2.EndInit();
                        BitmapImage myBitmapImage3 = new BitmapImage();
                        myBitmapImage3.BeginInit();
                        myBitmapImage3.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos.png");
                        teknos3.Source = myBitmapImage3;
                        myBitmapImage3.EndInit();
                        m3.Left -= 1;
                        m3.Right += 1;
                    }
                    if (i > 300)
                    {
                        m.Left += 1;
                        m.Right -= 1;
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos2.png");
                        teknos.Source = myBitmapImage;
                        myBitmapImage.EndInit();
                        if (i == 600) i = 0;
                        m2.Left -= 1;
                        m2.Right += 1;
                        if (m2.Left % 70 == 0)
                        {
                            teknos2X--;
                            teknos1X++;
                            teknos3X++;
                        }
                        BitmapImage myBitmapImage2 = new BitmapImage();
                        myBitmapImage2.BeginInit();
                        myBitmapImage2.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos.png");
                        teknos2.Source = myBitmapImage2;
                        myBitmapImage2.EndInit();
                        if (i == 600) i = 0;
                        BitmapImage myBitmapImage3 = new BitmapImage();
                        myBitmapImage3.BeginInit();
                        myBitmapImage3.UriSource = new Uri(@"C:\Users\rbarn\source\repos\Mario\src\teknos2.png");
                        teknos3.Source = myBitmapImage3;
                        myBitmapImage3.EndInit();
                        if (i == 600) i = 0;
                        m3.Left += 1;
                        m3.Right -= 1;
                    }
                    teknos.Margin = m;
                    teknos2.Margin = m2;
                    teknos3.Margin = m3;
                    //meghal
                    if ((marioX == teknos2X && marioY == teknos2Y) || (marioX == teknos1X && marioY == teknos1Y) || (marioX == teknos3X && marioY == teknos3Y))
                    {
                        Thickness mariopozicio = mario.Margin;
                        mariopozicio.Top = -280;
                        mariopozicio.Bottom = -755;
                        mariopozicio.Left = 0;
                        mariopozicio.Right = 70;
                        mario.Margin = mariopozicio;
                        marioX = 8;
                        marioY = 5;
                        //player.Stop();
                        //player.Play();
                    }
                    i++;
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
            }
        }
    }
}
