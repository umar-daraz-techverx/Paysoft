
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Services;

namespace Techverx.Paysoft.Controllers.V1
{
	
	public class PaymentRequestController : ApiControllerController
	{
		private readonly IPaymentRequestService _paymentRequestService;
		public PaymentRequestController(IPaymentRequestService paymentRequestService)
		{
			_paymentRequestService = paymentRequestService;
		}
		[HttpPost("PaymentRequest")]
		public async Task<IActionResult> PaymentRequest(PaymentCreator input)
		{
			return Ok(await _paymentRequestService.RequestPaymentAsync(input));
		}
	}
}
