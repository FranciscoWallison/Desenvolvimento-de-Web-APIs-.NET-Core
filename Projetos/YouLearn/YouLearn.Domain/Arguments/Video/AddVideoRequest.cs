using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Video
{
    public class AddVideoRequest
    {
        public Guid IdChannel { get; set; }
        public Guid IdPlayList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public Nullable<int> OrderPlayList { get; set; }
        public string IdVideoYoutube { get; set; }
    }
}
