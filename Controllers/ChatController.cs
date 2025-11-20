using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatClient _chatClient;
        private JsonSerializerOptions _options;

        public ChatController(ChatClient chatClient)
        {
            _chatClient = chatClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        [HttpPost("RunPrompt")]
        public async Task<IActionResult> RunPrompt()
        {
            //ChatCompletion completion = await _chatClient.CompleteChatAsync(chat.Message);

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("cinema_RAG")}");

            var body = new
            {
                prompt = new
                {
                    id = "pmpt_691697d2bd8c8193866f7f27f91c47290c4a13228f9a6dbc",
                    version = "15",
                    variables = new { action = "查詢" }

                },
                input = new[]
                {
                    new
                    {
                        role = "user",
                        content = new[]
                        {
                            new
                            {
                                type = "input_text",
                                text = "幫我查有哪些大廳可以使用"
                            }
                        }
                    }
                },
                reasoning = new { },
                store = true
            };

            StringContent content = new(JsonSerializer.Serialize(body), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/responses", content);
            string? json1 = await response.Content.ReadAsStringAsync();

            string json = @"{
  ""id"": ""resp_008fcb5a53f810b000691ac0ffe478819793c87ef571f6ce8c"",
  ""object"": ""response"",
  ""created_at"": 1763361024,
  ""status"": ""completed"",
  ""background"": false,
  ""billing"": {
    ""payer"": ""developer""
  },
  ""error"": null,
  ""incomplete_details"": null,
  ""instructions"": [
    {
      ""type"": ""message"",
      ""content"": [
        {
          ""type"": ""input_text"",
          ""text"": ""\u4f60\u662f\u4e00\u4f4d\u5c08\u696d\u7684\u300c\u5f71\u9662\u8a02\u7968\u7cfb\u7d71\u52a9\u7406\u300d\u3002\u4f60\u7684\u8077\u8cac\u662f\u6839\u64da\u4f7f\u7528\u8005\u7684\u81ea\u7136\u8a9e\u8a00\u8f38\u5165\uff0c\u81ea\u52d5\u89e3\u6790\u4e26\u627e\u51fa\u4ee5\u4e0b\u8cc7\u8a0a\uff0c\u4f7f\u7528\u8005\u6c92\u6709\u6307\u5b9a\u8a9e\u8a00\u5247\u4ee5\u7e41\u9ad4\u4e2d\u6587\u56de\u8986\uff1a\n\n\u4f60\u7684\u8077\u8cac\u4e3b\u8981\u8ca0\u8cac\u4f9d\u7167\u67e5\u8a62\u8655\u7406\u4ee5\u4e0b\u76f8\u95dc\u8a0a\u606f\uff1a\n- \u96fb\u5f71\u540d\u7a31\uff08movie\uff09\n- \u5834\u6b21 / \u6642\u9593\uff08showtime / datetime\uff09\n- \u5927\u5ef3\uff08hall\uff09\n- \u5ea7\u4f4d\uff08seat\uff09\n- \u8a02\u7968\u7d00\u9304\u67e5\u8a62\u9700\u6c42\uff08booking history\uff09\n- \u4f7f\u7528\u8005\u60f3\u57f7\u884c\u7684\u52d5\u4f5c\uff1a\u67e5\u8a62\u3001\u9810\u7d04\u3001\u4fee\u6539\u3001\u53d6\u6d88\u3001\u63a8\u85a6\u5ea7\u4f4d\u3001\u67e5\u7d00\u9304\u7b49\n\n\u7576\u63a5\u6536\u5230\u4f7f\u7528\u8005\u7684\u63d0\u554f\u6642\uff0c\u8acb\u4f9d\u7167\u4ee5\u4e0b\u898f\u5247\u904b\u4f5c\uff1a\n\n# \u53c3\u6578\u89e3\u6790\u898f\u5247\uff08\u81ea\u7136\u8a9e\u8a00\u2192\u53c3\u6578\uff09\n1. \u81ea\u52d5\u5f9e\u53e5\u5b50\u4e2d\u6293\u53d6 movie / showtime / hall / seat \u7b49\u8cc7\u8a0a\u3002\n2. \u82e5\u6642\u9593\u6a21\u7cca\uff08\u4f8b\u5982\uff1a\u4eca\u665a\u3001\u4e0b\u5348\u3001\u660e\u5929\uff09\uff0c\u8acb\u81ea\u52d5\u63a8\u8ad6\u70ba\u5177\u9ad4\u6642\u6bb5\u3002\n3. \u82e5\u4f7f\u7528\u8005\u63d0\u5230\u52d5\u4f5c\uff08\u67e5\u8a62\u3001\u9810\u7d04\u3001\u4fee\u6539\u3001\u53d6\u6d88\uff09\uff0c\u8acb\u8fa8\u8b58\u5176\u610f\u5716\u3002\n4. \u82e5\u7f3a\u5c11\u5fc5\u8981\u53c3\u6578\uff08\u4f8b\u5982\u672a\u6307\u5b9a\u96fb\u5f71\u540d\u7a31\uff09\uff0c\u8acb\u5411\u4f7f\u7528\u8005\u63d0\u554f\u88dc\u5145\u8cc7\u8a0a\u3002\n5. \u82e5\u4f7f\u7528\u8005\u8981\u67e5\u8a62\u8a02\u7968\u7d00\u9304\uff0c\u8acb\u63d0\u53d6\u53ef\u7528\u7684\u8b58\u5225\u8cc7\u8a0a\uff08\u4f8b\u5982\uff1aphone\u3001email\u3001userId\uff09\u3002\n\n\u82e5\u4ecd\u6709\u8cc7\u8a0a\u4e0d\u5b8c\u6574\u800c\u7121\u6cd5\u9032\u884c function call\uff0c\u8acb\u660e\u78ba\u8a62\u554f\u4f7f\u7528\u8005\u9700\u8981\u88dc\u54ea\u4e9b\u8cc7\u8a0a\u3002\n\n# \u56de\u8986\u98a8\u683c\n- \u4f7f\u7528\u7c21\u6f54\u3001\u660e\u78ba\u3001\u4eba\u985e\u6613\u8b80\u7684\u8a9e\u8a00\u3002\n- \u5728\u67e5\u8a62\u7d50\u679c\u4e2d\u63d0\u4f9b\u6700\u5fc5\u8981\u7684\u8cc7\u8a0a\uff08\u96fb\u5f71\u540d\u7a31\u3001\u6642\u9593\u3001\u5927\u5ef3\u3001\u5ea7\u4f4d\uff09\u3002\n- \u82e5\u4f7f\u7528\u8005\u8a62\u554f\u5ea7\u4f4d\u63a8\u85a6\uff0c\u53ef\u6839\u64da\u6700\u4f73\u8996\u89d2\u908f\u8f2f\u63d0\u4f9b\u5efa\u8b70\uff0c\u4f8b\u5982\uff1a\u4e2d\u9593\u504f\u5f8c\u3001\u907f\u958b\u7b2c\u4e00\u6392\u7b49\u3002\n- \u82e5\u547c\u53eb function \u5f8c\u53d6\u5f97\u7cfb\u7d71\u56de\u50b3\u7684\u8cc7\u6599\uff0c\u8acb\u6574\u5408\u4e26\u7528\u81ea\u7136\u8a9e\u8a00\u56de\u8986\u4f7f\u7528\u8005\u3002\n\n# \u7279\u6b8a\u898f\u5247\n- \u82e5\u4f7f\u7528\u8005\u554f\u300c\u96a8\u4fbf\u63a8\u85a6\u4e00\u90e8\u7247\u300d\u6216\u300c\u5e6b\u6211\u627e\u4e00\u500b\u597d\u4f4d\u5b50\u300d\uff0c\u53ef\u4f9d\u7167\u5e38\u898b\u504f\u597d\u7d66\u51fa\u5efa\u8b70\uff0c\u4e26\u4f7f\u7528  whatsNewMovies function \u67e5\u8a62\u8cc7\u6599\u3002\n- \u82e5\u4f7f\u7528\u8005\u8aaa\u300c\u5e6b\u6211\u8a02\u7968\u300d\uff0c\u9700\u5224\u65b7\u662f\u5426\u5177\u5099\u96fb\u5f71\u3001\u5834\u6b21\u3001\u5ea7\u4f4d\u7b49\u5fc5\u8981\u8cc7\u8a0a\uff0c\u4e0d\u5b8c\u6574\u6642\u8acb\u5148\u8a62\u554f\u3002\n- \u82e5\u4f7f\u7528\u8005\u63d0\u5230\u300c\u6539\u7968\u300d\u300c\u53d6\u6d88\u300d\u7b49\u9700\u6c42\uff0c\u8acb\u5f15\u5c0e\u63d0\u4f9b\u8a02\u55ae\u7de8\u865f\u6216\u8b58\u5225\u8cc7\u8a0a\u3002""
        }
      ],
      ""role"": ""developer""
    }
  ],
  ""max_output_tokens"": null,
  ""max_tool_calls"": null,
  ""model"": ""gpt-5-nano-2025-08-07"",
  ""output"": [
    {
      ""id"": ""rs_008fcb5a53f810b000691ac1007f7481978746da66dd48d342"",
      ""type"": ""reasoning"",
      ""summary"": []
    },
    {
      ""id"": ""fc_008fcb5a53f810b000691ac108e3048197a031027552932cbd"",
      ""type"": ""function_call"",
      ""status"": ""completed"",
      ""arguments"": ""{\""keyword\"":\""\u602a\u7378\u99ed\u5ba22\"",\""status\"":\""now_playing\""}"",
      ""call_id"": ""call_HnZXwrHnrUNvw5UoqTfrl98r"",
      ""name"": ""get_movies""
    },
    {
      ""id"": ""fc_008fcb5a53f810b000691ac1094d6c8197a6a1ddd92d4fbea2"",
      ""type"": ""function_call"",
      ""status"": ""completed"",
      ""arguments"": ""{\""keyword\"":\""\u602a\u7378\u99ed\u5ba22\"",\""status\"":\""coming_soon\""}"",
      ""call_id"": ""call_r36MLCA9D5TQoIUOoQj1Y2US"",
      ""name"": ""get_movies""
    }
  ],
  ""parallel_tool_calls"": true,
  ""previous_response_id"": null,
  ""prompt"": {
    ""id"": ""pmpt_691697d2bd8c8193866f7f27f91c47290c4a13228f9a6dbc"",
    ""variables"": {
      ""action"": {
        ""type"": ""input_text"",
        ""text"": ""\u67e5\u8a62""
      }
    },
    ""version"": ""13""
  },
  ""prompt_cache_key"": null,
  ""prompt_cache_retention"": null,
  ""reasoning"": {
    ""effort"": ""medium"",
    ""summary"": null
  },
  ""safety_identifier"": null,
  ""service_tier"": ""default"",
  ""store"": true,
  ""temperature"": 1.0,
  ""text"": {
    ""format"": {
      ""type"": ""text""
    },
    ""verbosity"": ""medium""
  },
  ""tool_choice"": ""auto"",
  ""tools"": [
    {
      ""type"": ""function"",
      ""description"": ""\u53d6\u5f97\u76ee\u524d\u53ef\u4f9b\u67e5\u8a62\u7684\u96fb\u5f71\u6e05\u55ae\uff0c\u53ef\u4f9d\u985e\u578b\u3001\u95dc\u9375\u5b57\u6216\u72c0\u614b\uff08\u4e0a\u6620\u4e2d\u3001\u5373\u5c07\u4e0a\u6620\uff09\u9032\u884c\u904e\u6ffe\u3002"",
      ""name"": ""get_movies"",
      ""parameters"": {
        ""type"": ""object"",
        ""properties"": {
          ""keyword"": {
            ""type"": ""string"",
            ""description"": ""\u96fb\u5f71\u641c\u5c0b\u95dc\u9375\u5b57\uff0c\u4f8b\u5982\u300e\u5492\u8853\u8ff4\u6230\u300f\u300e\u54e5\u5409\u62c9\u300f\u300eMarvel\u300f\u3002\u82e5\u672a\u63d0\u4f9b\u5247\u56de\u50b3\u6240\u6709\u96fb\u5f71\u3002""
          },
          ""genre"": {
            ""type"": ""string"",
            ""description"": ""\u96fb\u5f71\u985e\u578b\uff0c\u4f8b\u5982 action\u3001comedy\u3001drama\u3001animation \u7b49\uff08\u53ef\u9078\uff09\u3002""
          },
          ""status"": {
            ""type"": ""string"",
            ""description"": ""\u96fb\u5f71\u72c0\u614b\uff0c\u53ef\u7528 'now_playing'\uff08\u4e0a\u6620\u4e2d\uff09\u6216 'coming_soon'\uff08\u5373\u5c07\u4e0a\u6620\uff09\u3002\u82e5\u672a\u63d0\u4f9b\u5247\u986f\u793a\u6240\u6709\u72c0\u614b\u3002"",
            ""enum"": [
              ""now_playing"",
              ""coming_soon""
            ]
          }
        },
        ""required"": []
      },
      ""strict"": false
    }
  ],
  ""top_logprobs"": 0,
  ""top_p"": 1.0,
  ""truncation"": ""disabled"",
  ""usage"": {
    ""input_tokens"": 388,
    ""input_tokens_details"": {
      ""cached_tokens"": 0
    },
    ""output_tokens"": 775,
    ""output_tokens_details"": {
      ""reasoning_tokens"": 704
    },
    ""total_tokens"": 1163
  },
  ""user"": null,
  ""metadata"": {}
}";


            JsonDocument root = JsonDocument.Parse(json);

            if (root.RootElement.TryGetProperty("output", out JsonElement outputElem))
            {
                UnionTypes outputUnion = new(outputElem);
                outputUnion.Match<OpenAIOutputItem>
                (
                    onObject: (obj) =>
                    {
                        if (obj.Type?.ToLower() == "function_call")
                        {
                            switch (obj.Name)
                            {
                                case "get_movies":
                                    break;
                                case "get_showtimes":
                                    break;
                                case "get_halls":
                                    break;
                            }
                        }
                    },
                    onArray: (list) =>
                    {
                        foreach(OpenAIOutputItem item in list)
                        {
                            if (item.Type?.ToLower() == "function_call")
                            {

                                switch (item.Name)
                                {
                                    case "get_movies":
                                        //GetMoviesArgs? args = JsonSerializer.Deserialize<GetMoviesArgs>(item.Arguments!, _options);
                                        //if (args != null)
                                        //{
                                        //    Console.WriteLine($"Function Call - get_movies: keyword={args.Keyword}, status={args.Status}");
                                        //}
                                        break;
                                    case "get_reservation":
                                        break;
                                    case "get_halls":
                                        break;
                                }
                            }
                        }
                        Console.WriteLine("Output is an array with " + list.Count + " items.");
                    }
                );
            }

            //return Ok(json);
            return Ok(json1);
        }
        public void FunctionCall<T>(string function_name, params (string key, object? value)[] args)
        {
            var arguments = new Dictionary<string, object?>();
            foreach (var (key, value) in args)
            {
                arguments[key] = value;
            }
            string argsJson = JsonSerializer.Serialize(arguments);

        }

        /// <summary>
        /// 找出所有可能的硬幣組合，使其總和為目標值
        /// </summary>
        /// <returns></returns>
        [HttpGet("coins")]
        public IEnumerable<int[]> FindCoinCombinations()
        {
            int target = 10;
            int[] coins = new[] { 1, 3, 5 };
            var results = new List<int[]>();
            int n = coins.Length;

            void DFS(int index, int currentSum, int[] counts)
            {
                // 若剛好達到目標
                if (currentSum == target)
                {
                    results.Add((int[])counts.Clone());
                    return;
                }

                // 若已超過或沒有更多硬幣 → 終止
                if (currentSum > target || index == n)
                    return;

                int coin = coins[index];
                int maxCount = target / coin;

                for (int c = 0; c <= maxCount; c++)
                {
                    counts[index] = c;
                    DFS(index + 1, currentSum + c * coin, counts);
                }

                counts[index] = 0; // 回溯
            }

            DFS(0, 0, new int[n]);

            // 若完全沒有可能組合 → 回傳 -1
            if (results.Count == 0)
                return new List<int[]> { new[] { -1 } };

            return results;
        }
    }


    /// <summary>
    /// Union Types 支援類別
    /// </summary>
    public class UnionTypes
    {
        /// <summary>
        /// JSON 元素
        /// </summary>
        private readonly JsonElement _jsonElement;
        private readonly JsonValueKind _kind;
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="jsonElement"></param>
        public UnionTypes(JsonElement jsonElement)
        {
            _jsonElement = jsonElement;
            _kind = jsonElement.ValueKind;
        }
        /// <summary>
        /// 是否為 null 或未定義
        /// </summary>
        public bool IsNull => _kind == JsonValueKind.Null || _kind == JsonValueKind.Undefined;
        /// <summary>
        /// 是否為物件
        /// </summary>
        public bool IsObject => _kind == JsonValueKind.Object;
        /// <summary>
        /// 是否為陣列
        /// </summary>
        public bool IsArray => _kind == JsonValueKind.Array;
        /// <summary>
        /// 是否為字串
        /// </summary>
        public bool IsString => _kind == JsonValueKind.String;
        /// <summary>
        /// 是否為數字
        /// </summary>
        public bool IsNumber => _kind == JsonValueKind.Number;
        /// <summary>
        /// 是否為布林值
        /// </summary>
        public bool IsBoolean => _kind == JsonValueKind.True || _kind == JsonValueKind.False;
        /// <summary>
        /// 是否為原始類型（字串、數字、布林值）
        /// </summary>
        public bool IsPrimitive => IsString || IsNumber || IsBoolean;


        /// <summary>
        /// Union Types模式匹配
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onNull"></param>
        /// <param name="onObject"></param>
        /// <param name="onArray"></param>
        /// <param name="onString"></param>
        /// <param name="onNumber"></param>
        /// <param name="onBoolean"></param>
        public void Match<T>
        (
            Action? onNull = null,
            Action<T>? onObject = null,
            Action<List<T>>? onArray = null,
            Action<string>? onString = null,
            Action<double>? onNumber = null,
            Action<bool>? onBoolean = null
        )
        {
            //1. 判斷是否為 Null
            if (IsNull)
            {
                onNull?.Invoke();
                return;
            }
            //2. 判斷是否為物件
            if (IsObject)
            {
                T obj = JsonSerializer.Deserialize<T>(_jsonElement.GetRawText())!;
                onObject?.Invoke(obj);
                return;
            }
            //3. 判斷是否為陣列
            if (IsArray)
            {
                List<T> list = new();
                foreach (var item in _jsonElement.EnumerateArray())
                {
                    T obj = JsonSerializer.Deserialize<T>(item.GetRawText())!;
                    list.Add(obj);
                }
                onArray?.Invoke(list);
                return;
            }
            //4. 判斷是否為原始類型
            if (IsPrimitive)
            {
                switch (_jsonElement.ValueKind)
                {
                    case JsonValueKind.String:
                        onString?.Invoke(_jsonElement.GetString()!);
                        break;
                    case JsonValueKind.Number:
                        onNumber?.Invoke(_jsonElement.GetDouble());
                        break;
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                        onBoolean?.Invoke(_jsonElement.GetBoolean());
                        break;
                }
            }
        }
    }

    public class OpenAIOutputItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("arguments")]
        public string? Arguments { get; set; }

        [JsonPropertyName("call_id")]
        public string? CallId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    //public class GetMoviesArgs
    //{
    //    public string? Keyword { get; set; }
    //    public string? Status { get; set; }
    //}


}
