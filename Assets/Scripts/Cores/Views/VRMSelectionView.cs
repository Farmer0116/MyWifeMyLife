using Cores.Views.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Views
{
    public class VRMSelectionView : MonoBehaviour, IVRMSelectionView
    {
        public RectTransform RootTransform { get { return _rootTransform; } }
        public Button SpawnButton { get { return _spawnButton; } }
        public TMP_InputField VRMFilePath { get { return _vrmFilePath; } }
        public TMP_InputField CharacterPrompt { get { return _characterPrompt; } }
        public TMP_Dropdown CharacterSpeaker { get { return _characterSpeaker; } }

        [SerializeField] RectTransform _rootTransform;
        [SerializeField] Button _spawnButton;
        [SerializeField] TMP_InputField _vrmFilePath;
        [SerializeField] TMP_InputField _characterPrompt;
        [SerializeField] TMP_Dropdown _characterSpeaker;
    }
}
