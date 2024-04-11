using UnityEngine;
using Cores.Models.Interfaces;
using Cores.Repositories.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using System.IO;
using API.Dto;

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
            // var wavBytes = File.ReadAllBytes("C:/Users/kubot/Documents/Unity/MyWifeMyLife/Assets/Resources/Audio/ohayou_test_04.wav");
            // OpenAISpeechToTextResponse transcriptionText = await _openAIRepository.GetTranscription(wavBytes);
            // Debug.Log(transcriptionText.text);
        }

        public void Finish()
        {

        }
    }
}