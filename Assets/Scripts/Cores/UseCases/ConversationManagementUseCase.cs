using Cores.Models.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.UseCases
{
    public class ConversationManagementUseCase : IConversationManagementUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IPlayerConversationModel _playerConversationModel;

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
        }

        public void Finish()
        {

        }
    }
}