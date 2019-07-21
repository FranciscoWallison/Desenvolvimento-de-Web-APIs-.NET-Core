using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryChannel _repositoryChannel;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryVideo _repositoryVideo;

        public ServiceVideo(IRepositoryUser repositoryUser, IRepositoryChannel repositoryChannel, IRepositoryPlayList repositoryPlayList, IRepositoryVideo repositoryVideo)
        {
            _repositoryUser = repositoryUser;
            _repositoryChannel = repositoryChannel;
            _repositoryPlayList = repositoryPlayList;
            _repositoryVideo = repositoryVideo;
        }

        public AddVideoResponse AddVideo(AddVideoRequest request, Guid idUser)
        {
            if (request == null)
            {
                AddNotification("AdicionarVideoRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarVideoRequest"));
                return null;
            }

            User user = _repositoryUser.Get(idUser);
            if (user == null)
            {
                AddNotification("User", MSG.X0_NAO_INFORMADO.ToFormat("Usuário"));
                return null;
            }

            Channel channel = _repositoryChannel.Get(request.IdChannel);
            if (channel == null)
            {
                AddNotification("Canal", MSG.X0_NAO_INFORMADO.ToFormat("Canal"));
                return null;
            }

            PlayList playList = null;
            if (request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Get(request.IdPlayList);
                if (playList == null)
                {
                    AddNotification("PlayList", MSG.X0_NAO_INFORMADA.ToFormat("playList"));
                    return null;
                }
            }

            var video = new Video(channel, playList, request.Title, request.Description, request.Tags, request.OrderPlayList, request.IdVideoYoutube, user);

            AddNotifications(video);

            if (this.IsInvalid()) return null;

            _repositoryVideo.Add(video);

            return new AddVideoResponse(video.Id);
        }

        public IEnumerable<VideoResponse> List(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.List(tags);

            var response = videoCollection.ToList().Select(entidade => (VideoResponse)entidade);

            return response;
        }

        public IEnumerable<VideoResponse> List(Guid idPlayList)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.List(idPlayList);

            var response = videoCollection.OrderBy(x => x.OrderPlayList).ToList().Select(entidade => (VideoResponse)entidade);

            return response;
        }
    }
}
