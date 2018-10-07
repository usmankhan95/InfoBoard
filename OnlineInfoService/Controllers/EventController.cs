using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineInfoService.Models;
using OnlineInfoService.ViewModels;
using System.Data.Entity;

namespace OnlineInfoService.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = "AdminManager")]
        public ActionResult New()
        {
            var subjects = _context.Subjects.ToList();
            var viewModel = new EventFormViewModel
            {
                Event = new Event(),
                Subjects = subjects
            };
            return View("EventForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminManager")]
        public ActionResult Save(Event Event)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel
                {
                    Event = Event,
                    Subjects = _context.Subjects.ToList()
                };
                return View("EventForm", viewModel);
            }

            if (Event.Id == 0)
                _context.Events.Add(Event);
            else
            {
                var eventInDb = _context.Events.Single(e => e.Id == Event.Id);

                eventInDb.Name = Event.Name;
                eventInDb.SubjectId = Event.SubjectId;
                eventInDb.Date = Event.Date;
                eventInDb.Location = Event.Location;
                eventInDb.Description = Event.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Event");
        }

        public ActionResult Details(int id)
        {
            var Event = _context.Events.Include(e => e.Subject).SingleOrDefault(e => e.Id == id);

            if (Event == null)
                return HttpNotFound();

            return View(Event);
        }

        [Authorize(Roles = "AdminManager")]
        public ActionResult Edit(int id)
        {
            var Event = _context.Events.SingleOrDefault(e => e.Id == id);

            if (Event == null)
                return HttpNotFound();

            var viewModel = new EventFormViewModel
            {
                Event = Event,
                Subjects = _context.Subjects.ToList()
            };
            return View("EventForm", viewModel);
        }

        // GET: Event
        public ViewResult Index()
        {
            if (User.IsInRole("AdminManager"))
                return View("Index");

            return View("ReadOnlyIndex");
        }
    }
}