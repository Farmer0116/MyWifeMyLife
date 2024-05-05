using System;
using UniRx;
using UnityEngine.EventSystems;

namespace Cores.Presenters.Interfaces
{
    public interface IPlayerTalkingPresenter
    {
        IObservable<PointerEventData> OnClickDownTalkingButton { get; }
        IObservable<PointerEventData> OnClickUpTalkingButton { get; }
    }
}
