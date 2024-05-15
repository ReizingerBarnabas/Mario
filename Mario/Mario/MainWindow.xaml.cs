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
        private DispatcherTimer timer;
        private TimeSpan elapsedTime;
        public MainWindow()
        {
            InitializeComponent();
            input.Focus();
            
            // UserControl bezárásának eseménykezelője
            Menu.CloseRequested += (sender, e) =>
            {
                Menu.Visibility = Visibility.Hidden; // UserControl elrejtése
            };
            // Inicializálás
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Minden másodpercben frissít
            timer.Tick += Timer_Tick;
            Music();
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
        private static char[,] field;
        private static int counter = 0;
        private static int mt = -200;
        private static int mb = 30;
        private static int ml = -1200;
        private static int mr = 0;
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
                            t = stp.Margin;
                            t.Top += 14;
                            t.Bottom -= 14;
                            stp.Margin = t;

                            
                            t = mario.Margin;
                            t.Top -= 14;
                            t.Bottom +=14;
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
                DispatcherTimer _timer;
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (zs < 10)
                    {
                        Thickness t2 = stp.Margin;
                        t2.Top -= 14;
                        t2.Bottom += 14;
                        stp.Margin = t2;

                        t2 = mario.Margin;
                        t2.Top += 14;
                        t2.Bottom -= 14;
                        mario.Margin = t2;
                    }
                    zs++;
                }, Application.Current.Dispatcher);
                //z++;
            }
            int zsz = 0;
            if (input.Text == "s")
            {
                marioY += 2;
                DispatcherTimer _timer;
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    if (zsz < 10)
                    {
                        Thickness t = stp.Margin;
                        t.Top -= 14;
                        t.Bottom += 14;
                        stp.Margin = t;

                        t = mario.Margin;
                        t.Top += 14;
                        t.Bottom -= 14;
                        mario.Margin = t;
                    }
                    zsz++;
                }, Application.Current.Dispatcher);
            }
            input.Text = "";
            counter++;
        }

        public void CreateBlock(string block)
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
            image.Source = addBitmapImage(block);
            i++;
        }

        public void CreateTurtle()
        {
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
                olvas.ReadLine();
                i++;
            } 
            olvas.Close();
            StreamReader olvas2 = new StreamReader(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "field.txt"));
            
            field = new char[200, 200];
            i=0;
            while (!olvas2.EndOfStream)
            {
                elements = olvas2.ReadLine();
                x = 0;
                foreach (char item in elements)
                {
                    field[y, x] = item;
                    if (item == 'W')
                    {
                        CreateBlock("block");
                    }
                    if (item == 'M')
                    {
                        CreateBlock("block2");
                    }
                    if (item == '?')
                    {
                        CreateBlock("question");
                    }
                    if (item == 'X')
                    {
                        CreateTurtle();
                    }
                    ml += 140;

                    x++;
                }
                mb -= 140;
                ml = -1200;

                y++;
            }
            olvas2.Close();
        }
        public void play_Click(object sender, RoutedEventArgs e)
        {
            _ = Move();
            initializeFieldAndCharacters();
            StartTimer();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Minden tick eseménynél növeljük az eltelt időt
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
        
            // Frissítjük a TextBlock szövegét
            TimeDisplay.Text = $"IDŐ: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }

        public void StartTimer()
        {
            // Indítsd el az időzítőt és nullázd az eltelt időt
            elapsedTime = TimeSpan.Zero;
            timer.Start(); // A timer elkezd számolni
        }

        public void initializeFieldAndCharacters()
        {
            marioXX.Height = 70;
            play.Visibility = Visibility.Hidden;
            StartScreen.Visibility = Visibility.Hidden;
            turtle1.Height = 70;
            // turtle2.Height = 70;
            turtle3.Height = 70;
            // turtle4.Height = 70;
            turtle5.Height = 70;
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
            //Menu.Visibility = Visibility.Visible;
        }

        private async Task Move()
        {
                DispatcherTimer _timer;
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Normal, delegate
                {
                    Thickness m1 = turtle1.Margin;
                    // Thickness m2 = turtle2.Margin;
                    Thickness m3 = turtle3.Margin;
                    // Thickness m4 = turtle4.Margin;
                    Thickness m5 = turtle5.Margin;
                    if (i < 301)
                    {
                        m1.Left -= 1;
                        m1.Right += 1;
                        // m2.Left += 1;
                        // m2.Right -= 1;
                        m3.Left -= 1;
                        m3.Right += 1;
                        // m4.Left += 1;
                        // m4.Right -= 1;
                        m5.Left -= 1;
                        m5.Right += 1;
                        if (m3.Left % 70 == 0)
                        {
                            turtle2X++;
                            turtle1X--;
                            turtle3X--;
                        }
                        turtle1.Source = addBitmapImage("turtle");
                        // turtle2.Source = addBitmapImage("turtle2");
                        turtle3.Source = addBitmapImage("turtle");
                        // turtle4.Source = addBitmapImage("turtle2");
                        turtle5.Source = addBitmapImage("turtle");
                        
                    }
                    if (i > 300)
                    {
                        m1.Left += 1;
                        m1.Right -= 1;
                        if (i == 600) i = 0;
                        // m2.Left -= 1;
                        // m2.Right += 1;
                        m3.Left += 1;
                        m3.Right -= 1;
                        // m4.Left -= 1;
                        // m4.Right += 1;
                        m5.Left += 1;
                        m5.Right -= 1;
                        if (m3.Left % 70 == 0)
                        {
                            turtle2X--;
                            turtle1X++;
                            turtle3X++;
                        }
                        turtle1.Source = addBitmapImage("turtle2");
                        // turtle2.Source = addBitmapImage("turtle");
                        turtle3.Source = addBitmapImage("turtle2");
                        // turtle4.Source = addBitmapImage("turtle");
                        turtle5.Source = addBitmapImage("turtle2");
                        
                    }
                   
                    turtle1.Margin = m1;
                    // turtle2.Margin = m2;
                    turtle3.Margin = m3;
                    // turtle4.Margin = m4;
                    turtle5.Margin = m5;
                   
                    if ((marioX == turtle2X && marioY == turtle2Y) || (marioX == turtle1X && marioY == turtle1Y) || (marioX == turtle3X && marioY == turtle3Y))
                    {
                        Die();
                    }
                    i++;
                }, Application.Current.Dispatcher);
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Eseménykezelő logika, amely bezárja az ablakot
            //Close();
            Application.Current.Shutdown();
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
        }
        public void backToGame_Click(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
        }

        private bool _isPlaying = false;
        private SoundPlayer _p;
        public void Music()
        {
            _p = new SoundPlayer("zene.wav");
            _p.Load();
            _p.Play();
            _isPlaying = true;
        }
        private void MusicBtnStart_Click(object sender, RoutedEventArgs e)
        {
            // Ellenőrizd, hogy a lejátszó nem null és nem játszik
            if (!_isPlaying)
            {
                Music();
                _p.Play();
                _isPlaying = true;
            }
        }

        private void MusicBtnStop_Click(object sender, RoutedEventArgs e)
        {
            // Ellenőrizd, hogy a lejátszó nem null és játszik
            if (_isPlaying)
            {
                _p.Stop();
                _isPlaying = false;
            }
        }
    }
}
