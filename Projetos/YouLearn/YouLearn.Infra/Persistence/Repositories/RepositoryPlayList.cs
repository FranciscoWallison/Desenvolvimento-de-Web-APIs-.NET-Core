using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryPlayList
    {

        private readonly YouLearnContext _context;

        public RepositoryPlayList(YouLearnContext context)
        {
            _context = context;
        }

        public PlayList Add(PlayList playList)
        {
            _context.PlayLists.Add(playList);

            return playList;
        }

        public void Delete(PlayList playList)
        {
            _context.PlayLists.Remove(playList);
        }

        public IEnumerable<PlayList> List(Guid idUser)
        {
            return _context.PlayLists.Where(x => x.User.Id == idUser).ToList();
        }

        public PlayList Obter(Guid idPlayList)
        {
            return _context.PlayLists.FirstOrDefault(x => x.Id == idPlayList);
        }
    }
}
