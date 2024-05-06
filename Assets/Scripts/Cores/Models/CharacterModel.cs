using System.Collections.Generic;
using System.Threading.Tasks;
using Cores.Models.Interfaces;
using Structures;
using Types;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Cores.Models
{
    /// <summary>
    /// キャラクタに関するモデル
    /// </summary>
    public class CharacterModel : ICharacterModel
    {
        // 初期化パラメータ
        public class CharacterModelParam
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string VrmPath { get; set; }
            public int TalkSpeed { get; set; }
            public float HearingRange { get; set; }
            public string CharacterPrompt { get; set; }
            public SpeakerSelectionInfo SpeakerSelectionInfo { get; set; }

            public CharacterModelParam
            (
                int id = -1,
                string name = "default",
                string vrmPath = "Assets/Resources/Character/Character_1.vrm",
                int talkSpeed = 1,
                float hearingRange = 2.5f,
                string characterPrompt = ""
            )
            {
                Id = id;
                Name = name;
                VrmPath = vrmPath;
                TalkSpeed = talkSpeed;
                HearingRange = hearingRange;
                CharacterPrompt = characterPrompt;
                SpeakerSelectionInfo = new SpeakerSelectionInfo(TextToSpeechServiceType.Voicevox, 0, "");
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
            _hearingRange = characterModelParam.HearingRange;
            _characterPrompt = characterModelParam.CharacterPrompt;
            _speakerSelectionInfo = characterModelParam.SpeakerSelectionInfo;
        }

        // 初期値
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string VrmPath { get { return _vrmPath; } set { _vrmPath = value; } }
        public int TalkSpeed { get { return _talkSpeed; } set { _talkSpeed = value; } }
        public float HearingRange { get { return _hearingRange; } set { _hearingRange = value; } }
        public string CharacterPrompt { get { return _characterPrompt; } set { _characterPrompt = value; } }
        public SpeakerSelectionInfo SpeakerSelectionInfo { get { return _speakerSelectionInfo; } set { _speakerSelectionInfo = value; } }

        private int _id;
        private string _name;
        private string _vrmPath;
        private int _talkSpeed;
        private float _hearingRange;
        private string _characterPrompt;
        private SpeakerSelectionInfo _speakerSelectionInfo;

        // その他
        public List<MessageInfo> ConversationHistory { get { return _conversationHistory; } set { _conversationHistory = value; } }
        public GameObject CharacterInstance { get { return _characterInstance; } set { _characterInstance = value; } }
        public CompositeDisposable DespawnDisposables { get { return _despawnDisposables; } }

        private List<MessageInfo> _conversationHistory = new List<MessageInfo>();
        private GameObject _characterInstance = null;
        private CompositeDisposable _despawnDisposables = new CompositeDisposable();

        // 機能
        public Subject<GameObject> OnSpawnSubject => _onSpawnSubject;
        public Subject<GameObject> OnDespawnSubject => _onDespawnSubject;
        public Subject<string> OnTalkSubject => _onTalkSubject;
        public Subject<string> OnListenSubject => _onListenSubject;
        public Subject<Unit> OnForgetConversation => _onForgetConversation;

        private Subject<GameObject> _onSpawnSubject = new Subject<GameObject>();
        private Subject<GameObject> _onDespawnSubject = new Subject<GameObject>();
        private Subject<string> _onTalkSubject = new Subject<string>();
        private Subject<string> _onListenSubject = new Subject<string>();
        private Subject<Unit> _onForgetConversation = new Subject<Unit>();

        public async Task<GameObject> SpawnAsync(Vector3 position, Quaternion rotation, Vector3 scale)
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
                DespawnDisposables.Dispose();
                GameObject.Destroy(_characterInstance);
                _characterInstance = null;
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
            _conversationHistory.Add(new MessageInfo(SpeakerType.NPC, talkingText));
            _onTalkSubject.OnNext(talkingText);
        }

        public void Listen(string listeningText)
        {
#if UNITY_EDITOR
            Debug.Log($"{_name}が「{listeningText}。」と聞き取ります");
#endif
            _conversationHistory.Add(new MessageInfo(SpeakerType.Player, listeningText));
            _onListenSubject.OnNext(listeningText);
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