using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities : EntityBase
{
    public class Channel
    {
        
        public User User { get; set; }
        public string Name { get; set; }
        public string UrlLogo { get; set; }        

    }
}
