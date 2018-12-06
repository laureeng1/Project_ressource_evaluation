using Admin.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVALUATION.WEB.Map
{
    public static class Mapper
    {

        public static BusinessRequest<R> ConvertRequestToDto<T, R>(this BusinessRequest<T> request) where T : DtoBase, new() where R : DtoBase, new()
        {
            List<R> newListSave = new List<R>();
            List<R> newListSearch = new List<R>();
            foreach (var item in request.ItemsToSave)
            {
                R currentItemToAdd = item.ConvertToDTO() as R;
                newListSave.Add(currentItemToAdd);
            }
            foreach (var item in request.ItemsToSearch)
            {
                R currentItemToAdd = item.ConvertToDTO() as R;
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
                CanFilterByTenant = request.CanFilterByTenant,
                IdCurrentTenant = request.IdCurrentTenant,
                ItemToSearch = request.ItemToSearch.ConvertToDTO() as R,
                ItemsToSave = newListSave,
                ItemsToSearch = newListSearch
            };
        }

    }

}