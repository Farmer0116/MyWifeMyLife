using System;
using ComponentGroup.Interfaces;
using Cysharp.Threading.Tasks;
using Systems.Interfaces;
using UniRx;
using Zenject;

namespace Systems
{
    public class TalkerSystem : ITalkerSystem
    {
        [Inject] private ITalkerComponentGroup _talkerComponentGroup;

        private IDisposable _updateDisposable;

        public TalkerSystem()
        {
        }

        public async UniTask Begin()
        {
            _updateDisposable = Observable.EveryFixedUpdate().Subscribe(_ =>
            {
                if (_talkerComponentGroup.TalkerComponentMap.Count > 0)
                {
                    foreach (var prop in _talkerComponentGroup.TalkerComponentMap)
                    {
                        UnityEngine.Debug.Log("コンソール" + " : " + _talkerComponentGroup.TalkerComponentMap.Count + " : " + prop.Key);
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
