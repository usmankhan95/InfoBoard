using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInfoService.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string WorkLocation { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Biography { get; set; }

        public string MoreInfo { get; set; }

        public SubjectDto Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}