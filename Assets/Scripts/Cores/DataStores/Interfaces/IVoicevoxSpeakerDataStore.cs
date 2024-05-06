using API.Dto;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores.Interfaces
{
    public interface IVoicevoxSpeakerDataStore
    {
        UniTask<VoicevoxSpeakerListResponse> GetVoicevoxSpeakersAsync();
    }
}
