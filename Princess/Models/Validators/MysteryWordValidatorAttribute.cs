using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Princess.Models.Validators
{
    public class MysteryWordValidatorAttribute: ValidationAttribute
    {
        public string Clue { get; set; }

        public MysteryWordValidatorAttribute()
        {
            this.Clue = string.Empty;
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                return strValue.ToLower().Equals(Clue.ToLower());
            }
            return true;
        }
    }
}