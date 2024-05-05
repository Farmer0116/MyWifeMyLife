using System.Collections.Generic;
using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;
using Types;
using Structures;

namespace Cores.DataStores
{
    public class TextGenerationDataStore : ITextGenerationDataStore
    {
        private IAPIClient _apiClient;

        public TextGenerationDataStore
        (
            IAPIClient apiClient
        )
        {
            _apiClient = apiClient;
        }

        public async UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(string prompt, List<MessageInfo> messages)
        {
            var bodyMessages = new OpenAIGenerateTextRequestBody();

            if (!string.IsNullOrEmpty(prompt))
            {
                bodyMessages.messages.Add(new OpenAIGenerateTextRequestBodyMessage(RoleType.system.ToString(), prompt));
            }

            foreach (var message in messages)
            {
                switch (message.SpeakerType)
                {
                    case SpeakerType.Player:
                        bodyMessages.messages.Add(new OpenAIGenerateTextRequestBodyMessage(RoleType.user.ToString(), message.Content));
                        break;
                    case SpeakerType.NPC:
                        bodyMessages.messages.Add(new OpenAIGenerateTextRequestBodyMessage(RoleType.system.ToString(), message.Content));
                        break;
                    default:
                        break;
                }
            }

            var response = await _apiClient.PostOpenAIGenerateTextAsync(bodyMessages);
            return response;
        }
    }
}
