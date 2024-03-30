using UnityEngine;
using Zenject;
using Systems;
using Systems.Interfaces;
using Models.Interfaces;
using Models;

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
      Container.Bind<IFollowSystem>().To<FollowSystem>().AsCached().IfNotBound();

      // Model
      Container.Bind<ITalkerModel>().To<TalkerModel>().AsCached().IfNotBound();
      Container.Bind<IFollowModel>().To<FollowModel>().AsCached().IfNotBound();
    }
  }
}