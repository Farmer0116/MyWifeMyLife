using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface ISpeechToTextDataStore
    {
        UniTask<OpenAISpeechToTextResponse> GenerateSpeechToTextAsync(byte[] audioData, string language = "ja");
    }
}
