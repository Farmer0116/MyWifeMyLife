using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories.Interfaces
{
    public interface ITextGenerationRepository
    {
        UniTask<TextGenerationData> GenerateAnswerAsync(string prompt, List<MessageInfo> messages);
    }

    public class TextGenerationData
    {
        public string Text { get; set; }

        public TextGenerationData
        (
            string text
        )
        {
            Text = text;
        }
    }
}
