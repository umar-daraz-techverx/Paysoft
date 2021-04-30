using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Techverx.Paysoft.Services;

namespace Techverx.Paysoft.Controllers
{
	
	public class EmployeeController : ApiControllerController
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _employeeService.Get());
		}
	}
}