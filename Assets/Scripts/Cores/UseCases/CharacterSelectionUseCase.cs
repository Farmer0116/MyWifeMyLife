using Cysharp.Threading.Tasks;
using Cores.Models;
using Cores.Presenters.Interfaces;
using UniRx;
using UnityEngine;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using System.Collections.Generic;
using Structures;
using Types;

namespace Cores.UseCases
{
    public class CharacterSelectionUseCase : ICharacterSelectionUseCase
    {
        private CharacterModel.Factory _factory;
        private ISpawningCharactersModel _spawningCharactersModel;
        private ICharacterModel _characterModel;
        private ICharacterSelectionPresenter _characterSelectionPresenter;
        private IVoicevoxSpeakerRepository _voicevoxSpeakerRepository;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterSelectionUseCase
        (
            CharacterModel.Factory factory,
            ISpawningCharactersModel spawningCharactersModel,
            ICharacterSelectionPresenter characterSelectionPresenter,
            IVoicevoxSpeakerRepository voicevoxSpeakerRepository
        )
        {
            _factory = factory;
            _spawningCharactersModel = spawningCharactersModel;
            _characterSelectionPresenter = characterSelectionPresenter;
            _voicevoxSpeakerRepository = voicevoxSpeakerRepository;
        }

        public async UniTask Begin()
        {
            // 更新処理
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    if (_characterSelectionPresenter.GetRootUIState())
                    {
                        _characterSelectionPresenter.HideRootUI();
                    }
                    else
                    {
                        _characterSelectionPresenter.ShowRootUI();
                    }
                }
            }).AddTo(_disposables);

            // todo : 一時対応(ボイスボックス専用) ============
            // 話者情報設定
            var speakerInfos = await _voicevoxSpeakerRepository.GetVoicevoxSpeakersAsync();
            var speakerLabels = new List<string>();
            var speakerSelections = new List<SpeakerSelectionInfo>();
            foreach (var speaker in speakerInfos)
            {
                foreach (var style in speaker.Styles)
                {
                    var label = speaker.Name + " : " + style.Name;
                    speakerSelections.Add(new SpeakerSelectionInfo(TextToSpeechServiceType.Voicevox, style.Id, label));
                    speakerLabels.Add(label);
                }
            }
            _characterSelectionPresenter.SetSpeaker(speakerLabels);
            // ===============================================

            // スポーンボタンイベント
            _characterSelectionPresenter.OnClickSpawnButton.Subscribe(async _ =>
            {
                _characterSelectionPresenter.InvalidSpawnButton();

                if (_characterModel != null) _characterModel.Despawn();
                _characterModel = _factory.Create(new CharacterModel.CharacterModelParam());
                var path = _characterSelectionPresenter.GetVRMFilePath();
                if (!string.IsNullOrEmpty(path)) _characterModel.VrmPath = path;

                // todo : 一時対応 ================================
                _characterSelectionPresenter.OnChangeCharacterPromptText.Subscribe(_ =>
                {
                    setCharacterPrompt(_characterModel);
                }).AddTo(_characterModel.DespawnDisposables);

                _characterSelectionPresenter.OnChangeSpeaker.Subscribe(index =>
                {
                    _characterModel.SpeakerSelectionInfo = speakerSelections[index];
                }).AddTo(_characterModel.DespawnDisposables);
                // ===============================================

                // スポーン時のイベント
                _characterModel.OnSpawnSubject.Subscribe(root =>
                {
                    // todo : 一時対応 ================================
                    Animator animator = root.GetComponent<Animator>();
                    if (animator)
                    {
                        var controller = Resources.Load<RuntimeAnimatorController>("Character/CharacterLocomotions");
                        animator.runtimeAnimatorController = controller;
                    }
                    setCharacterPrompt(_characterModel);

                    var el = speakerSelections[_characterSelectionPresenter.GetSpeaker()];
                    _characterModel.SpeakerSelectionInfo = el;
                    // ===============================================

                    _spawningCharactersModel.Characters.Add(_characterModel);
                    _characterSelectionPresenter.ValidSpawnButton();
                }).AddTo(_characterModel.DespawnDisposables);

                // デスポーン時のイベント
                _characterModel.OnDespawnSubject.Subscribe(root =>
                {
                    _spawningCharactersModel.Characters.Remove(_characterModel);
                }).AddTo(_characterModel.DespawnDisposables);

                // スポーン
                await _characterModel.SpawnAsync(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), new Vector3(1, 1, 1));
            }).AddTo(_disposables);
        }

        private void setCharacterPrompt(ICharacterModel characterModel)
        {
            if (!string.IsNullOrEmpty(_characterSelectionPresenter.GetCharacterPrompt()))
            {
                characterModel.CharacterPrompt = _characterSelectionPresenter.GetCharacterPrompt();
            }
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
