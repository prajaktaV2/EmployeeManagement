
using EmployeeManagement.Data.DataList;
using EmployeeManagement.Model.Models;
using EmployeeManagement.Service.BusinessLogic.Interface;

namespace EmployeeManagement.Service.BusinessLogic.Service
{
    public class InquiryService : IInquiryService
    {
        private readonly IProductOrderService _productOrderService;
        public InquiryService(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
        public const int YEAR = 2023;
        public async Task<List<Inquiry>> GetNoOfInquiryPerCategory3Month()
        {
            // get the total number of inquiries per category in the last 3 months
            var inquiry= await _productOrderService.GetAllInquiryAsync();
            var getTotalInquiries3Month = inquiry.Where(x => x.InquiryDate >= DateTime.Now.AddMonths(-3))
                                        .GroupBy(x => x.CategoryName)
                                        .Select(g => new Inquiry
                                        {
                                            CategoryName = g.Key,
                                            TotalNoOfInquiry = g.Count()
                                        }).ToList();
            return getTotalInquiries3Month;
        }

        public async Task<List<Inquiry>> GetDateHadHighestNoInquiry()
        {
            // which date had the highest number of inquiries in year 2023
            var inquiry = await _productOrderService.GetAllInquiryAsync();
            var getHighestDate = inquiry.Where(x=>x.InquiryDate.Year==YEAR)
                                .GroupBy(x => x.InquiryDate.Date)
                                .Select(g => new Inquiry
                                {
                                    InquiryDate = g.Key,
                                    TotalNoOfInquiry = g.Count()
                                }).ToList();
            return getHighestDate;
        }

        public async Task<List<Inquiry>> GetProductCategoryHighestNoInquiry3Month()
        {
            // get the product categories with the highest number of inquiries in the last 3 months
            var inquiry = await _productOrderService.GetAllInquiryAsync();
            var getProductCategoryHighestNoInquiry= inquiry
                                                    .Where(x => x.InquiryDate >= DateTime.Now.AddMonths(-3))
                                                    .GroupBy(x => x.CategoryName)
                                                    .Select(g=> new Inquiry
                                                    {
                                                        CategoryName = g.Key,
                                                        TotalNoOfInquiry = g.Max(x => x.Quantity)
                                                    }).ToList();
            return getProductCategoryHighestNoInquiry;
        }
    }
}
