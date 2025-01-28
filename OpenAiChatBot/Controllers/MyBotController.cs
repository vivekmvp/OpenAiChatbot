using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAiChatBot.Models;
using System;
using System.Threading.Tasks;

namespace OpenAiChatBot.Controllers
{
    public class MyBotController : Controller
    {
        private readonly string openAIKey;

        public MyBotController(IConfiguration configuration)
        {
            openAIKey = configuration["OpenAI:ApiKey"];
        }

        // API Endpoint
        [HttpGet]
        [Route("api/search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query cannot be empty.");

            try
            {
                var openai = new OpenAIAPI(openAIKey);
                var chatRequest = new ChatRequest
                {
                    Model = "gpt-3.5-turbo",
                    Messages = new[] { new ChatMessage(ChatMessageRole.User, query) }
                };

                var response = await openai.Chat.CreateChatCompletionAsync(chatRequest);

                if (response.Choices == null || response.Choices.Count == 0)
                    return StatusCode(500, "No response from OpenAI.");

                return Ok(response.Choices[0].Message.Content); // JSON response
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred.");
            }
        }



        // GET: MyBot/Chat
        [HttpGet]
        public IActionResult Chat()
        {
            return View();
        }

        // POST: MyBot/Chat
        [HttpPost]
        public async Task<IActionResult> Chat(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ViewBag.Response = "Please enter a valid query.";
                return View();
            }

            try
            {
                var openai = new OpenAIAPI(openAIKey);

                var chatRequest = new ChatRequest
                {
                    Model = "gpt-3.5-turbo",
                    Messages = new[] { new ChatMessage(ChatMessageRole.User, query) }
                };

                var response = await openai.Chat.CreateChatCompletionAsync(chatRequest);
                ViewBag.Response = response.Choices[0].Message.Content;
            }
            catch (Exception ex)
            {
                ViewBag.Response = $"An error occurred: {ex.Message}";
            }

            return View();
        }



    }
}
