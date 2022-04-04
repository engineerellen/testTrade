using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Validator;

namespace Domain.Models
{
    public class Trade : BaseEntity
    {
        public DateTime ReferenceDate { get; set; }
        public int NumberOfTrades { get; set; }
        public List<TradeItem> Items { get; set; }

    }
}
