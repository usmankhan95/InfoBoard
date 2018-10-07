using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineInfoService.Models;

namespace OnlineInfoService.ViewModels
{
    public class MemberFormViewModel
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public Member Member { get; set; }
        
        public string Title
        {
            get
            {
                if (Member != null && Member.Id != 0)
                    return "Edit Member";

                return "New Member";
            }
        }
    }
}