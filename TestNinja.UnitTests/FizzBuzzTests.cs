using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture(Category = "Unit")]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15,"FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(7, "7")]
        [Category("Unit")]
        public void GetOutput_WhenCalled_ReturnsCorrectResult(int input, string expectedResult)
        {

            var result = FizzBuzz.GetOutput(input);
            Assert.That(result, Is.EqualTo(expectedResult));

        }

    }
}
