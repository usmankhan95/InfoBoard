using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineInfoService.Models;
using OnlineInfoService.ViewModels;
using System.Data.Entity;
using System.IO;

namespace OnlineInfoService.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext _context;

        public ReportController()
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
            var viewModel = new ReportFormViewModel
            {
                Members = _context.Members.ToList(),
                Report = new Report(),
                Subjects = _context.Subjects.ToList()
            };
            return View("ReportForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminManager")]
        public ActionResult Save(Report report)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ReportFormViewModel
                {
                    Report = report,
                    Members = _context.Members.ToList(),
                    Subjects = _context.Subjects.ToList()
                };
                return View("ReportForm", viewModel);
            }

            if (report.ReportFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(report.ReportFile.FileName);
                string filePath = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                report.ReportFile.SaveAs(filePath);
            }

            if (report.Id == 0)
                _context.Reports.Add(report);
               
            else
            {
                var reportInDb = _context.Reports.Single(e => e.Id == report.Id);

                reportInDb.Name = report.Name;
                reportInDb.MemberId = report.MemberId;
                reportInDb.SubjectId = report.SubjectId;
                reportInDb.Date = report.Date;
                reportInDb.ReportFile = report.ReportFile;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Report");
        }

        public ActionResult Details(int id)
        {
            var report = _context.Reports
                .Include(e => e.Subject)
                .Include(m => m.Member)
                .SingleOrDefault(r => r.Id == id);

            if (report == null)
                return HttpNotFound();

            return View(report);
        }

        [Authorize(Roles = "AdminManager")]
        public ActionResult Edit(int id)
        {
            var report = _context.Reports.SingleOrDefault(e => e.Id == id);

            if (report == null)
                return HttpNotFound();

            var viewModel = new ReportFormViewModel
            {
                Report = report,
                Members = _context.Members.ToList(),
                Subjects = _context.Subjects.ToList()
            };

            return View("ReportForm", viewModel);
        }

        public ActionResult Index()
        {
            if (User.IsInRole("AdminManager"))
                return View("Index");

            return View("ReadOnlyIndex");
        }
    }
}