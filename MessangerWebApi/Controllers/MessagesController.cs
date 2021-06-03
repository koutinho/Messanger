using MessangerWebApi.Model;
using MessangerWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessangerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return messageRepository.GetAllMessages();
        }

        // POST api/<MessagesController>
        [HttpPost]
        public void Post(Message message)
        {
            messageRepository.Add(message);
        }

        private IMessageRepository messageRepository;
    }
}
