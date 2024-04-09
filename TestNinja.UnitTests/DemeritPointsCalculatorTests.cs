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
    public class DemeritPointsCalculatorTests
    {

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        [Category("Unit")]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        [Category("Unit")]
        public void CalculateDemeritPoints_SpeedIsGreaterOrEqualThanZero_ReturnsDemeritPoints(int speed, int points)
        {
            var calculator = new DemeritPointsCalculator();
            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(points));
        }

    }
}
