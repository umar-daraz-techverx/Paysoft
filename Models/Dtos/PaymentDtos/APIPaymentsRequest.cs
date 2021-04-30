using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Dtos.TotalsDtos;

namespace Techverx.Paysoft.Dtos.PaymentDtos
{
    public class APIPaymentsRequest
    {
        public HeaderRequestDto Header { get; set; }
        public PaymentRequestDto Payments { get; set; }
        public TotalsRequestDto Totals { get; set; }

       public APIPaymentsRequest()
        {
	        Payments=new PaymentRequestDto();
        }

    }
}
