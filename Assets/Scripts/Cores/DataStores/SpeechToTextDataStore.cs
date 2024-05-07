using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores
{
    public class SpeechToTextDataStore : ISpeechToTextDataStore
    {
        private IAPIClient _apiClient;

        public SpeechToTextDataStore
        (
            IAPIClient apiClient
        )
        {
            _apiClient = apiClient;
        }

        public async UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            var response = await _apiClient.PostOpenAISpeechToTextAsync(audioData, language);
            return response;
        }
    }
}
