using Microsoft.AspNetCore.Mvc;
using Techverx.Paysoft.Contracts.V1;

namespace Techverx.Paysoft.Controllers
{
	[Route(ApiRoutes.Base + "/[controller]")]
	[ApiController]
	public class ApiControllerController : ControllerBase
	{
	}
}
