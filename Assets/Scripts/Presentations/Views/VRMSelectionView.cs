using Presentation.Views.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.Views
{
    public class VRMSelectionView : MonoBehaviour, IVRMSelectionView
    {
        public RectTransform RootTransform { get { return _rootTransform; } }
        public Button BrowserButton { get { return _browserButton; } }
        public Button SpawnButton { get { return _spawnButton; } }
        public TMP_InputField VRMFilePath { get { return _vrmFilePath; } }

        [SerializeField] RectTransform _rootTransform;
        [SerializeField] Button _browserButton;
        [SerializeField] Button _spawnButton;
        [SerializeField] TMP_InputField _vrmFilePath;
    }
}
