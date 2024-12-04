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

        public static DateTime maxSaleDate = DBData.MonthlySales.Max(p => p.SaleDate);
        public static DateTime minSaleDate = DBData.MonthlySales.Min(p => p.SaleDate);

        public static DateTime threeMonthsAgo = DBData.MonthlySales.Max(x=>x.SaleDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.MonthlySales.Min(x => x.SaleDate).AddMonths(3);
        public static DateTime sixMonthAgo = DBData.MonthlySales.Max(x => x.SaleDate).AddMonths(-6);
        public static DateTime sixMonthLater = DBData.MonthlySales.Min(x => x.SaleDate).AddMonths(6);
        public const int YEAR = 2023;
        public Task<List<Sale>> GetTop3ProductSale()
        {
            // get the top 3 products with the highest sales in first 3 months of the year 2023
            var getTop3Sales = DBData.MonthlySales.Where(x => x.SaleDate.Year == YEAR && x.SaleDate <= threeMonthsLater && x.SaleDate>=minSaleDate)
                             .GroupBy(x => x.ProductName)
                             .Select(grp => new Sale
                             { 
                                 ProductName = grp.Key,
                                 QuantitySold = grp.Sum(x => x.QuantitySold)
                             }).Take(3).ToList();
            return Task.FromResult(getTop3Sales);
        }

        public Task<List<Sale>> GetTotalSalePerMonthSale()
        {
            // get the total number of sales per month in the last 6 months of year 2023
            var get6MonthSales = DBData.MonthlySales.Where(x => x.SaleDate.Year == YEAR)
                                    .GroupBy(x => new { x.SaleDate.Month }).TakeLast(6)
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), Month = grp.Key.Month }).ToList();
            return Task.FromResult(get6MonthSales);
        }

        public Task<Sale?> GetMostPopularProduct()
        {
            // find the most popular product category in the last 6 months of the year 2023
            var getMostPopular = DBData.MonthlySales.Where(x => x.SaleDate.Year == YEAR && x.SaleDate >= sixMonthAgo && x.SaleDate <= maxSaleDate)
                                    .GroupBy(x => x.ProductName)
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), ProductName = grp.Key }).FirstOrDefault();
            return Task.FromResult(getMostPopular);
        }

        public Task<Sale?> GetLeastPopularProduct()
        {
            // find the least popular product category in the last 6 months of the year 2023
            var getMostPopular = DBData.MonthlySales.Where(x => x.SaleDate.Year == YEAR && x.SaleDate >= sixMonthAgo && x.SaleDate <= maxSaleDate)
                                    .GroupBy(x => x.ProductName)
                                    .Select(grp => new Sale { QuantitySold = grp.Sum(x => x.QuantitySold), ProductName = grp.Key }).LastOrDefault();
            return Task.FromResult(getMostPopular);
        }

        public Task<Sale?> GetLeastSoldProduct()
        {
            // find the least sold product in the year 2023
            var getLeastSold = DBData.MonthlySales
                                .Where(x => x.SaleDate.Year == YEAR)
                                .GroupBy(x => x.ProductName)
                                .Select(g => new Sale { ProductName = g.Key, QuantitySold = g.Sum(x => x.QuantitySold) }).LastOrDefault();
            return Task.FromResult(getLeastSold);
        }

        public Task<Sale?> GetMostSoldProduct()
        {
            // find the most sold product in the year 2023
            var getMostSold = DBData.MonthlySales
                                .Where(x => x.SaleDate.Year == YEAR)
                                .GroupBy(x => x.ProductName)
                                .Select(g => new Sale { ProductName = g.Key, QuantitySold = g.Sum(x => x.QuantitySold) }).FirstOrDefault();
            return Task.FromResult(getMostSold);
        }

        public Task<string> CalculateTotalQtySold()
        {
            // calculate the total quantity sold in in the year 2023
            var CalculateTotalQtySold = DBData.MonthlySales
                              .Where(x => x.SaleDate.Year == YEAR).Sum(x => x.QuantitySold).ToString();
            return Task.FromResult(CalculateTotalQtySold);

        }

        public Task<List<Sale>> GetMostSoldProductEveryMonth()
        {
            // get most sold product in every month of year 2023
            var getMostSoldEveryMonth = DBData.MonthlySales
                              .Where(x => x.SaleDate.Year == YEAR)
                              .GroupBy(x => x.SaleDate.Month)
                              .Select(g => new Sale
                              {
                                  Month = g.Key,
                                  QuantitySold = g.Max(x => x.QuantitySold),
                                  ProductName = g.OrderByDescending(x => x.QuantitySold).FirstOrDefault()?.ProductName
                              }).ToList();
            return Task.FromResult(getMostSoldEveryMonth);
        }

        public Task<List<Sale>> GetLeastSoldProductEveryMonth()
        {
            // get least sold product in every month of year 2023
            var getLeastSoldEveryMonth = DBData.MonthlySales
                             .Where(x => x.SaleDate.Year == YEAR)
                             .GroupBy(x => x.SaleDate.Month)
                             .Select(g => new Sale
                             {
                                 Month = g.Key,
                                 QuantitySold = g.Min(x => x.QuantitySold),
                                 ProductName = g.OrderByDescending(x => x.QuantitySold).LastOrDefault()?.ProductName
                             }).ToList();
            return Task.FromResult(getLeastSoldEveryMonth);
        }

        public Task<List<Sale>> GetAvgQtySoldProductEachMonth()
        {
            // find the average quantity sold of products in each month of year 2023
            var getAvgQty = DBData.MonthlySales
                                .GroupBy(x => x.SaleDate.Month)
                                .Select(g => new Sale 
                                {
                                    Month = g.Key, 
                                    QuantitySold = g.Average(x => x.QuantitySold) 
                                }).ToList();
            return Task.FromResult(getAvgQty);
        }

        public Task<List<object>> GetAggregateStatEachProduct()
        {
            // find aggregate statistics for each product category in year 2023
            var getAggregateStat = DBData.MonthlySales
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
            return Task.FromResult(obj);
        }
    }
}
