using def.Models;
using def.ModelsForEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace def.Controllers
{
    public class BetController : Controller
    {
        private static List<FightCommand> FightCommands = new List<FightCommand>();
        private static List<FightCommandForDisplay> FightCommandsForDisplay = new List<FightCommandForDisplay>();
        private static int SelectId { get; set; }
        private ApplicationContext _app = new ApplicationContext();

        public IActionResult Index()
        {
            if (FightCommands.Count == 0)
            {
                FightCommands = _app.FightCommands.AsNoTracking().ToList();
                if (FightCommandsForDisplay.Count == 0)
                {
                    FightCommands.ForEach(x => FightCommandsForDisplay.Add(new FightCommandForDisplay()
                    {
                        Id = x.Id,
                        Date = x.Date,
                        CommandOne = x.CommandOne,
                        CommandTwo = x.CommandTwo
                    }));
                }
            }

            return View(FightCommandsForDisplay);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            SelectId = id;
            ViewBag.CommandOne = FightCommandsForDisplay.Find(x => x.Id == SelectId).CommandOne;
            ViewBag.CommandTwo = FightCommandsForDisplay.Find(x => x.Id == SelectId).CommandTwo;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BetForCreate model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CommandOne = FightCommandsForDisplay.Find(x => x.Id == SelectId).CommandOne;
                ViewBag.CommandTwo = FightCommandsForDisplay.Find(x => x.Id == SelectId).CommandTwo;
                return View(model);
            }

            Bet bet = new Bet()
            {
                Name = model.Name,
                Command = model.Command,
                Pay = model.Pay
            };

            if (Create(bet))
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        private bool Create(Bet bet)
        {
            _app.Bets.Add(bet);
            _app.SaveChanges();
            return true;
        }
    }
}
