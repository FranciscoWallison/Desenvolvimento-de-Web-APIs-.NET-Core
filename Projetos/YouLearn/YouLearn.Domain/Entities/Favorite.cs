using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorite : EntityBase
    {        
        public Video Video { get; set; }
        public User User { get; set; }
    }
}