using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {

        protected Video()
        {

        }
        public Video(Channel channel, PlayList playList, string title, string description, string tags, int? orderPlayList, string idVideoYoutube, User userSuggested)
        {
            Channel = channel;
            PlayList = playList;
            Title = title;
            Description = description;
            Tags = tags;
            OrderPlayList = orderPlayList.HasValue ? orderPlayList.Value : 0;
            IdVideoYoutube = idVideoYoutube;
            UserSuggested = userSuggested;
            Status = EnumStatus.InAnalysis;

            new AddNotifications<Video>(this)
                .IfNullOrInvalidLength(x => x.Title, 1, 200, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Titulo", "1", "200"))
                .IfNullOrInvalidLength(x => x.Description, 1, 255, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "255"))
                .IfNullOrInvalidLength(x => x.Tags, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Tag", "1", "100"))
                .IfNullOrInvalidLength(x => x.IdVideoYoutube, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Id do Youtube", "1", "50"))
            ;

            AddNotifications(channel);

            if (playList != null)
            {
                AddNotifications(playList);
            }
        }


        public Channel Channel { get; private set; }
        public PlayList PlayList { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Tags { get; private set; }
        public int OrderPlayList { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public User UserSuggested { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}