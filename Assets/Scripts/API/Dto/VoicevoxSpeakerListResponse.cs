using System;
using System.Collections.Generic;

namespace API.Dto
{
    [Serializable]
    public class VoicevoxSpeakerListResponse
    {
        public List<VoicevoxSpeaker> root;
    }

    [Serializable]
    public class VoicevoxSpeaker
    {
        public VoicevoxSupportedFeature supported_features;
        public string name;
        public string speaker_uuid;
        public List<VoicevoxSpeakerStyle> styles;
        public string version;
    }

    [Serializable]
    public class VoicevoxSupportedFeature
    {
        public string permitted_synthesis_morphing;
    }

    [Serializable]
    public class VoicevoxSpeakerStyle
    {
        public string name;
        public int id;
        public string type;
    }
}