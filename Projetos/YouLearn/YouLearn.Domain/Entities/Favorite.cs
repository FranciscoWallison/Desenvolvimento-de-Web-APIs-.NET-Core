using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities : EntityBase
{
    public class Favorite
    {        
        public Video Video { get; set; }
        public User User { get; set; }
    }
}