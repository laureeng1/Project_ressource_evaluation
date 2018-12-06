//using System.ComponentModel;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace EVALUATION.DATA.Repository
//{
//    public class Connexion
//    {
//        private static SqlConnection _instance;

//        //internal static SqlConnection Instance
//        //{
//        //    get
//        //    {
//        //        return _instance =
//        //            new SqlConnection(
//        //                ConfigurationManager.ConnectionStrings["BD_ConnectionString_For_Dapper"]
//        //                    .ConnectionString);
//        //    }
//        //}

//        internal static SqlConnection Instance => _instance =
//                                                      new SqlConnection(
//                                                          ConfigurationManager.ConnectionStrings["BD_ConnectionString_For_Dapper"]
//                                                              .ConnectionString);

//        //internal static SqlConnection Instance => _instance ??
//        //                                          (_instance =
//        //                                              new SqlConnection(
//        //                                                  ConfigurationManager.ConnectionStrings["BD_ConnectionString_For_Dapper"]
//        //                                                      .ConnectionString));

//        //internal static SqlConnection Instance
//        //{
//        //    get
//        //    {
//        //        if (_instance == null) _instance = new SqlConnection(
//        //                                                  ConfigurationManager.ConnectionStrings["BD_ConnectionString_For_Dapper"]
//        //                                                      .ConnectionString);
//        //        if (_instance.State == ConnectionState.Open)
//        //        {
//        //            _instance.Dispose();
//        //            _instance = new SqlConnection(
//        //                                                  ConfigurationManager.ConnectionStrings["BD_ConnectionString_For_Dapper"]
//        //                                                      .ConnectionString);
//        //        }
//        //        return _instance;
//        //    }
//        //}
//    }
//}
