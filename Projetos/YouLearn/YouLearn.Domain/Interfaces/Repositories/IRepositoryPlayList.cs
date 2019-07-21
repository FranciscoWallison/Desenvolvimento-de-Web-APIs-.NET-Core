using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        IEnumerable<PlayList> List(Guid idUsuario);
        PlayList Get(Guid idPlayList);
        PlayList Add(PlayList playList);
        void Delete(PlayList playList);
    }
}
