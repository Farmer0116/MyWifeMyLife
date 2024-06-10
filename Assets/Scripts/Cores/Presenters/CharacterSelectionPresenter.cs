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
    public class CharacterSelectionPresenter : ICharacterSelectionPresenter
    {
        public IObservable<Unit> OnClickSpawnButton { get; private set; }
        public IObservable<string> OnChangeCharacterPromptText { get; private set; }
        public IObservable<int> OnChangeSpeaker { get; private set; }

        private ICharacterSelectionView _characterSelectionView;

        [Inject]
        public CharacterSelectionPresenter
        (
            ICharacterSelectionView characterSelectionView
        )
        {
            _characterSelectionView = characterSelectionView;

            OnClickSpawnButton = characterSelectionView.SpawnButton.onClick.AsObservable();
            OnChangeCharacterPromptText = characterSelectionView.CharacterPrompt.onValueChanged.AsObservable();
            OnChangeSpeaker = _characterSelectionView.CharacterSpeaker.onValueChanged.AsObservable();
        }

        public void ShowRootUI()
        {
            _characterSelectionView.RootTransform.gameObject.SetActive(true);
        }

        public void HideRootUI()
        {
            _characterSelectionView.RootTransform.gameObject.SetActive(false);
        }

        public bool GetRootUIState()
        {
            return _characterSelectionView.RootTransform.gameObject.activeSelf;
        }

        public void ValidSpawnButton()
        {
            _characterSelectionView.SpawnButton.interactable = true;
        }

        public void InvalidSpawnButton()
        {
            _characterSelectionView.SpawnButton.interactable = false;
        }

        public string GetVRMFilePath()
        {
            return _characterSelectionView.VRMFilePath.text ?? "";
        }

        public string GetCharacterPrompt()
        {
            return _characterSelectionView.CharacterPrompt.text ?? "";
        }

        public void SetSpeaker(List<string> speakers)
        {
            _characterSelectionView.CharacterSpeaker.options.Clear();
            var optionData = new List<TMP_Dropdown.OptionData>();
            foreach (string speakerInfo in speakers)
            {
                optionData.Add(new TMP_Dropdown.OptionData(speakerInfo));
            }
            _characterSelectionView.CharacterSpeaker.AddOptions(optionData);
        }

        public int GetSpeaker()
        {
            return _characterSelectionView.CharacterSpeaker.value;
        }
    }
}
