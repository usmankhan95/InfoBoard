using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInfoService.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public MemberDto Member { get; set; }

        public int MemberId { get; set; }

        public SubjectDto Subject { get; set; }

        public int SubjectId { get; set; }
        

    }
}