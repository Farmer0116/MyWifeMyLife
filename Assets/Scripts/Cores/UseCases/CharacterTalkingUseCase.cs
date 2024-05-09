using UniRx;
using Cysharp.Threading.Tasks;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using System.Diagnostics;
using UnityEngine;

namespace Cores.UseCases
{
    public class CharacterTalkingUseCase : ICharacterTalkingUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private ITextGenerationRepository _textGenerationRepository;
        private ITextToSpeechRepository _textToSpeechRepository;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterTalkingUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            ITextGenerationRepository textGenerationRepository,
            ITextToSpeechRepository textToSpeechRepository
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _textGenerationRepository = textGenerationRepository;
            _textToSpeechRepository = textToSpeechRepository;
        }

        public async UniTask Begin()
        {
            // キャラクタ追加イベント
            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                var audioSource = character.Value.CharacterInstance.GetComponentInChildren<AudioSource>();

                character.Value.OnListenSubject.Subscribe(async text =>
                {
                    var answer = await _textGenerationRepository.GenerateAnswerAsync(character.Value.CharacterPrompt, character.Value.ConversationHistory);
                    if (audioSource != null)
                    {
                        var audioClip = await _textToSpeechRepository.GenerateSpeechToTextAsync(character.Value.SpeakerSelectionInfo.SpeakerId, answer);
                        audioSource.clip = audioClip;
                        audioSource.Play();
                    }
                    character.Value.Talk(answer);
                }).AddTo(character.Value.DespawnDisposables);
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
