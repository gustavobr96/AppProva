
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppInfra.Interfaces
{
    public interface IDbConnectionString : IDisposable
    {
        MySqlConnection Connection();
    }
}
