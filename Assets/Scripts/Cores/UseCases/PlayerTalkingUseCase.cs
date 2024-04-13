using Cores.Presenters.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.Profiling;
using Utils;

namespace Cores.UseCases
{
    public class PlayerTalkingUseCase : IPlayerTalkingUseCase
    {
        private IPlayerTalkingPresenter _playerTalkingPresenter;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private const int _maxTimeSeconds = 100;

        public PlayerTalkingUseCase
        (
            IPlayerTalkingPresenter playerTalkingPresenter
        )
        {
            _playerTalkingPresenter = playerTalkingPresenter;
        }

        public async UniTask Begin()
        {
            var recorder = new MicRecorder();

            recorder.Launch("test");

            _playerTalkingPresenter.OnClickDownTalkingButton.Subscribe(_ =>
            {
                recorder.RecordStart(_maxTimeSeconds);
            }).AddTo(_disposables);

            _playerTalkingPresenter.OnClickDownTalkingButton.Subscribe(_ =>
            {
                recorder.RecordStop();
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _playerTalkingPresenter.Finish();
            _disposables.Dispose();
        }
    }
}
