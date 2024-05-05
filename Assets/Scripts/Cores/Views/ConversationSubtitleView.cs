using Cores.Views.Interfaces;
using TMPro;
using UnityEngine;

namespace Cores.Views
{
    public class ConversationSubtitleView : MonoBehaviour, IConversationSubtitleView
    {
        public TMP_Text ConversationTextBox { get { return _conversationTextBox; } private set { _conversationTextBox = value; } }
        [SerializeField] private TMP_Text _conversationTextBox;
    }
}
