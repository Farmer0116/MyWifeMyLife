using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface ITextToSpeechDataStore
    {
        UniTask<VoicevoxTextToSpeechResponse> GenerateTextToSpeechAsync(int speaker, string text, int intpitch = 0, float intonationScale = 1, float speed = 1);
    }
}