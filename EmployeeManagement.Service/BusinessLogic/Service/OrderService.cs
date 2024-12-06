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
    public class OrderService : IOrderService
    {

        public static DateTime maxOrderDate = DBData.Orders.Where(x => x.OrderDate.Year == YEAR).Max(p => p.OrderDate);
        public static DateTime minOrderDate = DBData.Orders.Where(x => x.OrderDate.Year == YEAR).Min(p => p.OrderDate);

        public static DateTime threeMonthsAgo = DBData.Orders.Where(x=> x.OrderDate.Year == YEAR).Max(x => x.OrderDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.Orders.Where(x => x.OrderDate.Year == YEAR).Min(x => x.OrderDate).AddMonths(3);
        public const int YEAR = 2023;

        public Task<List<string>> GetCustIdMadePurchaseInAfternoon()
        {
            // get customer ids who have made purchases in the afternoon of first month of year 2023
            var getAfternoonCustId = DBData.Orders
                            .Where(x => x.OrderDate.Year == YEAR && x.OrderDate.Hour >= 12 && x.OrderDate.Hour <= 18)
                            .Select(x => x.CustomerId).ToList();
                            
            return Task.FromResult(getAfternoonCustId);
        }

        public Task<List<string>> GetCustIdMadePurchaseInEvening()
        {
            // get customer ids who have made purchases in the evening of first month of year 2023
            var getEveningCustId = DBData.Orders
                            .Where(x => x.OrderDate.Year == YEAR && x.OrderDate.Hour >= 18 && x.OrderDate.Hour < 21)
                            .Select(x => x.CustomerId).ToList();
            return Task.FromResult(getEveningCustId);
        }

        public Task<List<string>> GetCustIdMadePurchaseInMorning()
        {
            // get customer ids who have made purchases in the morning of first month of year 2023
            var getMorningCustId = DBData.Orders
                            .Where(x => x.OrderDate.Year == YEAR && x.OrderDate.Hour >= 6 && x.OrderDate.Hour < 12)
                            .Select(x => x.CustomerId).ToList();
            return Task.FromResult(getMorningCustId);
        }

        public Task<List<Order>> GetOrderInfo(string custId)
        {
            // find the order information for customer id who have made purchases in the last 3 months
            var getOrderInfo = DBData.Orders.Where(x => x.OrderDate >= threeMonthsAgo && x.OrderDate <= maxOrderDate)
                            .Where(x => x.CustomerId == custId).ToList();
            return Task.FromResult(getOrderInfo);
        }

        public Task<List<OrderPurchaseViewModel>> GetOrderPurchaseInfo(string custId)
        {
            // find the purchase information and order information for customer id
            var getPurchaseOrderInfo = DBData.Purchases
                                       .Join(DBData.Orders, p => p.CustomerId, o => o.CustomerId, (p, o) => new OrderPurchaseViewModel
                                       {
                                           OrderId=o.OrderId,
                                           CustomerId = p.CustomerId,
                                           Amount = p.Amount,
                                           Products = o.Products,
                                           PurchaseDate = p.PurchaseDate,
                                           OrderDate = o.OrderDate
                                       }).Where(x => x.CustomerId == custId).ToList();
            return Task.FromResult(getPurchaseOrderInfo);
        }

        public Task<int> GetTotalNoMadePurchaseInAfterNoon()
        {
            // get the total number of purchases made in the afternoon of first month of year 2023
            var getTotalPurchaseAfterNoon = DBData.Orders
                            .Where(x => x.OrderDate.Year == YEAR && x.OrderDate.Hour >= 12 && x.OrderDate.Hour <= 18)
                            .Select(x => x.CustomerId).Count();
            return Task.FromResult(getTotalPurchaseAfterNoon);
        }

        public Task<int> GetTotalNoMadePurchaseInEvening()
        {
            // get the total number of purchases made in the evening of first month 
            var getTotalPurchaseEvening = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 18 && x.OrderDate.Hour < 21)
                            .Select(x => x.CustomerId).Count();
            return Task.FromResult(getTotalPurchaseEvening);
        }

        public Task<int> GetTotalNoMadePurchaseInMorning()
        {
            // get the total number of purchases made in the morning of first month of year 2023
            var getTotalPurchaseMorning = DBData.Orders
                            .Where(x => x.OrderDate.Year==YEAR && x.OrderDate.Hour >= 6 && x.OrderDate.Hour < 12)
                            .Select(x => x.CustomerId).Count();
            return Task.FromResult(getTotalPurchaseMorning);
        }

        public Task<int> GetTotalOrderIn3Month()
        {
            // get the total number of orders placed in the last 3 months
            var getTotalOrderPlaced = DBData.Orders.Where(x => x.OrderDate >= threeMonthsAgo && x.OrderDate <= maxOrderDate)
                                     .Count();
            return Task.FromResult(getTotalOrderPlaced);
        }

        public Task<List<Order>> GetTotalUniqueCustomerOrderIn3Month()
        {
            // get the total number of unique customers who have placed orders in the last 3 months
            var getUniqueCust = DBData.Orders.Where(x => x.OrderDate >= threeMonthsAgo && x.OrderDate <= maxOrderDate).Distinct().ToList();
            return Task.FromResult(getUniqueCust);
        }

        public Task<List<int>> GetTotalNoOrderPlacedPerMonth3Month()
        {
            // get the total number of orders placed per month in the last 3 months
            var getTotalOrderPlaced3Month = DBData.Orders.Where(x => x.OrderDate >= threeMonthsAgo && x.OrderDate <= maxOrderDate)
                                            .GroupBy(x => x.OrderDate.Month)
                                            .Select(grp => grp.Count()).ToList();
            return Task.FromResult(getTotalOrderPlaced3Month);
        }
    }
}
