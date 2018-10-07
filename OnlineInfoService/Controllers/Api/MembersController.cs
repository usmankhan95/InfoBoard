using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using OnlineInfoService.Models;
using System.Data.Entity;
using OnlineInfoService.Dtos;

namespace OnlineInfoService.Controllers.Api
{
    public class MembersController : ApiController
    {
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/members
        public IHttpActionResult GetMembers()
        {
            var memberDtos = _context.Members
                .Include(m => m.Subject)
                .ToList()
                .Select(Mapper.Map<Member, MemberDto>);

            return Ok(memberDtos);
        }

        // GET /api/members/1
        public IHttpActionResult GetMember(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return NotFound();

            return Ok(Mapper.Map<Member, MemberDto>(member));
        }

        // POST /api/members
        [HttpPost]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = Mapper.Map<MemberDto, Member>(memberDto);
            _context.Members.Add(member);
            _context.SaveChanges();

            memberDto.Id = member.Id;
            return Created(new Uri(Request.RequestUri + "/" + member.Id), memberDto);
        }

        //PUT /api/members/1
        [HttpPut]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var memberInDb = _context.Members.SingleOrDefault(m => m.Id == id);

            if (memberInDb == null)
                return NotFound();

            Mapper.Map(memberDto, memberInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/members/1
        [HttpDelete]
        [Authorize(Roles = "AdminManager")]
        public IHttpActionResult DeleteMember(int id)
        {
            var memberInDb = _context.Members.SingleOrDefault(m => m.Id == id);

            if (memberInDb == null)
                return NotFound();

            _context.Members.Remove(memberInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
