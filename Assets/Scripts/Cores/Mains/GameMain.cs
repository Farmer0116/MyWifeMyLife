using System;
using UnityEngine;
using Cores.UseCases.Interfaces;
using Zenject;

namespace Mains
{
    [DefaultExecutionOrder(999)]
    public class GameMain : MonoBehaviour
    {
        private ICharacterBehaviorUseCase _characterBehaviorUseCase;
        private ICharacterSelectionUseCase _characterSelectionUseCase;
        private IConversationManagementUseCase _conversationManagementUseCase;
        private IPlayerTalkingUseCase _playerTalkingUseCase;
        private ICharacterTalkingUseCase _characterTalkingUseCase;
        private IConversationSubtitleUseCase _conversationSubtitleUseCase;

        [Inject]
        private void construct
        (
          ICharacterBehaviorUseCase characterBehaviorUseCase,
          ICharacterSelectionUseCase characterSelectionUseCase,
          IConversationManagementUseCase conversationManagementUseCase,
          IPlayerTalkingUseCase playerTalkingUseCase,
          ICharacterTalkingUseCase characterTalkingUseCase,
          IConversationSubtitleUseCase conversationSubtitleUseCase
        )
        {
            _characterBehaviorUseCase = characterBehaviorUseCase;
            _characterSelectionUseCase = characterSelectionUseCase;
            _conversationManagementUseCase = conversationManagementUseCase;
            _playerTalkingUseCase = playerTalkingUseCase;
            _characterTalkingUseCase = characterTalkingUseCase;
            _conversationSubtitleUseCase = conversationSubtitleUseCase;
        }

        private async void Awake()
        {
            try
            {
                await _characterBehaviorUseCase.Begin();
                await _characterSelectionUseCase.Begin();
                await _conversationManagementUseCase.Begin();
                await _playerTalkingUseCase.Begin();
                await _characterTalkingUseCase.Begin();
                await _conversationSubtitleUseCase.Begin();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void Start()
        {
            // ========== 初期設定 ==========
        }

        private void OnDestroy()
        {
        }
    }
}


