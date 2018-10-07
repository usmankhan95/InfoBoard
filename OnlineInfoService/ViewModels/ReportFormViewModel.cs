using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineInfoService.Models;

namespace OnlineInfoService.ViewModels
{
    public class ReportFormViewModel
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public Report Report { get; set; }
        
        public string Title
        {
            get
            {
                if (Report != null && Report.Id != 0)
                    return "Edit Report";

                return "New Report";
            }
        }

    }
}