using Cysharp.Threading.Tasks;
using Cores.Models;
using Cores.Presenters.Interfaces;
using UniRx;
using UnityEngine;
using Cores.UseCases.Interfaces;

namespace Cores.UseCases
{
    public class VRMSelectionUseCase : IVRMSelectionUseCase
    {
        private CharacterModel.Factory _factory;
        private CharacterModel _characterModel;
        private IVRMSelectionPresenter _vrmSelectionPresenter;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public VRMSelectionUseCase
        (
            CharacterModel.Factory factory,
            IVRMSelectionPresenter vrmSelectionPresenter
        )
        {
            _factory = factory;
            _vrmSelectionPresenter = vrmSelectionPresenter;
        }

        public async UniTask Begin()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (_vrmSelectionPresenter.GetRootUIState())
                    {
                        _vrmSelectionPresenter.HideRootUI();
                    }
                    else
                    {
                        _vrmSelectionPresenter.ShowRootUI();
                    }
                }
            }).AddTo(_disposables);

            _vrmSelectionPresenter.OnClickBrowserButton.Subscribe(_ =>
            {
            }).AddTo(_disposables);

            _vrmSelectionPresenter.OnClickSpawnButton.Subscribe(async _ =>
            {
                _vrmSelectionPresenter.InvalidSpawnButton();

                if (_characterModel != null) _characterModel.Despawn();
                _characterModel = _factory.Create(new CharacterModel.CharacterModelParam());
                var path = _vrmSelectionPresenter.GetVRMFilePath();
                if (!string.IsNullOrEmpty(path)) _characterModel.VrmPath = path;

                _characterModel.OnSpawnSubject.Subscribe(root =>
                {
                    // todo : 一時対応
                    Animator animator = root.GetComponent<Animator>();
                    if (animator)
                    {
                        var controller = Resources.Load<RuntimeAnimatorController>("Character/CharacterLocomotions");
                        animator.runtimeAnimatorController = controller;
                    }
                    _vrmSelectionPresenter.ValidSpawnButton();
                });
                await _characterModel.Spawn(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), new Vector3(1, 1, 1));
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
