using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores
{
    public class TextToSpeechDataStore : ITextToSpeechDataStore
    {
        private IAPIClient _apiClient;

        public TextToSpeechDataStore
        (
            IAPIClient apiClient
        )
        {
            _apiClient = apiClient;
        }

        public async UniTask<VoicevoxTextToSpeechResponse> GenerateTextToSpeechAsync(int speaker, string text, int intpitch = 0, float intonationScale = 1, float speed = 1)
        {
            var response = await _apiClient.PostVoicevoxTextToSpeechAsync(speaker, text, intpitch, intonationScale, speed);
            return response;
        }
    }
}
