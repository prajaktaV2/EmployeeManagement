using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class SaleService : ISaleService
    {
        private readonly IProductOrderService _productOrderService;
        public SaleService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        public const int YEAR = 2023;
        public async Task<List<Sale>> GetTop3ProductSale()
        {
            // get the top 3 products with the highest sales in first 3 months of the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getTop3Sales = sales.Where(x => x.SaleDate >= new DateTime(YEAR,01,01) && x.SaleDate <= new DateTime(YEAR,03,31) )
                             .GroupBy(x => x.ProductName)
                             .Select(grp => new Sale
                             { 
                                 ProductName = grp.Key,
                                 QuantitySold = grp.Sum(x => x.QuantitySold)
                             }).Take(3).ToList();
            return getTop3Sales;
        }

        public async Task<List<Sale>> GetTotalSalePerMonthSale()
        {
            // get the total number of sales per month in the last 6 months of year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var get6MonthSales = sales.Where(x => x.SaleDate >= new DateTime(YEAR, 06, 01) && x.SaleDate <= new DateTime(YEAR, 12, 31))
                                    .GroupBy(x => new { x.SaleDate.Month })
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), Month = grp.Key.Month }).ToList();
            return get6MonthSales;
        }

        public async Task<Sale?> GetMostPopularProduct()
        {
            // find the most popular product category in the last 6 months of the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getMostPopular = sales.Where(x => x.SaleDate >= new DateTime(YEAR, 06, 01) && x.SaleDate <= new DateTime(YEAR, 12, 31))
                                    .GroupBy(x => x.ProductName)
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), ProductName = grp.Key }).FirstOrDefault();
            return getMostPopular;
        }

        public async Task<Sale?> GetLeastPopularProduct()
        {
            // find the least popular product category in the last 6 months of the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getMostPopular = sales.Where(x => x.SaleDate >= new DateTime(YEAR, 06, 01) && x.SaleDate <= new DateTime(YEAR, 12, 31))
                                    .GroupBy(x => x.ProductName)
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), ProductName = grp.Key }).LastOrDefault();
            return getMostPopular;
        }

        public async Task<Sale?> GetLeastSoldProduct()
        {
            // find the least sold product in the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getLeastSold = sales
                                .Where(x => x.SaleDate.Year == YEAR)
                                .GroupBy(x => x.ProductName)
                                .Select(g => new Sale { ProductName = g.Key, QuantitySold = g.Sum(x => x.QuantitySold) }).LastOrDefault();
            return getLeastSold;
        }

        public async Task<Sale?> GetMostSoldProduct()
        {
            // find the most sold product in the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getMostSold = sales
                                .Where(x => x.SaleDate.Year == YEAR)
                                .GroupBy(x => x.ProductName)
                                .Select(g => new Sale { ProductName = g.Key, QuantitySold = g.Sum(x => x.QuantitySold) }).FirstOrDefault();
            return getMostSold;
        }

        public async Task<string> CalculateTotalQtySold()
        {
            // calculate the total quantity sold in in the year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var CalculateTotalQtySold = sales
                              .Where(x => x.SaleDate.Year == YEAR).Sum(x => x.QuantitySold).ToString();
            return CalculateTotalQtySold;

        }

        public async Task<List<Sale>> GetMostSoldProductEveryMonth()
        {
            // get most sold product in every month of year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getMostSoldEveryMonth = sales
                              .Where(x => x.SaleDate.Year == YEAR)
                              .GroupBy(x => x.SaleDate.Month)
                              .Select(g => new Sale
                              {
                                  Month = g.Key,
                                  QuantitySold = g.Max(x => x.QuantitySold),
                                  ProductName = g.OrderByDescending(x => x.QuantitySold).FirstOrDefault()?.ProductName
                              }).ToList();
            return getMostSoldEveryMonth;
        }

        public async Task<List<Sale>> GetLeastSoldProductEveryMonth()
        {
            // get least sold product in every month of year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getLeastSoldEveryMonth = sales
                             .Where(x => x.SaleDate.Year == YEAR)
                             .GroupBy(x => x.SaleDate.Month)
                             .Select(g => new Sale
                             {
                                 Month = g.Key,
                                 QuantitySold = g.Min(x => x.QuantitySold),
                                 ProductName = g.OrderByDescending(x => x.QuantitySold).LastOrDefault()?.ProductName
                             }).ToList();
            return getLeastSoldEveryMonth;
        }

        public async Task<List<Sale>> GetAvgQtySoldProductEachMonth()
        {
            // find the average quantity sold of products in each month of year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getAvgQty = sales.Where(x => x.SaleDate.Year == YEAR)
                                .GroupBy(x => x.SaleDate.Month)
                                .Select(g => new Sale 
                                {
                                    Month = g.Key, 
                                    QuantitySold = g.Average(x => x.QuantitySold) 
                                }).ToList();
            return getAvgQty;
        }

        public async Task<List<object>> GetAggregateStatEachProduct()
        {
            // find aggregate statistics for each product category in year 2023
            var sales = await _productOrderService.GetAllSaleAsync();
            var getAggregateStat = sales
                               .Where(x => x.SaleDate.Year == YEAR)
                               .GroupBy(x => x.ProductName)
                               .Select(g => new 
                               {
                                   ProductName = g.Key,
                                   AverageQuantitySold = g.Average(x => x.QuantitySold),
                                   TotalQuantitySold = g.Sum(x => x.QuantitySold),
                                   MaxQuantitySold = g.Max(x => x.QuantitySold),
                                   MinQuantitySold = g.Min(x => x.QuantitySold),
                                   Count=g.Count()
                               }).ToList();
            var obj=new List<object>();
            foreach (var stat in getAggregateStat)
            {
                obj.Add($"Category: {stat.ProductName}");
                obj.Add($"  Total Sales: {stat.TotalQuantitySold}");
                obj.Add($"  Average Sale: {stat.AverageQuantitySold}");
                obj.Add($"  Number of Transactions: {stat.Count}");
                obj.Add($"  Minimum Sale: {stat.MaxQuantitySold}");
                obj.Add($"  Maximum Sale: {stat.MinQuantitySold}");
                
            }
            return obj;
        }
    }
}
