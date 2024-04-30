using System.Collections.Generic;
using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;
using Types;
using Structures;

namespace Cores.DataStores
{
    public class OpenAIDataStore : IOpenAIDataStore
    {
        private IAPIClient _apiClient;

        public OpenAIDataStore
        (
            IAPIClient apiClient
        )
        {
            _apiClient = apiClient;
        }

        public async UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(List<MessageInfo> messages)
        {
            var bodyMessages = new OpenAIGenerateTextRequestBody();

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

        public async UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            var response = await _apiClient.PostOpenAISpeechToTextAsync(audioData, language);
            return response;
        }
    }
}
