using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using СonferenceWeb.Context;
using СonferenceWeb.Entities;
using СonferenceWeb.ViewModels;

namespace СonferenceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConferenceDbContext _context;

        public HomeController(ConferenceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? selectedId)
        {
            ConferanceListViewModel model = new ConferanceListViewModel();
            if (selectedId != null)
            {
                var talks = _context.Set<Talk>().Where(i => i.ConferenceId == selectedId).ToList();
                var conferences = _context.Set<Conference>().ToList();
                var conference = _context.Set<Conference>().Find(Convert.ToInt32(selectedId));
                model.Conferences = conferences;
                model.Talk = talks;
                model.Conference = conference;
            }
            else
            {
                var dbSet = _context.Set<Conference>().ToList();
                model.Conferences = dbSet;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult SetConference(string conferationId)
        {
            return RedirectToAction("Index", new { selectedId = Convert.ToInt32(conferationId) });
        }

        [HttpGet]
        public IActionResult Members()
        {
            var members = _context.Set<Members>().ToList();
            return View(members);
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
    }
}
