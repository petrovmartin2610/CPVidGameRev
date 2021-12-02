using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CPVidGameRev.Models
{
    //USER REVIEWS
    public class UserReview
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25), MinLength(2, ErrorMessage = "Username must contain more than 2 characters!")]
        public string UserName { get; set; }
        public DateTime TimeAdded { get; set; }
        [StringLength(20000)]
        public string ReviewContent { get; set; }
        public double UserReviewScore { get; set; }
        public int NumberOfReviewedGames { get; set; }
        //number of reviewed games for that user.
    }
}