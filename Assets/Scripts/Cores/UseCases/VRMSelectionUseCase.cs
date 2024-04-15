using Cysharp.Threading.Tasks;
using Cores.Models;
using Cores.Presenters.Interfaces;
using UniRx;
using UnityEngine;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;

namespace Cores.UseCases
{
    public class VRMSelectionUseCase : IVRMSelectionUseCase
    {
        private CharacterModel.Factory _factory;
        private ISpawningCharactersModel _spawningCharactersModel;
        private ICharacterModel _characterModel;
        private IVRMSelectionPresenter _vrmSelectionPresenter;
        private CompositeDisposable _spawningDisposables = new CompositeDisposable();
        private CompositeDisposable _disposables = new CompositeDisposable();

        public VRMSelectionUseCase
        (
            CharacterModel.Factory factory,
            ISpawningCharactersModel spawningCharactersModel,
            IVRMSelectionPresenter vrmSelectionPresenter
        )
        {
            _factory = factory;
            _spawningCharactersModel = spawningCharactersModel;
            _vrmSelectionPresenter = vrmSelectionPresenter;
        }

        public async UniTask Begin()
        {
            // 更新処理
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

            // ブラウザボタンイベント
            _vrmSelectionPresenter.OnClickBrowserButton.Subscribe(_ =>
            {
            }).AddTo(_disposables);

            // スポーンボタンイベント
            _vrmSelectionPresenter.OnClickSpawnButton.Subscribe(async _ =>
            {
                _vrmSelectionPresenter.InvalidSpawnButton();

                if (_characterModel != null) _characterModel.Despawn();
                _characterModel = _factory.Create(new CharacterModel.CharacterModelParam());
                var path = _vrmSelectionPresenter.GetVRMFilePath();
                if (!string.IsNullOrEmpty(path)) _characterModel.VrmPath = path;

                // スポーン時のイベント
                _characterModel.OnSpawnSubject.Subscribe(root =>
                {
                    // todo : 一時対応
                    Animator animator = root.GetComponent<Animator>();
                    if (animator)
                    {
                        var controller = Resources.Load<RuntimeAnimatorController>("Character/CharacterLocomotions");
                        animator.runtimeAnimatorController = controller;
                    }

                    _spawningCharactersModel.Characters.Add(_characterModel);
                    _vrmSelectionPresenter.ValidSpawnButton();
                }).AddTo(_spawningDisposables);

                // デスポーン時のイベント
                _characterModel.OnDespawnSubject.Subscribe(root =>
                {
                    _spawningCharactersModel.Characters.Remove(_characterModel);
                }).AddTo(_spawningDisposables);

                // スポーン
                await _characterModel.SpawnAsync(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), new Vector3(1, 1, 1));
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _disposables.Dispose();
            _spawningDisposables.Dispose();
        }
    }
}
