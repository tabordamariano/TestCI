using NUnit.Framework;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture(Category = "Unit")]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("Unit")]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy( new User{ IsAdmin = true});

            //Act

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [Category("Unit")]
        public void CanBeCancelledBy_NotAdminCancelling_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Act

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [Category("Unit")]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation { MadeBy = user };
            
            var result = reservation.CanBeCancelledBy(user);

            //Act

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [Category("Unit")]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false});

            //Act

            //Assert
            Assert.That(result, Is.False);
        }
    }
}