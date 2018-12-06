using System;

namespace Admin.Common.Domain
{
    [Serializable]
    public class EntityBase
    {
        //[Key]
        //public int Id { get; set; }
    }

    [Serializable]
    public class DtoBase
    {
        public bool IsNewItem { get; set; }

        //public int IdTenant { get; set; }

        private bool _requiredTenant = true;

        public bool RequiredTenant
        {
            get { return _requiredTenant; }
            set { _requiredTenant = value; }
        }

       public virtual object ConvertToDTO()
        {
            return null;
        }
    }

    public interface IEntityBase
    {
         //int IdTenant { get; set; }

    }
}
