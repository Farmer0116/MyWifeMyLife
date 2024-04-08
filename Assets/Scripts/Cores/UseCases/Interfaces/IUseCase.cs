using Cysharp.Threading.Tasks;

namespace UseCases.Interfaces
{
    public interface IUseCase
    {
        UniTask Begin();
        void Finish();
    }
}
