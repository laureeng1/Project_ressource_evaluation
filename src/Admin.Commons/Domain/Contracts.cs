using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Admin.Common.Domain
{
    [DataContract]
    [Serializable]
    public partial class BusinessResponse<T> : ResponseBase
    {
        /// <summary>
        /// Obtient ou defini la liste des objets retournés
        /// </summary>
        [DataMember]
        public List<T> Items { get; set; }
        
        public BusinessResponse()
        {
            Items = new List<T>();
        }
    }

    [DataContract]
    [Serializable]
    public partial class BusinessRequest<T> : RequestBase where T : DtoBase, new()
    {
        /// <summary>
        /// Obtient ou defini l'objet contenant les criteres de recherche
        /// </summary>
        [DataMember]
        public T ItemToSearch { get; set; }

        /// <summary>
        /// Rechercher avec plusieurs objets de recherche en OU 
        /// (opérateur de comparaison des propriétés de chaque objet en ET)
        /// </summary>
        [DataMember]
        public List<T> ItemsToSearch { get; set; }

        /// <summary>
        /// Obtient ou defini la liste des objets à enregistrer
        /// </summary>
        [DataMember]
        public List<T> ItemsToSave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Object DbManager { get; set; }
        

        /// <summary>
        /// Verifie si les proprietés requises sont renseignées
        /// </summary>
        /// <param name="item">La collection d'objets a verifier</param>
        /// <returns>True si toutes proprietes requises sont valides, sinon faux</returns>
        public static bool ValidateRequiredProperties(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return true;
        }

        public BusinessRequest()
        {
            this.ItemsToSave = new List<T>();
            this.ItemsToSearch = new List<T>();
            this.ItemToSearch = new T();
        }

      
    }
}
