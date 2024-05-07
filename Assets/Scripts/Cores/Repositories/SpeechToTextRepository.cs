using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.Repositories
{
    public class SpeechToTextRepository : ISpeechToTextRepository
    {
        private ISpeechToTextDataStore _speechToTextDataStore { get; }

        public SpeechToTextRepository
        (
            ISpeechToTextDataStore speechToTextDataStore
        )
        {
            _speechToTextDataStore = speechToTextDataStore;
        }

        public async UniTask<string> GenerateSpeechToTextAsync(byte[] audioData, string language = "ja")
        {
            var response = await _speechToTextDataStore.GenerateSpeechToTextAsync(audioData, language);
            return response.text;
        }
    }
}
