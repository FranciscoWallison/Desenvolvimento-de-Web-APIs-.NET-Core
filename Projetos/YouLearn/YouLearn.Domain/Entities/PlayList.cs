using System;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {       
        public User User { get; set; }
        public EnumStatus Status { get; set; }
    }
}