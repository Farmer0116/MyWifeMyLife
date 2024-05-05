using UniRx;
using Cysharp.Threading.Tasks;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;

namespace Cores.UseCases
{
    public class CharacterTalkingUseCase : ICharacterTalkingUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private ITextGenerationRepository _textGenerationRepository;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterTalkingUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            ITextGenerationRepository textGenerationRepository
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _textGenerationRepository = textGenerationRepository;
        }

        public async UniTask Begin()
        {
            // キャラクタ追加イベント
            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                character.Value.OnListenSubject.Subscribe(async text =>
                {
                    var data = await _textGenerationRepository.GenerateAnswerAsync(character.Value.CharacterPrompt, character.Value.ConversationHistory);
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
