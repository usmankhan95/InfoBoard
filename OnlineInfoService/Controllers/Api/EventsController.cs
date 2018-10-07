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
    public class EventsController : ApiController
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/events
        public IHttpActionResult GetEvents()
        {
            var eventDtos = _context.Events
                .Include(m => m.Subject)
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);

            return Ok(eventDtos);
        }

        // GET api/events/1
        public IHttpActionResult GetEvent(int id)
        {
            var Event = _context.Events.SingleOrDefault(m => m.Id == id);
            if (Event == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(Event));
        }

        // POST api/events
        [HttpPost]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Event = Mapper.Map<EventDto, Event>(eventDto);
            _context.Events.Add(Event);
            _context.SaveChanges();

            eventDto.Id = Event.Id;

            return Created(new Uri(Request.RequestUri + "/" + Event.Id), eventDto);
        }

        // PUT api/events/1
        [HttpPut]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult UpdateEvent(int id, EventDto eventDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var eventInDb = _context.Events.SingleOrDefault(m => m.Id == id);

            if (eventInDb == null)
                return NotFound();

            Mapper.Map(eventDto, eventInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/events/1
        [HttpDelete]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(m => m.Id == id);

            if (eventInDb == null)
                return NotFound();

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
