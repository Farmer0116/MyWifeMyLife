using System.Collections.Generic;
using API.Dto;
using API.Interfaces;
using Configs;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class APIClient : IAPIClient
    {
        private OpenAIApiConfig _configProvider = ConfigProvider.OpenAIApiConfig;

        const string _openAISpeechToTextEndpoint = "https://api.openai.com/v1/audio/transcriptions";

        public async UniTask<OpenAISpeechToTextResponse> GetOpenAISpeechToTextAsync(byte[] audioData, string language = "ja")
        {
            var formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("model", "whisper-1"));
            formData.Add(new MultipartFormDataSection("language", language));
            formData.Add(new MultipartFormFileSection("file", audioData, "audio.wav", "multipart/form-data"));

            using (UnityWebRequest request = UnityWebRequest.Post(_openAISpeechToTextEndpoint, formData))
            {
                request.SetRequestHeader("Authorization", "Bearer " + _configProvider.SecretKey);

                var asyncOperation = request.SendWebRequest();
                await UniTask.WaitUntil(() => asyncOperation.isDone);

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    return null;
                }

                var response = JsonUtility.FromJson<OpenAISpeechToTextResponse>(request.downloadHandler.text);
                return response;
            }
        }
    }
}