using System.Collections.Generic;
using System.Linq;
using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories
{
    public class TextGenerationRepository : ITextGenerationRepository
    {
        private ITextGenerationDataStore _textGenerationDataStore { get; }

        public TextGenerationRepository
        (
            ITextGenerationDataStore textGenerationDataStore
        )
        {
            _textGenerationDataStore = textGenerationDataStore;
        }

        public async UniTask<string> GenerateAnswerAsync(string prompt, List<MessageInfo> messages)
        {
            var response = await _textGenerationDataStore.GenerateAnswerAsync(prompt, messages);
            return response.choices.Last().message.content;
        }
    }
}
