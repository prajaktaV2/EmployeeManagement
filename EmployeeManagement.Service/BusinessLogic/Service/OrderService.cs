using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class OrderService : IOrderService
    {
        public Task<List<string>> GetCustIdMadePurchaseInAfternoon()
        {
            // get customer ids who have made purchases in the afternoon of first month of year year
            var getAfternoonCustId = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 12 && x.OrderDate.Hour <= 18)
                            .Select(x => x.CustomerId).ToList();
                            
            return Task.FromResult(getAfternoonCustId);
        }

        public Task<List<string>> GetCustIdMadePurchaseInEvening()
        {
            // get customer ids who have made purchases in the evening of first month of year year
            var getEveningCustId = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 18 && x.OrderDate.Hour < 21)
                            .Select(x => x.CustomerId).ToList();
            return Task.FromResult(getEveningCustId);
        }

        public Task<List<string>> GetCustIdMadePurchaseInMorning()
        {
            // get customer ids who have made purchases in the morning of first month of year year
            var getMorningCustId = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 6 && x.OrderDate.Hour < 12)
                            .Select(x => x.CustomerId).ToList();
            return Task.FromResult(getMorningCustId);
        }

        public Task<int> GetTotalNoMadePurchaseInAfterNoon()
        {
            
            // get the total number of purchases made in the afternoon of first month of year year
            var getTotalPurchaseAfterNoon = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 12 && x.OrderDate.Hour <= 18)
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
            // get the total number of purchases made in the morning of first month of year year
            var getTotalPurchaseMorning = DBData.Orders
                            .Where(x => x.OrderDate.Hour >= 6 && x.OrderDate.Hour < 12)
                            .Select(x => x.CustomerId).Count();
            return Task.FromResult(getTotalPurchaseMorning);
        }
    }
}
