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

    [Inject]
    private void construct
    (
      ICharacterBehaviorUseCase characterBehaviorUseCase
    )
    {
      _characterBehaviorUseCase = characterBehaviorUseCase;
    }

    private async void Awake()
    {
      try
      {
        await _characterBehaviorUseCase.Begin();
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


