using Cysharp.Threading.Tasks;

namespace Cores.Repositories.Interfaces
{
    public interface ITextToSpeechRepository
    {
        UniTask<GenerateTranscription> GenerateTranscriptionAsync(byte[] audioData, string language = "ja");
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
