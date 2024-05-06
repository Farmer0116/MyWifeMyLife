using System.Collections.Generic;

namespace Cores.Repositories.Interfaces
{
    public interface IVoicevoxSpeakerRepository
    {
    }

    public class VoicevoxSpeakerInfo
    {
        public List<VoicevoxSpeaker> Styles;

        public VoicevoxSpeakerInfo()
        {
            Styles = new List<VoicevoxSpeaker>();
        }
    }

    public class VoicevoxSpeaker
    {
        public string Name;
        public int Id;
        public string Type;

        public VoicevoxSpeaker
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
