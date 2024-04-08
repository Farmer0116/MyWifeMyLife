using Cores.Presenters;
using Cores.Presenters.Interfaces;
using Cores.UseCases;
using Cores.UseCases.Interfaces;
using Cores.Models;
using UnityEngine;
using Zenject;

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

      // UseCase
      Container.Bind<ICharacterBehaviorUseCase>().To<CharacterBehaviorUseCase>().AsCached().IfNotBound();
      Container.Bind<IVRMSelectionUseCase>().To<VRMSelectionUseCase>().AsCached().IfNotBound();

      // Presenter
      Container.Bind<IVRMSelectionPresenter>().To<VRMSelectionPresenter>().AsCached().IfNotBound();

      // Factory
      Container.BindFactory<CharacterModel.CharacterModelParam, CharacterModel, CharacterModel.Factory>();
    }
  }
}