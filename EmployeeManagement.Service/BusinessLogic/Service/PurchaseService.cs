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
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductOrderService _productOrderService;
        public PurchaseService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        public const int YEAR = 2023;
        public async Task<List<Purchase>> GetPurchaseCustomerList()
        {
            //generate a list of customers who have made purchases in the year 2023
            var purchases= await _productOrderService.GetAllPurchaseAsync();
            return  (purchases
                     .Where(x => x.PurchaseDate.Year == YEAR)
                     .Select(x => new Purchase { CustomerId = x.CustomerId})
                     .ToList());
        }

        public async Task<List<Purchase>> GetTotalAmountSpentByEachCustomer()
        {
            /// get the total amount spent by each customer in the year 2023
            // var getAmtSpentlinq = (from c in purchases
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            return (purchases
                                    .Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.CustomerId)
                                    .Select(grp => new Purchase { CustomerId = grp.Key, Amount = grp.Sum(x => x.Amount) })
                                    .ToList());
        }

        public async Task<List<Purchase>> GetTopCustomerAmtSpentEachMonth()
        {
            // get top customer in terms of total amount spent in each month of year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getCustTotalSpentList = purchases
                                    .Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.PurchaseDate.Month)
                                    .Select(grp => new Purchase
                                    {
                                        Month = grp.Key,
                                        CustomerId = grp.OrderByDescending(x => x.Amount)?.FirstOrDefault()?.CustomerId,
                                        Amount = grp.Max(x => x.Amount)
                                    }).ToList();
            return getCustTotalSpentList;
        }

        public async Task<List<object>> GetMinMaxAvgAllCustomer()
        {
            // get minimum, maximum, and average purchase amount for all customers
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getforAllcustomer = purchases
                                    .GroupBy(x => x.CustomerId)
                                    .Select(g => new
                                    {
                                        Customer = g.Key,
                                        Min = g.Min(x => x.Amount),
                                        Max = g.Max(x => x.Amount),
                                        Average = g.Average(x => x.Amount)
                                    });
            var obj = new List<object>();
            foreach (var stat in getforAllcustomer)
            {
                obj.Add($"Customer: {stat.Customer}");
                obj.Add($"  Average Purchase: {stat.Average}");
                obj.Add($"  Minimum Purchase: {stat.Min}");
                obj.Add($"  Maximum Purchase: {stat.Max}");
            }
            return obj;
        }

        public async Task<List<Purchase>> GetAvgAmtSpentEachMonth()
        {
            // find the average amount spent by customers in each month of year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getAvgAmtCustomer = purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => new { x.PurchaseDate.Month, x.CustomerId })
                                    .Select(g => new Purchase
                                    {
                                        Amount = g.Average(x => x.Amount),
                                        Month = g.Key.Month,
                                        CustomerId = g.Key.CustomerId
                                    }).ToList();
            return getAvgAmtCustomer;
        }

        public async Task<List<Purchase>> GetGroupOfCustPurchase6Month()
        {
            // get group of customers who have made purchases in the last 6 months of year of 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getGroupCust = purchases.Where(x => x.PurchaseDate >= new DateTime(YEAR,06,01) && x.PurchaseDate<= new DateTime(YEAR,12,31))
                                    .GroupBy(x => x.CustomerId)
                                    .Select(g => new Purchase
                                    {
                                        //Amount = g.Sum(x => x.Amount),
                                        CustomerId = g.Key
                                    }).ToList();
            return getGroupCust;
        }

        public async Task<double> GetMedianAmtSpent()
        {
            // find the median amount spent by customers in the last 3 months
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getMedianAmt = purchases.Where(x => x.PurchaseDate >= DateTime.Now.AddMonths(-3)).ToList();
            int count = getMedianAmt.Count;
            double median = 0;
            if (count % 2 == 0)
            {
                median = (getMedianAmt[count / 2 - 1].Amount + getMedianAmt[count / 2].Amount) / 2;
            }
            else
            {
                median = getMedianAmt[count / 2].Amount;
            }
            return median;
        }

        public async Task<List<Purchase>> GetHighestPurchaseDayWeek()
        {
            // get the day of the week with the highest number of purchases in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getHighestpurchaseDayWeek = purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Max(x => x.Amount)
                                    }).ToList();
            return getHighestpurchaseDayWeek;
        }

        public async Task<List<Purchase>> GetLowestPurchaseDayWeek()
        {
            // get the day of the week with the lowest number of purchases in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getLowestpurchaseDayWeek = purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Min(x => x.Amount)
                                    }).ToList();
            return getLowestpurchaseDayWeek;
        }

        public async Task<List<Purchase>> GetTotalPurchaseWeekends()
        {
            // get the total number of purchases made on weekends in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getTotalWeekend = purchases.Where(x => x.PurchaseDate.Year == YEAR).Where(x=> x.PurchaseDate.DayOfWeek == (DayOfWeek)0 || x.PurchaseDate.DayOfWeek == (DayOfWeek)6)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Sum(x => x.Amount)
                                    }).ToList();
                                
            return getTotalWeekend;
        }

        public async Task<List<Purchase>> GetTotalPurchaseWeekdays()
        {
            // get the total number of purchases made on weekdays in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getTotalWeekDays = purchases.Where(x => x.PurchaseDate.Year == YEAR).Where(x => x.PurchaseDate.DayOfWeek > (DayOfWeek)0 && x.PurchaseDate.DayOfWeek < (DayOfWeek)6)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Sum(x => x.Amount)
                                    }).ToList();
            return getTotalWeekDays;

        }

        public async Task<List<Purchase>> GetTotalPurchaseEachDayWeek()
        {
            // get the total number of purchases made on each day of the week in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getEachDay = purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Sum(x => x.Amount)
                                        }).ToList();
            return getEachDay;

        }

        public async Task<List<Purchase>> GetTotalPurchaseEachDayWeek3Months()
        {
            // get the total number of purchases made on each day of the week in the last 3 months
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getEachDay3Month = purchases.Where(x => x.PurchaseDate >= DateTime.Now.AddMonths(-3))
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Sum(x => x.Amount)
                                        }).ToList();
            return getEachDay3Month;
        }

        public async Task<List<Purchase>> GetAvgPurchaseEachDayWeek()
        {
            // get average number of purchases made on each day of the week in year 2023
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getAvgEachDay = purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Average(x => x.Amount)
                                        }).ToList();
            return getAvgEachDay;
        }

        public async Task<List<Purchase>> GetPurchaseInformationforCustId3Months(string custId)
        {
            // find the purchase information for customer id who have made purchases in the last 3 months
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getCustPurchaseInfo = purchases
                                        .OrderByDescending(x => x.PurchaseDate >= DateTime.Now.AddMonths(-3))
                                        .Where(x => x.CustomerId == custId).ToList();
            return getCustPurchaseInfo;
        }
    }
}
