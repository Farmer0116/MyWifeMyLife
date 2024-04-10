using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface IOpenAIDataStore
    {
        UniTask<OpenAISpeechToTextResponse> GetTranscription(byte[] audioData, string language = "ja");
    }
}
