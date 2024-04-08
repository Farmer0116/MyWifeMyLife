using Cysharp.Threading.Tasks;
using UniRx;
using Cores.UseCases.Interfaces;

namespace Cores.UseCases
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
