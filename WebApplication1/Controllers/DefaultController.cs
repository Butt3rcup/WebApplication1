using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Http;
using WebApplication1.InterFace;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IUserInfoService _UserInfoService;

        private readonly HttpClienService HttpClienService;


        public DefaultController(IUserInfoService userInfoService, HttpClienService httpClienService)
        {
            _UserInfoService = userInfoService;
            HttpClienService = httpClienService;
        }







        public async Task<IActionResult> Get()
        {




            var temp = await _UserInfoService.GetUsers();

           temp.AsSpan();
            var jsonData = new { code = 200, meg = "ok", date = temp };

            var json = new JsonResult(jsonData);
            return json;


        }





        public async Task<IActionResult> Get1()
        {







            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"name", "as"}};





            string task = await HttpClienService.Get(dictionary, "https:www.baidu.com,", null);

            //Task<string> content = HttpClienService.GetContent("https://www.baidu.com");
            //var contentResult = content.Result;


            return Ok("200");
        }



       

    }
}
