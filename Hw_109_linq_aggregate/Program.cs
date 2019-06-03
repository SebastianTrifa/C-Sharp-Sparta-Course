using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_109_linq_aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class LinqAggregate
    {
        public static int LinqAggregateSum(int[] array)
        {
            return array.Aggregate((a,b)=>a+b);
        }

        public static string[] LinqUnion(string[] array1, string[] array2)
        {
            return array1.Union(array2).ToArray();
        }

        public static string[] LinqIntersect(string[] array1, string[] array2)
        {
            return array1.Intersect(array2).ToArray();
        }
    }
}
