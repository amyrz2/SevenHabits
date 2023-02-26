using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SevenHabits.Models;
using SevenHabits.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SevenHabits.Controllers
{
    public class HomeController : Controller
    {
        private ContextClass blahContext { get; set; }

        public HomeController(ContextClass someName)
        {
            blahContext = someName;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            var applications = blahContext.habits
            .Include(x => x.Category)
            .ToList();

            return View(applications);
        }


        [HttpGet]
        public IActionResult AddTask()
        {

            ViewBag.Categories = blahContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskForm ar)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(ar);
                blahContext.SaveChanges();
                return View("Confirmation", ar);
            }

            else //If Invalid
            {
                ViewBag.Categories = blahContext.Categories.ToList();
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            var application = blahContext.habits.Single(x => x.TaskID == taskid);

            return View("AddTask", application);
        }

        [HttpPost]
        public IActionResult Edit(TaskForm blah)
        {
            blahContext.Update(blah);
            blahContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Delete(int taskid)
        {

            var application = blahContext.habits.Single(x => x.TaskID == taskid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(TaskForm ar)
        {
            blahContext.habits.Remove(ar);
            blahContext.SaveChanges();
            return RedirectToAction("Delete");
        }

    }
}

