using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NeighborThrift.Api.Controllers
{
	public class MathRequest
	{
		public int Num1 { get; set; }
		public int Num2 { get; set; }
		public string Operation { get; set; }
	}

    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
		readonly ILogger<CalculatorController> _logger;

		public CalculatorController(ILogger<CalculatorController> logger)
		{
			_logger = logger;
		}

        // GET: api/Calculator
        [HttpGet]
        public int Get(MathRequest mathRequest)
        {
			switch (mathRequest.Operation)
			{
				case "+":
					var answer = mathRequest.Num1 + mathRequest.Num2;
					_logger.LogDebug($"added {mathRequest.Num1} and {mathRequest.Num2} to get {answer}");
					return answer;
				default:
					return 0;
			}
        }

		[HttpPost]
		public int DoMathUsingPost(MathRequest mathRequest)
		{
			switch (mathRequest.Operation)
			{
				case "+":
					return mathRequest.Num1 + mathRequest.Num2;
				default:
					return 0;
			}
		}

		// GET: api/Calculator/5
		[HttpGet]
		[Route("add")]
		public int Get(int num1, int num2)
		{
			return num1 + num2;
		}

		//// POST: api/Calculator
		//[HttpPost]
  //      public void Post([FromBody] string value)
  //      {
  //      }

  //      // PUT: api/Calculator/5
  //      [HttpPut("{id}")]
  //      public void Put(int id, [FromBody] string value)
  //      {
  //      }

  //      // DELETE: api/ApiWithActions/5
  //      [HttpDelete("{id}")]
  //      public void Delete(int id)
  //      {
  //      }
    }
}
