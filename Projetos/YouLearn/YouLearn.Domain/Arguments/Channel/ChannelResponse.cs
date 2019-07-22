using System;

namespace YouLearn.Domain.Arguments.Channel
{
    public class ChannelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlLogo { get; set; }

        public static explicit operator ChannelResponse(Entities.Channel entidade)
        {
            return new ChannelResponse()
            {
                Id = entidade.Id,
                Name = entidade.Name,
                UrlLogo = entidade.UrlLogo
            };
        }
    }
}
