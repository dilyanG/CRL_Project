using CRL.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRL.DataModel.Entities
{
    public class RouteEntity: ITrackable
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z']{1,5}-[0-9]{1,3}$")]
        public string Name { get; set; }
        [ForeignKey("StartCity")]
        public int StartCityId { get; set; }
        public CityEntity Start { get; set; }

        [ForeignKey("EndCity")]
        public int EndCityId { get; set; }
        public CityEntity End { get; set; }

        [Required]
        public int Distance { get; set; }
        public bool IsDirect { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
