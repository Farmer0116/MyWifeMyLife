using System;
using UniRx;
using UnityEngine.EventSystems;

namespace Cores.Presenters.Interfaces
{
    public interface IPlayerTalkingPresenter
    {
        ReactiveProperty<string> TalkingText { get; }

        IObservable<PointerEventData> OnClickDownTalkingButton { get; }
        IObservable<PointerEventData> OnClickUpTalkingButton { get; }

        void Finish();
    }
}
