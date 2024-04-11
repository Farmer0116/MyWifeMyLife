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
    private IVRMSelectionUseCase _vrmSelectionUseCase;
    private IConversationManagementUseCase _conversationManagementUseCase;
    private IPlayerTalkingUseCase _playerTalkingUseCase;

    [Inject]
    private void construct
    (
      ICharacterBehaviorUseCase characterBehaviorUseCase,
      IVRMSelectionUseCase vrmSelectionUseCase,
      IConversationManagementUseCase conversationManagementUseCase,
      IPlayerTalkingUseCase playerTalkingUseCase
    )
    {
      _characterBehaviorUseCase = characterBehaviorUseCase;
      _vrmSelectionUseCase = vrmSelectionUseCase;
      _conversationManagementUseCase = conversationManagementUseCase;
      _playerTalkingUseCase = playerTalkingUseCase;
    }

    private async void Awake()
    {
      try
      {
        await _characterBehaviorUseCase.Begin();
        await _vrmSelectionUseCase.Begin();
        await _conversationManagementUseCase.Begin();
        await _playerTalkingUseCase.Begin();
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


