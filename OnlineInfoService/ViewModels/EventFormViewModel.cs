using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineInfoService.Models;

namespace OnlineInfoService.ViewModels
{
    public class EventFormViewModel
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public Event Event { get; set; }

        public string Title
        {
            get
            {
                if (Event != null && Event.Id != 0)
                    return "Edit Event";

                return "New Event";
            }
        }
    }
}