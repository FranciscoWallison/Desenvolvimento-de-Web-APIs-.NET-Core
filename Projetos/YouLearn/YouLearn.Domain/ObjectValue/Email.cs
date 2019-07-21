using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ObjectValue
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string address)
        {
            Address = address;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Address, MSG.X0_INVALIDO
                    .ToFormat("E-mail"));
            
        }

       public string Address { get; private set; }
    }
}