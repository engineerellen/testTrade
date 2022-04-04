using Domain.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain.Models;
using System.Globalization;
using Domain.Util;
namespace Domain.Servico
{
    public class ProccessService : IProccessService
    {



        public ProccessService()
        {

        }



        public async Task<Trade> ProccessTradeInput(string input)
        {
            Trade trade = new Trade();
            trade.Items = new List<TradeItem>();
            int datePosition = 0;
            int numberPosition = 1;
            int position = 0;
            List<Task> x = new List<Task>();
            try
            {
                foreach (string line in input.Split(
                        new string[] { "\r\n", "\r", "\n" },
                        StringSplitOptions.None))
                {

                    if (string.IsNullOrEmpty(line))
                        break;

                    if (datePosition == position)
                    {
                        try
                        {
                            trade.ReferenceDate = DateTime.ParseExact(line.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            throw new Exception("Invalid or non present Reference Date.");
                        }
                    }
                    else if (numberPosition == position)
                    {
                        try
                        {
                            trade.NumberOfTrades = Convert.ToInt32(line.Trim());
                        }
                        catch
                        {
                            throw new Exception("Invalid or non present number of trades.");
                        }

                    }
                    else
                    {
                        var tradeitem = new TradeItem();
                        try
                        {
                            tradeitem.Value = Convert.ToDouble(line.Split(' ')[0]);

                        }
                        catch
                        {
                            throw new Exception("Invalid or non present value.");
                        }
                        try
                        {
                            tradeitem.ClientSector = Convert.ToString(line.Split(' ')[1]);
                            if (String.IsNullOrEmpty(tradeitem.ClientSector))
                                throw new Exception();
                        }
                        catch
                        {
                            throw new Exception("Invalid or non present client sector.");
                        }
                        try
                        {
                            tradeitem.NextPaymentDate = DateTime.ParseExact(line.Split(' ')[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);  
                        }
                        catch
                        {
                            throw new Exception("Invalid or non present next payment date.");
                        }

                        trade.Items .Add(tradeitem);

                    }

                    position++;

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error processing the line " + position, ex);
            }

            return trade;
        }

        public async Task<Trade> ProccessOutputClassification(Trade trade)
        {
            foreach (TradeItem item in trade.Items)
            {
                if (trade.ReferenceDate.AddDays(30) > item.NextPaymentDate)
                {
                    item.OutputClassification = ProcessingTypeEnum.EXPIRED.Description();
                }
                else if ((item.Value > 1000000) && (item.ClientSector.ToUpper() == ClientTypeEnum.PRIVATE.Description().ToUpper()))
                {
                    item.OutputClassification = ProcessingTypeEnum.HIGHRISK.Description();
                }
                else if ((item.Value > 1000000) && (item.ClientSector.ToUpper() == ClientTypeEnum.PUBLIC.Description().ToUpper()))
                {
                    item.OutputClassification = ProcessingTypeEnum.MEDIUMRISK.Description();
                }
                else
                {
                    item.OutputClassification = ProcessingTypeEnum.NA.Description();
                }
            }

            return trade;
        }

    }
}
