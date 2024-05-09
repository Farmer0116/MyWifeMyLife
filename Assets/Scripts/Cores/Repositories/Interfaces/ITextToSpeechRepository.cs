using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Cores.Repositories.Interfaces
{
    public interface ITextToSpeechRepository
    {
        UniTask<AudioClip> GenerateSpeechToTextAsync(int speaker, string text, int intpitch = 0, float intonationScale = 1, float speed = 1);
    }
}
