using System;
using Presentation.Presenters.Interfaces;
using Presentation.Views.Interfaces;
using UniRx;
using Zenject;

namespace Presentation.Presenters
{
    public class VRMSelectionPresenter : IVRMSelectionPresenter
    {
        public IObservable<Unit> OnClickBrowserButton { get; private set; }
        public IObservable<Unit> OnClickSpawnButton { get; private set; }

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
