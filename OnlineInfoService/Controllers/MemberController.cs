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
    public class MemberController : Controller
    {
        private ApplicationDbContext _context;

        public MemberController()
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
            var viewModel = new MemberFormViewModel
            {
                Member = new Member(),
                Subjects = subjects
            };
            return View("MemberForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminManager")]
        public ActionResult Save(Member member)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MemberFormViewModel
                {
                    Member = member,
                    Subjects = _context.Subjects.ToList()
                };
                return View("MemberForm", viewModel);
            }

            if (member.Id == 0)
                _context.Members.Add(member);
            else
            {
                var memberInDb = _context.Members.Single(m => m.Id == member.Id);

                memberInDb.Name = member.Name;
                memberInDb.DateOfBirth = member.DateOfBirth;
                memberInDb.Gender = member.Gender;
                memberInDb.Email = member.Email;
                memberInDb.WorkLocation = member.WorkLocation;
                memberInDb.Address = member.Address;
                memberInDb.ContactNumber = member.ContactNumber;
                memberInDb.Biography = member.Biography;
                memberInDb.MoreInfo = member.MoreInfo;
                memberInDb.SubjectId = member.SubjectId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Member");
        }

        public ActionResult Details(int id)
        {
            var member = _context.Members.Include(m => m.Subject).SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            return View(member);
        }

        [Authorize(Roles = "AdminManager")]
        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            var viewModel = new MemberFormViewModel
            {
                Member = member,
                Subjects = _context.Subjects.ToList()
            };
            return View("MemberForm", viewModel);
        }

        public ViewResult Index()
        {
            if (User.IsInRole("AdminManager"))
                return View("Index");

            return View("ReadOnlyIndex");
        }
    }
}