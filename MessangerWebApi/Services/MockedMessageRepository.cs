using MessangerWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerWebApi.Services
{
    public class MockedMessageRepository : IMessageRepository
    {
        public void Add(Message message)
        {
            messages.Add(message);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return messages;
        }

        private List<Message> messages = new List<Message>
            {
                new Message(DateTime.Now.AddHours(-1), "koutinho", "Сообщение1"),
                new Message(DateTime.Now.AddHours(-2), "koutinho", "Сообщение2"),
                new Message(DateTime.Now.AddHours(-3), "koutinho", "Сообщение3")
            };
    }
}
