using System;
using Cysharp.Threading.Tasks;
using Models.Interfaces;
using Systems.Interfaces;
using UniRx;
using Zenject;

namespace Systems
{
  public class TalkSystem : ITalkSystem
  {
    [Inject] private ITalkModel _talkModel;

    private IDisposable _updateDisposable;

    public TalkSystem()
    {
    }

    public async UniTask Begin()
    {
      _updateDisposable = Observable.EveryFixedUpdate().Subscribe(_ =>
      {
        if (_talkModel.TalkerMap.Count > 0)
        {
          foreach (var prop in _talkModel.TalkerMap)
          {
          }
        }
      });
    }

    public void Finish()
    {
      _updateDisposable.Dispose();
    }
  }
}
