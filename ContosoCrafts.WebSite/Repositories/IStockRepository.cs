using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Repositories
{
    public interface IStockRepository
    {
        void SubmitStockForProduct(Stock stock);
        double GetStocksForProduct(int productId);
        IEnumerable<Stock> GetAllStocks();
    }
}