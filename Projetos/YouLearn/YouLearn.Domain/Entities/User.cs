using System;
using YouLearn.Domain.ObjectValue;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities : EntityBase
{
    public class User
    {       
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
    }
}