using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _appDbContext;

        public StockRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public double GetStocksForProduct(int productId)
        {
            var result = _appDbContext.Stocks.ToList().Where(x => x.ProductId == productId).First();
            
            return result is null ? 0.0 : result.QuantityInStock;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _appDbContext.Stocks.ToList();
        }

        public void SubmitStockForProduct(Stock stock)
        {
            var currentStock = _appDbContext.Stocks.ToList().Find(x => x.ProductId == stock.ProductId);

            try
            {
                if (currentStock is null)
                {
                    _appDbContext.Stocks.Add(stock);
                }
                else
                {
                    currentStock.QuantityInStock = stock.QuantityInStock;
                    _appDbContext.Stocks.Update(currentStock);
                }

                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
