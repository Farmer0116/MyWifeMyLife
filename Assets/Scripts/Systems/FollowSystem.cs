using System;
using Cysharp.Threading.Tasks;
using Models.Interfaces;
using Systems.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems
{
  public class FollowSystem : IFollowSystem
  {
    [Inject] private IFollowModel _followModel;

    private IDisposable _updateDisposable;

    public FollowSystem()
    {
    }

    public async UniTask Begin()
    {
      _updateDisposable = Observable.EveryUpdate().Subscribe(_ =>
      {
        if (_followModel.FollowMap.Count > 0)
        {
          foreach (var prop in _followModel.FollowMap)
          {
            if (prop.Value.Component != null)
            {
              if (prop.Value.Target != null)
              {
                var moveToPosition = prop.Value.Target.transform.position + prop.Value.PositionOffset;
                var moveToRotation = prop.Value.Target.transform.rotation * Quaternion.Euler(prop.Value.EulerOffset.x, prop.Value.EulerOffset.y, prop.Value.EulerOffset.z);

                prop.Value.Component.gameObject.transform.position = new Vector3(moveToPosition.x, moveToPosition.y, moveToPosition.z);
                prop.Value.Component.gameObject.transform.rotation.Set(moveToRotation.x, moveToRotation.y, moveToRotation.z, moveToRotation.w);
              }
              else
              {
                prop.Value.Component.gameObject.transform.position = prop.Value.PositionOffset;
                prop.Value.Component.gameObject.transform.rotation = Quaternion.Euler(prop.Value.EulerOffset.x, prop.Value.EulerOffset.y, prop.Value.EulerOffset.z);
              }
            }
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