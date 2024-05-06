using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Cores.Repositories.Interfaces
{
    public interface IVoicevoxSpeakerRepository
    {
        UniTask<List<VoicevoxSpeaker>> GetVoicevoxSpeakersAsync();
    }

    public class VoicevoxSpeaker
    {
        public string Name;
        public List<VoicevoxSpeakerStyle> Styles;

        public VoicevoxSpeaker(string name)
        {
            Name = name;
            Styles = new List<VoicevoxSpeakerStyle>();
        }
    }

    public class VoicevoxSpeakerStyle
    {
        public string Name;
        public int Id;
        public string Type;

        public VoicevoxSpeakerStyle
        (
            string name,
            int id,
            string type
        )
        {
            Name = name;
            Id = id;
            Type = type;
        }
    }
}
