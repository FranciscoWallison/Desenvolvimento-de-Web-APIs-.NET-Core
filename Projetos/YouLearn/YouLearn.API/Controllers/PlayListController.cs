using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class PlayListController : Base.ControllerBase
    {
        private readonly IServicePlayList _servicePlayList;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayListController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServicePlayList servicePlayList) : base(unityOfWork)
        {
            _servicePlayList = servicePlayList;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("api/v1/PlayList/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                var response = _servicePlayList.List(userResponse.Id);
                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/PlayList/Add")]
        public async Task<IActionResult> Add([FromBody]AddPlayListRequest request)
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                var response = _servicePlayList.AddPlayList(request, userResponse.Id);

                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/PlayList/Delete/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = _servicePlayList.DeletePlayList(id);

                return await ResponseAsync(response, _servicePlayList);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
