using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient.Model
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
