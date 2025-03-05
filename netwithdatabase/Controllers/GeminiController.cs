using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netwithdatabase.Models;

namespace netwithdatabase.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeminiController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> AIResponseAsync([FromBody] string gemini)
        //{
        //    // You can pass the necessary parameters or use default values
        //    string projectId = "jamil-333509";
        //    string location = "us-central1";
        //    string publisher = "google";
        //    string model = "gemini-1.0-pro-vision";

        //    // Create an instance of the class containing the GenerateContent method
        //    YourClassContainingGenerateContent instance = new YourClassContainingGenerateContent();

        //    // Call the GenerateContent method
        //    string result = await instance.GenerateContent(projectId, location, publisher, model, gemini);

            
        //    return Ok(result);
        //}
        [HttpPost]
        public async Task<IActionResult> TextToTextResponse([FromBody] string input)
        {
            string result= await GenerateTextFromText.Generate(input);
            return Ok(result);
        }
    }
}
