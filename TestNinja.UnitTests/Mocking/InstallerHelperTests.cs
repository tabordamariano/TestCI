using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> fileDownloader;
        private InstallerHelper installerHelper;

        [SetUp]
        public void Setup() 
        {
            fileDownloader = new Mock<IFileDownloader>();
            installerHelper = new InstallerHelper(fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            //var installerHelper = new InstallerHelper(fileDownloader.Object);

            var result = installerHelper.DownloadInstaller("customer", "installer");


            Assert.That(result, Is.False);

        }

        [Test]
        public void DownloadInstaller_DownloadCompleted_ReturnsFalse()
        {

            var result = installerHelper.DownloadInstaller("customer", "installer");


            Assert.That(result, Is.True);

        }
    }
}
