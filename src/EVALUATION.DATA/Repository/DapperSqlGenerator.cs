using System;
using System.Collections.Generic;
using System.Linq;
using Admin.Common.Configuration;
using Admin.Common.Enum;
using Admin.Common.Domain;

namespace EVALUATION.DATA.Repository
{
    public static class DapperSqlGenerator
    {
        private static  IApplicationSettings _settings = WebConfigApplicationFactory.GetWebConfigApplication();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetSqlPagination(int index, int size)
        {
            var query = _settings.Sgbd == "MySQL"
                ? string.Format(" LIMIT {0} OFFSET {1}", size, index)
                : string.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", index, size);

            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="suffix"></param>
        /// <param name="hasPrefix"></param>
        /// <returns></returns>
        public static string GetSqlQueryParam(this string propertyName, short? suffix = null, bool hasPrefix = true)
        {
            return String.Format("{0}{1}{2}", (hasPrefix ? _settings.SqlQueryParamPrefix : String.Empty), propertyName,
                (suffix != null ? "_" + suffix : String.Empty));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCriteria"></param>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        /// <param name="colType"></param>
        /// <param name="operatorToUse"></param>
        /// <param name="suffix"></param>
        /// <param name="dictionary"></param>
        /// <param name="debut"></param>
        /// <param name="fin"></param>
        public static void AddWhereExpression(this List<string> lstCriteria, string colName, object colValue,
            string colType, string operatorToUse, short suffix,
            ref IDictionary<string, object> dictionary, object debut = null, object fin = null)
        {
            switch (colType)
            {
                case "bool":
                case "global::System.Nullable<bool>":
                    if (operatorToUse != OperatorEnum.BETWEEN)
                        dictionary.Add(colName.GetSqlQueryParam(suffix, false), colValue);

                    switch (operatorToUse)
                    {
                        case OperatorEnum.NOTEQUAL:
                            lstCriteria.Add(string.Format("{0} <> {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        default:
                            // opérateur par défaut : equal
                            lstCriteria.Add(string.Format("{0} = {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                    }
                    break;

                case "string":
                case "String":
                    if (operatorToUse != OperatorEnum.BETWEEN)
                        dictionary.Add(colName.GetSqlQueryParam(suffix, false), colValue);
                    switch (operatorToUse)
                    {
                        case OperatorEnum.NOTEQUAL:
                            lstCriteria.Add(string.Format("{0} <> {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.STARSTWITH:
                            lstCriteria.Add(string.Format("{0} LIKE ''+{1}+'%'", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.ENDSWITH:
                            lstCriteria.Add(string.Format("{0} LIKE '%'+{1}+''", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.EQUAL:
                            lstCriteria.Add(string.Format("{0} = {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        default:
                            // opérateur par défaut : contains
                            lstCriteria.Add(string.Format("{0} LIKE '%'+{1}+'%'", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                    }
                    break;

                case "int":
                case "short":
                case "double":
                case "float":
                case "long":
                case "byte":
                case "decimal":
                case "global::System.Nullable<decimal>":
                case "global::System.Nullable<short>":
                case "global::System.Nullable<double>":
                case "global::System.Nullable<float>":
                case "global::System.Nullable<long>":
                case "global::System.Nullable<int>":
                case "global::System.Nullable<byte>":
                    if (operatorToUse != OperatorEnum.BETWEEN)
                        dictionary.Add(colName.GetSqlQueryParam(suffix, false), colValue);

                    switch (operatorToUse)
                    {
                        case OperatorEnum.NOTEQUAL:
                            lstCriteria.Add(string.Format("{0} <> {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.LESS:
                            lstCriteria.Add(string.Format("{0} < {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.LESSOREQUAL:
                            lstCriteria.Add(string.Format("{0} <= {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.MORE:
                            lstCriteria.Add(string.Format("{0} > {1}", colName, colName.GetSqlQueryParam(suffix)));
                            ;
                            break;
                        case OperatorEnum.MOREOREQUAL:
                            lstCriteria.Add(string.Format("{0} >= {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.BETWEEN:
                            string paramDebut = colName + "_Debut";
                            string paramFin = colName + "_Fin";

                            dictionary.Add(paramDebut.GetSqlQueryParam(suffix, false), debut);
                            dictionary.Add(paramFin.GetSqlQueryParam(suffix, false), fin);

                            lstCriteria.Add(string.Format("({0} BETWEEN {1} AND {2})", colName,
                                paramDebut.GetSqlQueryParam(suffix), paramFin.GetSqlQueryParam(suffix)));
                            break;
                        default:
                            // opérateur par défaut : equal
                            lstCriteria.Add(string.Format("{0} = {1}", colName, colName.GetSqlQueryParam(suffix)));
                            break;
                    }
                    break;

                case "global::System.DateTime":
                case "global::System.Date":
                case "global::System.Nullable<System.DateTime>":
                case "global::System.Nullable<System.Date>":
                    if (operatorToUse != OperatorEnum.BETWEEN)
                        dictionary.Add(colName.GetSqlQueryParam(suffix, false), colValue);

                    switch (operatorToUse)
                    {
                        case OperatorEnum.NOTEQUAL:
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) <> CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.LESS:
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) < CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.LESSOREQUAL:
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) <= CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.MORE:
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) > CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.MOREOREQUAL:
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) >= CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                        case OperatorEnum.BETWEEN:
                            var paramDebut = colName + "_Debut";
                            var paramFin = colName + "_Fin";

                            dictionary.Add(paramDebut.GetSqlQueryParam(suffix, false), debut);
                            dictionary.Add(paramFin.GetSqlQueryParam(suffix, false), fin);

                            lstCriteria.Add(
                                string.Format("(CONVERT(DATE, {0}) BETWEEN CONVERT(DATE, {1}) AND CONVERT(DATE, {2}))",
                                    colName, paramDebut.GetSqlQueryParam(suffix), paramFin.GetSqlQueryParam(suffix)));
                            break;
                        default:
                            // opérateur par défaut : equal
                            lstCriteria.Add(string.Format("CONVERT(DATE, {0}) = CONVERT(DATE, {1})", colName,
                                colName.GetSqlQueryParam(suffix)));
                            break;
                    }
                    break;

            }
        }

        /// <summary>
        /// Generer la requete sql pour l'insertion
        /// </summary>
        /// <param name="tableName">Le nom de la table</param>
        /// <param name="keyProperties">La liste des clés primaires de la table</param>
        /// <param name="notKeyProperties">La liste des autres colonnes de la table</param>
        /// <param name="hasIdentityKey">Precise si les clé primaire sont auto-increment</param>
        /// <returns></returns>
        public static string GetInsertExpression(string tableName, List<string> keyProperties,
            List<string> notKeyProperties, bool hasIdentityKey = true)
        {
            if (keyProperties == null)
                throw new ArgumentNullException("keyProperties");
            if (notKeyProperties == null)
                throw new ArgumentNullException("notKeyProperties");

            // construction de la requete d'insertion
            // ajouter des colonnes et leurs valeurs

            var properties = new List<string>();
            if (!hasIdentityKey)
                properties.AddRange(keyProperties);

            properties.AddRange(notKeyProperties);

            var sqlstring = string.Join(", ", properties);

            var paramsLst = properties.Select(prop => prop.GetSqlQueryParam()).ToList();
            var paramsSqlstring = string.Join(", ", paramsLst);

            //return String.Format("INSERT INTO {0} ({1}) VALUES({2}); SELECT CAST(SCOPE_IDENTITY() as bigint)", tableName, sqlstring, paramsSqlstring);
            return String.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, sqlstring, paramsSqlstring);
        }


        public static string GenerateUpdateValueExpression<T>(BusinessRequest<T> request) where T : DtoBase, new()
        {

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">Le nom de la table</param>
        /// <param name="keyProperties">La liste des clés primaires de la table</param>
        /// <param name="notKeyProperties">La liste des autres colonnes de la table</param>
        /// <returns></returns>
        public static string GetUpdateExpression(string tableName, List<string> keyProperties,List<string> notKeyProperties)
        {

            if (keyProperties == null)
                throw new ArgumentNullException("keyProperties");
            if (notKeyProperties == null)
                throw new ArgumentNullException("notKeyProperties");

            // build the query
            notKeyProperties.Remove("DateCreation");
            notKeyProperties.Remove("CreatedBy");
            //notKeyProperties.Remove("DataKey");
            //notKeyProperties.Remove("IdTenant");

            var notKeyPropertiesBuild =
                notKeyProperties.Select(nkeyProp => string.Format("{0} = {1}", nkeyProp, nkeyProp.GetSqlQueryParam()))
                    .ToList();
            var notKeyPropertiesSqlString = string.Join(", ", notKeyPropertiesBuild);

            var keyBuild = keyProperties.Select(key => string.Format("{0} = {1}", key, key.GetSqlQueryParam())).ToList();
            var keySqlString = string.Join(" AND ", keyBuild);

            return String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, notKeyPropertiesSqlString, keySqlString);
        }

    }
}