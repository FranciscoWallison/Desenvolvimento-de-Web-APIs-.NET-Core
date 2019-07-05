using System;
using YouLearn.Domain.ObjectValue;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Extensions;
using prmToolkit.NotificationPattern;

namespace YouLearn.Domain.Entities
{
    public class User : EntityBase
    {

        protected User()
        {

        }

        public User(Email email, string password)
        {
            Email = email;
            Password = password;

            Password = Password.ConvertToMD5();

            AddNotifications(Email);
        }

        public User(Name name, Email email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            
            new AddNotifications<User>(this).
                IfNullOrInvalidLength(x=> x.Password, 3, 32);

            // Password = Password
            Password = Password.ConvertToMD5();

            AddNotifications(Name, Email);
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
    }
}