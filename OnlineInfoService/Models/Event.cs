using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInfoService.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Event Date")]
        public DateTime Date { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        public string Description { get; set; }
    }
}