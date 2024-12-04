using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface ISaleService
    {
        public Task<List<Sale>> GetTop3ProductSale();
        public Task<List<Sale>> GetTotalSalePerMonthSale();
        public Task<Sale?> GetMostPopularProduct();
        public Task<Sale?> GetLeastPopularProduct();
        public Task<Sale?> GetLeastSoldProduct();
        public Task<Sale?> GetMostSoldProduct();
        public Task<string> CalculateTotalQtySold();
        public Task<List<Sale>> GetMostSoldProductEveryMonth();
        public Task<List<Sale>> GetLeastSoldProductEveryMonth();
        public Task<List<Sale>> GetAvgQtySoldProductEachMonth();
        public Task<List<object>> GetAggregateStatEachProduct();

    }
}
