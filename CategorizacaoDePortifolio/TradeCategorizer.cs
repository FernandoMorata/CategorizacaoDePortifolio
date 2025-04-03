using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategorizacaoDePortifolio.Interface;

namespace CategorizacaoDePortifolio
{


    public static class TradeCategorizer
    {
        public static string CategorizeTrade(ITrade trade, DateTime referenceDate)
        {
            if (trade.NextPaymentDate < referenceDate.AddDays(-30))
                return "EXPIRED";
            if (trade.Value > 1000000 && trade.ClientSector == "Private")
                return "HIGHRISK";
            if (trade.Value > 1000000 && trade.ClientSector == "Public")
                return "MEDIUMRISK";

            return "LOWRISK";
        }
    }

}
