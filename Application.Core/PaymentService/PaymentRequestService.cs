
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Techverx.Paysoft.DataContext;
using Techverx.Paysoft.Dtos.FileContentsDto;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Dtos.PaymentDtos;
using Techverx.Paysoft.Dtos.PaySoft;
using Techverx.Paysoft.Dtos.TotalsDtos;
using Techverx.Paysoft.Enums.PaymentEnums;
using Techverx.Paysoft.Models;
using Techverx.Paysoft.ProxyService;
using Techverx.Paysoft.Utitlity;

namespace Techverx.Paysoft.Services
{
	public class PaymentRequestService: IPaymentRequestService
	{
		private readonly IConfiguration _config;
		private readonly ContextClass _contextClass;
		private readonly IProxyService _proxyService;

        public PaymentRequestService(ContextClass contextClass,
			IConfiguration config,
			IHttpContextAccessor httpContextAccessor,
			IProxyService proxyService)
		{
			_contextClass = contextClass;
			_proxyService = proxyService;
			_config = config;
		}
        public async Task<Response> RequestPaymentAsync(PaymentCreator input)
        {
            var request = await RequestBuilder(input);
            var response = await _proxyService.Send(XmlRequestGenerator.Serialize(request));
            if (response.Result.Equals("Error"))
            {
                await SavePayment(2, request, response);
            }
            else if (response.Result.Equals("OK"))
            {
                await SavePayment(1, request, response);
            }
            return response;
        }
        private async Task<APIPaymentsRequest> RequestBuilder(PaymentCreator input)
        {
            var apiPaymentsRequest = new APIPaymentsRequest();
            var entity = await _contextClass.Employees.
                Include(x => x.Account)
                .ThenInclude(x => x.Bank)
                .FirstOrDefaultAsync(x => x.Id == input.EmployeeId);
            var file = new FileContentsRequestDto
            {
                Reference = entity.Account.Bank.Reference,
                AccountType = entity.Account.AccountType,
                AmountMultiplier = FileAmountType.Cents,
                AccountNumber = entity.Account.AccountNumber,
                FileAmount = 100,
                BranchCode = entity.Account.BranchCode,
                FirstName = entity.FirstName,
                Surname = entity.Surname
            };
            apiPaymentsRequest.Payments.FileContents = file;
            apiPaymentsRequest.Header = new HeaderRequestDto
            {
                Service = input.Service,
                ServiceType = input.ServiceType,
                CallBackUrl = _config["PaySoft:CallBackUrl"],
                Client = entity.ClientCode,
                PsVer = _config["PaySoft:PsVer"],
                DueDate = "20200625"
            };
            apiPaymentsRequest.Totals = new TotalsRequestDto
            {
                Records = 1,
                Amount = 100,
                AccountHash = file.BranchCode,
                BranchHash = file.BranchCode
            };
            return apiPaymentsRequest;
        }
		private async Task SavePayment(int status, APIPaymentsRequest input, Response response)
        {
            await _contextClass.Payments.AddAsync(new Payment
            {
                AmountMultiplier = FileAmountType.Cents,
                Client = input.Header.Client,
                FileAmount = input.Payments.FileContents.FileAmount,
                PaymentStatus = (PaymentStatus)status,
                Reference = input.Payments.FileContents.Reference,
                BranchCode = input.Payments.FileContents.BranchCode,
                AccountNumber = input.Payments.FileContents.AccountNumber,
                Result = response.Result,
                ResultMessage = status == 2 ? response.ResultMessage : string.Empty,
            });
            await _contextClass.SaveChangesAsync();
        }

    }
}
