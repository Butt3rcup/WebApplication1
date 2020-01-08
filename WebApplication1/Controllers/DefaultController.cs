using Microsoft.AspNetCore.Mvc;
using WebApplication1.InterFace;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IUserInfoService _UserInfoService;

        public DefaultController(IUserInfoService userInfoService)
        {
            this._UserInfoService = userInfoService;
        }

        public IActionResult Get()
        {
            string[] strings = _UserInfoService.GetUsers();
            return Ok(strings);
        }
    }
}
