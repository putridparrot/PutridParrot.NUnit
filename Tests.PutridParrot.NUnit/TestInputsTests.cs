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
    public class TestInputsTests
    {
        [TestInputs]
        public void Mean(double[] values)
        {
            // this should fail with a null sequence
            // this should fail with an empty sequence
            Statistics.Mean(values);
        }

        [TestInputs]
        public void Median(double[] values)
        {
            // this should fail with a null sequence
            // this should fail with an empty sequence
            Statistics.Median(values);
        }

        [TestInputs]
        public void Mode(double[] values)
        {
            // this should fail with a null sequence
            // this should fail with an empty sequence
            Statistics.Mode(values);
        }
    }
}
