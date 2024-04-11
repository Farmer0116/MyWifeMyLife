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

    [Inject]
    private void construct
    (
      ICharacterBehaviorUseCase characterBehaviorUseCase,
      IVRMSelectionUseCase vrmSelectionUseCase,
      IConversationManagementUseCase conversationManagementUseCase
    )
    {
      _characterBehaviorUseCase = characterBehaviorUseCase;
      _vrmSelectionUseCase = vrmSelectionUseCase;
      _conversationManagementUseCase = conversationManagementUseCase;
    }

    private async void Awake()
    {
      try
      {
        await _characterBehaviorUseCase.Begin();
        await _vrmSelectionUseCase.Begin();
        await _conversationManagementUseCase.Begin();
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


