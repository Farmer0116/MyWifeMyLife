using API.Dto;
using API.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.DataStores
{
    public class VoicevoxSpeakerDataStore : IVoicevoxSpeakerDataStore
    {
        private IAPIClient _apiClient;

        public VoicevoxSpeakerDataStore
        (
            IAPIClient apiClient
        )
        {
            _apiClient = apiClient;
        }

        public async UniTask<VoicevoxSpeakerListResponse> GetVoicevoxSpeakersAsync()
        {
            return await _apiClient.GetVoicevoxSpeakersAsync();
        }
    }
}
