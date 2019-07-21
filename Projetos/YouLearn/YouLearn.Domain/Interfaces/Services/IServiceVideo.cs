using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceVideo : IServiceBase
    {
        AddVideoResponse AddVideo(AddVideoRequest request, Guid idUser);
        IEnumerable<VideoResponse> List(string tags);
        IEnumerable<VideoResponse> List(Guid idPlayList);
    }
}
