
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Servico.Interface
{
    public interface IProccessService
    {
        Task<Trade> ProccessTradeInput(string input);
        Task<Trade> ProccessOutputClassification(Trade trade);

    }
}
