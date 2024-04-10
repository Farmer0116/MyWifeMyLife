using Cores.Models.Interfaces;
using UniRx;
using UnityEngine;

namespace Cores.Models
{
    /// <summary>
    /// プレーヤーの会話に関する入力情報を管理するモデル
    /// </summary>
    public class PlayerConversationModel : IPlayerConversationModel
    {
        public ReadOnlyReactiveProperty<string> TalkText { get { return _talkText; } }
        private ReadOnlyReactiveProperty<string> _talkText;

        public Subject<string> OnTalkSubject => _onTalkSubject;
        public Subject<string> OnListenSubject => _onListenSubject;

        private Subject<string> _onTalkSubject = new Subject<string>();
        private Subject<string> _onListenSubject = new Subject<string>();

        public void Talk(string talkingText)
        {
#if UNITY_EDITOR
            Debug.Log($"プレーヤーが「{talkingText}。」と話します");
#endif
            _onTalkSubject.OnNext(talkingText);
        }

        public void Listen(string listeningText)
        {
#if UNITY_EDITOR
            Debug.Log($"プレーヤーが「{listeningText}。」と聞き取ります");
#endif
            _onListenSubject.OnNext(listeningText);
        }
    }
}
