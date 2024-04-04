using Cysharp.Threading.Tasks;
using Models;
using UniRx;
using UnityEngine;
using UseCases.Interfaces;

namespace UseCases
{
    public class CharacterBehaviorUseCase : ICharacterBehaviorUseCase
    {
        private CharacterModel.Factory _factory;
        private CompositeDisposable _disposables = new CompositeDisposable();

        private CharacterModel _characterModel;

        public CharacterBehaviorUseCase
        (
            CharacterModel.Factory factory
        )
        {
            _factory = factory;
        }

        public async UniTask Begin()
        {
            _characterModel = _factory.Create(new CharacterModel.CharacterModelParam());
            _characterModel.OnSpawnSubject.Subscribe(root =>
            {
                // todo : 一時対応
                Animator animator = root.GetComponent<Animator>();
                if (animator)
                {
                    var controller = Resources.Load<RuntimeAnimatorController>("Character/CharacterLocomotions");
                    animator.runtimeAnimatorController = controller;
                }
            });
            _characterModel.Spawn(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), new Vector3(1, 1, 1));
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
