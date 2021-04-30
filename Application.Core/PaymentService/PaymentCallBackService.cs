using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Techverx.Paysoft.DataContext;
using Techverx.Paysoft.Dtos.CallBack;
using Techverx.Paysoft.Models;

namespace Techverx.Paysoft.Services
{
	public class PaymentCallBackService : IPaymentCallBackService
	{
		private readonly ContextClass _dbContext;

		public PaymentCallBackService(ContextClass dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task CallBack(Response input)
		{
			var payment = await _dbContext.Payments.OrderBy(x => x.Id).LastOrDefaultAsync(x => x.AccountNumber.Equals(input.PaymentResults.Result.AccountNumber));
			payment.PaymentStatus = PaymentStatus.Success;
			payment.Result = input.Result;
			payment.ResultMessage = input.PaymentResults.Result.ResultMessage;
			await _dbContext.SaveChangesAsync();
		}
	}
}
