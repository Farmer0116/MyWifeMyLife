using API.Dto;
using API.Interfaces;
using Configs;
using Cysharp.Threading.Tasks;

namespace API
{
    public class APIClient : IAPIClient
    {
        private OpenAIApiConfig _configProvider = ConfigProvider.OpenAIApiConfig;
        
        private const string _wisperModel = "whisper-1";
        private const float _wisperTemperature = 0.2f;

        UniTask<WisperSTTResponse> GetWisperSTTAsync(byte[] audioData , string language)
        {
            
        }
    }
}