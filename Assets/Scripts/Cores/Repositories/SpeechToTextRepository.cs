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

        public async UniTask<GenerateTranscription> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            var response = await _speechToTextDataStore.GenerateTranscriptionAsync(audioData, language);
            var data = new GenerateTranscription(response.text);
            return data;
        }
    }
}
