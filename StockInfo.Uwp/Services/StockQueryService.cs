using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Services
{
    public class StockQueryService : IStockQueryService
    {
        /// <summary>
        /// Auto complete the stock name or code
        /// </summary>
        private const string TWSE_STOCK_AUTOCOMPLETE_API = "http://mops.twse.com.tw/mops/web/ajax_autoComplete";

         
    }
}
