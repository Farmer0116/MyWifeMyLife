using System;
using UniRx;

namespace Presentation.Presenters.Interfaces
{
    public interface IVRMSelectionPresenter
    {
        IObservable<Unit> OnClickBrowserButton { get; }
        IObservable<Unit> OnClickSpawnButton { get; }

        void ShowRootUI();
        void HideRootUI();
        bool GetRootUIState();
        string GetVRMFilePath();
        void ValidSpawnButton();
        void InvalidSpawnButton();
    }
}
