using System;

namespace YouLearn.Domain.Arguments.User
{
    public class AuthenticateUserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public static explicit operator AuthenticateUserResponse(Entities.User entitie)
        {
            return new AuthenticateUserResponse() {
                Id = entitie.Id,
                FirstName = entitie.Name.FirstName
            };
        }
    }
    
}