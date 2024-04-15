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
        private IOpenAIRepository _openAIRepository;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public ConversationManagementUseCase
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
            // プレーヤー → キャラクタ
            _playerConversationModel.OnTalkSubject.Subscribe(text => {
                foreach(var characterModel in _spawningCharactersModel.Characters)
                {
                    characterModel.Listen(text);
                }
            }).AddTo(_disposables);

            // キャラクタ → プレーヤー
            _spawningCharactersModel.OnAddCharacter.Subscribe(info => {
                info.Value.OnTalkSubject.Subscribe(text => {
                    _playerConversationModel.Listen(text);
                }).AddTo(_disposables);

                // List管理ならdisposeは要素自体（CharaModel）に持たせるべきじゃね？
            });

            _spawningCharactersModel.OnRemoveCharacter.Subscribe(info => {

            });
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}