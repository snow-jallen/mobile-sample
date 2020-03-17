using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NeighborThrift4.Data;
using Refit;

namespace NeighborThrift4.Services
{
	public interface IWeatherForecastApi
	{
		[Get("/weatherforecast/")]
		Task<IEnumerable<WeatherForecast>> GetForecastAsync();
	}

	public interface ICalculatorApi
	{
		[Get("/api/calculator")]
		Task<int> Add([Body]MathRequest mathRequest);

		[Post("/api/calculator")]
		Task<int> AddUsingPost(MathRequest mathRequest);

		[Get("/api/calculator/add")]
		Task<int> AddWithRoute(int num1, int num2);
	}

	public class MathRequest
	{
		public int Num1 { get; set; }
		public int Num2 { get; set; }
		public string Operation { get; set; }
	}
}
