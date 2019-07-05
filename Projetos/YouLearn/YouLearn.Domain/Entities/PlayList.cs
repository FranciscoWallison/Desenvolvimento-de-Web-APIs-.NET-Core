using System;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {   
        public string Name { get; private set; }
        public User User { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}