using System;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void ToSave(User user)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string email)
        {
            throw new NotImplementedException();
        }
    }
}