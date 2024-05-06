using Cores.Repositories.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.Repositories
{
    public class VoicevoxSpeakerRepository : IVoicevoxSpeakerRepository
    {
        private IVoicevoxSpeakerDataStore _voicevoxSpeakerDataStore;

        public VoicevoxSpeakerRepository
        (
            IVoicevoxSpeakerDataStore voicevoxSpeakerDataStore
        )
        {
            _voicevoxSpeakerDataStore = voicevoxSpeakerDataStore;
        }

        public async UniTask<VoicevoxSpeakerInfo> GetVoicevoxSpeakersAsync()
        {
            var response = await _voicevoxSpeakerDataStore.GetVoicevoxSpeakersAsync();
            var speakers = new VoicevoxSpeakerInfo();

            foreach (var speakerInfo in response.styles)
            {
                var speaker = new VoicevoxSpeaker(speakerInfo.name, speakerInfo.id, speakerInfo.type);
                speakers.Styles.Add(speaker);
            }

            return speakers;
        }
    }
}
