using API.Dto;
using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;

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

        public async UniTask<OpenAISpeechToTextResponse> GetTranscription(byte[] audioData, string language = "ja")
        {
            return await _openAIDataStore.GetTranscription(audioData, language);
        }
    }
}
