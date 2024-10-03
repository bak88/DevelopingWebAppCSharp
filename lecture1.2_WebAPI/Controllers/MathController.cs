using lecture1._2_WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace lecture1._2_WebAPI.Controllers
{
    [LogActionFilter]
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public MathController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(template: "Square")]
        public int Square(int x) => x * x;

        [HttpGet(template: "Divide")]
        public ActionResult<int> Divide(int x, int y)
        {
            try
            {
                var z =  x / y;
                return Ok(z);
            }
            catch(DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        private static int CalculateFibonacci(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException("Fibonacci number can't less then 1");

            if (number > 46)
                throw new ArgumentOutOfRangeException("Fibonacci exceed max integer value");

            int first = 1;
            int second = 1;

            for (int i = 2; i <= number; i++)
            {
                int temp = first;
                first = second;
                second = temp + first;
            }
            return first;
        }

        [HttpGet(template: "Fibonacci")]
        public async Task<ActionResult<int>> FibonacciAsync(int x, int y)
        {
            var rx = await Task.Run(() => CalculateFibonacci(x));
            var ry = await Task.Run(() => CalculateFibonacci(y));

            return Ok(rx +  ry);    
        }
    }
}
