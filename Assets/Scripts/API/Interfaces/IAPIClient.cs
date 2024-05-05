using Cysharp.Threading.Tasks;
using API.Dto;

namespace API.Interfaces
{
    public interface IAPIClient
    {
        UniTask<OpenAIGenerateTextResponse> PostOpenAIGenerateTextAsync(OpenAIGenerateTextRequestBody body);
        UniTask<OpenAISpeechToTextResponse> PostOpenAISpeechToTextAsync(byte[] audioData, string language = "ja");
    }
}