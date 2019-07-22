using System;

namespace YouLearn.Domain.Arguments.PlayList
{
    public class PlayListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator PlayListResponse(Entities.PlayList entidade)
        {
            return new PlayListResponse()
            {
                Id = entidade.Id,
                Name = entidade.Name
            };
        }
    }
}
