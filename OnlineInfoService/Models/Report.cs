using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineInfoService.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Name = "Upload File")]
        [NotMapped]
        public HttpPostedFileBase ReportFile { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Report Title")]
        public string Name { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime Date { get; set; }

        public Member Member { get; set; }

        [Display(Name = "Author")]
        public int MemberId { get; set; }

        public Subject Subject { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
    }
}