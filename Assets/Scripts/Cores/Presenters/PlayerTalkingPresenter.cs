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

        public IObservable<PointerEventData> OnClickDownTalkingButton { get { return _onClickDownTalkingButton; } }
        public IObservable<PointerEventData> OnClickUpTalkingButton { get { return _onClickUpTalkingButton; } }

        private IObservable<PointerEventData> _onClickDownTalkingButton;
        private IObservable<PointerEventData> _onClickUpTalkingButton;

        public PlayerTalkingPresenter
        (
            IPlayerTalkingView playerTalkingView
        )
        {
            _playerTalkingView = playerTalkingView;

            _onClickDownTalkingButton = _playerTalkingView.TalkingButton.OnPointerDownAsObservable();
            _onClickUpTalkingButton = _playerTalkingView.TalkingButton.OnPointerUpAsObservable();
        }
    }
}
