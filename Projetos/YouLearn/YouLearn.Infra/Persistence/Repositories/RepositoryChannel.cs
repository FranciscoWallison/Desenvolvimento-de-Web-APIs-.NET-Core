using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryChannel : IRepositoryChannel
    {
        private readonly YouLearnContext _context;

        public RepositoryChannel(YouLearnContext context)
        {
            _context = context;
        }

        public Channel Add(Channel channel)
        {
            _context.Channels.Add(channel);

            return channel;
        }

        public void Delete(Channel channel)
        {
            _context.Channels.Remove(channel);
        }

        public IEnumerable<Channel> List(Guid idUser)
        {
            return _context.Channels.Where(x => x.User.Id == idUser).ToList();
        }

        public Channel Get(Guid idChannel)
        {
            return _context.Channels.FirstOrDefault(x => x.Id == idChannel);
        }
    }
}
