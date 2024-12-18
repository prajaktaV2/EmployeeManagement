﻿
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class ApplicationDataService : IApplicationDataService
    {
        private readonly IProductOrderService _productOrderService;
        public ApplicationDataService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
        public async Task<List<CustomerActivityResponse>> GetListOfEachCustomerLoyaltyTier()
        {
            //-Return a list showing each customer's loyalty tier.
            var customerActivities = await _productOrderService.GetAllCustomerActivityAsync();
            var getLoyaltyCustomerList = customerActivities
                                        .GroupBy(x => x.CustomerId)
                                        .Select(grp => new CustomerActivityResponse
                                        {
                                            CustomerId = grp.Key,
                                            LoyaltyTier = GetLoyaltyTier(grp.Count())
                                        })
                                        .ToList();

            return getLoyaltyCustomerList;
        }

        public async Task<List<ComplaintResponse>> GetListOfMajorComplaintRaised()
        {
            //- Return a list of major complaint categories, their occurrence count, and a status indicating if they are critical.
            var supportTickets = await _productOrderService.GetAllSupportTicketAsync();
            var getCountofComplaintRaised = supportTickets
                                            .GroupBy(x => x.TicketType)
                                            .Select(grp => new ComplaintResponse
                                            {
                                                Category = grp.Key,
                                                TotalCount = grp.Count(),
                                                Critical = (grp.Count())>=10 ? true : false
                                            }).ToList();
            return getCountofComplaintRaised;

        }

        public async Task<List<OrderResponse>> GetListOfProductWithOrderCountEachMonth(int year)
        {
            //- Return a list of products with their order counts for each month of the specified year.
            var orders = await _productOrderService.GetAllOrderAsync();
            var getProductOrder = orders.Where(o => o.OrderDate.Year == year)
                                .SelectMany(o => o.Products, (or, pr) => new { or.OrderDate, pr.ProductId,pr.Name })
                                .GroupBy(x => new { x.ProductId, x.Name })
                                .Select(grp => new OrderResponse
                                {
                                    ProductId = grp.Key.ProductId,
                                    Product = grp.Key.Name,
                                    monthlyOrders = grp.GroupBy(x => x.OrderDate.ToString("MMMM"))
                                                    .ToDictionary(m=> m.Key,m=>m.Count())
                                }).OrderBy(x=>x.ProductId).ToList();
            return getProductOrder;
        }

        public static string GetLoyaltyTier(int purchaseFrequency)
        {
            if (purchaseFrequency >= 12)
                return "Platinum";
            else if (purchaseFrequency >= 6 && purchaseFrequency <= 11)
                return "Gold";
            else if (purchaseFrequency >= 1 && purchaseFrequency <= 5)
                return "Silver";
            return string.Empty;
        }

        public async Task<Dictionary<string,List<SalesResponse>>> GetProductSalesVolumeEachSeason(int num)
        {
            var seasons = new Dictionary<string, List<int>>
            {
                { "Spring", new List<int> {3, 4, 5 } },
                { "Summer", new List<int>{6, 7, 8 } },
                { "Autumn", new List < int > { 9, 10, 11 } },
                { "Winter", new List < int > { 12, 1, 2 } } 
            };
            var sales = await _productOrderService.GetAllSaleAsync();

            var filteredSales = seasons.ToDictionary(
                season => season.Key,
                season => sales
                    .Where(x => (x.SaleDate.Month >= season.Value.First() && x.SaleDate.Month <= season.Value.Last())
                                   || (season.Key == "Winter" && (x.SaleDate.Month == season.Value.First() || x.SaleDate.Month <= season.Value.Last())))
                    .GroupBy(x => x.ProductName)
                    .Select(grp => new SalesResponse
                    {
                        Product = grp.Key,
                        Sales = grp.Sum(x => x.QuantitySold),
                    })
                    .Take(num).ToList()
                );
            return filteredSales;
        }
    }
}
