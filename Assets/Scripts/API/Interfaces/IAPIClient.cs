using Cysharp.Threading.Tasks;
using API.Dto;

namespace API.Interfaces
{
    public interface IAPIClient
    {
        UniTask<OpenAIGenerateTextResponse> PostOpenAIGenerateTextAsync(OpenAIGenerateTextRequestBody body);
        UniTask<OpenAISpeechToTextResponse> PostOpenAISpeechToTextAsync(byte[] audioData, string language = "ja");
        UniTask<VoicevoxSpeakerListResponse> GetVoicevoxSpeakersAsync();
        UniTask<VoicevoxTextToSpeechResponse> PostVoicevoxTextToSpeechAsync(int speaker, string text, int intpitch = 0, float intonationScale = 1, float speed = 1);
    }
}