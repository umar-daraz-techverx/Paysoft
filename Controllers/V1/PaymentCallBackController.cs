using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.CallBack;
using Techverx.Paysoft.Services;

namespace Techverx.Paysoft.Controllers
{
	public class PaymentCallBackController : ApiControllerController
	{
		private readonly IPaymentCallBackService _paymentCallBackService;
		public PaymentCallBackController(IPaymentCallBackService paymentCallBackService)
		{
			_paymentCallBackService = paymentCallBackService;
		}
		[Consumes("application/xml")]
		[Produces("application/xml")]
		[ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
		[HttpPost("PaymentCallBack")]
		public async Task<IActionResult> PaymentCallBack([FromBody] Response input)
		{
			await _paymentCallBackService.CallBack(input);
			return Ok();
		}
	}
}
