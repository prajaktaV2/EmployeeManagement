
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class ApplicationDataService : IApplicationDataService
    {
        public Task<List<CustomerActivityResponse>> GetListOfEachCustomerLoyaltyTier()
        {
            //-Return a list showing each customer's loyalty tier.
            var getLoyaltyCustomerList = DBData.CustomerActivities
                                        .GroupBy(x => x.CustomerId)
                                        .Select(grp => new CustomerActivityResponse
                                        {
                                            CustomerId = grp.Key,
                                            Purchasefrequency = grp.Count(),
                                            LoyaltyTier = GetLoyaltyTier(grp.Count())
                                        })
                                        .ToList();

            return Task.FromResult(getLoyaltyCustomerList);
        }

        public Task<List<ComplaintResponse>> GetListOfMajorComplaintRaised()
        {
            //- Return a list of major complaint categories, their occurrence count, and a status indicating if they are critical.
            var getCountofComplaintRaised = DBData.MonthlySupportTickets
                                            .GroupBy(x => x.TicketType)
                                            .Select(grp => new ComplaintResponse
                                            {
                                                Category = grp.Key,
                                                TotalCount = grp.Count()
                                            }).Where(x => x.TotalCount >= 10).ToList();
            return Task.FromResult(getCountofComplaintRaised);

        }

        public Task<List<OrderResponse>> GetListOfProductWithOrderCountEachMonth(int year)
        {
            //- Return a list of products with their order counts for each month of the specified year.
            var getProductOrder = DBData.Orders.Where(o => o.OrderDate.Year == year)
                                .SelectMany(o => o.Products, (or, pr) => new { or.OrderDate, pr })
                                .GroupBy(x => new { x.OrderDate.Month, x.pr.Category })
                                .Select(grp => new OrderResponse
                                {
                                    Month = grp.Key.Month,
                                    Product = grp.Key.Category,
                                    TotalCount = grp.Count()
                                }).OrderBy(x => x.Month).ToList();
            return Task.FromResult(getProductOrder);
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

        public Task<List<SalesResponse>> GetProductSalesVolumeEachSeason(int num)
        {
            var seasons = new Dictionary<string, (int startMonth, int endMonth)>
        {
            { "Spring", (3, 5) },
            { "Summer", (6, 8) },
            { "Autumn", (9, 11) },
            { "Winter", (12, 2) } 
        };
            var topProductsBySeason = new List<SalesResponse>();

            foreach (var season in seasons)
            {
                // Filter and group sales by the month range for each season
                var filteredSales = DBData.MonthlySales
                    .Where(x => (x.SaleDate.Month >= season.Value.startMonth && x.SaleDate.Month <= season.Value.endMonth)
                                   || (season.Key == "Winter" && (x.SaleDate.Month == 12 || x.SaleDate.Month <= 2)))
                    .GroupBy(x => x.ProductName)
                    .Select(grp => new SalesResponse
                    {
                        ProductName = grp.Key,
                        TotalSales = grp.Sum(x => x.QuantitySold)
                    })
                    .OrderByDescending(x => x.TotalSales)
                    .Take(num);

                // Add top products of the current season
                topProductsBySeason.AddRange(filteredSales);
                
            }
            return Task.FromResult(topProductsBySeason);

        }
    }
}
