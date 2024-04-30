using System.Collections.Generic;
using API.Dto;
using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories
{
    public class OpenAIRepository : IOpenAIRepository
    {
        private IOpenAIDataStore _openAIDataStore { get; }

        public OpenAIRepository
        (
            IOpenAIDataStore openAIDataStore
        )
        {
            _openAIDataStore = openAIDataStore;
        }

        public async UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(List<MessageInfo> messages)
        {
            return await _openAIDataStore.GenerateAnswerAsync(messages);
        }

        public async UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            return await _openAIDataStore.GenerateTranscriptionAsync(audioData, language);
        }
    }
}
