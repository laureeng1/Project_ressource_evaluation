using Admin.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVALUATION.DATA
{
    /// <summary>
    /// A simple database connection manager
    /// </summary>
    public class DbManager : IDisposable
    {
        private IDbConnection _conn { get; set; }
        public IDbTransaction DbTransaction;
        private bool _closeautomaticaly;
        public bool CloseAutomaticaly
        {
            get { return _closeautomaticaly; }
            set { _closeautomaticaly = value; }
        }

        /// <summary>
        /// Return open connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                return _conn;
            }
        }


        /// <summary>
        /// Create a new Sql database connection
        /// </summary>
        /// <param name="connString">The name of the connection string</param>
        public DbManager(string connString, bool closeautomaticaly = true)
        {
            // Use first?
            if (connString == "")
                connString = WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString;

            _conn = new SqlConnection(connString);
            _closeautomaticaly = closeautomaticaly;
        }

        /// <summary>
        /// Close and dispose of the database connection
        /// </summary>
        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
                _conn = null;
            }
        }
    }

}
