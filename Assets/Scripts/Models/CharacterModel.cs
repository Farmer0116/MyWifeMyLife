using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Interfaces;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Models
{
    public class CharacterModel : ICharacterModel
    {
        // 初期化パラメータ
        public class CharacterModelParam
        {
            public int Id;
            public string Name;
            public string VrmPath;
            public int TalkSpeed;
            public string NaturePrompt;
            public string TonePrompt;

            public CharacterModelParam
            (
                int id = -1,
                string name = "default",
                string vrmPath = "Assets/Resources/Character/Character_1.vrm",
                int talkSpeed = 1,
                string naturePrompt = "",
                string tonePrompt = ""
            )
            {
                Id = id;
                Name = name;
                VrmPath = vrmPath;
                TalkSpeed = talkSpeed;
                NaturePrompt = naturePrompt;
                TonePrompt = tonePrompt;
            }
        }

        public class Factory : PlaceholderFactory<CharacterModelParam, CharacterModel> { }

        public CharacterModel
        (
            CharacterModelParam characterModelParam
        )
        {
            _id = characterModelParam.Id;
            _name = characterModelParam.Name;
            _vrmPath = characterModelParam.VrmPath;
            _talkSpeed = characterModelParam.TalkSpeed;
            _naturePrompt = characterModelParam.NaturePrompt;
            _tonePrompt = characterModelParam.TonePrompt;
        }

        // 初期値
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string VrmPath { get { return _vrmPath; } set { _vrmPath = value; } }
        public int TalkSpeed { get { return _talkSpeed; } set { _talkSpeed = value; } }
        public string NaturePrompt { get { return _naturePrompt; } set { _naturePrompt = value; } }
        public string TonePrompt { get { return _tonePrompt; } set { _tonePrompt = value; } }

        private int _id;
        private string _name;
        private string _vrmPath;
        private int _talkSpeed;
        private string _naturePrompt;
        private string _tonePrompt;

        // その他
        public List<string> ConversationHistory { get { return _conversationHistory; } set { _conversationHistory = value; } }
        public GameObject CharacterInstance { get { return _characterInstance; } set { _characterInstance = value; } }

        private List<string> _conversationHistory = new List<string>();
        private GameObject _characterInstance = null;

        // 機能
        public Subject<GameObject> OnSpawnSubject => _onSpawnSubject;
        public Subject<GameObject> OnDespawnSubject => _onDespawnSubject;
        public Subject<string> OnTalkSubject => _onTalkSubject;
        public Subject<string> OnListenSubject => _onListenSubject;
        public Subject<string> OnMemorizeConversation => _onMemorizeConversation;
        public Subject<Unit> OnForgetConversation => _onForgetConversation;

        private Subject<GameObject> _onSpawnSubject = new Subject<GameObject>();
        private Subject<GameObject> _onDespawnSubject = new Subject<GameObject>();
        private Subject<string> _onTalkSubject = new Subject<string>();
        private Subject<string> _onListenSubject = new Subject<string>();
        private Subject<string> _onMemorizeConversation = new Subject<string>();
        private Subject<Unit> _onForgetConversation = new Subject<Unit>();

        public async Task<GameObject> Spawn(Vector3 position, Quaternion rotation, Vector3 scale)
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}を{position}に{rotation}を向いて{scale}のサイズで生成します");
#endif
            _characterInstance = await SpawnVrmCharacter.Spawn(_vrmPath, position, rotation, scale);
            OnSpawnSubject.OnNext(_characterInstance);
            return _characterInstance;
        }

        public void Despawn()
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}を削除します");
#endif
            if (_characterInstance != null)
            {
                OnDespawnSubject.OnNext(_characterInstance);
                GameObject.Destroy(_characterInstance);
            }
            else
            {
                Debug.LogError("モデルに対応したキャラクタが生成されていません");
            }
        }

        public void Talk(string talkingText)
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}が「{talkingText}。」と話します");
#endif
            _onTalkSubject.OnNext(talkingText);
        }

        public void Listen(string listeningText)
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}が「{listeningText}。」と聞き取ります");
#endif
            _onListenSubject.OnNext(listeningText);
        }

        public void MemorizeConversation(string conversationText)
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}が会話内容「{conversationText}。」を記憶します");
#endif
            _conversationHistory.Add(conversationText);
            _onMemorizeConversation.OnNext(conversationText);
        }

        public void ForgetConversation()
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}が会話内容の記憶を忘れます");
#endif
            _conversationHistory.Clear();
            _onForgetConversation.OnNext(Unit.Default);
        }
    }
}