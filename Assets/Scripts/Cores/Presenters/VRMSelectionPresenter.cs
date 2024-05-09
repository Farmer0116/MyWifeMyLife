using System;
using System.Collections.Generic;
using Cores.Presenters.Interfaces;
using Cores.Views.Interfaces;
using TMPro;
using UniRx;
using UnityEngine.Events;
using Zenject;

namespace Cores.Presenters
{
    public class VRMSelectionPresenter : IVRMSelectionPresenter
    {
        public IObservable<Unit> OnClickSpawnButton { get; private set; }
        public IObservable<string> OnChangeCharacterPromptText { get; private set; }
        public IObservable<int> OnChangeSpeaker { get; private set; }

        private IVRMSelectionView _vrmSelectionView;

        [Inject]
        public VRMSelectionPresenter
        (
            IVRMSelectionView vrmSelectionView
        )
        {
            _vrmSelectionView = vrmSelectionView;

            OnClickSpawnButton = vrmSelectionView.SpawnButton.onClick.AsObservable();
            OnChangeCharacterPromptText = vrmSelectionView.CharacterPrompt.onValueChanged.AsObservable();
            OnChangeSpeaker = _vrmSelectionView.CharacterSpeaker.onValueChanged.AsObservable();
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

        public void ValidSpawnButton()
        {
            _vrmSelectionView.SpawnButton.interactable = true;
        }

        public void InvalidSpawnButton()
        {
            _vrmSelectionView.SpawnButton.interactable = false;
        }

        public string GetVRMFilePath()
        {
            return _vrmSelectionView.VRMFilePath.text ?? "";
        }

        public string GetCharacterPrompt()
        {
            return _vrmSelectionView.CharacterPrompt.text ?? "";
        }

        public void SetSpeaker(List<string> speakers)
        {
            _vrmSelectionView.CharacterSpeaker.options.Clear();
            var optionData = new List<TMP_Dropdown.OptionData>();
            foreach (string speakerInfo in speakers)
            {
                optionData.Add(new TMP_Dropdown.OptionData(speakerInfo));
            }
            _vrmSelectionView.CharacterSpeaker.AddOptions(optionData);
        }

        public int GetSpeaker()
        {
            return _vrmSelectionView.CharacterSpeaker.value;
        }
    }
}
