using System;

namespace YouLearn.Domain.Arguments.User
{
    public class AddUserRequest
    {
        public AddUserResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
    
}