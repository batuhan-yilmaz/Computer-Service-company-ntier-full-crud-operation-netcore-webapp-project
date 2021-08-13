using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using General.Entities;


namespace General.WebUI.Models
{
    public class CompanyServiceModel
    {
        public List<CompanyService> CompanyServices { get; set; }
        public List<ControlCenter> ControlCenters { get; set; }

        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]

        public string name { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]

        public string longexplanation { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Kısa açıklama minimum 10 maksimum 200 karakter olmalıdır.")]

        public string shortexplanation { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]

        public string icon { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz.")]

        public string image { get; set; }

        public int ControlCenterId { get; set; }
        public ControlCenterModel ControlCenterModel { get; set; }


    }
}
