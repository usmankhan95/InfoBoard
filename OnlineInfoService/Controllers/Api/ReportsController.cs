using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using OnlineInfoService.Dtos;
using OnlineInfoService.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace OnlineInfoService.Controllers.Api
{
    public class ReportsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/reports
        public IHttpActionResult GetReports()
        {
            var reportDtos = _context.Reports
                .Include(s => s.Subject)
                .Include(m => m.Member)
                .ToList()
                .Select(Mapper.Map<Report, ReportDto>);

            return Ok(reportDtos);
        }

        // GET api/reports/1
        public IHttpActionResult GetReport(int id)
        {
            var report = _context.Reports.SingleOrDefault(r => r.Id == id);
            if (report == null)
                return NotFound();

            return Ok(Mapper.Map<Report, ReportDto>(report));
        }

        // POST api/reports
        [HttpPost]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult CreateEvent(ReportDto reportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var report = Mapper.Map<ReportDto, Report>(reportDto);
            _context.Reports.Add(report);
            _context.SaveChanges();

            reportDto.Id = report.Id;

            return Created(new Uri(Request.RequestUri + "/" + report.Id), reportDto);
        }

        // PUT api/reports/1
        [HttpPut]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult UpdateReport(int id, ReportDto reportDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reportInDb = _context.Reports.SingleOrDefault(r => r.Id == id);

            if (reportInDb == null)
                return NotFound();

            Mapper.Map(reportDto, reportInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/reports/1
        [HttpDelete]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult DeleteReport(int id)
        {
            var reportInDb = _context.Reports.SingleOrDefault(r => r.Id == id);

            if (reportInDb == null)
                return NotFound();

            _context.Reports.Remove(reportInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
