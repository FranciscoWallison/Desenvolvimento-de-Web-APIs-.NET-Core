using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorite : EntityBase
    {
        protected Favorite(){}
        public Video Video { get; set; }
        public User User { get; set; }
    }
}