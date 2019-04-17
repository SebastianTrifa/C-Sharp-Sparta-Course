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
            Button01.FontSize = 40;
        }

        static int counter = 0;

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            Label01.Content = $"You clicked {counter} times";
            ListBox01.Items.Add($"You clicked {counter} times");
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            Label01.Content = $"You clicked {counter} times";
            ListBox01.Items.Clear();
        }
    }
}
