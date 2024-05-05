using System.Collections.Generic;
using Structures;
using UniRx;

namespace Cores.Models.Interfaces
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public interface IPlayerConversationModel
    {
        List<MessageInfo> ConversationHistory { get; }

        Subject<string> OnTalkSubject { get; }
        Subject<string> OnListenSubject { get; }
        Subject<Unit> OnForgetConversation { get; }

        void Talk(string talkingText);
        void Listen(string listeningText);
        void ForgetConversation();
    }
}
