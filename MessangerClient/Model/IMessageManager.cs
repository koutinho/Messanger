using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient.Model
{
    public interface IMessageManager
    {
        IEnumerable<Message> GetAllMessages();

        Task<IEnumerable<Message>> GetAllMessagesAsync();
    }
}
