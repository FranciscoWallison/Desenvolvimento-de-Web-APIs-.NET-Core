using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NameChannel { get; set; }
        public Guid? IdPlayList { get; set; }
        public string NamePlayList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string IdVideoYoutube { get; set; }
        public int OrderPlayList { get; set; }
        public string Url { get; set; }

        public static explicit operator VideoResponse(Entities.Video entidade)
        {
            return new VideoResponse()
            {
                Description = entidade.Description,
                Url = string.Concat("https://www.youtube.com/embed/", entidade.IdVideoYoutube),
                NameChannel = entidade.Channel.Name,
                IdVideoYoutube = entidade.IdVideoYoutube,
                Thumbnail = string.Concat("https://img.youtube.com/vi/", entidade.IdVideoYoutube, "/mqdefault.jpg"),
                Title = entidade.Title,
                IdPlayList = entidade.PlayList?.Id,
                NamePlayList = entidade.PlayList?.Name,
                OrderPlayList = entidade.OrderPlayList
            };
        }
    }
}
