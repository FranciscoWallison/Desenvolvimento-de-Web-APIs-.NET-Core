using System;
using YouLearn.Domain.Arguments.User;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        AddUserResponse AddUser(AddUserRequest request);

        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
    
}