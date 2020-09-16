using BitzenAppInfra.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppInfra.Repositories
{
    public class DbConnectionString : IDbConnectionString
    {
        public MySqlConnection Connection()
        {
            return new MySqlConnection("Server=localhost; Port=3306; User=root ; Password=1234; Database=sys");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
