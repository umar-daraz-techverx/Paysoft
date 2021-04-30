using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.DataContext;
using Techverx.Paysoft.Dtos.PaymentDtos;
using Techverx.Paysoft.Models;

namespace Techverx.Paysoft.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ContextClass _dbContext;

        public PaymentService(ContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<List<GetPaymentDto>>> GetAllPayments(string clientCode)
        {
	        return new ServiceResponse<List<GetPaymentDto>>
	        {
		        Data = await _dbContext.Payments.Where(x => x.Client.Equals(clientCode))
			        .Select(payment => new
				        GetPaymentDto
				        {
                            Reference = payment.Reference,
                            ResultMessage = payment.ResultMessage,
                            Result = payment.Result,
					        FileAmount = payment.FileAmount,
					        AmountMultiplier = payment.AmountMultiplier,
					        PaymentStatus = (int) payment.PaymentStatus,
					        EmployeeCode = payment.Client,
					        Id = payment.Id
				        }).ToListAsync(),
		        Success = true
	        };
        }
    }




}
