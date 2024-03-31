using System;
using Cysharp.Threading.Tasks;
using Models.Interfaces;
using Systems.Interfaces;
using UniRx;
using Zenject;

namespace Systems
{
  public class TalkerSystem : ITalkerSystem
  {
    [Inject] private ITalkerModel _talkerModel;

    private IDisposable _updateDisposable;

    public TalkerSystem()
    {
    }

    public async UniTask Begin()
    {
      _updateDisposable = Observable.EveryFixedUpdate().Subscribe(_ =>
      {
        if (_talkerModel.TalkerMap.Count > 0)
        {
          foreach (var prop in _talkerModel.TalkerMap)
          {
            UnityEngine.Debug.Log("コンソール" + " : " + _talkerModel.TalkerMap.Count + " : " + prop.Key);
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
