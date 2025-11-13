using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Data;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatClient _chatClient;

        public ChatController(ChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        [HttpPost("Complete")]
        public async Task<IActionResult> CompleteChat([FromBody] ChatViewModel chat)
        {
            //ChatCompletion completion = await _chatClient.CompleteChatAsync(chat.Message);

            List<string> contents = new List<string>();
            AsyncCollectionResult<StreamingChatCompletionUpdate> completionUpdates = _chatClient.CompleteChatStreamingAsync(chat.Message);


            Console.Write($"[ASSISTANT]: ");
            await foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
            {
                if (completionUpdate.ContentUpdate.Count > 0)
                {
                    contents.Add(completionUpdate.ContentUpdate[0].Text);
                    //Console.Write(completionUpdate.ContentUpdate[0].Text);
                }
            }

            return Ok(contents);
        }
    }
}
