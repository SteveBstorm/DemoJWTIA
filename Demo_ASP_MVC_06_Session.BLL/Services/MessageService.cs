using Demo_ASP_MVC_06_Session.BLL.Interfaces;
using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using Demo_ASP_MVC_06_Session.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepo;

        public MessageService(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepo.GetAll();
        }

        public void Insert(Message message)
        {

            if(_messageRepo.Add(message) <= 0)
            {
                throw new Exception("Erreur dans l'enregistrement du message");
            }

        }
    }
}
