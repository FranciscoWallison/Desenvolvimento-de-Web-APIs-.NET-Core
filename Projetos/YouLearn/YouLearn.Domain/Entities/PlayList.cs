using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        protected PlayList()
        {

        }
        public PlayList(string name, User user)
        {
            Name = name;
            User = user;

            new AddNotifications<PlayList>(this).IfNullOrInvalidLength(x => x.Name, 2, 100);

            AddNotifications(user);
        }
        public string Name { get; private set; }
        public User User { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}