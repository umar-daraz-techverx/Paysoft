using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.PaySoft;

namespace Techverx.Paysoft.ProxyService
{
	public interface IProxyService
	{
		Task<Response> Send(string date,string key);
	}
}
