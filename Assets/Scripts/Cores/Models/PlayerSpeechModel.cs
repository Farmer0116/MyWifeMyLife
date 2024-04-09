using Cores.Models.Interfaces;
using UniRx;

namespace Cores.Models
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public class PlayerSpeechModel : IPlayerSpeechModel
    {
        public ReadOnlyReactiveProperty<string> SpeechText { get { return _speechText; } }
        private ReadOnlyReactiveProperty<string> _speechText;
    }
}
