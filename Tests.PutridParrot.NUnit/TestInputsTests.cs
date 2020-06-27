using System;
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
            try
            {
                Statistics.Mean(values);
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.True(false);
            }
        }

        [TestInputs]
        public void Median(double[] values)
        {
            // this should fail with a null sequence
            // this should fail with an empty sequence
            try
            {
                Statistics.Median(values);
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.True(false);
            }
        }

        [TestInputs]
        public void Mode(double[] values)
        {
            // this should fail with a null sequence
            // this should fail with an empty sequence
            try
            {
                Statistics.Mode(values);
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.True(false);
            }
        }
    }
}
