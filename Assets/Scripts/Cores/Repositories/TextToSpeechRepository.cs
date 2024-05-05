using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.Repositories
{
    public class TextToSpeechRepository : ITextToSpeechRepository
    {
        private ITextToSpeechDataStore _textToSpeechDataStore { get; }

        public TextToSpeechRepository
        (
            ITextToSpeechDataStore textToSpeechDataStore
        )
        {
            _textToSpeechDataStore = textToSpeechDataStore;
        }

        public async UniTask<GenerateTranscription> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            var response = await _textToSpeechDataStore.GenerateTranscriptionAsync(audioData, language);
            var data = new GenerateTranscription(response.text);
            return data;
        }
    }
}
