using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechExam2.Interface;
using TechExam2.Model;
using TechExam2.Service;

namespace TechExam2.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _iCalculatorService;
        public CalculatorController(ICalculatorService iCalculatorService)
        {
            _iCalculatorService = iCalculatorService;
        }
        [HttpPost("RoundSumOfTwoNumber")]
        public async Task/*set return type to Task*/<IActionResult> RoundSumOfTwoNumber(CalculateRequest request) => Ok(await _iCalculatorService.RoundingSumOf2Int(request.FirstNumber, request.SecondNumber)); //simplify to one liner
    }
}
