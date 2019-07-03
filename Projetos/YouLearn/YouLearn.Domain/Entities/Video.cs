using System;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class Video
    {
        public Guid Id { get; set; }
        public Channel Channel { get; set; }
        public PlayList PlayList { get; set; }
        public User UserSuggested { get; set; }
        public EnumStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int OrderPlayList { get; set; }
        public string IdVideoYoutube { get; set; }        
    }
}