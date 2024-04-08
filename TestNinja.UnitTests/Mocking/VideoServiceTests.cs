using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideosRepository> _videosRepository;
        private List<Video> Videos;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videosRepository = new Mock<IVideosRepository>();
            _videoService = new VideoService(_fileReader.Object, _videosRepository.Object);
            Videos = new List<Video> { new Video { Id = 1, IsProcessed = false, Title = "pelicula1" }
                                      ,new Video { Id = 2, IsProcessed = false, Title = "pelicula2" }
                                      ,new Video { Id = 3, IsProcessed = false, Title = "pelicula3" }};

        }



        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
           
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }


        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideos_ReturnsEmptyList()
        {
            _videosRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_Read3VideosList_ReturnsList()
        {
            _videosRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(Videos);
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));

        }

    }
}
