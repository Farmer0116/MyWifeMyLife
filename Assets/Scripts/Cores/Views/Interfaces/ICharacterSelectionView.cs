using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Views.Interfaces
{
    public interface ICharacterSelectionView
    {
        RectTransform RootTransform { get; }
        Button SpawnButton { get; }
        TMP_InputField VRMFilePath { get; }
        TMP_InputField CharacterPrompt { get; }
        TMP_Dropdown CharacterSpeaker { get; }
    }
}
