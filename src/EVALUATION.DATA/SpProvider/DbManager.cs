using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EVALUATION.CORE.Dto;
using System.Threading.Tasks;
using EVALUATION.DATA.Provider;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;
using Admin.Common.Configuration;

namespace EVALUATION.DATA.SpProvider
{
    public class DbManager
    {
        //private static DbManager _instance;

        //public static DbManager Instance
        //{
        //    get { return _instance ?? (_instance = new DbManager()); }
        //}

        readonly string ConnectionStrings = WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString;

        public IDbConnection DbConnection;
        public IDbTransaction DbTransaction;

        public DbManager()
        {
            DbConnection = new SqlConnection(ConnectionStrings);
        }


        public void OpenConnection()
        {
            try
            {
                if (DbConnection.State == ConnectionState.Closed)
                {
                    //DbConnection.ConnectionString = ConnectionStrings;
                    DbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (DbConnection != null)
                {
                    if (DbConnection.State == ConnectionState.Open)
                    {
                        DbConnection.Close();
                        DbConnection.Dispose();
                    }
                    DbConnection = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
