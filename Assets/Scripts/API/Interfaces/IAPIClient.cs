using Cysharp.Threading.Tasks;
using API.Dto;

namespace API.Interfaces
{
    public interface IAPIClient
    {
        UniTask<WisperSTTResponse> GetWisperSTTAsync(byte[] audioData , string language);
    } 
}