using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Paysoft.DataContext;
using Techverx.Paysoft.Dtos.EmployeeDtos;
using Techverx.Paysoft.Models;

namespace Techverx.Paysoft.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ContextClass _contextClass;
		private readonly IMapper _mapper;
		public EmployeeService(ContextClass contextClass, IMapper mapper)
		{
			_contextClass = contextClass;
			_mapper = mapper;
		}
		public async Task<ServiceResponse<List<GetEmployeeDto>>> Get()
		{
			var response = new ServiceResponse<List<GetEmployeeDto>>();
			var query = _contextClass.Employees.AsQueryable();
			response.Data = await query.Select(o => _mapper.Map<GetEmployeeDto>(o)).ToListAsync();
			response.Success = true;
			return response;
		}

	}

}
