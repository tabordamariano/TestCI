using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture(Category = "Unit")]
    public class HousekeeperHelperTests
    {
        public List<Housekeeper> houseKeepers;

        [SetUp]
        public void SetUp()
        {
            houseKeepers = new List<Housekeeper> {
                new Housekeeper { Email = "h1@gmail.com", FullName = "h1", Oid = 1, StatementEmailBody = "statement"},
                new Housekeeper { Email = "h2@gmail.com", FullName = "h2", Oid = 2, StatementEmailBody = "statement"},
                new Housekeeper { Email = "h3@gmail.com", FullName = "h3", Oid = 3, StatementEmailBody = "statement"}
            };
        }

        [Test]
        public void SendStatementEmails_NoHousekeepers_ReturnsTrue()
        {
            var fileSaver = new Mock<IFileSaver>();
            fileSaver.Setup(f => f.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("filename");

            var emailSender = new Mock<IEmailSender>();
            emailSender.Setup(e => e.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var repository = new Mock<IHousekeeperRepository>();
            repository.Setup(r => r.GetHousekeepers()).Returns(new List<Housekeeper>().AsQueryable);

            var houseKeeperHelper = new HousekeeperHelper(fileSaver.Object, emailSender.Object);

            
            Assert.That(houseKeeperHelper.SendStatementEmails(DateTime.Now), Is.True);

            fileSaver.Verify(r => r.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()),Times.Never);

        }


        [Test]
        public void SendStatementEmails_HousekeepersInList_ReturnsTrue()
        {
            var fileSaver = new Mock<IFileSaver>();
            fileSaver.Setup(f => f.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("filename");

            var emailSender = new Mock<IEmailSender>();
            emailSender.Setup(e => e.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var repository = new Mock<IHousekeeperRepository>();
            repository.Setup(r => r.GetHousekeepers()).Returns(houseKeepers.AsQueryable);

            var houseKeeperHelper = new HousekeeperHelper(fileSaver.Object, emailSender.Object, repository.Object);
                        
            Assert.That(houseKeeperHelper.SendStatementEmails(DateTime.Now), Is.True);

            fileSaver.Verify(r => r.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));

        }
    }
}
