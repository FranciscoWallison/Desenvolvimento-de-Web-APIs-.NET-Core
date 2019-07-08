using System;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly YouLearnContext _context;

        public RepositoryUser(YouLearnContext context)
        {
            _context = context;
        }

        public bool Exist(string email)
        {
            return _context.Users.Any(x => x.Email.Address == email);
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Get(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email.Address == email && x.Password == password);
        }

        public void ToSave(User user)
        {
            _context.Users.Add(user);
        }
    }
}
