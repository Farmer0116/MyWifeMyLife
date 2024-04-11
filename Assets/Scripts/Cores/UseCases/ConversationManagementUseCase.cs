using UnityEngine;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using System.IO;

namespace Cores.UseCases
{
    public class ConversationManagementUseCase : IConversationManagementUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IPlayerConversationModel _playerConversationModel;
        private IOpenAIRepository _openAIRepository;

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
            Debug.Log("文字起こしテスト");
            var audioSource =  File.ReadAllBytes("C:/Users/kubota.daichi20/Documents/Personal/MyWifeMyLife/Assets/Resources/Audio/ohayou_test_04.wav");
            Debug.Log(audioSource);
        }

        public void Finish()
        {

        }
    }
}