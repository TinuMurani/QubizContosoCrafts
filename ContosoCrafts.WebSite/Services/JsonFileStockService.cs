//using ContosoCrafts.WebSite.Models;
//using Microsoft.AspNetCore.Hosting;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace ContosoCrafts.WebSite.Services
//{
//    public class JsonFileStockService : IJsonFileStockService
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public JsonFileStockService(IWebHostEnvironment webHostEnvironment)
//        {
//            _webHostEnvironment = webHostEnvironment;
//        }

//        private string JsonFileName
//        {
//            get { return Path.Combine(_webHostEnvironment.WebRootPath, "data", "stocks.json"); }
//        }

//        public IEnumerable<Stock> GetStocks()
//        {
//            using (var jsonFileReader = File.OpenText(JsonFileName))
//            {
//                var stocks = JsonSerializer.Deserialize<Stock[]>(jsonFileReader.ReadToEnd(),
//                    new JsonSerializerOptions
//                    {
//                        PropertyNameCaseInsensitive = true
//                    });

//                return stocks == null ? new Stock[0] : stocks;
//            }
//        }

//        public void SetStock(string productId, double stock)
//        {
//            var stocks = GetStocks();

//            var productStock = stocks.First(x => x.ProductId == productId);

//            if (productStock?.QuantityInStock == 0)
//            {
//                productStock = new Stock() { ProductId = productId, QuantityInStock = 0 };
//            }
//            else
//            {
//                productStock.QuantityInStock = stock;
//            }

//            using (var outputStream = File.OpenWrite(JsonFileName))
//            {
//                JsonSerializer.Serialize<IEnumerable<Stock>>(
//                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
//                    {
//                        SkipValidation = true,
//                        Indented = true
//                    }),
//                    stocks
//                );
//            }
//        }
//    }
//}
