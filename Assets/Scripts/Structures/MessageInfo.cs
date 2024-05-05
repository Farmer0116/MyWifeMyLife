using Types;

namespace Structures
{
    public struct MessageInfo
    {
        public SpeakerType SpeakerType { get; set; }
        public string Content { get; set; }

        public MessageInfo(SpeakerType speakerType, string content)
        {
            SpeakerType = speakerType;
            Content = content;
        }
    }
}
