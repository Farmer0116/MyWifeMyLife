using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

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

        public async UniTask<AudioClip> GenerateSpeechToTextAsync(int speaker, string text, int intpitch = 0, float intonationScale = 1, float speed = 1)
        {
            var response = await _textToSpeechDataStore.GenerateTextToSpeechAsync(speaker, text, intpitch, intonationScale, speed);
            return response.audioClip;
        }
    }
}
