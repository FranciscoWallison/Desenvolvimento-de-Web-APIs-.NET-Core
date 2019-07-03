using System;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        User Get(Guid id);
        User Get(string email, string password);

        void ToSave(User user);
        bool Exist(string email);

    }
    
}