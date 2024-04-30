using System;
using System.Collections.Generic;

namespace API.Dto
{
    [Serializable]
    public class OpenAIGenerateTextRequestBody
    {
        public List<OpenAIGenerateTextRequestBodyMessage> messages;

        public OpenAIGenerateTextRequestBody()
        {
            messages = new List<OpenAIGenerateTextRequestBodyMessage>();
        }
    }

    [Serializable]
    public class OpenAIGenerateTextRequestBodyMessage
    {
        public string role;
        public string content;

        public OpenAIGenerateTextRequestBodyMessage
        (
            string role = "",
            string content = ""
        )
        {
            this.role = role;
            this.content = content;
        }
    }

    public enum RoleType
    {
        user = 0,
        system = 1
    }
}