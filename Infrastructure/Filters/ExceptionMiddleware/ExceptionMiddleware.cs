using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Techverx.Paysoft.Models.Dtos.Error;

namespace Techverx.Paysoft.Filters.ExceptionMiddleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorDetails> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ErrorDetails> logger)
		{
			_logger = logger;
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false); ;
			}
		}

		private Task HandleExceptionAsync(
			HttpContext context,
			Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			return context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = exception.Message
			}.ToString());
		}
	}
}
