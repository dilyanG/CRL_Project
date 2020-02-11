using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRL.DataService.ViewModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z']{1,5}-[0-9]{1,3}$")]
        public string Name { get; set; }
        [Required]
        public CityViewModel Start { get; set; }
        [Required]
        public CityViewModel End { get; set; }
        [Required]
        public int Distance { get; set; }
        public bool IsDirect { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool TwoWay { get; set; }
    }
}
