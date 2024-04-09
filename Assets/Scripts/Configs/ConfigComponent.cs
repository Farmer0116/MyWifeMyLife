using UnityEngine;
using Utils;

namespace Configs
{
    /// <summary>
    /// 設定情報管理コンポーネント
    /// </summary>
    public class ConfigComponent : SingletonMonoBehaviour<ConfigComponent>
    {
        private readonly string basePath = "Configs/";

        [SerializeField] private ConfigEnvironment targetEnv = ConfigEnvironment.Development;
        private ApplicationConfigs config;

        void Awake()
        {
            //シーンをまたいでも消さない
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Conf値
        /// </summary>
        public ApplicationConfigs Config
        {
            //configがnullならロードしてキャッシュする
            get { return config ?? (config = LoadConfig()); }
        }

        /// <summary>
        /// 環境別設定値読み込み
        /// </summary>
        /// <returns></returns>
        private ApplicationConfigs LoadConfig()
        {
            switch (targetEnv)
            {
                case ConfigEnvironment.Development:
                    Debug.Log("Load 'Development' conf");
                    return Resources.Load<ApplicationConfigs>(basePath + "Development");
                default:
                    return Resources.Load<ApplicationConfigs>(basePath + "Development");
            }
        }
    }
    /// <summary>
    /// 環境一覧
    /// </summary>
    public enum ConfigEnvironment
    {
        Development
    }
}