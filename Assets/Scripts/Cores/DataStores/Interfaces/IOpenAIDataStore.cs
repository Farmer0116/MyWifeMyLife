using System.Collections.Generic;
using API.Dto;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.DataStores.Interfaces
{
    public interface IOpenAIDataStore
    {
        UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(string prompt, List<MessageInfo> messages);
        UniTask<OpenAISpeechToTextResponse> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
    }
}
