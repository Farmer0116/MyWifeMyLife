using TMPro;
using UnityEngine.UI;

namespace Cores.Views.Interfaces
{
    public interface IPlayerTalkingView
    {
        Button TalkingButton { get; }
        TMP_Text TalkingTextBox { get; }
    }
}
