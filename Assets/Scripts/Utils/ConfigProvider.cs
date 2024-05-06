using UnityEngine;

namespace Configs
{
    /// <summary>
    /// ゲーム中の設定情報を提供する
    /// </summary>
    public static class ConfigProvider
    {
        private const string path = "Utils/ConfigProvider";

        private static ConfigComponent _confgiComponent;

        private static ConfigComponent ConfigComponent
        {
            get
            {
                //ConfigComponentが存在しないなら新しく生成する
                if (_confgiComponent != null) return _confgiComponent;
                if (ConfigComponent.Instance == null)
                {
                    var resource = Resources.Load(path);
                    Object.Instantiate(resource);
                }
                _confgiComponent = ConfigComponent.Instance;
                return _confgiComponent;
            }
        }

        /// <summary>
        /// OpenAIのAPI設定
        /// </summary>
        public static OpenAIApiConfig OpenAIApiConfig
        {
            get { return ConfigComponent.Config.OpenAIApiConfig; }
        }

        /// <summary>
        /// VoicevoxのAPI設定
        /// </summary>
        public static VoicevoxApiConfig VoicevoxApiConfig
        {
            get { return ConfigComponent.Config.VoicevoxApiConfig; }
        }
    }
}