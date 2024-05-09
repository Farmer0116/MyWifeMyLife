using System;
using System.Collections.Generic;
using UniRx;

namespace Cores.Presenters.Interfaces
{
    public interface IVRMSelectionPresenter
    {
        IObservable<Unit> OnClickSpawnButton { get; }
        IObservable<string> OnChangeCharacterPromptText { get; }
        IObservable<int> OnChangeSpeaker { get; }

        void ShowRootUI();
        void HideRootUI();
        bool GetRootUIState();
        void ValidSpawnButton();
        void InvalidSpawnButton();
        string GetVRMFilePath();
        string GetCharacterPrompt();
        void SetSpeaker(List<string> speakers);
        int GetSpeaker();
    }
}
