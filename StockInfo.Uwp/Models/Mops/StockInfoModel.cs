using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Models.Mops
{
    public class StockInfoModel
    {
        public string Name { get; set; }

        /// <summary>
        /// 股票代碼
        /// </summary>
        public string Code { get; set; }

        public string DisplayLabel
        {
            get => Code + " " + Name;
        }
    }
}
