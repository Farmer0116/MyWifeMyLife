using System.Linq;
using API.Dto;
using Cores.Models.Interfaces;
using Cores.Presenters.Interfaces;
using Cores.Repositories.Interfaces;
using Cores.UseCases.Interfaces;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Utils;

namespace Cores.UseCases
{
    public class PlayerTalkingUseCase : IPlayerTalkingUseCase
    {
        private IPlayerTalkingPresenter _playerTalkingPresenter;
        private IPlayerConversationModel _playerConversationModel;
        private IOpenAIRepository _openAIRepository;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private const int _maxTimeSeconds = 10;
        private const float _thresholdDeltaTime = 0.75f;

        public PlayerTalkingUseCase
        (
            IPlayerTalkingPresenter playerTalkingPresenter,
            IPlayerConversationModel playerConversationModel,
            IOpenAIRepository openAIRepository
        )
        {
            _playerTalkingPresenter = playerTalkingPresenter;
            _playerConversationModel = playerConversationModel;
            _openAIRepository = openAIRepository;
        }

        public async UniTask Begin()
        {
            var recorder = new MicRecorder();
            float startTime = 0;

            recorder.Launch("マイク (2- USB Audio Device)");

            _playerTalkingPresenter.OnClickDownTalkingButton.Subscribe(_ =>
            {
                startTime = Time.time;
                recorder.RecordStart(_maxTimeSeconds);
            }).AddTo(_disposables);

            _playerTalkingPresenter.OnClickUpTalkingButton.Subscribe(async _ =>
            {
                if (_thresholdDeltaTime > Time.time - startTime)
                {
                    Debug.LogWarning("発声時間が短すぎます");
                    return;
                }

                var audioByte = recorder.RecordStop();
                OpenAISpeechToTextResponse transcriptionText = await _openAIRepository.GenerateTranscriptionAsync(audioByte);
                _playerConversationModel.Talk(transcriptionText.text);
                _playerTalkingPresenter.TalkingText.Value = transcriptionText.text;
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _playerTalkingPresenter.Finish();
            _disposables.Dispose();
        }
    }
}
