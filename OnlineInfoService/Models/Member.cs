using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineInfoService.Models
{
    public class Member
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Work Location")]
        public string WorkLocation { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public string Biography { get; set; }

        [Display(Name = "Key words")]
        public string MoreInfo { get; set; }

        public Subject Subject { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

    }
}