using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Services
{
    public interface IJsonFileStockService
    {
        IEnumerable<Stock> GetStocks();
        void SetStock(string productId, double stock);
    }
}