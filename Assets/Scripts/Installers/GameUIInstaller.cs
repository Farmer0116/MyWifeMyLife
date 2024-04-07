using Presentation.Presenters;
using Presentation.Presenters.Interfaces;
using Presentation.Views;
using Presentation.Views.Interfaces;
using UseCases;
using UseCases.Interfaces;
using UnityEngine;
using Zenject;
using Models;

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