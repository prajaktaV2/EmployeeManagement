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
        public static DateTime maxPurchaseDate = DBData.Purchases.Max(p => p.PurchaseDate);
        public static DateTime minPurchaseDate = DBData.Purchases.Min(p => p.PurchaseDate);

        public static DateTime threeMonthsAgo = DBData.Purchases.Max(x => x.PurchaseDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.Purchases.Min(x => x.PurchaseDate).AddMonths(3);
        public static DateTime sixMonthAgo = DBData.Purchases.Max(x => x.PurchaseDate).AddMonths(-6);
        public static DateTime sixMonthLater = DBData.Purchases.Min(x => x.PurchaseDate).AddMonths(6);
        public const int YEAR = 2023;
        public Task<List<Purchase>> GetPurchaseCustomerList()
        {
            //generate a list of customers who have made purchases in the year 2023
            return Task.FromResult(DBData.Purchases
                                    .Where(x => x.PurchaseDate.Year == YEAR)
                                    .Select(x => new Purchase { CustomerId = x.CustomerId})
                                    .ToList());
        }

        public Task<List<Purchase>> GetTotalAmountSpentByEachCustomer()
        {
            /// get the total amount spent by each customer in the year 2023
            // var getAmtSpentlinq = (from c in DBData.Purchases
            return Task.FromResult(DBData.Purchases
                                    .Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.CustomerId)
                                    .Select(grp => new Purchase { CustomerId = grp.Key, Amount = grp.Sum(x => x.Amount) })
                                    .ToList());
        }

        public Task<List<Purchase>> GetTopCustomerAmtSpentEachMonth()
        {
            // get top customer in terms of total amount spent in each month of year 2023

            var getList = DBData.Purchases
                                    .Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => x.PurchaseDate.Month)
                                    .Select(grp => new Purchase
                                    {
                                        Month = grp.Key,
                                        CustomerId = grp.OrderByDescending(x => x.Amount)?.FirstOrDefault()?.CustomerId,
                                        Amount = grp.Max(x => x.Amount)
                                    }).ToList();
            return Task.FromResult(getList);
        }

        public Task<List<object>> GetMinMaxAvgAllCustomer()
        {
            // get minimum, maximum, and average purchase amount for all customers
            var getforAllcustomer = DBData.Purchases
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
            return Task.FromResult(obj);
        }

        public Task<List<Purchase>> GetAvgAmtSpentEachMonth()
        {
            // find the average amount spent by customers in each month of year 2023
            var getAvgAmtCustomer = DBData.Purchases.Where(x => x.PurchaseDate.Year == YEAR)
                                    .GroupBy(x => new { x.PurchaseDate.Month, x.CustomerId })
                                    .Select(g => new Purchase
                                    {
                                        Amount = g.Average(x => x.Amount),
                                        Month = g.Key.Month,
                                        CustomerId = g.Key.CustomerId
                                    }).ToList();
            return Task.FromResult(getAvgAmtCustomer);
        }

        public Task<List<Purchase>> GetGroupOfCustPurchase6Month()
        {
            // get group of customers who have made purchases in the last 6 months of year of year
            var getGroupCust = DBData.Purchases.Where(x => x.PurchaseDate >= sixMonthAgo && x.PurchaseDate<=maxPurchaseDate)
                                    .GroupBy(x => x.CustomerId)
                                    .Select(g => new Purchase
                                    {
                                        //Amount = g.Sum(x => x.Amount),
                                        CustomerId = g.Key
                                    }).ToList();
            return Task.FromResult(getGroupCust);
        }

        public Task<double> GetMedianAmtSpent()
        {
            // find the median amount spent by customers in the last 3 months
            var getMedianAmt = DBData.Purchases.Where(x => x.PurchaseDate >= threeMonthsAgo && x.PurchaseDate<=maxPurchaseDate).ToList();
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
            return Task.FromResult(median);
        }

        public Task<List<Purchase>> GetHighestPurchaseDayWeek()
        {
            // get the day of the week with the highest number of purchases in year 2023
            var getHighestpurchaseDayWeek = DBData.Purchases
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Max(x => x.Amount)
                                    }).ToList();
            return Task.FromResult(getHighestpurchaseDayWeek);
        }

        public Task<List<Purchase>> GetLowestPurchaseDayWeek()
        {
            // get the day of the week with the lowest number of purchases in year 2023
            var getLowestpurchaseDayWeek = DBData.Purchases
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Min(x => x.Amount)
                                    }).ToList();
            return Task.FromResult(getLowestpurchaseDayWeek);
        }

        public Task<List<Purchase>> GetTotalPurchaseWeekends()
        {
            // get the total number of purchases made on weekends in year 2023
            var getTotalWeekend = DBData.Purchases.Where(x => x.PurchaseDate.DayOfWeek == (DayOfWeek)0 || x.PurchaseDate.DayOfWeek == (DayOfWeek)6)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Sum(x => x.Amount)
                                    }).ToList();
                                
            return Task.FromResult(getTotalWeekend);
        }

        public Task<List<Purchase>> GetTotalPurchaseWeekdays()
        {
            // get the total number of purchases made on weekdays in year 2023
            var getTotalWeekDays = DBData.Purchases.Where(x => x.PurchaseDate.DayOfWeek > (DayOfWeek)0 && x.PurchaseDate.DayOfWeek < (DayOfWeek)6)
                                    .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                    .Select(g => new Purchase
                                    {
                                        Day = g.Key.ToString(),
                                        Amount = g.Sum(x => x.Amount)
                                    }).ToList();
            return Task.FromResult(getTotalWeekDays);

        }

        public Task<List<Purchase>> GetTotalPurchaseEachDayWeek()
        {
            // get the total number of purchases made on each day of the week in year year
            var getEachDay = DBData.Purchases
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Sum(x => x.Amount)
                                        }).ToList();
            return Task.FromResult(getEachDay);

        }

        public Task<List<Purchase>> GetTotalPurchaseEachDayWeek3Months()
        {
            // get the total number of purchases made on each day of the week in the last 3 months
            var getEachDay3Month = DBData.Purchases.Where(x => x.PurchaseDate >= threeMonthsAgo && x.PurchaseDate <= maxPurchaseDate)
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Sum(x => x.Amount)
                                        }).ToList();
            return Task.FromResult(getEachDay3Month);
        }

        public Task<List<Purchase>> GetAvgPurchaseEachDayWeek()
        {
            // get average number of purchases made on each day of the week in year year
            var getAvgEachDay = DBData.Purchases
                                        .GroupBy(x => x.PurchaseDate.DayOfWeek)
                                        .Select(g => new Purchase
                                        {
                                            Day = g.Key.ToString(),
                                            Amount = g.Average(x => x.Amount)
                                        }).ToList();
            return Task.FromResult(getAvgEachDay);
        }

        public Task<List<Purchase>> GetPurchaseInformationforCustId3Months(string custId)
        {
            // find the purchase information for customer id who have made purchases in the last 3 months
            var getCustPurchaseInfo = DBData.Purchases
                                        .OrderByDescending(x => x.PurchaseDate >= threeMonthsAgo && x.PurchaseDate <= maxPurchaseDate)
                                        .Where(x => x.CustomerId == custId).ToList();
            return Task.FromResult(getCustPurchaseInfo);
        }
    }
}
