using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Threading.Tasks;

namespace OpenAiChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBotController : ControllerBase
    {
        private const string openAIKey = "your-api-key-here";

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string query)
        {
            var openai = new OpenAIAPI(openAIKey);

            var chatRequest = new ChatRequest()
            {
                // Either update your NuGet package and use:
                // Model = OpenAI_API.Models.Model.ChatGPTTurbo,

                // OR use the direct model name string:
                Model = "gpt-3.5-turbo",

                Messages = new[]
                {
                    new ChatMessage(ChatMessageRole.User, query)
                }
            };

            var response = await openai.Chat.CreateChatCompletionAsync(chatRequest);
            return Ok(response.Choices[0].Message.Content);
        }
    }
}