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
        private IPlayerConversationModel _playerConversationModel;
        private IOpenAIRepository _openAIRepository;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterTalkingUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            IPlayerConversationModel playerConversationModel,
            IOpenAIRepository openAIRepository
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _playerConversationModel = playerConversationModel;
            _openAIRepository = openAIRepository;
        }

        public async UniTask Begin()
        {
            // キャラクタ追加イベント
            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                character.Value.OnListenSubject.Subscribe(async text =>
                {
                    var answer = await _openAIRepository.GenerateAnswerAsync(character.Value.ConversationHistory);
                }).AddTo(character.Value.DespawnDisposables);

                // _playerConversationModel.OnTalkSubject.Subscribe(text =>
                // {
                //     character.Value.Listen(text);
                // }).AddTo(character.Value.DespawnDisposables);
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
