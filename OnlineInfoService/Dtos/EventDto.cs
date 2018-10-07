using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInfoService.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public SubjectDto Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}