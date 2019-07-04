using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ObjectValue
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;   

            new AddNotifications<Name>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES
                    .ToFormat("Primeiro nome", 1, 50))
                .IfNullOrInvalidLength(x => x.LastName, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES
                    .ToFormat("Sobre nome", 1, 50));

                     
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}