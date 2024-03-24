using Cysharp.Threading.Tasks;

namespace Systems.Interfaces
{
    public interface IBaseSystem
    {
        UniTask Begin();
        void Finish();
    }
}
