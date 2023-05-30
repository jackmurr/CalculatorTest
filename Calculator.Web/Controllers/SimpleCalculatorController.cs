using Calculator.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Web.Controllers
{
    [ApiController] // don't need apicontroller here as i put it in base, part of my cors debacle 
    [Route("calculator")]
    public class SimpleCalculatorController : ApiControllerBase
    {
        private readonly ISimpleCalculator _simpleCalculator;
        public SimpleCalculatorController(ISimpleCalculator simpleCalculator) 
        {
            _simpleCalculator = simpleCalculator;
        }

        [HttpGet]
        [Route("add/{start}/{amount}")]
        public ObjectResult Add(int start, int amount)
        {
            try
            {
                var result = _simpleCalculator.Add(start, amount);
                return Ok(result);
            }
            catch (OverflowException ex) // hadle the error, we could add an additonal catch(Exeception) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("subtract/{start}/{amount}")]
        public ObjectResult subtract(int start, int amount)
        {
            try
            {
                var result = _simpleCalculator.Subtract(start, amount);
                return Ok(result);
            }
            catch (OverflowException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
