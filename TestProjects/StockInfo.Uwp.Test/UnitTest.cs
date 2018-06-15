
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockInfo.Uwp.RestClient;
using System.Threading.Tasks;
using System.Threading;

namespace StockInfo.Uwp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            MopsRestApi api = new MopsRestApi();
            var a = api.GetStockList("23");
            int aa = 5;
            Task.WaitAll(a);
        }
    }
}
