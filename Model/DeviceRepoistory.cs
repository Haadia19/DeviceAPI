using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAPI.Model
{
    public class DeviceRepoistory
    {
        private string connectionString;
        public DeviceRepoistory()
        {
            connectionString = @"Data Source=DESKTOP-99CIQF8;Initial Catalog=WooooDev;Integrated Security=True";
        }
        public IDbConnection Conn
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public void Add(Device dev)
        {
            using (IDbConnection dbConnection = Conn)
            {
                string sQuery = @"insert into Device values (@deviceId, @deviceName)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, dev);
                dbConnection.Close();
            }
        }

        public IEnumerable<Device> Get()
        {
            using (IDbConnection dbConnection = Conn)
            {
                string sQuery = @"select * from Device";
                dbConnection.Open();
                return dbConnection.Query<Device>(sQuery);
            }
        }
        public Device GetbyID(Guid deviceId)
        {
            using (IDbConnection dbConnection = Conn)
            {
                string sQuery = @"select* from Device where deviceId = @deviceId";
                dbConnection.Open();
                return dbConnection.Query<Device>(sQuery, new { deviceId = deviceId }).FirstOrDefault();
            }
        }
        public void Delete(Guid deviceId)
        {
            using (IDbConnection dbConnection = Conn)
            {
                string sQuery = @"delete from Device where deviceId = @deviceId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { deviceId = deviceId });
            }
        }
        public void Update(Device dev)
        {
            using (IDbConnection dbConnection = Conn)
            {
                string sQuery = @"update Device set @deviceName = @deviceName where deviceId = @deviceId";
                dbConnection.Open();
                dbConnection.Query(sQuery, dev);
            }
        }

    }
}
