using System;

namespace YouLearn.Domain.Arguments.User
{
    public class AuthenticateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}