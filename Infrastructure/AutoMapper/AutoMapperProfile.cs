using AutoMapper;
using Techverx.Paysoft.Dtos.EmployeeDtos;
using Techverx.Paysoft.Dtos.PaymentDtos;
using Techverx.Paysoft.Models;

namespace Techverx.Paysoft
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //Employee Mappers
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<Payment, GetPaymentDto>().ReverseMap();
        }
    }
}
