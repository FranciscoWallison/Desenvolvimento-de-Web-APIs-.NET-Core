using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Interfaces.Services.Base;


namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceChannel : IServiceBase
    {
        IEnumerable<ChannelResponse> List(Guid idUser);
        ChannelResponse AddChannel(AddChannelRequest request, Guid idUser);
        Response DeleteChannel(Guid idChannel);
    }
    
}