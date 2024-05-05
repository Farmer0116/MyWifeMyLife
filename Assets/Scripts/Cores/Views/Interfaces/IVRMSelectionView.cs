using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Views.Interfaces
{
    public interface IVRMSelectionView
    {
        RectTransform RootTransform { get; }
        Button BrowserButton { get; }
        Button SpawnButton { get; }
        TMP_InputField VRMFilePath { get; }
        TMP_InputField CharacterPrompt { get; }
    }
}
