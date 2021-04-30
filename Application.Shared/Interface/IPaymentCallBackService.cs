using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techverx.Paysoft.Services
{
	public interface IPaymentCallBackService
	{
		Task CallBack(Dtos.CallBack.Response input);
	}
}
