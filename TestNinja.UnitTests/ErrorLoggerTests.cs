using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {

        [Test]
        [TestCase("a")]        
        public void Log_WhenValidTextIsPassed_SetTheLastErrorProperty(string? error)
        {
            var logger = new ErrorLogger();

            logger.Log(error);

            Assert.That(logger.LastError, Is.EqualTo(error));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" " )]
        public void Log_WhenNoValidTextIsPassed_SetTheLastErrorProperty(string? error)
        {
            var logger = new ErrorLogger();

            //logger.Log(error);

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

            //Assert.That(logger.LastError, Is.EqualTo(error));
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;

            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

    }
}
