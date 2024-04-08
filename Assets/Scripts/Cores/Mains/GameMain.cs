using System;
using UnityEngine;
using UseCases.Interfaces;
using Zenject;

namespace Mains
{
  [DefaultExecutionOrder(999)]
  public class GameMain : MonoBehaviour
  {
    private ICharacterBehaviorUseCase _characterBehaviorUseCase;
    private IVRMSelectionUseCase _vrmSelectionUseCase;

    [Inject]
    private void construct
    (
      ICharacterBehaviorUseCase characterBehaviorUseCase,
      IVRMSelectionUseCase vrmSelectionUseCase
    )
    {
      _characterBehaviorUseCase = characterBehaviorUseCase;
      _vrmSelectionUseCase = vrmSelectionUseCase;
    }

    private async void Awake()
    {
      try
      {
        await _characterBehaviorUseCase.Begin();
        await _vrmSelectionUseCase.Begin();
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


