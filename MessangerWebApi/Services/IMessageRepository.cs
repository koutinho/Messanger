using MessangerWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerWebApi.Services
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();

        void Add(Message message);
    }
}
