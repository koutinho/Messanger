using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient.Model
{
    public class WebApiMessageManager : IMessageManager
    {
        public IEnumerable<Message> GetAllMessages()
        {
            var request = new RestRequest(messagesRout, DataFormat.Json);

            var messages = client.Get<IEnumerable<Message>>(request);

            return messages.Data;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            var client = new RestClient(serverAddress);

            var request = new RestRequest(messagesRout, DataFormat.Json);

            var messages = await client.GetAsync<IEnumerable<Message>>(request);

            return messages;
        }

        public async Task SendMessageAsync(Message message)
        {
            var request = new RestRequest(messagesRout, Method.POST, DataFormat.Json);

            request.AddJsonBody(message);

            var response = await client.ExecuteAsync(request);
        }

        private RestClient client = new RestClient(serverAddress);

        private const string serverAddress = "http://localhost:48945";

        private const string messagesRout = "api/messages";
    }
}
