using System;
using Systems.Interfaces;
using UnityEngine;
using Zenject;

namespace Mains
{
  [DefaultExecutionOrder(999)]
  public class GameMain : MonoBehaviour
  {
    private ITalkerSystem _talkerSystem;
    private IFollowSystem _followSystem;

    [Inject]
    private void construct
    (
        ITalkerSystem talkerSystem,
        IFollowSystem followSystem
    )
    {
      _talkerSystem = talkerSystem;
      _followSystem = followSystem;
    }

    private async void Awake()
    {
      try
      {
        await _talkerSystem.Begin();
        await _followSystem.Begin();
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


