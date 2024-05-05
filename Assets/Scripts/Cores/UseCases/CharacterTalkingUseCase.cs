using UniRx;
using Cysharp.Threading.Tasks;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using System.Diagnostics;

namespace Cores.UseCases
{
    public class CharacterTalkingUseCase : ICharacterTalkingUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IOpenAIRepository _openAIRepository;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterTalkingUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            IOpenAIRepository openAIRepository
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _openAIRepository = openAIRepository;
        }

        public async UniTask Begin()
        {
            // キャラクタ追加イベント
            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                character.Value.OnListenSubject.Subscribe(async text =>
                {
                    var data = await _openAIRepository.GenerateAnswerAsync(character.Value.CharacterPrompt, character.Value.ConversationHistory);
                    character.Value.Talk(data.Text);
                }).AddTo(character.Value.DespawnDisposables);
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
