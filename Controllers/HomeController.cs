using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quotingDojo.Models;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddQuote")]
        public IActionResult AddQuote(Quote newQuote){
            if (ModelState.IsValid){
                string query = $"INSERT INTO quotes (name, content, created_at, updated_at) VALUES ('{newQuote.name}', '{newQuote.content}', now(), now())";
                DbConnector.Execute(query);
                System.Console.WriteLine("*************************");
                System.Console.WriteLine(newQuote.name);
                System.Console.WriteLine(newQuote.content);
                return RedirectToAction("AllQuotes");
            } else {
                return View("Error");
            }
        }

        [HttpGet("quotes")]
        public IActionResult AllQuotes(){
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.Quotes = AllQuotes;
            return View();
        }
    }
}
