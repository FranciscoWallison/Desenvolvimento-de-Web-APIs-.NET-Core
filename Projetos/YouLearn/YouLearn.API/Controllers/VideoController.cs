using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Channel;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers
{
    public class VideoController : Base.ControllerBase
    {
        private readonly IServiceVideo _serviceVideo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideoController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServiceVideo serviceVideo) : base(unityOfWork)
        {
            _serviceVideo = serviceVideo;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/List/{tags}")]
        public async Task<IActionResult> List(string tags)
        {
            try
            {
                var response = _serviceVideo.List(tags);
                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/Video/List/{idPlayList:Guid}")]
        public async Task<IActionResult> List(Guid idPlayList)
        {
            try
            {
                var response = _serviceVideo.List(idPlayList);
                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/Video/Add")]
        public async Task<IActionResult> Add([FromBody]AddVideoRequest request)
        {
            try
            {
                string userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AuthenticateUserResponse userResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse>(userClaims);

                var response = _serviceVideo.AddVideo(request, userResponse.Id);

                return await ResponseAsync(response, _serviceVideo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
