using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryChannel
    {
        IEnumerable<Channel> List(Guid idUser);
        Channel Get(Guid idChannel);
        Channel Add(Channel channel);
        void Delete(Channel channel);
    }
}
