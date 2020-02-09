using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRL.DataService.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsConnected { get; set; }
        public bool IsLogisticCenter { get; set; }
        public double ClosenessCentralityCoefficient { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
