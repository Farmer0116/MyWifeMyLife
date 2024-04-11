using Types;

namespace Structures
{
    public struct ConversationInfo
    {
        public SpeakerType SpeakerType { get; set; }
        public string Text { get; set; }

        public ConversationInfo(SpeakerType speakerType, string text)
        {
            SpeakerType = speakerType;
            Text = text;
        }
    }
}
