using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Text;

namespace OpenAiChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBotController : ControllerBase
    {
        //Only demo purpose - I have use key inline.
        //Dont put the key in your code.
        string openAIKey = "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";

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string query)
        {   
            var openai = new OpenAIAPI(openAIKey);

            //Create Request
            CompletionRequest completionRequest = new CompletionRequest();              
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            //Call API
            var response = await openai.Completions.CreateCompletionAsync(completionRequest);

            //Build Output
            var sbOutput = new StringBuilder();            
            foreach (var completion in response.Completions)
            {
                sbOutput.Append(completion.Text);
            }
            return Ok(sbOutput.ToString());
        }
    }
}
