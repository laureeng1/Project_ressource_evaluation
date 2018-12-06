using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;
using Admin.Common.Helper;
using YAXLib;

namespace Admin.Common.Domain
{
    [DataContract]
    [Serializable]
    public partial class RequestBase
    {
        #region proprietés communes
        [DataMember]
        public long IdCurrentUser { get; set; }
        [DataMember]
        public short IdCurrentStructure { get; set; }
        [DataMember]
        public long IdCurrentTenant { get; set; }


        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public bool TakeAll { get; set; }
        [DataMember]
        public int Deepth { get; set; }

        [DataMember]
        public bool NotIn { get; set; }

        [DataMember]
        public bool CanFilterByStruct { get; set; }

        [DataMember]
        public bool CanFilterByTenant { get; set; }

        [DataMember]
        public bool CanDoSum { get; set; }

        [DataMember]
        public string SortOrder { get; set; }

        [DataMember]
        public Navigator Navigator { get; set; }

        public bool CanApplyTransaction { get; set; }

        public string AppDomainAppPath { get; set; }

        private int transactionQueue = -1;
        public int TransactionQueue
        {
            get
            {
                return this.transactionQueue;
            }
            set
            {
                transactionQueue = value;
            }
        }


       public string HostName { get; set; }

        public RequestBase()
        {
            Deepth = 1;
            Navigator = new Navigator();
            CanFilterByStruct = true;
            CanDoSum = false;
        }
        #endregion

       
    }

    public static class RequestBaseExtension
    {
        public static RequestBase ToFinalRequest(this RequestBase request)
        {
            try
            {
                if (request == null)
                {
                    request = new RequestBase();
                }
                if (request.TakeAll)
                    request.Size = int.MaxValue;
                else
                    request.Size = (request.Size != 0) ? request.Size : 5;
            }
            catch (Exception ex)
            {
                throw new Exception(CustomException.GetErrorMessage(ex));
            }
            return request;
        }

        private static Object ConvertObj(Object objToConvert, int level)
        {
            if (level <= 0) return objToConvert;

            var properties = objToConvert.GetType().GetProperties();

            foreach (var property in properties)
            {
                Object newObj;
                switch (property.PropertyType.Name)
                {
                    case "String":
                        var str = (string)property.GetValue(objToConvert, null);
                        newObj = string.IsNullOrEmpty(str) ? string.Empty : str.Trim();
                        property.SetValue(objToConvert, newObj, null);
                        break;
                    case "DateTime":
                    case "DateTime?":
                        Debug.Write("");
                        break;
                    case "Byte[]":
                        newObj = Array.CreateInstance(typeof(byte), 2);
                        property.SetValue(objToConvert, newObj, null);
                        break;
                    default:
                        if (!property.PropertyType.Name.StartsWith("I"))
                            if (property.GetValue(objToConvert, null) == null)
                            {
                                newObj = Activator.CreateInstance(property.PropertyType);
                                property.SetValue(objToConvert, newObj, null);
                            }
                        break;
                }

                if (property.PropertyType.IsValueType || property.PropertyType.Name == "String" || property.PropertyType.Name == "Byte[]" || property.PropertyType.Name.Contains("IEnumerable"))
                    continue;
                var newInst = ConvertObj(property.GetValue(objToConvert, null), level - 1);
                property.SetValue(objToConvert, newInst, null);
            }

            return objToConvert;
        }

        public static string ToXmlString(this RequestBase request)
        {
            // Now serialize the instance
            var serializer = new YAXSerializer(request.GetType());
            return serializer.Serialize(request);
        }

    }

    [DataContract]
    [Serializable]
    public class Intervalle<T>
    {
        [DataMember]
        public T Debut { get; set; }

        [DataMember]
        public T Fin { get; set; }

        public Intervalle()
        {
        }
    }

    public class Navigator
    {
        /// <summary>
        /// Returns the code name of the browser
        /// </summary>
        public string appCodeName { get; set; }

        /// <summary>
        /// Returns the name of the browser
        /// </summary>
        public string appName { get; set; }

        /// <summary>
        /// Returns the version information of the browser
        /// </summary>
        public string appVersion { get; set; }

        /// <summary>
        /// Determines whether cookies are enabled in the browser
        /// </summary>
        public string cookieEnabled { get; set; }

        /// <summary>
        /// Returns the language of the browser
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// Determines whether the browser is online
        /// </summary>
        public string onLine { get; set; }

        /// <summary>
        /// Returns for which platform the browser is compiled
        /// </summary>
        public string platform { get; set; }

        /// <summary>
        /// Returns the engine name of the browser
        /// </summary>
        public string product { get; set; }

        /// <summary>
        /// Returns the user-agent header sent by the browser to the server
        /// </summary>
        public string userAgent { get; set; }
    }
}
