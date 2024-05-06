using Cores.Repositories.Interfaces;
using Cores.DataStores.Interfaces;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

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

        public async UniTask<List<VoicevoxSpeaker>> GetVoicevoxSpeakersAsync()
        {
            var response = await _voicevoxSpeakerDataStore.GetVoicevoxSpeakersAsync();
            var speakers = new List<VoicevoxSpeaker>();

            foreach (var speaker in response.root)
            {
                var speakerEl = new VoicevoxSpeaker(speaker.name);
                foreach (var style in speaker.styles)
                {
                    var styleEl = new VoicevoxSpeakerStyle(style.name, style.id, style.type);
                    speakerEl.Styles.Add(styleEl);
                }
                speakers.Add(speakerEl);
            }

            return speakers;
        }
    }
}
