using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServicePlayList : IServiceBase
    {
        IEnumerable<PlayListResponse> List(Guid idUser);
        PlayListResponse AddPlayList(AddPlayListRequest request, Guid idUser);
        Response DeletePlayList(Guid idPlayList);
    }
}
