using Cores.Views;
using Cores.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        [field: Header("メイン")]
        [SerializeField] private GameObject _vrmSelectionView;

        public override void InstallBindings()
        {
            // View
            Container.Bind<IVRMSelectionView>().To<VRMSelectionView>().FromComponentOn(_vrmSelectionView).AsTransient();
        }
    }
}