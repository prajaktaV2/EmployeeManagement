
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class OrderService : IOrderService
    {
        private readonly IProductOrderService _productOrderService;
        public OrderService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
        
        public const int YEAR = 2023;

        public async Task<List<string>> GetCustIdMadePurchaseInAfternoon()
        {
            // get customer ids who have made purchases in the afternoon of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getAfternoonCustId = orders
                            .Where(x => x.OrderDate >= new DateTime(YEAR,01,01,12,00,00) && x.OrderDate<= new DateTime(YEAR,01,31,16,00,00))
                            .Select(x => x.CustomerId).ToList();
                            
            return getAfternoonCustId;
        }

        public async Task<List<string>> GetCustIdMadePurchaseInEvening()
        {
            // get customer ids who have made purchases in the evening of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getEveningCustId = orders
                            .Where(x => x.OrderDate >= new DateTime(YEAR, 01, 01, 16, 00, 00) && x.OrderDate <= new DateTime(YEAR, 01, 31, 21, 00, 00))
                            .Select(x => x.CustomerId).ToList();
            return getEveningCustId;
        }

        public async Task<List<string>> GetCustIdMadePurchaseInMorning()
        {
            // get customer ids who have made purchases in the morning of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getMorningCustId = orders
                            .Where(x => x.OrderDate >= new DateTime(YEAR, 01, 01, 06, 00, 00) && x.OrderDate <= new DateTime(YEAR, 01, 31, 12, 00, 00))
                            .Select(x => x.CustomerId).ToList();
            return getMorningCustId;
        }

        public async Task<List<Order>> GetOrderInfo(string custId)
        {
            // find the order information for customer id who have made purchases in the last 3 months
            var orders = await _productOrderService.GetAllOrderAsync();
            var getOrderInfo = orders.Where(x => x.OrderDate >= DateTime.Now.AddMonths(-3))
                            .Where(x => x.CustomerId == custId).ToList();
            return getOrderInfo;
        }

        public async Task<List<OrderPurchaseViewModel>> GetOrderPurchaseInfo(string custId)
        {
            // find the purchase information and order information for customer id
            var orders = await _productOrderService.GetAllOrderAsync();
            var purchases = await _productOrderService.GetAllPurchaseAsync();
            var getPurchaseOrderInfo = purchases
                                       .Join(orders, p => p.CustomerId, o => o.CustomerId, (p, o) => new OrderPurchaseViewModel
                                       {
                                           OrderId=o.OrderId,
                                           CustomerId = p.CustomerId,
                                           Amount = p.Amount,
                                           Products = o.Products,
                                           PurchaseDate = p.PurchaseDate,
                                           OrderDate = o.OrderDate
                                       }).Where(x => x.CustomerId == custId).ToList();
            return getPurchaseOrderInfo;
        }

        public async Task<int> GetTotalNoMadePurchaseInAfterNoon()
        {
            // get the total number of purchases made in the afternoon of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getTotalPurchaseAfterNoon = orders
                            .Where(x => x.OrderDate >= new DateTime(YEAR, 01, 01, 12, 00, 00) && x.OrderDate <= new DateTime(YEAR, 01, 31, 16, 00, 00))
                            .Select(x => x.CustomerId).Count();
            return getTotalPurchaseAfterNoon;
        }

        public async Task<int> GetTotalNoMadePurchaseInEvening()
        {
            // get the total number of purchases made in the evening of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getTotalPurchaseEvening = orders
                           .Where(x => x.OrderDate >= new DateTime(YEAR, 01, 01, 16, 00, 00) && x.OrderDate <= new DateTime(YEAR, 01, 31, 21, 00, 00))
                            .Select(x => x.CustomerId).Count();
            return getTotalPurchaseEvening;
        }

        public async Task<int> GetTotalNoMadePurchaseInMorning()
        {
            // get the total number of purchases made in the morning of first month of year 2023
            var orders = await _productOrderService.GetAllOrderAsync();
            var getTotalPurchaseMorning = orders
                            .Where(x => x.OrderDate >= new DateTime(YEAR, 01, 01, 06, 00, 00) && x.OrderDate <= new DateTime(YEAR, 01, 31, 12, 00, 00))
                            .Select(x => x.CustomerId).Count();
            return getTotalPurchaseMorning;
        }

        public async Task<int> GetTotalOrderIn3Month()
        {
            // get the total number of orders placed in the last 3 months
            var orders = await _productOrderService.GetAllOrderAsync();
            var getTotalOrderPlaced = orders.Where(x => x.OrderDate >= DateTime.Now.AddMonths(-3))
                                     .Count();
            return getTotalOrderPlaced;
        }

        public async Task<List<Order>> GetTotalUniqueCustomerOrderIn3Month()
        {
            // get the total number of unique customers who have placed orders in the last 3 months
            var orders = await _productOrderService.GetAllOrderAsync();
            var getUniqueCust = orders.Where(x => x.OrderDate >= DateTime.Now.AddMonths(-3)).DistinctBy(x=>x.CustomerId).ToList();
            return getUniqueCust;
        }

        public async Task<List<int>> GetTotalNoOrderPlacedPerMonth3Month()
        {
            // get the total number of orders placed per month in the last 3 months
            var orders = await _productOrderService.GetAllOrderAsync();
            var getTotalOrderPlaced3Month = orders.Where(x => x.OrderDate >= DateTime.Now.AddMonths(-3))
                                            .GroupBy(x => x.OrderDate.Month)
                                            .Select(grp =>  grp.Count()).ToList();
            return getTotalOrderPlaced3Month;
        }
    }
}
