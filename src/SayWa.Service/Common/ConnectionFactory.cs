using SayWa.Entities.Common;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Options;

namespace SayWa.Service
{

    public class ConnectionFactory
    {
        private ConnectConfig _connConfig; 

        public ConnectionFactory(IOptions<ConnectConfig> connConfig)
        {
            _connConfig = connConfig.Value;
        }
        
        #region mysql
        /// <summary>
        /// 获取mysql对象
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        private MySqlConnection GetMySqlConn(string connStr)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
      
        public MySqlConnection GetMySqlConn()
        {
            return GetMySqlConn(_connConfig.ConnectionString);
        }       
        
        #endregion


    }
}
