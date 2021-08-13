using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Entities
{
   public class CompanyService
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string longexplanation { get; set; }
        public string shortexplanation { get; set; }
        public string icon { get; set; }
        public string image { get; set; }
        public ControlCenter ControlCenter { get; set; }
        public int ControlCenterId { get; set; }
    }
}
