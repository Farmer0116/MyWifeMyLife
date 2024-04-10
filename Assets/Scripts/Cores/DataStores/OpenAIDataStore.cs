using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;

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

        public async UniTask<OpenAISpeechToTextResponse> GetTranscription(byte[] audioData, string language = "ja")
        {
            var response = await _apiClient.PostOpenAISpeechToTextAsync(audioData, language);
            return response;
        }
    }
}
