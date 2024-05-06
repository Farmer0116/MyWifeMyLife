using System.Collections.Generic;

namespace API.Dto
{
    public class VoicevoxSpeakerListResponse
    {
        public VoicevoxSupportedFeature supported_features;
        public string name;
        public string speaker_uuid;
        public List<VoicevoxSpeakerStyle> styles;
        public string version;
    }

    public class VoicevoxSupportedFeature
    {
        public string permitted_synthesis_morphing;
    }

    public class VoicevoxSpeakerStyle
    {
        public string name;
        public int id;
        public string type;
    }
}