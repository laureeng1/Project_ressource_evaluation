using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EVALUATION.DATA;
using Admin.Common.Configuration;
using EVALUATION.CORE;

namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces
    /// </summary>
    public class RoleStore<TRole> : IQueryableRoleStore<TRole,int>
        where TRole : IdentityRole
        {
            private RoleTable roleTable;
            private RoleClaimsTable _roleClaimsTable;

        public DbManager Database { get; private set; }
        public IQueryable<TRole> Roles
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Default constructor that initializes a new database
        /// instance using the Default Connection string
        /// </summary>
        public RoleStore()
        {
            new RoleStore<TRole>(new DbManager(WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString));
        }

        /// <summary>
        /// Constructor that takes a dbmanager as argument 
        /// </summary>
        /// <param name="database"></param>
        public RoleStore(DbManager database)
        {
            Database = database;
            roleTable = new RoleTable(database);
            _roleClaimsTable=new RoleClaimsTable(database);
        }

        public async Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            await roleTable.Insert(role);

            // return Task.FromResult<object>(null);
        }

        public async Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            await roleTable.Delete(role.Id);

            //return Task.FromResult<Object>(null);
        }

        public Task<TRole> FindByIdAsync(int roleId)
        {
            TRole result = roleTable.GetRoleById(roleId) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            TRole result = roleTable.GetRoleByName(roleName) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public async Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            await roleTable.Update(role);

            //return Task.FromResult<Object>(null);
        }

        /// <summary>
        /// Returns all claims for a given role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<IList<Claim>> GetClaimsAsync(TRole role)
        {
            ClaimsIdentity identity = await _roleClaimsTable.FindByRoleId(role.Id);
            List<Claim> list = new List<Claim>();
            foreach (var claim in identity.Claims)
                list.Add(claim);
            return list;
        }

            /// <summary>
            /// Removes a claim from a role
            /// </summary>
            /// <param name="role">User to have claim removed</param>
            /// <param name="claim">Claim to be removed</param>
            /// <returns></returns>
            public async Task RemoveClaimAsync(TRole role, Claim claim)
            {
                if (role == null)
                {
                    throw new ArgumentNullException("role");
                }
                if (claim == null)
                {
                    throw new ArgumentNullException("claim");
                }
                await _roleClaimsTable.Delete(role, claim);
            }

        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
                Database = null;
            }
        }

    }
}
