using MintyIssueTracker.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TokenStady.Controller
{
    [RoutePrefix("api/image")]
    public class AuthenticationController : ApiController
    {
        public AuthenticationController()
        {

        }
        // POST api/users/register
        [HttpPost, Route("register")]
        public async Task<HttpResponseMessage> RegisterAsync([FromBody] UserRegistrationModel userModel)
        {
            var result ="";
            if (ModelState.IsValid)
            {
                result = TokenProvider.TokenProvider.GenerateToken(userModel);
            }
            return Request.CreateResponse(HttpStatusCode.BadGateway, result);
        }
    }
}
