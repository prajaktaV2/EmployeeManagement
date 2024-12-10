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
    public class SupportTicketService : ISupportTicketService
    {
        private readonly IProductOrderService _productOrderService;
        public SupportTicketService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
       
        public const int YEAR = 2023;
        public async Task<List<ViewModel>> GetAvgSupportTicket3Months()
        {
            // get average number of support tickets raised per month in the last 3 months
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var getAvgSupportTicket = supportTicket.Where(x => x.TicketDate >= DateTime.Now.AddMonths(-3))
                                    .GroupBy(x => x.TicketDate.Month)
                                    .Select(g => new ViewModel  { Month = g.Key, Avg = g.Average(x => x.TicketType.Count()) }).ToList();
            return getAvgSupportTicket;
        }

        public async Task<List<ViewModel>> GetDuplicateSupportTicket()
        {
            // get duplicate support tickets
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var getDuplicateTicket = supportTicket
                                    .GroupBy(x => x.TicketType)
                                    .Where(g => g.Count() > 1)
                                    .Select(g => new ViewModel { TicketType = g.Key })
                                    .ToList();
            return getDuplicateTicket;
        }

        public async Task<List<ViewModel>> GetSupportTicket3Month()
        {
            // get the total number of support tickets raised per month in the last 3 months
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var gettotalSupportTicketPerMonth = supportTicket.Where(x => x.TicketDate >= DateTime.Now.AddMonths(-3))
                                    .GroupBy(x => x.TicketDate.Month)
                                    .Select(g => new ViewModel { Month = g.Key, TotalNo = g.Count() }).ToList();
            return gettotalSupportTicketPerMonth;
        }

        public async Task<List<ViewModel>> GetSupportTicketCategory3Month()
        {
            // get count of support tickets raised per category in the last 3 months
            // get the total number of support tickets raised per category in the last 3 months
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var gettotalSupportTicket = supportTicket.Where(x => x.TicketDate >= DateTime.Now.AddMonths(-3))
                                    .GroupBy(x => x.TicketType)
                                    .Select(g => new ViewModel { TicketType = g.Key, TotalNo = g.Count() }).ToList();
            return gettotalSupportTicket;
        }

        public async Task<List<ViewModel>> GetAvgSupportTicketPerMonth()
        {
            // find the average number of support tickets raised per month in year 2023
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var getAvgSupportTicketPerMonth = supportTicket.Where(x => x.TicketDate.Year == YEAR)
                              .GroupBy(x => x.TicketDate.Month)
                              .Select(g => new ViewModel { Month = g.Key, Avg = g.Average(x => x.TicketDate.Month) }).ToList();
            return getAvgSupportTicketPerMonth;
        }

        public async Task<ViewModel> GetHighestSupportTicket()
        {
            // which month had the highest number of support tickets raised in year 2023
            var supportTicket = await _productOrderService.GetAllSupportTicketAsync();
            var getHighestTicketRaised = supportTicket.Where(x => x.TicketDate.Year == YEAR)
                                        .GroupBy(x => x.TicketDate.Month)
                                        .Select(g => new ViewModel { Month = g.Key, TotalNo = g.Count() }).OrderByDescending(x=>x.TotalNo).First();
            return getHighestTicketRaised;
        }
    }
}
