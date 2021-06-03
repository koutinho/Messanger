using MessangerWebApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerWebApi.Services
{
    public class JsonMessageRepository : IMessageRepository
    {
        public void Add(Message message)
        {
            List<Message> messagesFromFile = ReadMessagesFromFile();

            messagesFromFile.Add(message);

            WriteMessagesToFile(messagesFromFile);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return ReadMessagesFromFile();
        }

        private List<Message> ReadMessagesFromFile()
        {
            if (!File.Exists(fileName))
                return new List<Message>();

            string fileContent = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<List<Message>>(fileContent);
        }

        private void WriteMessagesToFile(IEnumerable<Message> messages)
        {
            string content = JsonConvert.SerializeObject(messages, Formatting.Indented);

            File.WriteAllText(fileName, content);
        }

        private const string fileName = "messages.json";
    }
}
