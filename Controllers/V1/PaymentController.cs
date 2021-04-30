using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Techverx.Paysoft.Services;
using Techverx.Paysoft.Dtos.CallBack;
using Techverx.Paysoft.Dtos.EmployeeDtos;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Dtos.PaymentDtos;

namespace Techverx.Paysoft.Controllers
{
    
    public class PaymentController : ApiControllerController
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
		[HttpGet("Get")]
		public async Task<IActionResult> Get(string clientCode)
		{
			return Ok(await _paymentService.GetAllPayments(clientCode));
		}

		

		
    }
}
