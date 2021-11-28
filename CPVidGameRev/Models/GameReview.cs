using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CPVidGameRev.Models
{
    public class GameReview
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string GameTitle { get; set; }
        
        public DateTime TimeAdded { get; set; }
        public double ReviewScore { get; set; }
        [StringLength(10000, ErrorMessage = "Review must not contain more than 10000 symbols!")]
        public string ReviewContent { get; set; }
        public string Reviewer { get; set; }
    }
}