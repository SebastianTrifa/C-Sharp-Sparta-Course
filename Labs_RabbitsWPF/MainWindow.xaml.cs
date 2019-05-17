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
using System.Diagnostics;

namespace Labs_RabbitsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int population = 10000;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            Label01.Content = "Rabbit explosion";
            Label02.Content = $"Up to population {population}";
            Label03.Content = Rabbit.Growth(population);
        }
    }
        public class Rabbit
        {
            public static int Growth(int population)
            {
                var csv = new StringBuilder();
                List<Rabbit> pop = new List<Rabbit>();
                Rabbit rabbit = new Rabbit();
                pop.Add(rabbit);
                Stopwatch stopWatch = new Stopwatch();
                TimeSpan ts = new TimeSpan();
                stopWatch.Start();
                int step = 0;
                //csv.AppendLine($"Time(seconds),Population");
                while (pop.Count < population)
                {
                    int j = pop.Count;
                    for (int i = 1; i <= j; i++)
                    {
                        rabbit = new Rabbit();
                        pop.Add(rabbit);
                    }
                    Console.WriteLine(pop.Count);
                    ++step;
                    //csv.AppendLine($"{step},{pop.Count}");
                    while (ts.Seconds < step)
                    { ts = stopWatch.Elapsed;
                    }
                }
                ts = stopWatch.Elapsed;
                Console.WriteLine(ts.Seconds);
            return ts.Seconds;
        }
    }
}
