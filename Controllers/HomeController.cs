using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tacocat_Core.Models;

namespace Tacocat_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        //HttpGet
        public IActionResult Solve()
        {
            ViewData["IsPalindrome"] = "";
            return View();
        }
        

        [HttpPost]
        public IActionResult Solve(string userWord)
        {
            var userWordNoSpace = userWord.Replace(" ", "").ToLower();
            var reverseWord = string.Join("", userWordNoSpace.Reverse().ToArray());
            if(reverseWord == userWordNoSpace)
            {
                ViewData["Result"] = userWord;
            } else
            {
                ViewData["Result"] = string.Join("", userWord.Reverse().ToArray());
            }
            ViewData["IsPalindrome"] = userWordNoSpace == reverseWord ? "success" : "fail";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
