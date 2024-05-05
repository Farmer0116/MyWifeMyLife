using System.Collections.Generic;
using System.Linq;
using API.Dto;
using API.Interfaces;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class APIClient : IAPIClient
    {
        private OpenAIApiConfig _configProvider = ConfigProvider.OpenAIApiConfig;

        const string _openAISpeechToTextEndpoint = "https://api.openai.com/v1/audio/transcriptions";
        const string _openAIGenerateTextEndpoint = "https://api.openai.com/v1/chat/completions";

        public async UniTask<OpenAIGenerateTextResponse> PostOpenAIGenerateTextAsync(OpenAIGenerateTextRequestBody body)
        {
            var messagesJson = JsonUtility.ToJson(body);

            int startIndex = messagesJson.IndexOf('[');
            int endIndex = messagesJson.LastIndexOf(']');

            string messages = messagesJson.Substring(startIndex, endIndex - startIndex + 1);

            string jsonBody = $"{{\"model\":\"{_configProvider.Model}\",\"messages\":{messages},\"temperature\":1,\"top_p\":1,\"n\":1,\"stream\":false,\"max_tokens\":500,\"presence_penalty\":0,\"frequency_penalty\":0}}";

            using (UnityWebRequest request = new UnityWebRequest(_openAIGenerateTextEndpoint, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", "Bearer " + _configProvider.SecretKey);

                var asyncOperation = await request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    return null;
                }
                var response = JsonUtility.FromJson<OpenAIGenerateTextResponse>(request.downloadHandler.text);

                return response;
            }
        }

        public async UniTask<OpenAISpeechToTextResponse> PostOpenAISpeechToTextAsync(byte[] audioData, string language = "ja")
        {
            var formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("model", "whisper-1"));
            formData.Add(new MultipartFormDataSection("language", language));
            formData.Add(new MultipartFormFileSection("file", audioData, "audio.wav", "multipart/form-data"));

            using (UnityWebRequest request = UnityWebRequest.Post(_openAISpeechToTextEndpoint, formData))
            {
                request.SetRequestHeader("Authorization", "Bearer " + _configProvider.SecretKey);

                var asyncOperation = await request.SendWebRequest();

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