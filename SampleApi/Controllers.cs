using DataContract;
using System;
using System.Web.Http;

namespace SampleApi
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public LoginResponse Login(LoginRequest request)
        {
            return new LoginResponse() {
                IsSuccess = true,
                TimeUtc = DateTime.UtcNow
            };
        }
    }
}