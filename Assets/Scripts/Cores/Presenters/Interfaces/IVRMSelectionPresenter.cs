using System;
using UniRx;

namespace Cores.Presenters.Interfaces
{
    public interface IVRMSelectionPresenter
    {
        IObservable<Unit> OnClickBrowserButton { get; }
        IObservable<Unit> OnClickSpawnButton { get; }
        IObservable<string> OnChangeCharacterPromptText { get; }

        void ShowRootUI();
        void HideRootUI();
        bool GetRootUIState();
        string GetVRMFilePath();
        string GetCharacterPrompt();
        void ValidSpawnButton();
        void InvalidSpawnButton();
    }
}
