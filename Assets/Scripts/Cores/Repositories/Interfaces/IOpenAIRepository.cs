using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories.Interfaces
{
    public interface IOpenAIRepository
    {
        UniTask<GenerateTextData> GenerateAnswerAsync(string prompt, List<MessageInfo> messages);
        UniTask<GenerateTranscription> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
    }
}
