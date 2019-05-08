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

namespace Labs_minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool click = false;
        static int[,] minen = new int[100, 2];
        static int n = 9, m = 10;
        static Button[,] but = new Button[25, 25];
        static Label[,] lab = new Label[25, 25];
        Image Img = new Image();
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
            Initialise();
            /*if (click)
            {
                Random();
                Initialise_Label();
                Modify_Label();
            }*/
        }

        static public void Random(int x, int y)
        {
            bool exists = false;
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            { 
                do
                {
                    exists = false;
                    minen[i, 0] = rand.Next(n);
                    minen[i, 1] = rand.Next(n);
                    for (int j = 0; j < i; j++)
                    {
                        if (minen[j, 0] == minen[i, 0] && minen[j, 1] == minen[i, 1]||(minen[i,0]==x && minen[i,1]==y))
                            exists = true;
                    }
                }while (exists);
            }
        }

        void Initialise()
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    var b = new Button();
                    var bc = new BrushConverter();
                    b.Background = (Brush)bc.ConvertFrom("#a2a3a5");
                    b.Content = $"";
                    b.FontSize = 10;
                    b.Padding = new System.Windows.Thickness(20, 13, 20, 14);
                    b.HorizontalAlignment = HorizontalAlignment.Center;
                    b.VerticalAlignment = VerticalAlignment.Center;
                    //b.Click += Button_Click;
                    Grid.SetRow(b, row);
                    Grid.SetColumn(b, column);
                    b.Click += (sender, EventArgs) => { Button_Click(sender, EventArgs); };
                    b.MouseRightButtonDown += (sender, EventArgs) => { Button_Right(sender, EventArgs); };
                    Sweeper.Children.Add(b);
                    but[row, column] = b;
                }
            }
        }

        void Initialise_Label()
        {
            var bc = new BrushConverter();
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    var b = new Label();
                    b.Background = (Brush)bc.ConvertFrom("#c0c1c4");
                    b.Content = 0;
                    b.FontSize = 30;
                    b.Padding = new System.Windows.Thickness(12,0,12,1);
                    b.HorizontalAlignment = HorizontalAlignment.Center;
                    b.VerticalAlignment = VerticalAlignment.Center;
                    for (int i = 0; i < m; i++)
                    {
                        if (minen[i, 0] == row && minen[i, 1] == column)
                        {
                            b.Content = "mine";
                        }
                    }
                    Grid.SetRow(b, row);
                    Grid.SetColumn(b, column);
                    b.Visibility = Visibility.Collapsed;
                    lab[row, column] = b;
                    Sweeper.Children.Add(b);
                }
            }
        }

        void Modify_Label()
        {
            var bc = new BrushConverter();
            int i = 0, j = 0;
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (lab[row, column].Content.ToString() != "mine")
                    {
                        for (j = column - 1; j <= column + 1 && j < n; j++)
                        {
                            if (row < n - 1 && j>=0 && lab[row + 1, j].Content.ToString() == "mine")
                                lab[row, column].Content = Int32.Parse(lab[row, column].Content.ToString()) + 1;
                            if (row >= 1 && j>=0 &&  lab[row - 1, j].Content.ToString() == "mine")
                                lab[row, column].Content = Int32.Parse(lab[row, column].Content.ToString()) + 1;
                        }
                        for (i = row; i <= row; i++)
                        {
                            if (column < n - 1 && lab[i, column + 1].Content.ToString() == "mine")
                                lab[row, column].Content = Int32.Parse(lab[row, column].Content.ToString()) + 1;
                            if (column >= 1 && lab[i, column - 1].Content.ToString() == "mine")
                                lab[row, column].Content = Int32.Parse(lab[row, column].Content.ToString()) + 1;
                        }
                        //MessageBox.Show($"{lab[row, column].Content.ToString()}");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 1)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#261eb5");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 2)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#33b210 ");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 3)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#99d620");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 4)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#fbff1e");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 5)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#fcb40c");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 6)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#f90404");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 7)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#c40000");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 8)
                            lab[row, column].Foreground = (Brush)bc.ConvertFrom("#890909");
                        if (Int32.Parse(lab[row, column].Content.ToString()) == 0)
                        {
                            lab[row, column].Content = "  ";
                        }
                    }
                }
            }
        }

        void Window_Loaded()
        {
            Sweeper.RowDefinitions.Clear();
            Sweeper.ColumnDefinitions.Clear();
            for (int j = 0; j < n; j++)
            {
                ColumnDefinition Gridcol1 = new ColumnDefinition();
                Gridcol1.Width = new GridLength(40);//;1, GridUnitType.Star);
                Sweeper.ColumnDefinitions.Add(Gridcol1);
                RowDefinition Gridrow1 = new RowDefinition();
                Gridrow1.Height = new GridLength(40);//1, GridUnitType.Star);
                Sweeper.RowDefinitions.Add(Gridrow1);
            }
        }

        void Button_Click(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (!click)
            {
                Random(Grid.GetRow(button),Grid.GetColumn(button));
                Initialise_Label();
                Modify_Label();
            }
            button.Visibility = Visibility.Collapsed;
            lab[Grid.GetRow(button), Grid.GetColumn(button)].Visibility = Visibility.Visible;
            if (lab[Grid.GetRow(button), Grid.GetColumn(button)].Content.ToString() == "mine")
            {
                Image Img = new Image();
                Img.Source = new BitmapImage(new Uri(
                         "C:\\c-\\Labs_minesweeper\\explosions-transparent-sprite-5-original.png"));
                lab[Grid.GetRow(button), Grid.GetColumn(button)].Padding = new System.Windows.Thickness(0,0,0,1);
                lab[Grid.GetRow(button), Grid.GetColumn(button)].Content = Img;
                MessageBox.Show("YOU LOSE");
                but[Grid.GetRow(button), Grid.GetColumn(button)].Content = "explosion";
                End();
            }
            else if (lab[Grid.GetRow(button), Grid.GetColumn(button)].Content.ToString() == "  ")
                Cascade(Grid.GetRow(button), Grid.GetColumn(button));
            Check_Win();
            click = true;
        }

        void Check_Win()
        {
            bool win = true;
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (lab[row, column].Content.ToString() != "mine" && (but[row, column].Content.ToString() == "explosion" || but[row, column].Visibility != Visibility.Collapsed))
                        win = false;
                }
            }
            if (win)
            {
                MessageBox.Show("You Win");
                End();
            }
        }

        void End()
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (lab[row, column].Content.ToString() == "mine")
                    {
                        lab[row, column].Padding = new System.Windows.Thickness(0, 0, 0, 0);
                        Image Img2 = new Image();
                        Img2.Source = new BitmapImage(new Uri(
                            "C:\\c-\\Labs_minesweeper\\download.jpg"));
                        lab[row, column].Content = Img2;
                    }
                    but[row, column].Visibility = Visibility.Collapsed;
                    lab[row, column].Visibility = Visibility.Visible;
                }
            }
        }

        void Cascade(int i, int j)
        {
            but[i, j].Content = "collapse";
            bool empty = true;
            while (empty)
            {
                empty = false;
                for (int k = j - 1; k <= j + 1 && k < n; k++)
                {
                    if (i < n - 1 && k >= 0 && Collapsed(i + 1, k))
                    {
                        but[i + 1, k].Visibility = Visibility.Collapsed;
                        lab[i + 1, k].Visibility = Visibility.Visible;
                        if (lab[i + 1, k].Content.ToString() == "  " && but[i + 1, k].Content.ToString() != "collapse")
                        {
                            but[i + 1, k].Content = "collapse";
                            empty = true;
                            Cascade(i + 1, k);
                        }
                    }
                    if (i >= 1 && k >= 0 && Collapsed(i - 1, k))
                    {
                        but[i - 1, k].Visibility = Visibility.Collapsed;
                        lab[i - 1, k].Visibility = Visibility.Visible;
                        if (lab[i - 1, k].Content.ToString() == "  " && but[i - 1, k].Content.ToString() != "collapse")
                        {
                            but[i - 1, k].Content = "collapse";
                            empty = true;
                            Cascade(i - 1, k);
                        }
                    }
                }
                for (int l = i; l <= i && l < n; l++)
                {
                    if (j < n - 1 && l>=0 && Collapsed(l, j+1))
                    {
                        but[l, j + 1].Visibility = Visibility.Collapsed;
                        lab[l, j + 1].Visibility = Visibility.Visible;
                        if (lab[l, j + 1].Content.ToString() == "  " && but[l, j + 1].Content.ToString() != "collapse")
                        {
                            but[l, j + 1].Content = "collapse";
                            empty = true;
                            Cascade(l, j + 1);
                        }
                    }
                    if (j >= 1 && l>=0 && Collapsed(l, j-1))
                    {
                        but[l, j - 1].Visibility = Visibility.Collapsed;
                        lab[l, j - 1].Visibility = Visibility.Visible;
                        if (lab[l, j - 1].Content.ToString() == "  " && but[l, j - 1].Content.ToString() != "collapse")
                        {
                            but[l, j - 1].Content = "collapse";
                            empty = true;
                            Cascade(l, j - 1);
                        }
                    }
                }
            }
        }

        bool Collapsed(int i, int j)
        {
            for (int k = j - 1; k <= j + 1 && k < n; k++)
            {
                if (i < n - 1 && k >= 0 && but[i + 1, k].Content.ToString() == "collapse")
                {
                    return true;
                }
                if (i >= 1 && k >= 0 && but[i - 1, k].Content.ToString() == "collapse")
                {
                    return true;
                }
            }
            for (int l = i - 1 + 1; l <= i + 1 - 1 && l < n; l++)
            {
                if (j < n - 1 && l >= 0 && but[l, j + 1].Content.ToString() == "collapse")
                {
                    return true;
                }
                if (j >= 1 && l >= 0 && but[l, j - 1].Content.ToString() == "collapse")
                {
                    return true;
                }
            }
            return false;
        }

        private void Button_Right(object sender, MouseButtonEventArgs e)
        {
            Button butn = (Button)sender;
            if (butn.Content == Img)
            {
                butn.Content = "  ";
                butn.Padding = new System.Windows.Thickness(16, 12, 16, 13);
                return;
            }
                Img = new Image();
                Img.Source = new BitmapImage(new Uri(
                         "C:\\c-\\Labs_minesweeper\\F8578719-01.jpg"));
                but[Grid.GetRow(butn),Grid.GetColumn(butn)].Content = Img;
                but[Grid.GetRow(butn), Grid.GetColumn(butn)].Padding = new System.Windows.Thickness(0);
                return;
        }

        public void Toolbar_Click01(object sender, RoutedEventArgs e)
        {
            m = 10;
            n = 9;
            click = false;
            MyToolbar.Width = n * 40;
            //Button[,] but = new Button[n, n];
            //Label[,] lab = new Label[n, n];
            InitializeComponent();
            Window_Loaded();
            Initialise();
            /*Random();
            Initialise_Label();
            Modify_Label();*/
        }

        public void Toolbar_Click02(object sender, RoutedEventArgs e)
        {
            m = 25;
            n = 12;
            click = false;
            MyToolbar.Width = n * 40;
            InitializeComponent();
            Window_Loaded();
            Initialise();
            /*Random();
            Initialise_Label();
            Modify_Label();*/
        }

        public void Toolbar_Click03(object sender, RoutedEventArgs e)
        {
            m = 52;
            n = 18;
            click = false;
            MyToolbar.Width = n * 40;
            InitializeComponent();
            Window_Loaded();
            Initialise();
            /*Random();
            Initialise_Label();
            Modify_Label();*/
        }
    }
}
