using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using Dapper;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;
using System.Threading.Tasks;

namespace EVALUATION.DATA.Repository
{
    public class GenericProvider : IDisposable
    {
        readonly DbManager _dbManager;
        private string _connexionString;
        private bool _closeautomaticaly;
        public bool CloseConnetionAutomaticaly
        {
            get { return _closeautomaticaly; }
            set { _closeautomaticaly = value; }
        }
        public string ConnexionString
        {
            get { return _connexionString; }
            set { _connexionString = value; }
        }
        public  DbManager DbManager
        {
            get { return _dbManager; }
            //set { _dbManager = value; }

        }

        #region Delegate
        public delegate string GetWhereExpressionMethod<in T>(T itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false);
        public delegate string GetTableUpdateExpressionMethod<in T>(T itemToSave, List<string> keyProperties, List<string> notKeyProperties);
        public delegate string GenerateOrderByExpressionMethod<in T>(T itemToSearch, string sortOrder);
        public delegate string GenerateSumExpressionMethod<in T>(T itemToSearch);
        public delegate T GenerateSumMethod<T>(string criteria, object paramObj, T itemToSearch, T itemToReturn);
        public delegate void FormatItemsToSave<T>(List<T> itemsToSave, List<T> itemsToInsert, List<T> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey);
        public delegate void FormatItemsToDelete<T>(List<T> itemsToSave, List<T> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey);
        #endregion

        #region Singleton
        public GenericProvider(bool CloseConnetionAutomaticaly = true)
        {
            _dbManager = !string.IsNullOrEmpty(_connexionString) ? new DbManager(_connexionString) : new DbManager(string.Empty);
            _closeautomaticaly = CloseConnetionAutomaticaly;
            
        }

        public IDbTransaction Getransaction()
        {
            return (!CloseConnetionAutomaticaly)? _dbManager.Connection.BeginTransaction():null;
        }

        public GenericProvider(string connString, bool CloseConnetionAutomaticaly = true)
        {
            _dbManager = new DbManager(connString);
            _closeautomaticaly = CloseConnetionAutomaticaly;

        }

        
        public GenericProvider(DbManager dbManager, bool CloseConnetionAutomaticaly = true)
        {
            if (dbManager == null)
                _dbManager = new DbManager(string.Empty);
            else
                _dbManager = dbManager;
            _closeautomaticaly = CloseConnetionAutomaticaly;

        }
        //private static GenericProvider _instance;

        //public static GenericProvider Instance
        //{
        //    get { return _instance ?? (_instance = new GenericProvider()); }
        //}

        #endregion

        #region Read
        public T GetItemById<T>(object id, string tableName, string keyPropertie)
        {
            var query = string.Format("SELECT * FROM {0} WHERE {1} = {2}", tableName, keyPropertie, "Id".GetSqlQueryParam());

            return _dbManager.Connection.Query<T>(query, new { Id = id }).SingleOrDefault();
        }
        public BusinessResponse<T> GetItemsByCriteria<T>(BusinessRequest<T> request, string tableName, GetWhereExpressionMethod<T> getWhereExpressionMethod, GenerateOrderByExpressionMethod<T> generateOrderByExpressionMethod, GenerateSumMethod<T> generateSumMethod) where T : DtoBase, new()
        {
            var response = new BusinessResponse<T>();
            try
            {
                request.ToFinalRequest();

                var queryBase = string.Format("SELECT * FROM {0} ", tableName);
                var queryCount = string.Format("SELECT COUNT(*) FROM {0} ", tableName);

                var paramObj = new ExpandoObject() as IDictionary<string, object>;

                //generate main criteria
                var mainCriteria = getWhereExpressionMethod(request.ItemToSearch, 0, ref paramObj, true);

                //generate others criteria
                if (request.ItemsToSearch == null)
                    request.ItemsToSearch = new List<T>();
                var lstOtherCriteria = new List<string>();
                short index = 0;
                foreach (var dto in request.ItemsToSearch)
                {
                    index++;
                    var criteriaElt = getWhereExpressionMethod(dto, index, ref paramObj);
                    if (!string.IsNullOrEmpty(criteriaElt))
                        lstOtherCriteria.Add(criteriaElt);
                }
                var otherCriterias = new StringBuilder();
                foreach (var elt in lstOtherCriteria)
                {
                    otherCriterias.Append(request.NotIn
                        ? string.Format(" AND ({0})", elt)
                        : string.Format(" OR ({0})", elt));
                }

                if (string.IsNullOrEmpty(request.SortOrder) || (request.SortOrder != MySortOrder.Ascending && request.SortOrder != MySortOrder.Descending))
                    request.SortOrder = MySortOrder.Descending;
                var orderByExp = generateOrderByExpressionMethod(request.ItemToSearch, request.SortOrder);

                if (string.IsNullOrEmpty(mainCriteria) && !string.IsNullOrEmpty(otherCriterias.ToString()))
                {
                    if (otherCriterias.ToString().StartsWith(" AND"))
                        otherCriterias.Remove(0, " AND".Length);
                    if (otherCriterias.ToString().StartsWith(" OR"))
                        otherCriterias.Remove(0, " OR".Length);
                    mainCriteria = " WHERE ";
                }
                var fullQueryMain = queryBase + mainCriteria + otherCriterias + orderByExp + DapperSqlGenerator.GetSqlPagination(request.Index, request.Size);
                var fullQueryCount = queryCount + mainCriteria + otherCriterias;
                var query = fullQueryMain + ";" + fullQueryCount;

                //using (var cnx = Connexion.Instance)
                //{
                var result = _dbManager.Connection.QueryMultiple(query, paramObj);
                response.Items = result.Read<T>().ToList();
                response.Count = result.Read<int>().Single();
                response.IndexDebut = request.Index;
                response.IndexFin = response.IndexDebut + response.Items.Count() - 1;
                // }

                // add sum value
                if (request.CanDoSum && response.Count > 0)
                {
                    var dto = response.Items[0];
                    response.Items[0] = generateSumMethod(mainCriteria + otherCriterias, paramObj, request.ItemToSearch, dto);
                }
            }
            catch (Exception ex)
            {
                CustomException.Write(response, ex);
            }

            return response;
        }
        public BusinessResponse<decimal> GetSumByCriteria<T>(BusinessRequest<T> request, string tableName, GetWhereExpressionMethod<T> getWhereExpressionMethod, GenerateSumExpressionMethod<T> generateSumExpressionMethod) where T : DtoBase, new()
        {
            var response = new BusinessResponse<decimal>();
            try
            {
                request.ToFinalRequest();

                var paramObj = new ExpandoObject() as IDictionary<string, object>;

                //generate main criteria
                var mainCriteria = getWhereExpressionMethod(request.ItemToSearch, 0, ref paramObj, true);

                //generate others criteria
                if (request.ItemsToSearch == null)
                    request.ItemsToSearch = new List<T>();
                var lstOtherCriteria = new List<string>();
                short index = 0;
                foreach (var dto in request.ItemsToSearch)
                {
                    index++;
                    var criteriaElt = getWhereExpressionMethod(dto, index, ref paramObj);
                    if (!string.IsNullOrEmpty(criteriaElt))
                        lstOtherCriteria.Add(criteriaElt);
                }
                var otherCriterias = new StringBuilder();
                foreach (var elt in lstOtherCriteria)
                {
                    otherCriterias.Append(request.NotIn
                        ? string.Format(" AND ({0})", elt)
                        : string.Format(" OR ({0})", elt));
                }

                var sumField = generateSumExpressionMethod(request.ItemToSearch);

                //using (var cnx = Connexion.Instance)
                //{
                var sum = _dbManager.Connection.Query<decimal>(string.Format("SELECT SUM({0}) FROM {1} {2} ", sumField, tableName, mainCriteria + otherCriterias), paramObj).Single();

                response.Items.Add(sum);
                //}

            }
            catch (Exception ex)
            {
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Save
        public BusinessResponse<T> SaveItems<T>(BusinessRequest<T> request, string tableName, List<string> keyProperties, List<string> notKeyProperties, FormatItemsToSave<T> formatItemsTo) where T : DtoBase, new()
        {
            var response = new BusinessResponse<T>();
            try
            {
                if (request == null)
                    throw new ArgumentException("request");
                var notKeyPropertiesclone = (List<string>)notKeyProperties.Clone();
                var keyPropertiesclone = (List<string>)keyProperties.Clone();

              

                var itemsToInsert = new List<T>();
                var itemsToUpdate = new List<T>();

                var date = Utilities.CurrentDate;
                var dataKey = string.Format("{0}{1}{2}H{3}-{4}-{5}-{6}", date.Year, date.Month, date.Day,
                    date.ToLongTimeString(), request.IdCurrentStructure, request.IdCurrentUser, Utilities.GetUniqueKey());

                formatItemsTo(request.ItemsToSave, itemsToInsert, itemsToUpdate, request.IdCurrentUser, request.IdCurrentStructure, dataKey);
                //using (var cnx = Connexion.Instance)
                //{
                int countInsert = 0, countUpdate = 0;
                if (itemsToInsert.Any())
                {
                    string sqlInsert = DapperSqlGenerator.GetInsertExpression(tableName, keyPropertiesclone, notKeyPropertiesclone);

                    countInsert = _dbManager.Connection.Execute(sqlInsert, itemsToInsert);
                }
                if (itemsToUpdate.Any())
                {
                    string sqlUpdate = DapperSqlGenerator.GetUpdateExpression(tableName, keyProperties, notKeyProperties);
                    countUpdate = _dbManager.Connection.Execute(sqlUpdate, itemsToUpdate);
                    //response.Items.AddRange(itemsToUpdate);
                }
                // get inserted data
                var query = string.Format("SELECT TOP {0} * FROM {1} WHERE DataKey = '{2}'", (countInsert + countUpdate), tableName, dataKey);
                var result = _dbManager.Connection.Query<T>(query);
                response.Items.AddRange(result);
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }
        #endregion

             #region Delete
        public BusinessResponse<Boolean> DeleteItems<T>(BusinessRequest<T> request, string tableName,
            List<string> keyProperties,
            List<string> deleteProperties, FormatItemsToDelete<T> formatItemsTo) where T : DtoBase, new()
        {
            var response = new BusinessResponse<Boolean>();
            try
            {
                if (request == null)
                    throw new ArgumentException("request");

                string sqlUpdate = DapperSqlGenerator.GetUpdateExpression(tableName, keyProperties, deleteProperties);

                var itemsToDelete = new List<T>();

                var date = Utilities.CurrentDate;
                var dataKey = string.Format("{0}{1}{2}H{3}-{4}-{5}", date.Year, date.Month, date.Day,
                    date.ToLongTimeString(), request.IdCurrentStructure, request.IdCurrentUser);

                formatItemsTo(request.ItemsToSave, itemsToDelete, request.IdCurrentUser,
                    request.IdCurrentStructure, dataKey);

                //using (var cnx = Connexion.Instance)
                //{
                if (itemsToDelete.Any())
                {
                    _dbManager.Connection.Execute(sqlUpdate, itemsToDelete);
                }
                response.Items.Add(true);
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }
        #endregion

        #region Read database infos
        public BusinessResponse<string> GetLstClasseDtos()
        {
            var response = new BusinessResponse<string>();
            try
            {
                //using (var cnx = Connexion.Instance)
                //{
                var lst = _dbManager.Connection.Query<string>("SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_TYPE IN ('BASE TABLE', 'VIEW') ORDER BY TABLE_NAME");
                response.Items = lst.Select(n => n + "Dto").ToList();
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }
        public BusinessResponse<string> GetLstProperties(string classeName)
        {
            var response = new BusinessResponse<string>();
            //using (var cnx = Connexion.Instance)
            //{
            if (classeName.EndsWith("Dto")) classeName = classeName.Replace("Dto", string.Empty);
            response.Items = _dbManager.Connection.Query<string>(string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' ORDER BY COLUMN_NAME", classeName)).ToList();
            //}
            return response;
        }
        public void AutoDisconnecteUserAsync()
        {
            //using (var cnx = Connexion.Instance)
            //{
            const string query = @"declare @currentDate datetime;
                        set @currentDate = GETDATE();UPDATE [Admin].[AdminSessionUtilisateur] SET IsConnected = 0, DateLastActivity = @currentDate, DateMaj = @currentDate
                        WHERE (DATEDIFF(ss, DateLastActivity, @currentDate) - TimeSession) > 0
                        AND IsConnected = 1";
            _dbManager.Connection.Execute(query);
            //}
        }
        public void Dispose()
        {
            if (_dbManager != null)
                _dbManager.Dispose();
        }

        #endregion

          #region Read Async
        public async Task<T> GetItemByIdAsync<T>(object id, string tableName, string keyPropertie)
        {
            try
            {

            var query = string.Format("SELECT * FROM {0} WHERE {1} = {2}", tableName, keyPropertie, "Id".GetSqlQueryParam());
            return await _dbManager.Connection.QueryFirstAsync<T>(query, new { Id = id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<BusinessResponse<T>> GetItemsByCriteriaAsync<T>(BusinessRequest<T> request, string tableName, GetWhereExpressionMethod<T> getWhereExpressionMethod, GenerateOrderByExpressionMethod<T> generateOrderByExpressionMethod, GenerateSumMethod<T> generateSumMethod) where T : DtoBase, new()
        {
            var response = new BusinessResponse<T>();
            try
            {
                request.ToFinalRequest();
                var queryBase = string.Format("SELECT * FROM {0} ", tableName);

                var queryCount = string.Format("SELECT COUNT(*) FROM {0} ", tableName);
                var paramObj = new ExpandoObject() as IDictionary<string, object>;
                //generate main criteria
                var mainCriteria = getWhereExpressionMethod(request.ItemToSearch, 0, ref paramObj, true);
                //generate others criteria
                if (request.ItemsToSearch == null)
                    request.ItemsToSearch = new List<T>();
                var lstOtherCriteria = new List<string>();
                short index = 0;
                foreach (var dto in request.ItemsToSearch)
                {
                    index++;
                    var criteriaElt = getWhereExpressionMethod(dto, index, ref paramObj);
                    if (!string.IsNullOrEmpty(criteriaElt))
                        lstOtherCriteria.Add(criteriaElt);
                }
                var otherCriterias = new StringBuilder();
                foreach (var elt in lstOtherCriteria)
                {
                    otherCriterias.Append(request.NotIn
                        ? string.Format(" AND ({0})", elt)
                        : string.Format(" OR ({0})", elt));
                }
                if (string.IsNullOrEmpty(request.SortOrder) || (request.SortOrder != MySortOrder.Ascending && request.SortOrder != MySortOrder.Descending))
                    request.SortOrder = MySortOrder.Descending;
                var orderByExp = generateOrderByExpressionMethod(request.ItemToSearch, request.SortOrder);
                if (string.IsNullOrEmpty(mainCriteria) && !string.IsNullOrEmpty(otherCriterias.ToString()))
                {
                    if (otherCriterias.ToString().StartsWith(" AND"))
                        otherCriterias.Remove(0, " AND".Length);
                    if (otherCriterias.ToString().StartsWith(" OR"))
                        otherCriterias.Remove(0, " OR".Length);
                    mainCriteria = " WHERE ";
                }
                var fullQueryMain = queryBase + mainCriteria + otherCriterias + orderByExp + DapperSqlGenerator.GetSqlPagination(request.Index, request.Size);
                var fullQueryCount = queryCount + mainCriteria + otherCriterias;
                var query = fullQueryMain + ";" + fullQueryCount;
                //using (var cnx = Connexion.Instance)
                //{
                var result = await _dbManager.Connection.QueryMultipleAsync(query, paramObj);
                response.Items = result.Read<T>().ToList();
                response.Count = result.Read<int>().Single();
                response.IndexDebut = request.Index;
                response.IndexFin = response.IndexDebut + response.Items.Count - 1;
                // }
                // add sum value
                if (request.CanDoSum && response.Count > 0)
                {
                    var dto = response.Items[0];
                    response.Items[0] = generateSumMethod(mainCriteria + otherCriterias, paramObj, request.ItemToSearch, dto);
                }
            }
            catch (Exception ex)
            {
                CustomException.Write(response, ex);
            }
            return response;
        }
        public async Task<BusinessResponse<decimal>> GetSumByCriteriaAsync<T>(BusinessRequest<T> request, string tableName, GetWhereExpressionMethod<T> getWhereExpressionMethod, GenerateSumExpressionMethod<T> generateSumExpressionMethod) where T : DtoBase, new()
        {
            var response = new BusinessResponse<decimal>();
            try
            {
                request.ToFinalRequest();
                var paramObj = new ExpandoObject() as IDictionary<string, object>;
                //generate main criteria
                var mainCriteria = getWhereExpressionMethod(request.ItemToSearch, 0, ref paramObj, true);
                //generate others criteria
                if (request.ItemsToSearch == null)
                    request.ItemsToSearch = new List<T>();
                var lstOtherCriteria = new List<string>();
                short index = 0;
                foreach (var dto in request.ItemsToSearch)
                {
                    index++;
                    var criteriaElt = getWhereExpressionMethod(dto, index, ref paramObj);
                    if (!string.IsNullOrEmpty(criteriaElt))
                        lstOtherCriteria.Add(criteriaElt);
                }
                var otherCriterias = new StringBuilder();
                foreach (var elt in lstOtherCriteria)
                {
                    otherCriterias.Append(request.NotIn
                        ? string.Format(" AND ({0})", elt)
                        : string.Format(" OR ({0})", elt));
                }
                var sumField = generateSumExpressionMethod(request.ItemToSearch);
                //using (var cnx = Connexion.Instance)
                //{
                var sum = await _dbManager.Connection.QueryFirstAsync<decimal>(string.Format("SELECT SUM({0}) FROM {1} {2} ", sumField, tableName, mainCriteria + otherCriterias), paramObj);
                response.Items.Add(sum);
                //}
            }
            catch (Exception ex)
            {
                CustomException.Write(response, ex);
            }
            return response;
        }
        #endregion Read Async

        #region Save Async

        public async Task<BusinessResponse<T>> SaveItemsAsync<T>(BusinessRequest<T> request, string tableName, List<string> keyProperties, List<string> notKeyProperties, FormatItemsToSave<T> formatItemsTo, GetTableUpdateExpressionMethod<T> getTableUpdateExpressionMethod) where T : DtoBase, new()
        {
            var response = new BusinessResponse<T>();
            try
            {
                if (request == null)
                    throw new ArgumentException("request");

                string sqlInsert = DapperSqlGenerator.GetInsertExpression(tableName, keyProperties, notKeyProperties);

                var itemsToInsert = new List<T>();
                var itemsToUpdate = new List<T>();

                var date = Utilities.CurrentDate;
                var dataKey = string.Format("{0}{1}{2}H{3}-{4}-{5}-{6}", date.Year, date.Month, date.Day,
                    date.ToLongTimeString(), request.IdCurrentStructure, request.IdCurrentUser, Utilities.GetUniqueKey());

                formatItemsTo(request.ItemsToSave, itemsToInsert, itemsToUpdate, request.IdCurrentUser, request.IdCurrentStructure, dataKey);

                //using (var cnx = Connexion.Instance)
                //{

                int countInsert = 0, countUpdate = 0;
                if (itemsToInsert.Any())
                {
                    countInsert = await _dbManager.Connection.ExecuteAsync(sqlInsert, itemsToInsert);
                }
                if (itemsToUpdate.Any())
                {
                    foreach(var itemToUpdate in itemsToUpdate)
                    {
                        string sqlUpdate = getTableUpdateExpressionMethod(itemToUpdate, keyProperties, notKeyProperties);
                        await _dbManager.Connection.ExecuteAsync(sqlUpdate, new List<T>() { itemToUpdate});
                        countUpdate++;
                    }
                   /* string sqlUpdate = DapperSqlGenerator.GetUpdateExpression(tableName, keyProperties, notKeyProperties);
                    countUpdate = await _dbManager.Connection.ExecuteAsync(sqlUpdate, itemsToUpdate);*/
                    //response.Items.AddRange(itemsToUpdate);
                }
                // get inserted data
                var query = string.Format("SELECT TOP {0} * FROM {1} WHERE DataKey = '{2}'", (countInsert + countUpdate), tableName, dataKey);
                var result = await _dbManager.Connection.QueryAsync<T>(query, null);
                response.Items.AddRange(result);
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }

        #endregion

        #region Delete Async

        public async Task<BusinessResponse<Boolean>> DeleteItemsAsync<T>(BusinessRequest<T> request, string tableName,
            List<string> keyProperties,
            List<string> deleteProperties, FormatItemsToDelete<T> formatItemsTo) where T : DtoBase, new()
        {
            var response = new BusinessResponse<Boolean>();
            try
            {
                if (request == null)
                    throw new ArgumentException("request");

                string sqlUpdate = DapperSqlGenerator.GetUpdateExpression(tableName, keyProperties, deleteProperties.Where(i => i == "IsDeleted" || i == "ModifiedBy" || i == "DateMaj").ToList());

                //var itemsToDelete = new List<T>();
                var itemsToDelete = request.ItemsToSave;

                var date = Utilities.CurrentDate;
                var dataKey = string.Format("{0}{1}{2}H{3}-{4}-{5}", date.Year, date.Month, date.Day,
                    date.ToLongTimeString(), request.IdCurrentStructure, request.IdCurrentUser);

                formatItemsTo(request.ItemsToSave, itemsToDelete, request.IdCurrentUser,
                    request.IdCurrentStructure, dataKey);
                //using (var cnx = Connexion.Instance)
                //{
                int countDelete = 0;
                if (itemsToDelete.Any())
                {
                    countDelete = await _dbManager.Connection.ExecuteAsync(sqlUpdate, itemsToDelete);
                }
                response.Items.Add(true);
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }

        #endregion

        #region Read database infos Async

        public async Task<BusinessResponse<string>> GetLstClasseDtosAsync()
        {
            var response = new BusinessResponse<string>();

            try
            {
                //using (var cnx = Connexion.Instance)
                //{
                var lst = await _dbManager.Connection.QueryAsync<string>("SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_TYPE IN ('BASE TABLE', 'VIEW') ORDER BY TABLE_NAME");

                response.Items = lst.Select(n => n + "Dto").ToList();
                //}
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }
            return response;
        }

        public async Task<BusinessResponse<string>> GetLstPropertiesAsync(string classeName)
        {
            var response = new BusinessResponse<string>();

            //using (var cnx = Connexion.Instance)
            //{
            if (classeName.EndsWith("Dto")) classeName = classeName.Replace("Dto", string.Empty);

            response.Items = (await _dbManager.Connection.QueryAsync<string>(string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' ORDER BY COLUMN_NAME", classeName))).ToList();
            //}

            return response;
        }

        public void AutoDisconnecteUser()
        {
            //using (var cnx = Connexion.Instance)
            //{
            const string query = @"declare @currentDate datetime;
                        set @currentDate = GETDATE();UPDATE [Admin].[AdminSessionUtilisateur] SET IsConnected = 0, DateLastActivity = @currentDate, DateMaj = @currentDate
                        WHERE (DATEDIFF(ss, DateLastActivity, @currentDate) - TimeSession) > 0
                        AND IsConnected = 1";
            _dbManager.Connection.ExecuteAsync(query);
            //}
        }

        #endregion

        #region SQL RAW

        public async Task<BusinessResponse<dynamic>> ExecuteRawSqlTask(string sql)
        {
            var response = new BusinessResponse<dynamic>();
            try
            {

                var result = await _dbManager.Connection.QueryAsync(sql);
                response.Items.AddRange(result);
                return response;
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
                return response;

            }

        }

        public async Task<BusinessResponse<int>> ExecuteStoredProcedure(string procedure,  DynamicParameters parameters )
        {
            var response = new BusinessResponse<int>();
            try
            {

                var result =
                     _dbManager.Connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                response.Items.Add(result);
                return response;
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
                return response;

            }

        }

        public async Task<BusinessResponse<int>> ExecuteStoredProcedureList(string procedure, List<DynamicParameters> parameters)
        {
            var response = new BusinessResponse<int>();
            try
            {

                var result =
                     _dbManager.Connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                response.Items.Add(result);
                return response;
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
                return response;

            }

        }
        public async Task<BusinessResponse<T>> ExecuteStoredProcedureObjet<T>(string procedure, DynamicParameters parameters)
        {
            var response = new BusinessResponse<T>();
            try
            {

                var result = await 
                     _dbManager.Connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
                response.Items.AddRange(result);
                return response;
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
                return response;

            }
           
        }
        #endregion
    }
}

