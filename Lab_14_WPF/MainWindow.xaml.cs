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

namespace Lab_14_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            Button01.FontSize = 30;
            Button01.Content = "Collapsed";
            Button01.Background = Brushes.Pink;
            Button01.MouseRightButtonDown += Button01_right;
            //Button01.Visibility = Visibility.Collapsed;
        }

        static int counter = 0;

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            Label01.FontSize = 30;
            Label01.Padding = new System.Windows.Thickness(-100);
            Label01.HorizontalContentAlignment = HorizontalAlignment.Center;
            Label01.VerticalContentAlignment = VerticalAlignment.Center;
            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri(
                         "C:\\c-\\Lab_14_WPF\\download.jpg"));
            Label01.Content = "5";// $"You clicked {counter} times";
            ListBox01.Items.Add($"You clicked {counter} times");
            Label01.Content = Img;
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            Label01.Content = $"You clicked {counter} times";
            ListBox01.Items.Clear();
        }

        private void Toolbar_Click(object sender, RoutedEventArgs e)
        {
            Button01.Content = "K";
        }

        private void Button01_right(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed && Button01.Content.ToString() == "X")
            {
                Button01.Content = "";
                return;
            }
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Button01.Content = "X";
                return;
            }
        }
    }
}
