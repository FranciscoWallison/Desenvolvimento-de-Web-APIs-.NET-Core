using System;

namespace YouLearn.Domain.Entities
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Video Video { get; set; }
        public User User { get; set; }
    }
}