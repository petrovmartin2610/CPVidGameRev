using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CPVidGameRev.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Genre { get; set; }
        public DateTime TimeAdded { get; set; }
        public double AverageUserRating { get; set; }
        //average rating of min and max
        public double MaxUserRating { get; set; }
        public double MinUserRating { get; set; }
    }

}