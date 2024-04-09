using UniRx;

namespace Cores.Models.Interfaces
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public interface IPlayerSpeechModel
    {
        ReadOnlyReactiveProperty<string> SpeechText { get; }
    }
}
