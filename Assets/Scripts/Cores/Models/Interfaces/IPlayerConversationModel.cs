using UniRx;

namespace Cores.Models.Interfaces
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public interface IPlayerConversationModel
    {
        ReadOnlyReactiveProperty<string> TalkText { get; }

        Subject<string> OnTalkSubject { get; }
        Subject<string> OnListenSubject { get; }

        void Talk(string talkingText);
        void Listen(string listeningText);
    }
}
