using Princess.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Princess.Models
{
    public class Mystery
    {
        [Required]
        [MysteryWordValidator(Clue = "nieskazitelna")]
        public string Clue1 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "dewocjonalia")]
        public string Clue2 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "paciorek")]
        public string Clue3 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "konewka")]
        public string Clue4 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "laczek")]
        public string Clue5 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "kompatybilny")]
        public string Clue6 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "mysipyszczek")]
        public string Clue7 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "placek")]
        public string Clue8 { get; set; }

        [Required]
        [MysteryWordValidator(Clue = "mordka")]
        public string Clue9 { get; set; }


    }
}