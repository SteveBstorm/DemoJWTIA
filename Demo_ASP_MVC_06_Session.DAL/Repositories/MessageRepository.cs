using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using Demo_ASP_MVC_06_Session.DAL.Utils;
using Demo_ASP_MVC_06_Session.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.DAL.Repositories
{
    public class MessageRepository : RepositoryBase<int, Message>, IMessageRepository
    {
        public MessageRepository(IDbConnection connection) : base(connection)
        {
        }

        protected override Message Mapper(IDataRecord record)
        {
            return new Message
            {
                Member_Id = (int)record["Member_Id"],
                Content = record["Content"].ToString(),
                Message_Id = (int)record["Message_Id"],
                CreatedAt = (DateTime)record["Create_At"]
            };
        }

        public override int Add(Message entity)
        {
            string sql = "INSERT INTO Message (Content, Member_Id, Create_At) " +
                "OUTPUT inserted.Message_Id " +
                "VALUES (@content, @mid, @cat)";
            using(IDbCommand command = _connection.CreateQueryCommand(sql))
            {
                command.AddParam("content", entity.Content);
                command.AddParam("mid", entity.Member_Id);
                command.AddParam("cat", entity.CreatedAt);

                _connection.Open();
                int newMessageId = (int)command.ExecuteScalar();
                _connection.Close();

                return newMessageId;
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Message> GetAll()
        {
            IDbCommand command = _connection.CreateQueryCommand("SELECT * FROM Message");
            _connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
            _connection.Close();
        }

        public override Message? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, Message entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
