using General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Models
{
    public class ControlCenterModel
    {
        public List<CompanyService> CompanyServices { get; set; }
        public List<ControlCenter> ControlCenters { get; set; }
        public string mainsliderimage2 { get; set; }
        public string mainsliderimage { get; set; }
        public string mainsliderimage3 { get; set; }
        public string mainsliderimage4 { get; set; }


        //////////////////


        public string parallax1 { get; set; }
        public string parallax2 { get; set; }
        public string parallax3 { get; set; }



        /////////////////////
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string webadress { get; set; }
        /////////////////////
        public string Logo { get; set; }

        public string contract1tr { get; set; }
        public string contract2tr { get; set; }
        public string contract3tr { get; set; }
        public string contract4tr { get; set; }




        public string socialnetwork1 { get; set; }
        public string socialnetwork2 { get; set; }
        public string socialnetwork3 { get; set; }
        public string socialnetwork4 { get; set; }
    }
}
