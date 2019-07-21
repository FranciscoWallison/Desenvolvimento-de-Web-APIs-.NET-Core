using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class ChannelController : Base.ControllerBase
    {
        private readonly IServiceChannel _serviceChannel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChannelController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServiceChannel serviceChannel) : base(unityOfWork)
        {
            _serviceChannel = serviceChannel;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/Channel/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                var response = _serviceChannel.List(userResponse.Id);

                return await ResponseAsync(response, _serviceChannel);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);

            }
        }

        [HttpPost]
        [Route("api/v1/Channel/Add")]
        public async Task<IActionResult> Add([FromBody]AddChannelRequest request)
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                var response = _serviceChannel.AddChannel(request, userResponse.Id);

                return await ResponseAsync(response, _serviceChannel);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/Channel/Delete/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var response = _serviceChannel.DeleteChannel(id);

                return await ResponseAsync(response, _serviceChannel);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
