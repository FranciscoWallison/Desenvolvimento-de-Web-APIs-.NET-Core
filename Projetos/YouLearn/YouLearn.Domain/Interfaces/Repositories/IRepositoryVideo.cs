using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo
    {
        void Add(Video video);
        IEnumerable<Video> List(string tags);
        IEnumerable<Video> List(Guid idPlayList);
        bool ThereIsAssociatedChannel(Guid idCanal);
        bool ThereIsAssociatePlayList(Guid idPlayList);
    }
}