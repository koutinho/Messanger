using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangerWebApi.Model
{
    public class Message
    {
        public Message(DateTime sendDateTime, string userName, string text)
        {
            SendDateTime = sendDateTime;
            UserName = userName;
            Text = text;
        }

        public DateTime SendDateTime { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }
    }
}
