using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient.Model
{
    public class MockedMessageManager : IMessageManager
    {
        public MockedMessageManager()
        {
            messages = new List<Message>
            {
                new Message(DateTime.Now.AddHours(-1), "koutinho", "Although the property name suggests that you can use only singular values, CornerRadius also supports non-uniform radii. Radius values that are too large are scaled so that they blend smoothly from corner to corner."),
                new Message(DateTime.Now.AddHours(-2), "koutinho", "Сообщение2"),
                new Message(DateTime.Now.AddHours(-3), "koutinho", "Сообщение3")
            };
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return messages;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            await Task.Delay(2000);

            return messages;
        }

        public async Task SendMessageAsync(Message message)
        {
            messages.Add(message);

            await Task.Delay(1000);
        }

        private List<Message> messages;
    }
}
