using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideosRepository _videosRepository;

        public VideoService(IFileReader fileReader = null, IVideosRepository videosReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videosRepository = videosReader ?? new VideosRepository();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
              
            foreach (var v in _videosRepository.GetUnprocessedVideos())
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);

        }



    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}