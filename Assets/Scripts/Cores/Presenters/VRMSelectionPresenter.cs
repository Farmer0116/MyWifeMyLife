using System;
using Cores.Presenters.Interfaces;
using Cores.Views.Interfaces;
using UniRx;
using UnityEngine.Events;
using Zenject;

namespace Cores.Presenters
{
    public class VRMSelectionPresenter : IVRMSelectionPresenter
    {
        public IObservable<Unit> OnClickBrowserButton { get; private set; }
        public IObservable<Unit> OnClickSpawnButton { get; private set; }
        public IObservable<string> OnChangeCharacterPromptText { get; private set; }

        private IVRMSelectionView _vrmSelectionView;

        [Inject]
        public VRMSelectionPresenter
        (
            IVRMSelectionView vrmSelectionView
        )
        {
            _vrmSelectionView = vrmSelectionView;

            OnClickBrowserButton = vrmSelectionView.BrowserButton.onClick.AsObservable();
            OnClickSpawnButton = vrmSelectionView.SpawnButton.onClick.AsObservable();
            OnChangeCharacterPromptText = vrmSelectionView.CharacterPrompt.onValueChanged.AsObservable();
        }

        public void ShowRootUI()
        {
            _vrmSelectionView.RootTransform.gameObject.SetActive(true);
        }

        public void HideRootUI()
        {
            _vrmSelectionView.RootTransform.gameObject.SetActive(false);
        }

        public bool GetRootUIState()
        {
            return _vrmSelectionView.RootTransform.gameObject.activeSelf;
        }

        public string GetVRMFilePath()
        {
            return _vrmSelectionView.VRMFilePath.text ?? "";
        }

        public string GetCharacterPrompt()
        {
            return _vrmSelectionView.CharacterPrompt.text ?? "";
        }

        public void ValidSpawnButton()
        {
            _vrmSelectionView.SpawnButton.interactable = true;
        }

        public void InvalidSpawnButton()
        {
            _vrmSelectionView.SpawnButton.interactable = false;
        }
    }
}
