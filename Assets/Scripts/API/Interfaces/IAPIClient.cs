using Cysharp.Threading.Tasks;
using API.Dto;

namespace API.Interfaces
{
    public interface IAPIClient
    {
        UniTask<OpenAISpeechToTextResponse> GetOpenAISpeechToTextAsync(byte[] audioData, string language = "ja");
    }
}