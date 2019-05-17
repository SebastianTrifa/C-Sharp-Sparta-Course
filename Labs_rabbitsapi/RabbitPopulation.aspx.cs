using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Text;

namespace Labs_rabbitsapi
{
    public partial class RabbitPopulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = $"Results : {Rabbit.Growth(Int32.Parse(TextBox1.Text))}";
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
                {
                    ts = stopWatch.Elapsed;
                }
            }
            ts = stopWatch.Elapsed;
            Console.WriteLine(ts.Seconds);
            return ts.Seconds;
        }
    }
}