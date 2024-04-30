using System.Collections.Generic;
using API.Dto;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories.Interfaces
{
    public interface IOpenAIRepository
    {
        UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(List<MessageInfo> messages);
        UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
    }
}
