using UnityEngine;
using Cores.Views.Interfaces;
using UnityEngine.UI;
using TMPro;

namespace Cores.Views
{
    public class PlayerTalkingView : MonoBehaviour, IPlayerTalkingView
    {
        public Button TalkingButton { get { return _talkingButton; } private set { _talkingButton = value; } }

        [SerializeField] private Button _talkingButton;
    }

}
