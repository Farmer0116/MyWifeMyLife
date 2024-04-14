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
        private IOpenAIRepository _openAIRepository;
        private IPlayerConversationModel _playerConversationModel;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private const int _maxTimeSeconds = 10;
        private const float _thresholdDeltaTime = 0.75f;

        public PlayerTalkingUseCase
        (
            IPlayerTalkingPresenter playerTalkingPresenter,
            IOpenAIRepository openAIRepository,
            IPlayerConversationModel playerConversationModel
        )
        {
            _playerTalkingPresenter = playerTalkingPresenter;
            _openAIRepository = openAIRepository;
            _playerConversationModel = playerConversationModel;
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
                    Debug.LogError("発声時間が短すぎます");
                    return;
                }

                var audioByte = recorder.RecordStop();
                OpenAISpeechToTextResponse transcriptionText = await _openAIRepository.GetTranscription(audioByte);
                _playerConversationModel.Talk(transcriptionText.text);
                _playerTalkingPresenter.TalkingText.Value = transcriptionText.text;
                Debug.Log(_playerConversationModel.ConversationHistory.LastOrDefault());
            }).AddTo(_disposables);
        }

        public void Finish()
        {
            _playerTalkingPresenter.Finish();
            _disposables.Dispose();
        }
    }
}
