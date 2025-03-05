using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netwithdatabase.Models;

namespace netwithdatabase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeminiController : ControllerBase
    {       
        [HttpPost]
        public async Task<IActionResult> TextToTextResponse([FromBody] string input)
        {
            string result= await GenerateTextFromText.Generate(input);
            return Ok(result);
        }
    }
}
