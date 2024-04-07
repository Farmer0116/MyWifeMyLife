using Cysharp.Threading.Tasks;
using UniRx;
using UseCases.Interfaces;

namespace UseCases
{
    public class CharacterBehaviorUseCase : ICharacterBehaviorUseCase
    {
        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterBehaviorUseCase
        (
        )
        {
        }

        public async UniTask Begin()
        {
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}
