using UnityEngine;
using Zenject;
using Systems;
using Systems.Interfaces;
using ComponentGroup.Interfaces;
using ComponentGroup;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [field: Header("メイン")]
        [SerializeField] private GameObject main = default;

        // [SerializeField] private BaseCharacterController baseCharacterController = default;
        // [SerializeField] private PlayerCamera playerCamera = default;

        public GameObject Main => main;

        public override void InstallBindings()
        {
            // if (Container.HasBinding<ITest>() && main != null)
            // {
            //     main.SetActive(false);
            // }

            // System
            Container.Bind<ITalkerSystem>().To<TalkerSystem>().AsCached().IfNotBound();

            // Model
            Container.Bind<ITalkerComponentGroup>().To<TalkerComponentGroup>().AsCached().IfNotBound();
        }
    }
}