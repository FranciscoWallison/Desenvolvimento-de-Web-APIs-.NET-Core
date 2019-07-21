using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServicePlayList(IRepositoryUser repositoryUser, IRepositoryPlayList repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryUser = repositoryUser;
            _repositoryPlayList = repositoryPlayList;
            _repositoryVideo = repositoryVideo;
        }
        public PlayListResponse AddPlayList(AddPlayListRequest request, Guid idUser)
        {
            User user = _repositoryUser.Get(idUser);

            PlayList playList = new PlayList(request.Name, user);

            AddNotifications(playList);

            if (this.IsInvalid()) return null;

            playList = _repositoryPlayList.Add(playList);

            return (PlayListResponse)playList;
        }

        public Arguments.Base.Response DeletePlayList(Guid idPlayList)
        {
            bool existe = _repositoryVideo.ThereIsAssociatePlayList(idPlayList);

            if (existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Playlist", "vídeo"));
                return null;
            }

            PlayList playList = _repositoryPlayList.Get(idPlayList);

            if (playList == null)
            {
                AddNotification("PlayList", MSG.DADOS_NAO_ENCONTRADOS);
            }

            if (this.IsInvalid()) return null;

            _repositoryPlayList.Delete(playList);

            return new Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<PlayListResponse> List(Guid idUser)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.List(idUser);

            var response = playListCollection.ToList().Select(entidade => (PlayListResponse)entidade);

            return response;
        }
    }
}
