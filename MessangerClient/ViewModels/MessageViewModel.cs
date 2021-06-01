using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        public MessageViewModel(DateTime sendDateTime, string userName, string text)
        {
            SendDateTime = sendDateTime;
            UserName = userName;
            Text = text;
        }

        public DateTime SendDateTime
        {
            get
            {
                return _sendDateTime;
            }

            set
            {
                SetValue(ref _sendDateTime, value);
            }
        }
        public DateTime _sendDateTime;

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                SetValue(ref _userName, value);
            }
        }
        public string _userName;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                SetValue(ref _text, value);
            }
        }
        public string _text;
    }
}
