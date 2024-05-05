using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Cores.UseCases
{
    public class ConversationManagementUseCase : IConversationManagementUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IPlayerConversationModel _playerConversationModel;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public ConversationManagementUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            IPlayerConversationModel playerConversationModel
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _playerConversationModel = playerConversationModel;
        }

        public async UniTask Begin()
        {
            // プレーヤー → キャラクタ
            _playerConversationModel.OnTalkSubject.Subscribe(text =>
            {
                foreach (var characterModel in _spawningCharactersModel.Characters)
                {
                    characterModel.Listen(text);
                }
            }).AddTo(_disposables);

            // キャラクタ → プレーヤー
            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                character.Value.OnTalkSubject.Subscribe(text =>
                {
                    _playerConversationModel.Listen(text);
                }).AddTo(character.Value.DespawnDisposables);
            });
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}