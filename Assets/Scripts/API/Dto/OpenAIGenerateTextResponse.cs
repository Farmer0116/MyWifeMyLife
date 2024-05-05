namespace API.Dto
{
    [System.Serializable]
    public class OpenAIGenerateTextResponse
    {
        public string id;
        public string @object;
        public long created;
        public string model;
        public string system_fingerprint;
        public OpenAIGenerateTextResponseChoice[] choices;
        public OpenAIGenerateTextResponseUsage usage;
    }

    [System.Serializable]
    public class OpenAIGenerateTextResponseChoice
    {
        public int index;
        public OpenAIGenerateTextResponseMessage message;
        public object logprobs;
        public string finish_reason;
    }

    [System.Serializable]
    public class OpenAIGenerateTextResponseMessage
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public class OpenAIGenerateTextResponseUsage
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }
}