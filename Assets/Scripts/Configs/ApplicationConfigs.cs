using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    [CreateAssetMenu(menuName = "Configs/Application Configs")]
    public class ApplicationConfigs : ScriptableObject
    {
        public OpenAIApiConfig OpenAIApiConfig;
    }

    [Serializable]
    public class OpenAIApiConfig
    {
        public string SecretKey = "";
        public string Model = "";
    }
}