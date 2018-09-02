using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.NUnit;

namespace Tests.PutridParrot.NUnit
{
    // demo of using the TestInputs attribute
    // by default each test should create multiple
    // test cases, two of which will be failures
    // as our Statistics methods do not handle null
    // or empty arrays
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class StatisticsTests
    {
        [TestInputs]
        public void Mean(double[] values)
        {
            Statistics.Mean(values);
        }

        [TestInputs]
        public void Median(double[] values)
        {
            Statistics.Median(values);
        }

        [TestInputs]
        public void Mode(double[] values)
        {
            Statistics.Mode(values);
        }
    }

}
