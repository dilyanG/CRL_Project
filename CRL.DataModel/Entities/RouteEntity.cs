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
        public string Name { get; set; }

        public CityEntity Start { get; set; }

        public CityEntity End { get; set; }

        [Required]
        public int Distance { get; set; }
        public bool IsDirect { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
