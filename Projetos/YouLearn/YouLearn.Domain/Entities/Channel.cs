using System;

namespace YouLearn.Domain.Entities
{
    public class Channel
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string UrlLogo { get; set; }        

    }
}
