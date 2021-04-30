using System.Threading.Tasks;
using Techverx.Paysoft.Dtos.HeaderDtos;
using Techverx.Paysoft.Dtos.PaySoft;

namespace Techverx.Paysoft.Services
{
	public interface IPaymentRequestService
	{
		Task<Response> RequestPaymentAsync(PaymentCreator input);
	}
}
