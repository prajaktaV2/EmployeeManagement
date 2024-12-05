using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.Models.PartnerApi;

namespace EmployeeManagement.Service.BusinessLogic.Interface
{
    public interface IPartnerApiService
    {
        public Task<List<ProductResponse>> GetPartnerProduct(int limit);
    }
}
