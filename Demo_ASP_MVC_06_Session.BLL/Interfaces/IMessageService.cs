using Demo_ASP_MVC_06_Session.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.BLL.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();
        void Insert(Message message);
    }
}
