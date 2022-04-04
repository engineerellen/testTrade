using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class ClientSectorValidator : ValidationAttribute
    {

        public ClientSectorValidator()
    : base("{0} Deverá ser Publico (Pu) ou Privado (Pr)")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = Convert.ToString(value);

            bool valid = val.Equals("Pu") || val.Equals("Pr");

            if (valid)
                return null;

            return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                , new string[] { validationContext.MemberName });
        }
    }
}
