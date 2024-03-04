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
        private static int marioX = 8;
        private static int marioY = 5;
        private static int turtle1X = 8;
        private static int turtle1Y = 7;
        private static int turtle2X = 7;
        private static int turtle2Y = 3;
        private static int turtle3X = 12;
        private static int turtle3Y = 7;
        private static int x = 0;
        private static int y = 0;
        private static char[,] field = new char[9, 18];
        private static int counter = 0;
        private static int mt = -200;
        private static int mb = 30;
        private static int ml = -1200;
        private static int mr = 0;
        TextBlock map = new TextBlock();
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
                myBitmapImage.UriSource = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "mario1.png"));
                mario.Source = myBitmapImage;
                myBitmapImage.EndInit();
            }
            d = 0;
            if (input.Text == "a")
            {
                marioX--;

                _timer3 = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (d < 10)
                    {
                        Thickness t = mario.Margin;
                        t.Left -= 7;
                        t.Right += 7;
                        mario.Margin = t;
                    }
                    d++;
                }, Application.Current.Dispatcher);
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "mario2.png"));
                mario.Source = myBitmapImage;
                myBitmapImage.EndInit();
            }
            int z = 0;
            int zs = 0;
            if (input.Text == "w")
            {
                TimeSpan _time;

                Thickness t = mario.Margin;
                if (field[marioY - 1, marioX] == ' ')
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

                if (field[marioY - 1, marioX] != ' ')
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
            if (field[marioY + 1, marioX] == ' ')
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
            map.Text = "";
            for (int k = 0; k < 9; k++)
            {
                for (int l = 0; l < 18; l++)
                {
                    if (k == marioY)
                    {
                        if (l == marioX)
                            map.Text += "O";
                        if (l != marioX)
                            map.Text += field[k, l].ToString();
                    }
                    if (k != marioY) map.Text += field[k, l].ToString();
                }
                map.Text += "\r\n";
            }
            counter++;
        }

        public void CreateBlokk(string blokk)
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
            myBitmapImage.UriSource = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), blokk+".png"));
            myBitmapImage.EndInit();
            image.Source = myBitmapImage;
            i++;
        }

        public void Read()
        {
            StreamReader olvas = new StreamReader(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "field.txt"));
            string elements = "";

            int i = 0;
            y = 0;
            x = 0;
            while (!olvas.EndOfStream)
            {
                elements = olvas.ReadLine();
                x = 0;
                foreach (char item in elements)
                {
                    field[y, x] = item;
                    if (item == 'W')
                    {
                        CreateBlokk("block");
                    }
                    if (item == 'M')
                    {
                        CreateBlokk("block2");
                    }
                    if (item == '?')
                    {
                        CreateBlokk("question");
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
        public void play_Click(object sender, RoutedEventArgs e)
        {
            _ = Move();
            initializeFieldAndCharacters();
        }

        public void initializeFieldAndCharacters()
        {
            marioXX.Height = 70;
            play.Height = 0;
            turtle.Height = 70;
            turtle2.Height = 70;
            turtle3.Height = 70;
            input.Focus();
            Read();
            stp.Children.Add(mario);
            mario.Height = 70;
            mario.Source = addBitmapImage("mario1");
            Thickness marioMargin = mario.Margin;
            marioMargin.Left = 0;
            marioMargin.Top = -280;
            marioMargin.Right = 70;
            marioMargin.Bottom = -755;
            mario.Margin = marioMargin;
            stp.Children.Add(map);
            map.FontFamily = new FontFamily("Courier New");
            map.FontSize = 10;
            map.MaxHeight = 115;
            map.Width = 115;
            map.Background = Brushes.White;
            Thickness labm = map.Margin;
            labm.Left = -1250;
            labm.Top = -280;
            map.Margin = labm;
            for (int k = 0; k < 9; k++)
            {
                for (int l = 0; l < 18; l++)
                {
                    if (k == marioY)
                    {
                        if (l == marioX)
                            map.Text += "O";
                        if (l != marioX)
                            map.Text += field[k, l].ToString();
                    }
                    if (k != marioY) map.Text += field[k, l].ToString();
                }
                map.Text += "\r\n";
            }
        }

        private int i = 0;

        private BitmapImage addBitmapImage(string key)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), key+".png"));
            myBitmapImage.EndInit();
            return myBitmapImage;
        }

        private void Die()
        {
            if ((marioX == turtle2X && marioY == turtle2Y) || (marioX == turtle1X && marioY == turtle1Y) || (marioX == turtle3X && marioY == turtle3Y))
            {
                Thickness position = mario.Margin;
                position.Top = -280;
                position.Bottom = -755;
                position.Left = 0;
                position.Right = 70;
                mario.Margin = position;
                marioX = 8;
                marioY = 5;
            }
        }

        private async Task Move()
        {
                DispatcherTimer _timer;
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    Thickness m = turtle.Margin;
                    Thickness m2 = turtle2.Margin;
                    Thickness m3 = turtle3.Margin;
                    if (i < 301)
                    {
                        m.Left -= 1;
                        m.Right += 1;
                        turtle.Source = addBitmapImage("turtle");
                        m2.Left += 1;
                        m2.Right -= 1;
                        if (m2.Left % 70 == 0)
                        {
                            turtle2X++;
                            turtle1X--;
                            turtle3X--;
                        }
                        turtle2.Source = addBitmapImage("turtle2");
                        turtle3.Source = addBitmapImage("turtle");
                        m3.Left -= 1;
                        m3.Right += 1;
                    }
                    if (i > 300)
                    {
                        m.Left += 1;
                        m.Right -= 1;
                        turtle.Source = addBitmapImage("turtle2");
                        if (i == 600) i = 0;
                        m2.Left -= 1;
                        m2.Right += 1;
                        if (m2.Left % 70 == 0)
                        {
                            turtle2X--;
                            turtle1X++;
                            turtle3X++;
                        }
                        turtle2.Source = addBitmapImage("turtle");
                        turtle3.Source = addBitmapImage("turtle2");
                        m3.Left += 1;
                        m3.Right -= 1;
                    }
                    turtle.Margin = m;
                    turtle2.Margin = m2;
                    turtle3.Margin = m3;
                    if ((marioX == turtle2X && marioY == turtle2Y) || (marioX == turtle1X && marioY == turtle1Y) || (marioX == turtle3X && marioY == turtle3Y))
                    {
                        Die();
                    }
                    i++;
                }, Application.Current.Dispatcher);
        }
    }
}
