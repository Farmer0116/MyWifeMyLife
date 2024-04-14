using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.Repositories.Interfaces
{
    public interface IOpenAIRepository
    {
        UniTask<OpenAISpeechToTextResponse> GetTranscription(byte[] audioData, string language = "ja");
    }
}
