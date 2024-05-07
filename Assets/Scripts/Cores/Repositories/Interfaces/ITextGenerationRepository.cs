using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories.Interfaces
{
    public interface ITextGenerationRepository
    {
        UniTask<string> GenerateAnswerAsync(string prompt, List<MessageInfo> messages);
    }
}
