using Princess.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Princess.Models
{
    public class GimmeMyPrize
    {
        [Required]
        [MysteryWordValidator(Clue = "27")]
        public string PartOne { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "10")]
        public string PartTwo { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "19")]
        public string PartThree { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "90")]
        public string PartFour { get; set; }

    }
}