using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryVideo : IRepositoryVideo
    {
        private readonly YouLearnContext _context;

        public RepositoryVideo(YouLearnContext context)
        {
            _context = context;
        }

        public void Add(Video video)
        {
            _context.Videos.Add(video);
        }

        public IEnumerable<Video> List(string tags)
        {
            var query = _context.Videos.Include(x => x.Channel).Include(x => x.PlayList).AsQueryable();

            tags.Split(' ').ToList().ForEach(tag => {
                query = query.Where(x => x.Tags.Contains(tag) || x.Title.Contains(tag) || x.Description.Contains(tag));
            });

            return query.ToList();
        }

        public IEnumerable<Video> List(Guid idPlayList)
        {
            return _context.Videos.Include(x => x.Channel).Include(x => x.PlayList)
                .Where(x => x.PlayList.Id == idPlayList).ToList();
        }

        public bool ThereIsAssociatedChannel(Guid idChannel)
        {
            return _context.Videos.Any(x => x.Channel.Id == idChannel);
        }

        public bool ThereIsAssociatedPlayList(Guid idPlayList)
        {
            return _context.Videos.Any(x => x.PlayList.Id == idPlayList);
        }
    }
}
