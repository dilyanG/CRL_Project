using CRL.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRL.DataModel.Entities
{
    public class CityEntity: ITrackable
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z']{2,30}")]
        public string Name { get; set; }
        public bool IsConnected { get; set; }
        public bool IsLogisticCenter { get; set; }
        public double ClosenessCentralityCoefficient { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
