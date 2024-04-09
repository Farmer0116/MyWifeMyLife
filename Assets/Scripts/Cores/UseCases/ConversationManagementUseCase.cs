using Cores.Models.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;

namespace Cores.UseCases
{
    public class ConversationManagementUseCase : IConversationManagementUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IPlayerSpeechModel _playerSpeechModel;

        public ConversationManagementUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            IPlayerSpeechModel playerSpeechModel
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _playerSpeechModel = playerSpeechModel;
        }

        public async UniTask Begin()
        {
        }

        public void Finish()
        {

        }
    }
}