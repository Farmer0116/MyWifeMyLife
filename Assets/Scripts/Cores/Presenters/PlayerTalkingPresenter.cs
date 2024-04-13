using System;
using Cores.Presenters.Interfaces;
using Cores.Views.Interfaces;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace Cores.Presenters
{
    public class PlayerTalkingPresenter : IPlayerTalkingPresenter
    {
        private IPlayerTalkingView _playerTalkingView;

        public ReactiveProperty<string> TalkingText { get { return _talkingText; } private set { _talkingText = value; } }
        private ReactiveProperty<string> _talkingText = new ReactiveProperty<string>("");

        public IObservable<PointerEventData> OnClickDownTalkingButton { get { return _onClickDownTalkingButton; } }
        public IObservable<PointerEventData> OnClickUpTalkingButton { get { return _onClickUpTalkingButton; } }

        private IObservable<PointerEventData> _onClickDownTalkingButton;
        private IObservable<PointerEventData> _onClickUpTalkingButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public PlayerTalkingPresenter
        (
            IPlayerTalkingView playerTalkingView
        )
        {
            _playerTalkingView = playerTalkingView;

            TalkingText.Subscribe(text =>
            {
                _playerTalkingView.TalkingTextBox.text = text;
            }).AddTo(_disposables);

            _onClickDownTalkingButton = _playerTalkingView.TalkingButton.OnPointerDownAsObservable();
            _onClickUpTalkingButton = _playerTalkingView.TalkingButton.OnPointerUpAsObservable();
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
