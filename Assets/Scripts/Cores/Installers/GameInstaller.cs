using UnityEngine;
using Zenject;
using API;
using API.Interfaces;
using Cores.Presenters;
using Cores.Presenters.Interfaces;
using Cores.UseCases;
using Cores.UseCases.Interfaces;
using Cores.Models;
using Cores.Models.Interfaces;
using Cores.Repositories;
using Cores.Repositories.Interfaces;
using Cores.DataStores;
using Cores.DataStores.Interfaces;

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

      // API
      Container.Bind<IAPIClient>().To<APIClient>().AsCached().IfNotBound();

      // Model
      Container.Bind<ISpawningCharactersModel>().To<SpawningCharactersModel>().AsCached().IfNotBound();
      Container.Bind<IPlayerConversationModel>().To<PlayerConversationModel>().AsCached().IfNotBound();

      // UseCase
      Container.Bind<ICharacterBehaviorUseCase>().To<CharacterBehaviorUseCase>().AsCached().IfNotBound();
      Container.Bind<IVRMSelectionUseCase>().To<VRMSelectionUseCase>().AsCached().IfNotBound();
      Container.Bind<IConversationManagementUseCase>().To<ConversationManagementUseCase>().AsCached().IfNotBound();
      Container.Bind<IPlayerTalkingUseCase>().To<PlayerTalkingUseCase>().AsCached().IfNotBound();

      // Repository
      Container.Bind<IOpenAIRepository>().To<OpenAIRepository>().AsCached().IfNotBound();

      // DataStore
      Container.Bind<IOpenAIDataStore>().To<OpenAIDataStore>().AsCached().IfNotBound();

      // Presenter
      Container.Bind<IVRMSelectionPresenter>().To<VRMSelectionPresenter>().AsCached().IfNotBound();

      // Factory
      Container.BindFactory<CharacterModel.CharacterModelParam, CharacterModel, CharacterModel.Factory>();
    }
  }
}