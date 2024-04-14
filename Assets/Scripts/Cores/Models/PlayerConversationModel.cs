using System.Collections.Generic;
using Cores.Models.Interfaces;
using Structures;
using Types;
using UniRx;
using UnityEngine;

namespace Cores.Models
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public class PlayerConversationModel : IPlayerConversationModel
    {
        public List<ConversationInfo> ConversationHistory { get { return _conversationHistory; } }
        private List<ConversationInfo> _conversationHistory = new List<ConversationInfo>();

        public Subject<string> OnTalkSubject => _onTalkSubject;
        public Subject<string> OnListenSubject => _onListenSubject;
        public Subject<Unit> OnForgetConversation => _onForgetConversation;

        private Subject<string> _onTalkSubject = new Subject<string>();
        private Subject<string> _onListenSubject = new Subject<string>();
        private Subject<Unit> _onForgetConversation = new Subject<Unit>();

        public void Talk(string talkingText)
        {
#if UNITY_EDITOR
            Debug.Log($"プレーヤーが「{talkingText}。」と話します");
#endif
            _conversationHistory.Add(new ConversationInfo(SpeakerType.Player, talkingText));
            _onTalkSubject.OnNext(talkingText);
        }

        public void Listen(string listeningText)
        {
#if UNITY_EDITOR
            Debug.Log($"プレーヤーが「{listeningText}。」と聞き取ります");
#endif
            _conversationHistory.Add(new ConversationInfo(SpeakerType.NPC, listeningText));
            _onListenSubject.OnNext(listeningText);
        }

        public void ForgetConversation()
        {
#if UNITY_EDITOR
            Debug.Log($"プレーヤーが会話内容の記憶を忘れます");
#endif
            _conversationHistory.Clear();
            _onForgetConversation.OnNext(Unit.Default);
        }
    }
}
