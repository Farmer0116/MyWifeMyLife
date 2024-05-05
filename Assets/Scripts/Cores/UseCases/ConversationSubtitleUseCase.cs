using Cores.Models.Interfaces;
using Cores.Presenters.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Cores.UseCases
{
    public class ConversationSubtitleUseCase : IConversationSubtitleUseCase
    {
        private IConversationSubtitlePresenter _conversationSubtitlePresenter;
        private IPlayerConversationModel _playerConversationModel;
        private ISpawningCharactersModel _spawningCharactersModel;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ConversationSubtitleUseCase
        (
            IConversationSubtitlePresenter conversationSubtitlePresenter,
            IPlayerConversationModel playerConversationModel,
            ISpawningCharactersModel spawningCharactersModel
        )
        {
            _conversationSubtitlePresenter = conversationSubtitlePresenter;
            _playerConversationModel = playerConversationModel;
            _spawningCharactersModel = spawningCharactersModel;
        }

        public async UniTask Begin()
        {
            _playerConversationModel.OnTalkSubject.Subscribe(text =>
            {
                _conversationSubtitlePresenter.SetSubtitleText(text);
            }).AddTo(_disposables);

            _spawningCharactersModel.OnAddCharacter.Subscribe(character =>
            {
                character.Value.OnTalkSubject.Subscribe(text =>
                {
                    _conversationSubtitlePresenter.SetSubtitleText(text);
                }).AddTo(character.Value.DespawnDisposables);
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}