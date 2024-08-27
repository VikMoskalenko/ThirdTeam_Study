using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class DapperContext
    {
        //added readonly and added param to ctor dappercontext
       // private readonly string connectionString;
        public DapperContext() 
        { 
           
        }
        public bool IsConnected { get; set; }
        public NpgsqlConnection OpenConnection(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            IsConnected = true;
            return connection;
        }
        public void CloseConnection(NpgsqlConnection connection)
        {
            connection.Close();
            IsConnected = false;
        }
      
        
        
    }
}
