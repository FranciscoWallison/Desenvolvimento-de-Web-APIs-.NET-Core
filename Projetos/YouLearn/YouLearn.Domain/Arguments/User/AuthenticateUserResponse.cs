using System;

namespace YouLearn.Domain.Arguments.User
{
    public class AuthenticateUserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
    }
    
}