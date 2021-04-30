using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.PaymentDtos;
using Techverx.Paysoft.Models;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Dtos.PaySoft;

namespace Techverx.Paysoft.Services
{
    public interface IPaymentService
    {
        Task<ServiceResponse<List<GetPaymentDto>>> GetAllPayments(string clientCode);
    }
}
