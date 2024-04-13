using UnityEngine;
using Cores.Views.Interfaces;
using UnityEngine.UI;
using TMPro;

namespace Cores.Views
{
    public class PlayerTalkingView : MonoBehaviour, IPlayerTalkingView
    {
        public Button TalkingButton { get { return _talkingButton; } private set { _talkingButton = value; } }
        public TMP_Text TalkingTextBox { get { return _talkingTextBox; } private set { _talkingTextBox = value; } }

        [SerializeField] private Button _talkingButton;
        [SerializeField] private TMP_Text _talkingTextBox;
    }

}
