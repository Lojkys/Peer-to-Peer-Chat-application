using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2PChat.Models;

namespace P2PChat.Controllers.API
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserService userService;

        public ValuesController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("message/receive")]
        public ActionResult Messages()
        {
            var list = userService.GetAllMessages();
            return Ok(new { message = list });
        }
    }
}