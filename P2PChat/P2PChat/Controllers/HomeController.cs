using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2PChat.Models;

namespace P2PChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService userService;

        public HomeController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(string username)
        {
            if (userService.DoesUserExist(username))
            {
                var currentUser = userService.FindUserByUsername(username);
                return RedirectToAction("mainpage", new { id = currentUser.ID });
            }
            else
            {
                var newUser = userService.AddUserToDatabase(username);
                return RedirectToAction("mainpage", new { newUser.ID});
            }
        }

        [HttpPost("send/{id}")]
        public IActionResult SendMessage([FromRoute ] long Id, string text)
        {
            userService.AddMessage(Id, text);
            return RedirectToAction("mainpage", new { Id });
        }

        [HttpGet("mainpage/{id}")]
        public IActionResult MainPage(long id)
        {
            var user = userService.GetUserByID(id);
            user.Messages = userService.GetMessages(id);
            return View(user);
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(string username)
        {
            var user = userService.AddUserToDatabase(username);
            return RedirectToAction("mainpage", new { user.ID });
        }
    }
}