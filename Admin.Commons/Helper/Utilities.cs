using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Admin.Common.Configuration;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Logging;
using System.Reflection;

namespace Admin.Common.Helper
{
    public static class Utilities
    {

        private static DateTime _currentDate = DateTime.Now;

        public static DateTime CurrentDate
        {
            get { return DateTime.Now; }
            set { _currentDate = value; }
        }

        public static int? GetDefaultIntValue(int? value)
        {
            if (value == null)
                return 0;
            return value;
        }

        public static string GetCodeProduit(string sLastCode, string produit)
        {
            string deb = "";
            switch (produit)
            {

                case SubProduitEnum.PRODUIT:
                    deb = SubProduitEnum.PRODUIT;
                    break;
                default:
                    deb = produit;
                    break;

            }
            string valueTest = deb + "Z999999";
            if (string.IsNullOrEmpty(sLastCode))
                sLastCode = "";
            if (sLastCode.Length < valueTest.Length)
                sLastCode = "";
            // Fait attention aux bornes inf et supp
            if (String.IsNullOrEmpty(sLastCode) || sLastCode == deb + "Z999999")
                return deb + "A000001";

            // Suivant
            string sNextCode = string.Empty;
            string testLastCode = sLastCode.Substring(5, 6);
            if (Convert.ToInt64(testLastCode) == 999999)
                sNextCode = (((char)((int)sLastCode[4]) == 'Z') ? 'A' : (char)((int)sLastCode[4] + 1)) + "000001";
            else
                sNextCode = (char)((int)sLastCode[4]) + (Convert.ToInt64(sLastCode.Substring(5, 6)) + 1).ToString("000000");

            return deb + sNextCode;
        }


        public static int GetAge(this DateTime birthDay)
        {
            if (birthDay == null)
                throw new Exception("la date ne peut etre null");

            return CurrentDate.Year - birthDay.Year;
        }

        public static string GetCodeActeMedicalGenere(string sLastCode, string actemedical)
        {
            string deb = "";
            switch (actemedical)
            {

                case SubActemedicalEnum.ACTEMEDICAL:
                    deb = SubActemedicalEnum.ACTEMEDICAL;
                    break;
                default:
                    deb = actemedical;
                    break;

            }
            string valueTest = deb + "Z999999";
            if (string.IsNullOrEmpty(sLastCode))
                sLastCode = "";
            if (sLastCode.Length < valueTest.Length)
                sLastCode = "";
            // Fait attention aux bornes inf et supp
            if (String.IsNullOrEmpty(sLastCode) || sLastCode == deb + "Z999999")
                return deb + "A000001";

            // Suivant
            string sNextCode = string.Empty;
            if (Convert.ToInt64(sLastCode.Substring(4, 6)) == 999999)
                sNextCode = (((char)((int)sLastCode[3]) == 'Z') ? 'A' : (char)((int)sLastCode[3] + 1)) + "000001";
            else
                sNextCode = (char)((int)sLastCode[3]) + (Convert.ToInt64(sLastCode.Substring(4, 6)) + 1).ToString("000000");

            return deb + sNextCode;
        }
        

        public static string GetMatriculePersonnel(string sLastCode, string prefix)
        {
            string deb = "";
            switch (prefix)
            {
          
                case SubPersonnelEnum.PERSONNELMEDICAL:
                    deb = SubPersonnelEnum.PERSONNELMEDICAL;
                    break;
                case SubCentreConventionneEnum.REFERENCECENTRECONVENTION:
                    deb = SubCentreConventionneEnum.REFERENCECENTRECONVENTION;
                    break;
                default:
                    deb = prefix;
                    break;

            }
            string valueTest = deb + "Z999999";
            if (string.IsNullOrEmpty(sLastCode))
                sLastCode = "";
            if (sLastCode.Length < valueTest.Length)
                sLastCode = "";
            // Fait attention aux bornes inf et supp
            if (String.IsNullOrEmpty(sLastCode) || sLastCode == deb + "Z999999")
                return deb + "A000001";

            // Suivant
            string sNextCode = string.Empty;
            if (Convert.ToInt64(sLastCode.Substring(3, 6)) == 999999)
                sNextCode = (((char)((int)sLastCode[2]) == 'Z') ? 'A' : (char)((int)sLastCode[2] + 1)) + "000001";
            else
                sNextCode = (char)((int)sLastCode[2]) + (Convert.ToInt64(sLastCode.Substring(3, 6)) + 1).ToString("000000");

            return deb + sNextCode;
        }

        public static string GetNextCode(string sLastCode, string valueDeb)
        {
            string deb = "";
            switch (valueDeb)
            {
                case SubMatriculeAssureEnum.ADHERENT:
                    //deb = SubMatriculeAssureEnum.ADHERENT;
                    deb = SubNumeroSouscripteurEnum.VALUE;
                    break;
                case SubNumeroSouscripteurEnum.VALUE:
                    //deb = SubMatriculeAssureEnum.ADHERENT;
                    deb = SubNumeroSouscripteurEnum.VALUE;
                    break;
                case SubMatriculeAssureEnum.AFFILIE:
                    deb = SubMatriculeAssureEnum.AFFILIE;
                    break;
                case NumeroBonDePriseEnCharge.FACTURERD:
                      deb =  NumeroBonDePriseEnCharge.FACTURERD;
                    break;
                case NumeroDecompte.DECOMPTERD:
                    deb = NumeroDecompte.DECOMPTERD;
                    break;
                case NumeroDecompte.DECOMPTETP:
                    deb = NumeroDecompte.DECOMPTETP;
                    break;
                case NumeroBordereau.BORDEREAU:
                    deb = NumeroBordereau.BORDEREAU;
                    break;
              
                case NumeroComptetiers.COMPTETIERS:
                    deb = NumeroComptetiers.COMPTETIERS;
                    break;
                 
                case NumeroConvention.CONVENTION:
                    deb = NumeroConvention.CONVENTION;
                    break;
                case NumeroCarte.CARTE :
                    deb = NumeroCarte.CARTE;
                    break;
                case SubAvenantContratClientGarant.REFERENCEAVENANTCLIENTGARANT:
                    deb = SubAvenantContratClientGarant.REFERENCEAVENANTCLIENTGARANT;
                    break;
                case SubNumeroReglementEnum.RECU:
                    deb = SubNumeroReglementEnum.RECU;
                    break;
                case SubNumeroReglementEnum.VALUE:
                    deb = SubNumeroReglementEnum.VALUE;
                    break;
                default:
                    deb = valueDeb;
                    break;
              
            }
            string valueTest = deb + "Z999999";
            if (string.IsNullOrEmpty(sLastCode))
                sLastCode = "";
            if (sLastCode.Length < valueTest.Length)
                sLastCode = "";
            // Fait attention aux bornes inf et supp
            if (String.IsNullOrEmpty(sLastCode) || sLastCode == deb + "Z999999")
                return deb + "A000001";

            // Suivant
            string sNextCode = string.Empty;

            if (Convert.ToInt64(sLastCode.Substring(4, 6)) == 999999)
                sNextCode = (((char)((int)sLastCode[3]) == 'Z') ? 'A' : (char)((int)sLastCode[3] + 1)) + "000001";
            else
                sNextCode = (char)((int)sLastCode[3]) + (Convert.ToInt64(sLastCode.Substring(4, 6)) + 1).ToString("000000");

            return deb + sNextCode;
        }

        public static bool DateIsValid(DateTime? date)
        {
            DateTime dateConverted = date??DateTime.Now;
            if (date == null || dateConverted > DateTime.Now|| dateConverted<= DateTime.MinValue)
            {
                return false;
            }
            return true;
        }

        public static string SaveFile(long idToSave, string dossierBase, string targetFolder, string pieceJointe,string extension)
        {
            var location = "";
            extension = extension.Replace(@".", "").Trim();
            targetFolder = "File\\" + targetFolder;
            var nomFichier = "";
            try
            {
                //Céer le dossier
                DirectoryInfo di = Directory.CreateDirectory(@dossierBase +targetFolder);

                
                nomFichier = String.Format(@"file{0}_{1}_{2}_{3}_{4}_{5}_{6}.{7}", idToSave, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, extension);
                var dossier = targetFolder+"\\";
                var emplacement = String.Format("{0}{1}", dossier, nomFichier);
                
                var contenu = pieceJointe.Split(',');
                if (contenu.Length > 0)
                {
                    var filec = Convert.FromBase64String(contenu[contenu.Length - 1]);
                    location = String.Format("{0}{1}", dossierBase, emplacement);
                   
                    //création du fichier dans un repertoire sur l'application web
                    File.WriteAllBytes(location, filec);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return targetFolder + "\\" + nomFichier;
        }


        //public static List<InfoData> GetPropertyInfos(Object obj)
        //{
        //    var list = new List<InfoData>();

        //    foreach (var propInfo in obj.GetType().GetProperties())
        //    {
        //        var infoData = new InfoData
        //        {
        //            PropertyName = propInfo.Name,
        //            PropertyType = propInfo.PropertyType,
        //            PropertyValue = propInfo.GetValue(obj, null),
        //            ObjectType = propInfo.DeclaringType
        //        };

        //        list.Add(infoData);
        //    }

        //    return list;
        //}

        public static bool IsTrue(dynamic value, dynamic reference, string operatorToUse)
        {
            var isTrue = false;

            switch (operatorToUse)
            {
                case OperatorEnum.NOTEQUAL:
                    isTrue = (value != reference);
                    break;
                case OperatorEnum.LESS:
                    isTrue = (value < reference);
                    break;
                case OperatorEnum.LESSOREQUAL:
                    isTrue = (value <= reference);
                    break;
                case OperatorEnum.MORE:
                    isTrue = (value > reference);
                    break;
                case OperatorEnum.MOREOREQUAL:
                    isTrue = (value > reference);
                    break;
                default:
                    // égalité par défaut
                    isTrue = (value == reference);
                    break;
            }

            return isTrue;
        }

        public static string LeftPad(int targetLength, string padChar = "0")
        {
            var output = "";
            for (var i = 0; i < targetLength; i++)
            {
                output = padChar + output;
            }

            return output;
        }

        public static bool HasSpecialCharacters(this string str)
        {
            const string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            var specialCharactersArray = specialCharacters.ToCharArray();

            var index = str.IndexOfAny(specialCharactersArray);
            //index == -1 no special characters
            return index != -1;
        }

        public static void VerifyPasswordComplexity(this string mdp, string codeElt, string msgError)
        {
            switch (codeElt)
            {
                case ElementComplexiteEnum.Letter:
                    if (!mdp.Any(char.IsLetter))
                        throw new CustomException(msgError);
                    break;
                case ElementComplexiteEnum.Num:
                    if (!mdp.Any(char.IsNumber))
                        throw new CustomException(msgError);
                    break;
                case ElementComplexiteEnum.SpeChar:
                    if (!mdp.HasSpecialCharacters())
                        throw new CustomException(msgError);
                    break;
                case ElementComplexiteEnum.Maj:
                    if (!mdp.Any(char.IsUpper))
                        throw new CustomException(msgError);
                    break;
                case ElementComplexiteEnum.Min:
                    if (!mdp.Any(char.IsLower))
                        throw new CustomException(msgError);
                    break;
            }
        }

        public static string GetUniqueKey()
        {
            int maxSize = 10;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length)]); }

            return result.ToString().ToUpper();
        }

        public static string BuildQuery(List<string> lstCriteria)
        {
            if (lstCriteria == null) throw new ArgumentNullException("lstCriteria");

            var criteria = new StringBuilder();

            foreach (var elt in lstCriteria)
            {
                if (lstCriteria.Last() == elt)
                {
                    criteria.Append(elt);
                }
                else
                {
                    criteria.Append(elt).Append(" AND ");
                }
            }

            return lstCriteria.Any() ? criteria.ToString() : string.Empty;
        }

        public static T CastObject<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                if(propertyInfo!=null)
                {
                    try
                    {
                       
                        if(myobj.GetType().GetProperty(memberInfo.Name)!=null)
                        {
                            value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
                            if (!IsNullOrDefault(value))
                                propertyInfo.SetValue(x, value, null);

                        }
                      
                    }
                    catch(Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                 

                }
                
            }
            return (T)x;
        }

        public static bool IsNullOrDefault<T>(T value)
        {
            long longValue = 0;
            bool isNull = object.Equals(value, default(T));
            if (!isNull && Int64.TryParse(value.ToString(), out longValue))
            {
                if (longValue == 0)
                    isNull = true;
            }
            return isNull;
        }

        public static BusinessRequest<R> convertRequestFromViewModelToDto<T,R>(BusinessRequest<T> request) where T:DtoBase,new() where R:DtoBase, new()
        {
            List<R> newListSave = new List<R>();
            List<R> newListSearch = new List<R>();
            foreach(var item in request.ItemsToSave)
            {
                R currentItemToAdd = item.CastObject<R>();
                newListSave.Add(currentItemToAdd);
            }
            foreach (var item in request.ItemsToSearch)
            {
                R currentItemToAdd = item.CastObject<R>();
                newListSearch.Add(currentItemToAdd);
            }
            return new BusinessRequest<R>()
            {
                CanApplyTransaction = request.CanApplyTransaction,
                CanDoSum = request.CanDoSum,
                CanFilterByStruct = request.CanFilterByStruct,
                Deepth = request.Deepth,
                IdCurrentStructure = request.IdCurrentStructure,
                IdCurrentUser = request.IdCurrentUser,
                Index = request.Index,
                Navigator = request.Navigator,
                NotIn = request.NotIn,
                Size = request.Size,
                SortOrder = request.SortOrder,
                TakeAll = request.TakeAll,
                ItemToSearch = request.ItemToSearch.CastObject<R>(),
                ItemsToSave = newListSave,
                ItemsToSearch = newListSearch
            };
        }


        public static BusinessResponse<R> convertResponseFromViewModelToDto<T, R>(BusinessResponse<T> response) where T : DtoBase, new() where R : DtoBase, new()
        {
            List<R> newListSave = new List<R>();
            foreach (var item in response.Items)
            {
                R currentItemToAdd = item.CastObject<R>();
                newListSave.Add(currentItemToAdd);
            }
          
            return new BusinessResponse<R>()
            {
               Count = response.Count,
               HasError = response.HasError,
               IndexDebut = response.IndexDebut,
               IndexFin = response.IndexFin,
               IsAuthentify = response.IsAuthentify,
               IsConnected = response.IsConnected,
               Items = newListSave
            };
        }

    }


  

    #region Custom exception
    /// <summary>
    /// Represente les erreurs qui se produisent lors de l'execution de l'application
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe CustomException avec un message d'erreur specifié
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exceptionType"></param>
        public CustomException(string message, string exceptionType = null)
            : base(Processor(message, exceptionType))
        {
        }


        /// <summary>
        /// Capture une exception et envoi un email contenant les details de l'erreur à l'administrateur de l'application
        /// </summary>
        /// <param name="request">Contient les parametres d'entree ayant generé l'exception</param>
        /// <param name="response">Contient l'exception generée</param>
        /// <param name="sendMail"></param>
        public CustomException(RequestBase request, ResponseBase response, bool sendMail = false)
            : base(Processor(request, response, sendMail))
        {
        }

        /// <summary>
        /// Notifie une exception 
        /// </summary>
        /// /// <param name="response"></param>
        /// <param name="ex"></param>
        public static void Write(ResponseBase response, Exception ex)
        {
            //response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            response.Message = GetErrorMessage(ex);
            response.HasError = true;
        }

        /// <summary>
        /// Notifie une exception 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="ex"></param>
        public static void Write(RequestBase request, ResponseBase response, Exception ex)
        {
           //if(request.Transaction!=null && request.CanApplyTransaction)  request.Transaction.Rollback();
            //response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            response.Message = GetErrorMessage(ex);
            response.HasError = true;
        }


        public static void WriteTest(RequestBase request, ResponseBase response, Exception ex)
        {
            //response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            response.Message = GetErrorMessage(ex);
            response.HasError = true;
        }

        public static string GetErrorMessage(Exception ex)
        {
            var listException = ex.FlattenHierarchy().ToList();
            var msg = string.Empty;
            var level = 0;
            foreach (var exception in listException)
            {
                if (exception.Message.EndsWith(GlobalConstantes.CustomException) || exception.Message.StartsWith("Level 1"))
                {
                    msg = exception.Message;
                }
                else
                {
                    level++;
                    msg = msg + string.Format("Level {0}: {1}<br/>", level, exception.Message);
                }
            }

            return msg;
        }

        private static string Processor(string message, string exceptionType = null)
        {
            return string.Format("{0} {1}", message, exceptionType ?? GlobalConstantes.CustomException);
        }

        private static string Processor(RequestBase request, ResponseBase response, bool sendMail = false)
        {
            var webConfigApp = new WebConfigApplicationSettings();

            var detailException = string.Format("REQUEST :\n {0}.\n\n\n RESPONSE :\n{1}", request.ToXmlString(),
                                                response.ToXmlString());
            var mailBody =
                string.Format("exception : {0} \n\n detail exception : {1}",
                              response.Message, detailException);

            EmailSender.SendAsync(new MailRequest()
            {
                Sender = webConfigApp.ExpEmail,
                SenderName = webConfigApp.ExpFullName,
                Recipient = webConfigApp.ToMail,
                RecipientName = webConfigApp.ToFullName,
                Subject = @"ERP Exception",
                Body = mailBody,
                SendOrNo = sendMail,
                BccRecipient = webConfigApp.BccMail,
                BccRecipientName = webConfigApp.BccFullName,
                IsBodyHtml = true
            });

            LoggingFactory.GetLogger().Log(string.Format("Utilities => ThrowException : exception {0}", mailBody));

            return response.Message;
        }
    }

    public static class DebugExtensions
    {
        public static IEnumerable<Exception> FlattenHierarchy(this Exception ex)
        {
            if (ex == null) throw new ArgumentNullException("ex");

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }
    }
    #endregion

    #region helper

    /// <span class="code-SummaryComment"><summary/></span>
    /// Provides a method for performing a deep copy of an object.
    /// Binary Serialization is used to perform the copy.
    /// <span class="code-SummaryComment"></span>
    public static class ObjectCopier
    {
        /// <span class="code-SummaryComment"><summary/></span>
        /// Perform a deep Copy of the object.
        /// <span class="code-SummaryComment"></span>
        /// <span class="code-SummaryComment"><typeparam name="T">The type of object being copied.</typeparam></span>
        /// <span class="code-SummaryComment"><param name="source">The object instance to copy.</param></span>
        /// <span class="code-SummaryComment"><returns>The copied object.</returns></span>
        public static T Clone<T>(this T source)
        {
            var dcSer = new DataContractSerializer(source.GetType());
            var memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, source);
            memoryStream.Position = 0;

            var newObject = (T)dcSer.ReadObject(memoryStream);
            return newObject;
        }
        //public static T Clone<T>(this T source)
        //{
        //    if (!typeof(T).IsSerializable)
        //    {
        //        throw new ArgumentException("The type must be serializable.", "source");
        //    }

        //    // Don't serialize a null object, simply return the default for that object
        //    if (Object.ReferenceEquals(source, null))
        //    {
        //        return default(T);
        //    }

        //    IFormatter formatter = new BinaryFormatter();
        //    Stream stream = new MemoryStream();
        //    using (stream)
        //    {
        //        formatter.Serialize(stream, source);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        var clone = (T)formatter.Deserialize(stream);
        //        return clone;
        //    }
        //}
    }

    public static class EmailHelper
    {
        /// <summary>
        /// Regular expression, which is used to validate an E-Mail address.
        /// </summary>
        private const string MatchEmailPattern =
                  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        /// <summary>
        /// Verifier si la chaine est une adresse E-Mail valide.
        /// </summary>
        /// <param name="email">chaine qui contient l'adresse E-Mail.</param>
        /// <returns>True, quand la chaine est non null et 
        /// contient une adresse E-Mail valide;
        /// sinon false.</returns>
        public static bool IsEmail(this string email)
        {
            return email != null && Regex.IsMatch(email, MatchEmailPattern);
        }
    }

    public class ConverterHelper
    {
        public static string ConvertNumberToLettre(float number)
        {
            int centaine, dizaine, unite, reste, y;
            var dix = false;
            var lettre = "";
            //strcpy(lettre, "");

            reste = (int)(number / 1);

            for (int i = 1000000000; i >= 1; i /= 1000)
            {
                y = reste / i;
                if (y != 0)
                {
                    centaine = y / 100;
                    dizaine = (y - centaine * 100) / 10;
                    unite = y - (centaine * 100) - (dizaine * 10);
                    switch (centaine)
                    {
                        case 0:
                            break;
                        case 1:
                            lettre += "cent ";
                            break;
                        case 2:
                            if ((dizaine == 0) && (unite == 0)) lettre += "deux cents ";
                            else lettre += "deux cent ";
                            break;
                        case 3:
                            if ((dizaine == 0) && (unite == 0)) lettre += "trois cents ";
                            else lettre += "trois cent ";
                            break;
                        case 4:
                            if ((dizaine == 0) && (unite == 0)) lettre += "quatre cents ";
                            else lettre += "quatre cent ";
                            break;
                        case 5:
                            if ((dizaine == 0) && (unite == 0)) lettre += "cinq cents ";
                            else lettre += "cinq cent ";
                            break;
                        case 6:
                            if ((dizaine == 0) && (unite == 0)) lettre += "six cents ";
                            else lettre += "six cent ";
                            break;
                        case 7:
                            if ((dizaine == 0) && (unite == 0)) lettre += "sept cents ";
                            else lettre += "sept cent ";
                            break;
                        case 8:
                            if ((dizaine == 0) && (unite == 0)) lettre += "huit cents ";
                            else lettre += "huit cent ";
                            break;
                        case 9:
                            if ((dizaine == 0) && (unite == 0)) lettre += "neuf cents ";
                            else lettre += "neuf cent ";
                            break;
                    }// endSwitch(centaine)

                    switch (dizaine)
                    {
                        case 0:
                            break;
                        case 1:
                            dix = true;
                            break;
                        case 2:
                            lettre += "vingt ";
                            break;
                        case 3:
                            lettre += "trente ";
                            break;
                        case 4:
                            lettre += "quarante ";
                            break;
                        case 5:
                            lettre += "cinquante ";
                            break;
                        case 6:
                            lettre += "soixante ";
                            break;
                        case 7:
                            dix = true;
                            lettre += "soixante ";
                            break;
                        case 8:
                            lettre += "quatre-vingt ";
                            break;
                        case 9:
                            dix = true;
                            lettre += "quatre-vingt ";
                            break;
                    } // endSwitch(dizaine)

                    switch (unite)
                    {
                        case 0:
                            if (dix) lettre += "dix ";
                            break;
                        case 1:
                            if (dix) lettre += "onze ";
                            else lettre += "un ";
                            break;
                        case 2:
                            if (dix) lettre += "douze ";
                            else lettre += "deux ";
                            break;
                        case 3:
                            if (dix) lettre += "treize ";
                            else lettre += "trois ";
                            break;
                        case 4:
                            if (dix) lettre += "quatorze ";
                            else lettre += "quatre ";
                            break;
                        case 5:
                            if (dix) lettre += "quinze ";
                            else lettre += "cinq ";
                            break;
                        case 6:
                            if (dix) lettre += "seize ";
                            else lettre += "six ";
                            break;
                        case 7:
                            if (dix) lettre += "dix-sept ";
                            else lettre += "sept ";
                            break;
                        case 8:
                            if (dix) lettre += "dix-huit ";
                            else lettre += "huit ";
                            break;
                        case 9:
                            if (dix) lettre += "dix-neuf ";
                            else lettre += "neuf ";
                            break;
                    } // endSwitch(unite)

                    switch (i)
                    {
                        case 1000000000:
                            if (y > 1) lettre += "milliards ";
                            else lettre += "milliard ";
                            break;
                        case 1000000:
                            if (y > 1) lettre += "millions ";
                            else lettre += "million ";
                            break;
                        case 1000:
                            lettre += "mille ";
                            break;
                    }
                } // end if(y!=0)
                reste -= y * i;
                dix = false;
            } // end for
            if (lettre.Length == 0) lettre += "zero";

            return lettre;
        }

        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }

        

        public static LambdaExpression ChangeInputType<T, TResult>(Expression<Func<T, TResult>> expression, Type newInputType)
        {
            if (!typeof(T).IsAssignableFrom(newInputType))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T), newInputType));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(newInputType, beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda(visitor.Visit(expression.Body), afterParameter);
        }

        public static Expression<Func<T2, TResult>> ChangeInputType<T1, T2, TResult>(Expression<Func<T1, TResult>> expression)
        {
            if (!typeof(T1).IsAssignableFrom(typeof(T2)))
                throw new Exception(string.Format("{0} is not assignable from {1}.", typeof(T1), typeof(T2)));
            var beforeParameter = expression.Parameters.Single();
            var afterParameter = Expression.Parameter(typeof(T2), beforeParameter.Name);
            var visitor = new SubstitutionExpressionVisitor(beforeParameter, afterParameter);
            return Expression.Lambda<Func<T2, TResult>>(visitor.Visit(expression.Body), afterParameter);
        }

        public class SubstitutionExpressionVisitor : ExpressionVisitor
        {
            private Expression before, after;
            public SubstitutionExpressionVisitor(Expression before, Expression after)
            {
                this.before = before;
                this.after = after;
            }
            public override Expression Visit(Expression node)
            {
                return node == before ? after : base.Visit(node);
            }
        }
    }

    //public static class ImageHelper
    //{
    //    public static Bitmap GetScaleImage(this MediaTypeNames.Image image, Size size)
    //    {
    //        return new Bitmap(image, size.Width, size.Height);
    //    }

    //    public static byte[] ImageToByteArray(this MediaTypeNames.Image imageToConvert)
    //    {
    //        if (imageToConvert == null)
    //            return null;

    //        var ms = new MemoryStream();
    //        imageToConvert.Save(ms, ImageFormat.Jpeg);
    //        return ms.ToArray();
    //    }

    //    public static MediaTypeNames.Image ByteArrayToImage(this byte[] byteArrayToConvert)
    //    {
    //        if (byteArrayToConvert == null)
    //            return null;

    //        var ms = new MemoryStream(byteArrayToConvert);
    //        var returnImage = MediaTypeNames.Image.FromStream(ms);
    //        return returnImage;
    //    }

    //    public static string ImageToBase64(this MediaTypeNames.Image image, ImageFormat format)
    //    {
    //        using (var ms = new MemoryStream())
    //        {
    //            // Convert Image to byte[]
    //            image.Save(ms, format);
    //            byte[] imageBytes = ms.ToArray();

    //            // Convert byte[] to Base64 String
    //            var base64String = Convert.ToBase64String(imageBytes);
    //            return base64String;
    //        }
    //    }

    //    public static MediaTypeNames.Image Base64ToImage(this string base64String)
    //    {
    //        // Convert Base64 String to byte[]
    //        byte[] imageBytes = Convert.FromBase64String(base64String);
    //        var ms = new MemoryStream(imageBytes, 0,
    //          imageBytes.Length);

    //        // Convert byte[] to Image
    //        ms.Write(imageBytes, 0, imageBytes.Length);
    //        var image = MediaTypeNames.Image.FromStream(ms, true);
    //        return image;
    //    }
    //}
    #endregion



}
