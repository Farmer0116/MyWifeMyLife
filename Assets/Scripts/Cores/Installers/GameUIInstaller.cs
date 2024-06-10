using Cores.Views;
using Cores.Views.Interfaces;
using Cores.Presenters;
using Cores.Presenters.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        [field: Header("メイン")]
        [SerializeField] private CharacterSelectionView _characterSelectionView;
        [SerializeField] private PlayerTalkingView _playerTalkingView;
        [SerializeField] private ConversationSubtitleView _conversationSubtitleView;

        public override void InstallBindings()
        {
            // View
            Container.Bind<ICharacterSelectionView>().To<CharacterSelectionView>().FromComponentOn(_characterSelectionView.gameObject).AsTransient();
            Container.Bind<IPlayerTalkingView>().To<PlayerTalkingView>().FromComponentOn(_playerTalkingView.gameObject).AsTransient();
            Container.Bind<IConversationSubtitleView>().To<ConversationSubtitleView>().FromComponentOn(_conversationSubtitleView.gameObject).AsTransient();

            // Presenter
            Container.Bind<ICharacterSelectionPresenter>().To<CharacterSelectionPresenter>().AsCached().IfNotBound();
            Container.Bind<IPlayerTalkingPresenter>().To<PlayerTalkingPresenter>().AsCached().IfNotBound();
            Container.Bind<IConversationSubtitlePresenter>().To<ConversationSubtitlePresenter>().AsCached().IfNotBound();
        }
    }
}