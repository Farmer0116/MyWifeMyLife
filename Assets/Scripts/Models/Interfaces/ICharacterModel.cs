using System.Collections.Generic;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Models.Interfaces
{
    public interface ICharacterModel : IModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string VrmPath { get; set; }
        int TalkSpeed { get; set; }
        string NaturePrompt { get; set; }
        string TonePrompt { get; set; }
        List<string> ConversationHistory { get; }

        Subject<GameObject> OnSpawnSubject { get; }
        Subject<GameObject> OnDespawnSubject { get; }
        Subject<string> OnTalkSubject { get; }
        Subject<string> OnListenSubject { get; }
        Subject<string> OnMemorizeConversation { get; }
        Subject<Unit> OnForgetConversation { get; }

        Task<GameObject> Spawn(Vector3 position, Quaternion rotation, Vector3 scale);
        void Despawn();
        void Talk(string talkingText);
        void Listen(string listeningText);
        void MemorizeConversation(string conversationText);
        void ForgetConversation();
    }
}