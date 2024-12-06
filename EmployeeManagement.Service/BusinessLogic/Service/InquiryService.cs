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
    public class InquiryService : IInquiryService
    {
        public static DateTime maxInquiryDate = DBData.MonthlyInquiries.Max(p => p.InquiryDate);
        public static DateTime minInquiryDate = DBData.MonthlyInquiries.Min(p => p.InquiryDate);

        public static DateTime threeMonthsAgo = DBData.MonthlyInquiries.Max(x => x.InquiryDate).AddMonths(-3);
        public static DateTime threeMonthsLater = DBData.MonthlyInquiries.Min(x => x.InquiryDate).AddMonths(3);
        public const int YEAR = 2023;
        public Task<List<Inquiry>> GetNoOfInquiryPerCategory3Month()
        {
            // get the total number of inquiries per category in the last 3 months
            var getTotalInquiries3Month = DBData.MonthlyInquiries.Where(x => x.InquiryDate > threeMonthsAgo && x.InquiryDate<= maxInquiryDate)
                                        .GroupBy(x => x.CategoryName)
                                        .Select(g => new Inquiry
                                        {
                                            CategoryName = g.Key,
                                            TotalNoOfInquiry = g.Count()
                                        }).ToList();
            return Task.FromResult(getTotalInquiries3Month);
        }

        public Task<List<Inquiry>> GetDateHadHighestNoInquiry()
        {
            // which date had the highest number of inquiries in year 2023
            var getHighestDate = DBData.MonthlyInquiries
                                .GroupBy(x => x.InquiryDate.Date)
                                .Select(g => new Inquiry
                                {
                                    InquiryDate = g.Key,
                                    TotalNoOfInquiry = g.Count()
                                }).ToList();
            return Task.FromResult(getHighestDate);
        }

        public Task<List<Inquiry>> GetProductCategoryHighestNoInquiry3Month()
        {
            // get the product categories with the highest number of inquiries in the last 3 months
            var getProductCategoryHighestNoInquiry= DBData.MonthlyInquiries
                                                    .Where(x => x.InquiryDate > threeMonthsAgo && x.InquiryDate < maxInquiryDate)
                                                    .GroupBy(x => x.CategoryName)
                                                    .Select(g=> new Inquiry
                                                    {
                                                        CategoryName = g.Key,
                                                        TotalNoOfInquiry = g.Max(x => x.Quantity)
                                                    }).ToList();
            return Task.FromResult(getProductCategoryHighestNoInquiry);
        }
    }
}
