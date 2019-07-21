using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceChannel : Notifiable, IServiceChannel
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryChannel _repositoryChanner;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceChannel(IRepositoryUser repositoryUser, IRepositoryChannel repositoryChannel/*, IRepositoryVideo repositoryVideo*/)
        {
            _repositoryUser = repositoryUser;
            _repositoryChanner = repositoryChannel;
            //_repositoryVideo = repositoryVideo;
        }

        public ChannelResponse AddChannel(AddChannelRequest request, Guid idUser)
        {
            User user = _repositoryUser.Get(idUser);

            Channel channel = new Channel(request.Name, request.UrlLogo, user);

            AddNotifications(channel);

            if (this.IsInvalid()) return null;

            channel = _repositoryChanner.Add(channel);

            return (ChannelResponse)channel;

        }

        public Response DeleteChannel(Guid idChannel)
        {
            bool existe = _repositoryVideo.ThereIsAssociatedChannel(idChannel);

            if (existe)
            {
                AddNotification("Canal", MSG.NAO_E_POSSIVEL_EXCLUIR_UM_X0_ASSOCIADO_A_UM_X1.ToFormat("canal", "vídeo"));
                return null;
            }

            Channel channel = _repositoryChanner.Get(idChannel);

            if (channel == null)
            {
                AddNotification("Canal", MSG.DADOS_NAO_ENCONTRADOS);
            }

            if (IsInvalid()) return null;

            _repositoryChanner.Delete(channel);

            return new Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<ChannelResponse> List(Guid idUser)
        {
            IEnumerable<Channel> canalCollection = _repositoryChanner.List(idUser);

            var response = canalCollection.ToList().Select(entidade => (ChannelResponse)entidade);

            return response;
        }

    }
}
