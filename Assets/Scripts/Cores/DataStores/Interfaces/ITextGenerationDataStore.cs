using System.Collections.Generic;
using API.Dto;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.DataStores.Interfaces
{
    public interface ITextGenerationDataStore
    {
        UniTask<OpenAIGenerateTextResponse> GenerateAnswerAsync(string prompt, List<MessageInfo> messages);
    }
}
