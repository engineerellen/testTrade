using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validator;

namespace Domain.Models
{
    public class TradeItem
    {
        public double Value { get; set; }

        [Required(ErrorMessage = "Setor do Cliente é obrigatório!")]
        [ClientSectorValidator(ErrorMessage = "Sector must be Public (Pu) or Private (Pr)")]
        [MaxLength(2, ErrorMessage = "Devera ter 2 caracteres")]
        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public string OutputClassification { get; set; }
    }
}
