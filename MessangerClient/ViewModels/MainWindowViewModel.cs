using DevExpress.Data;
using DevExpress.Mvvm;
using MessangerClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MessangerClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IMessageManager messageManager)
        {
            LoadAllMessagesCommand = new AsyncCommand(LoadAllMessages);
            SendMessageCommand = new AsyncCommand(SendMessage, () => !string.IsNullOrEmpty(MessageText));

            this.messageManager = messageManager;
        }

        public string Title { get; set; } = "Messanger Client";

        public bool IsLoadingAllMessages
        {
            get
            {
                return _isLoadingAllMessages;
            }
            set
            {
                SetValue(ref _isLoadingAllMessages, value);
            }
        }
        public bool _isLoadingAllMessages;

        public string MessageText
        {
            get
            {
                return _messageText;
            }

            set
            {
                SetValue(ref _messageText, value);
            }
        }
        private string _messageText;

        public DateTime? From
        {
            get
            {
                return _from;
            }

            set
            {
                SetValue(ref _from, value);
                ApplyFiltering();
            }
        }
        private DateTime? _from;

        public DateTime? To
        {
            get
            {
                return _to;
            }

            set
            {
                SetValue(ref _to, value);
                ApplyFiltering();
            }
        }
        private DateTime? _to;

        public bool EnableFilter
        {
            get
            {
                return enableFilter;
            }

            set
            {
                SetValue(ref enableFilter, value);
                ApplyFiltering();
            }
        }
        private bool enableFilter;

        public ICollectionView MessagesView
        {
            get
            {
                return _messagesView;
            }

            set
            {
                SetValue(ref _messagesView, value);
            }
        }
        private ICollectionView _messagesView;

        public AsyncCommand LoadAllMessagesCommand { get; set; }

        public AsyncCommand SendMessageCommand { get; set; }

        private ObservableCollection<MessageViewModel> Messages { get; set; }

        private IMessageManager messageManager;

        private async Task LoadAllMessages()
        {
            var messages = await messageManager.GetAllMessagesAsync();

            var messageViewModels = messages.Select(message => new MessageViewModel(message.SendDateTime, message.UserName, message.Text));

            Messages = new ObservableCollection<MessageViewModel>(messageViewModels);

            MessagesView = CollectionViewSource.GetDefaultView(Messages);
        }

        private async Task SendMessage()
        {
            string text = MessageText;
            DateTime currentDateTime = DateTime.Now;

            MessageText = null;

            Message message = new Message(currentDateTime, Environment.UserName, text);
            await messageManager.SendMessageAsync(message);

            MessageViewModel messageViewModel = new MessageViewModel(currentDateTime, Environment.UserName, text);
            Messages.Add(messageViewModel);
        }

        private void ApplyFiltering()
        {
            if (EnableFilter && From != null && To != null)
            {
                MessagesView.Filter = new Predicate<object>(x => ((MessageViewModel)x).SendDateTime >= From && ((MessageViewModel)x).SendDateTime <= To);
            }
            else
            {
                MessagesView.Filter = null;
            }
        }
    }
}
