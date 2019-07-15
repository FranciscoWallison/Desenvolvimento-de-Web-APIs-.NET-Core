using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Welcome to YouLearn";
        }

        [HttpGet]
        [Route("Version")]
        public string Versao()
        {
            return "Version : 0.0.1";
        }

    }
}
