using Cysharp.Threading.Tasks;

namespace Cores.Repositories.Interfaces
{
    public interface ISpeechToTextRepository
    {
        UniTask<string> GenerateSpeechToTextAsync(byte[] audioData, string language = "ja");
    }
}
