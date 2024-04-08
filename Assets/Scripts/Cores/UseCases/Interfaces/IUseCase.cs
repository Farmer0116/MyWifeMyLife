using Cysharp.Threading.Tasks;

namespace Cores.UseCases.Interfaces
{
    public interface IUseCase
    {
        UniTask Begin();
        void Finish();
    }
}
