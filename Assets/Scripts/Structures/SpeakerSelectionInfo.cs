using Types;

namespace Structures
{
    public class SpeakerSelectionInfo
    {
        public TextToSpeechServiceType TextToSpeechServiceType { get; set; }
        public int SpeakerId { get; set; }
        public string SpeakerName { get; set; }

        public SpeakerSelectionInfo
        (
            TextToSpeechServiceType textToSpeechServiceType = TextToSpeechServiceType.Voicevox,
            int speakerId = 0,
            string speakerName = ""
        )
        {
            TextToSpeechServiceType = textToSpeechServiceType;
            SpeakerId = speakerId;
            SpeakerName = speakerName;
        }
    }
}
