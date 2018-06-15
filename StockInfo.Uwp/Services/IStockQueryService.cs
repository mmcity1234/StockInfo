using StockInfo.Uwp.Models.Mops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Services
{
    public interface IStockQueryService
    {
        Task<List<StockInfoModel>> GetStockQueryList(string stock);
    }
}