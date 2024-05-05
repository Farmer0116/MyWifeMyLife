using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface ITextToSpeechDataStore
    {
        UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
    }
}
