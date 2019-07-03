using System;
using YouLearn.Domain.ObjectValue;

namespace YouLearn.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
    }
}