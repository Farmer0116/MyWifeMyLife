using System.Collections.Generic;
using System.Linq;
using Cores.DataStores.Interfaces;
using Cores.Repositories.Interfaces;
using Cysharp.Threading.Tasks;
using Structures;

namespace Cores.Repositories
{
    public class OpenAIRepository : IOpenAIRepository
    {
        private IOpenAIDataStore _openAIDataStore { get; }

        public OpenAIRepository
        (
            IOpenAIDataStore openAIDataStore
        )
        {
            _openAIDataStore = openAIDataStore;
        }

        public async UniTask<GenerateTextData> GenerateAnswerAsync(string prompt, List<MessageInfo> messages)
        {
            var response = await _openAIDataStore.GenerateAnswerAsync(prompt, messages);
            var data = new GenerateTextData(response.choices.Last().message.content);
            return data;
        }

        public async UniTask<GenerateTranscription> GenerateTranscriptionAsync(byte[] audioData, string language = "ja")
        {
            var response = await _openAIDataStore.GenerateTranscriptionAsync(audioData, language);
            var data = new GenerateTranscription(response.text);
            return data;
        }
    }

    public class GenerateTextData
    {
        public string Text { get; set; }

        public GenerateTextData
        (
            string text
        )
        {
            Text = text;
        }
    }

    public class GenerateTranscription
    {
        public string Text { get; set; }

        public GenerateTranscription
        (
            string text
        )
        {
            Text = text;
        }
    }
}
