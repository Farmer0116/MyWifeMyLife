using System.Collections.Generic;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Cores.Models.Interfaces
{
    /// <summary>
    /// キャラクタに関するモデル
    /// </summary>
    public interface ICharacterModel : IModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string VrmPath { get; set; }
        int TalkSpeed { get; set; }
        float HearingRange { get; set; }
        string NaturePrompt { get; set; }
        string TonePrompt { get; set; }
        
        List<string> ConversationHistory { get; }
        GameObject CharacterInstance { get; }

        Subject<GameObject> OnSpawnSubject { get; }
        Subject<GameObject> OnDespawnSubject { get; }
        Subject<string> OnTalkSubject { get; }
        Subject<string> OnListenSubject { get; }
        Subject<string> OnMemorizeConversation { get; }
        Subject<Unit> OnForgetConversation { get; }

        Task<GameObject> SpawnAsync(Vector3 position, Quaternion rotation, Vector3 scale);
        void Despawn();
        void Talk(string talkingText);
        void Listen(string listeningText);
        void MemorizeConversation(string conversationText);
        void ForgetConversation();
    }
}