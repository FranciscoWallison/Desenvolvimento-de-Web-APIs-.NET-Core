using System;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public EnumStatus Status { get; set; }
    }
}