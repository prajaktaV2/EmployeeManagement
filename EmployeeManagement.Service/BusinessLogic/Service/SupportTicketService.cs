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
        public static DateTime maxTicketDate = DBData.MonthlySupportTickets.Max(p => p.TicketDate);
        public static DateTime minTicketDate = DBData.MonthlySupportTickets.Min(p => p.TicketDate);

        public static DateTime threeMonthsAgo = DBData.MonthlySupportTickets.Max(x => x.TicketDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.MonthlySupportTickets.Min(x => x.TicketDate).AddMonths(3);
        public const int YEAR = 2023;
        public Task<List<ViewModel>> GetAvgSupportTicket3Months()
        {
            // get average number of support tickets raised per month in the last 3 months
            var getAvgSupportTicket = DBData.MonthlySupportTickets.Where(x => x.TicketDate >= threeMonthsAgo && x.TicketDate<=maxTicketDate)
                                    .GroupBy(x => x.TicketDate.Month)
                                    .Select(g => new ViewModel  { Month = g.Key, Avg = g.Average(x => x.TicketType.Count()) }).ToList();
            return Task.FromResult(getAvgSupportTicket);
        }

        public Task<List<ViewModel>> GetDuplicateSupportTicket()
        {
            // get duplicate support tickets
            var getDuplicateTicket = DBData.MonthlySupportTickets
                                    .GroupBy(x => x.TicketType)
                                    .Where(g => g.Count() > 1)
                                    .Select(g => new ViewModel { TicketType = g.Key })
                                    .ToList();
            return Task.FromResult(getDuplicateTicket);
        }

        public Task<List<ViewModel>> GetSupportTicket3Month()
        {
            // get the total number of support tickets raised per month in the last 3 months
            var gettotalSupportTicketPerMonth = DBData.MonthlySupportTickets.Where(x => x.TicketDate >= threeMonthsAgo)
                                    .GroupBy(x => x.TicketDate.Month)
                                    .Select(g => new ViewModel { Month = g.Key, TotalNo = g.Count() }).ToList();
            return Task.FromResult(gettotalSupportTicketPerMonth);
        }

        public Task<List<ViewModel>> GetSupportTicketCategory3Month()
        {
            // get count of support tickets raised per category in the last 3 months
            // get the total number of support tickets raised per category in the last 3 months
            var gettotalSupportTicket = DBData.MonthlySupportTickets.Where(x => x.TicketDate >= threeMonthsAgo)
                                    .GroupBy(x => x.TicketType)
                                    .Select(g => new ViewModel { TicketType = g.Key, TotalNo = g.Count() }).ToList();
            return Task.FromResult(gettotalSupportTicket);
        }

        public Task<List<ViewModel>> GetAvgSupportTicketPerMonth()
        {
            // find the average number of support tickets raised per month in year 2023
            var getAvgSupportTicketPerMonth = DBData.MonthlySupportTickets.Where(x => x.TicketDate.Year == YEAR)
                              .GroupBy(x => x.TicketDate.Month)
                              .Select(g => new ViewModel { Month = g.Key, Avg = g.Average(x => x.TicketDate.Month) }).ToList();
            return Task.FromResult(getAvgSupportTicketPerMonth);
        }

        public Task<ViewModel> GetHighestSupportTicket()
        {
            // which month had the highest number of support tickets raised in year 2023
            var getHighestTicketRaised = DBData.MonthlySupportTickets.Where(x => x.TicketDate.Year == YEAR)
                                        .GroupBy(x => x.TicketDate.Month)
                                        .Select(g => new ViewModel { Month = g.Key, TotalNo = g.Count() }).OrderByDescending(x=>x.TotalNo).First();
            return Task.FromResult(getHighestTicketRaised);
        }
    }
}
