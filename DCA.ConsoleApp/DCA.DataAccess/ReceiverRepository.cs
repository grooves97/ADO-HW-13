using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using DCA.DataAcces.Abstract;
using DCA.Models;

namespace DCA.DataAccess
{
    public class ReceiverRepository : IRepository<Receiver>
    {
        private DbConnection _connection;

        public ReceiverRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }
        public void Add(Receiver item)
        {
            var sql = "insert into Receiver (Id,CreationDate,FullName,Address,DeletedDate) values (@Id,@CreationDate,@FullName,@Address,@DeletedDate)";
            var result = _connection.Execute(sql, item);
            if (result < 1) throw new Exception();
        }

        public void Delete(Guid id)
        {
            var sql = "update Receiver set DeletedDate = GETDATE() WHERE Id = @ID";
            _connection.Query(sql, new { ID = id });
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public ICollection<Receiver> GetAll()
        {
            var sql = "select * from Receiver";
            return _connection.Query<Receiver>(sql).AsList();
        }

        public void Update(Receiver item)
        {
            var result = _connection.Execute("update Receiver set FullName = @FullName WHERE Id = @Id", item);
            if (result < 1) throw new Exception();

            result = _connection.Execute("update Receiver set Address = @Address WHERE Id = @Id", item);
            if (result < 1) throw new Exception();
        }
    }
}
