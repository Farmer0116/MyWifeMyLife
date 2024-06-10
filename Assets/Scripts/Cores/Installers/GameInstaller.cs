using UnityEngine;
using Zenject;
using API;
using API.Interfaces;
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
            Container.Bind<ICharacterSelectionUseCase>().To<CharacterSelectionUseCase>().AsCached().IfNotBound();
            Container.Bind<IConversationManagementUseCase>().To<ConversationManagementUseCase>().AsCached().IfNotBound();
            Container.Bind<IPlayerTalkingUseCase>().To<PlayerTalkingUseCase>().AsCached().IfNotBound();
            Container.Bind<ICharacterTalkingUseCase>().To<CharacterTalkingUseCase>().AsCached().IfNotBound();
            Container.Bind<IConversationSubtitleUseCase>().To<ConversationSubtitleUseCase>().AsCached().IfNotBound();

            // Repository
            Container.Bind<ISpeechToTextRepository>().To<SpeechToTextRepository>().AsCached().IfNotBound();
            Container.Bind<ITextGenerationRepository>().To<TextGenerationRepository>().AsCached().IfNotBound();
            Container.Bind<IVoicevoxSpeakerRepository>().To<VoicevoxSpeakerRepository>().AsCached().IfNotBound();
            Container.Bind<ITextToSpeechRepository>().To<TextToSpeechRepository>().AsCached().IfNotBound();

            // DataStore
            Container.Bind<ISpeechToTextDataStore>().To<SpeechToTextDataStore>().AsCached().IfNotBound();
            Container.Bind<ITextGenerationDataStore>().To<TextGenerationDataStore>().AsCached().IfNotBound();
            Container.Bind<IVoicevoxSpeakerDataStore>().To<VoicevoxSpeakerDataStore>().AsCached().IfNotBound();
            Container.Bind<ITextToSpeechDataStore>().To<TextToSpeechDataStore>().AsCached().IfNotBound();

            // Factory
            Container.BindFactory<CharacterModel.CharacterModelParam, CharacterModel, CharacterModel.Factory>();
        }
    }
}