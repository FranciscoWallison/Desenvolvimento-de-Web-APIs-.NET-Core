using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Channel : EntityBase
    {

        protected Channel()
        {

        }
        public Channel(string name, string urlLogo, User user)
        {
            Name = name;
            UrlLogo = urlLogo;
            User = user;

            //new AddNotifications<Canal>(this)
            //    .IfNullOrInvalidLength(x => x.Nome, 2, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "50"))
            //    .IfNullOrInvalidLength(x => x.UrlLogo, 4, 200, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("4", "200"));

            new AddNotifications<Channel>(this).IfNullOrInvalidLength(x => x.Name, 2, 50)
                                              .IfNullOrInvalidLength(x => x.UrlLogo, 4, 200);
            AddNotifications(user);
        }

        public User User { get; set; }
        public string Name { get; set; }
        public string UrlLogo { get; set; }
        
    }
}
