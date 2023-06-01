using LLama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLlamaSharp.Services
{
    internal class ChatSession
    {
        ChatSession<LLamaModel> _session;
        public string _response;
        public ChatSession(string modelPath, string[] antiprompt)
        {
            LLamaModel model = new(new LLamaParams(model: modelPath, n_ctx: 512, interactive: true, repeat_penalty: 1.0f, verbose_prompt: false));
            _session = new ChatSession<LLamaModel>(model)
                .WithAntiprompt(antiprompt);
        }

        public async void Chat(string userPrompt)
        {
            var outputs = _session.Chat(userPrompt, encoding: "UTF-8");
            _response = string.Join("", outputs.ToArray());
            //foreach (var output in outputs)
            //{
            //    Console.Write(output);
            //}
        }
    }
}
