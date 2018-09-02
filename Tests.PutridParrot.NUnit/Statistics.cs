using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PutridParrot.NUnit
{
    public static class Statistics
    {
        public static double Mean(double[] values)
        {
            return values.Average();
        }

        public static double Median(double[] values)
        {
            Array.Sort(values);

            int mid = values.Length / 2;
            return (values.Length % 2 == 0) ?
                (values[mid - 1] + values[mid]) / 2 :
                values[mid];
        }

        public static double[] Mode(double[] values)
        {
            var grouped = values.GroupBy(v => v).OrderBy(g => g.Count());
            int max = grouped.Max(g => g.Count());

            return (max <= 1) ?
                new double[0] :
                grouped.Where(g => g.Count() == max).Select(g => g.Key).ToArray();
        }
    }

}
