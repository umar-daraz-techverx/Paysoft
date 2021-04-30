using System.Collections.Generic;
using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.EmployeeDtos;
using Techverx.Paysoft.Models;

namespace Techverx.Paysoft.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDto>>> Get();
    }
}
