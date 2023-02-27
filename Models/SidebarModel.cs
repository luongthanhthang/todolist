using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDo1.Models
{
    public class SidebarModel
    {
        public string name { get; set; }
        public string icon { get; set; }
        public bool isActive { get; set; }
        public string url { get; set; }
        public List<SidebarModel> subMenu { get; set; }
    }
}
