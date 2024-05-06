using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface ISpeechToTextDataStore
    {
        UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
    }
}
