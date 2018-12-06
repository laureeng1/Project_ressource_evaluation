using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using EVALUATION.CORE.Dto;

namespace EVALUATION.CORE
{
    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IUser interface 
    /// </summary>
    public class IdentityMember : IUser<int>
    {
        /// <summary>
        /// Default constructor 
        /// </summary>
        public IdentityMember()
        {
            // Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Constructor that takes user name as argument
        /// </summary>
        /// <param name="userName"></param>
        public IdentityMember(string userName)
            : this()
        {
            UserName = userName;
        }
        /// <summary>
        /// Tenant ID
        /// </summary>
        public long TenantId { get; set; } 


        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; set; }
        //public long IdPrestataireMedical { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string UserName { get; set; }

        public long IdGarant { get; set; }

        public string Nom { get; set; }
        public DateTime CreationTime { get; set; }

        public string Prenoms { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        /// 
        public string Email { get; set; }

        /// <summary>
        ///     True if the email is confirmed, default is false
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        ///     The salted/hashed form of the user password
        /// </summary>
        public  string PasswordHash { get; set; }

        /// <summary>
        ///     A random value that should change whenever a users credentials have changed (password changed, login removed)
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        ///     PhoneNumber for the user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     True if the phone number is confirmed, default is false
        /// </summary>
        public bool IsPhoneNumberConfirmed { get; set; }

        /// <summary>
        ///     Is two factor enabled for the user
        /// </summary>
        public bool IsTwoFactorEnabled { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </summary>
        public DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout Begin, any time in the past is considered not locked out.
        /// </summary>
        public DateTime? DateDebutValidite { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout Begin, any time in the past is considered not locked out.
        /// </summary>
        public DateTime? DateFinValidite { get; set; }

        /// <summary>
        ///     Is lockout enabled for this user
        /// </summary>
        public bool IsLockoutEnabled { get; set; }

        /// <summary>
        ///     Used to record failures for the purposes of lockout
        /// </summary>
        public int AccessFailedCount { get; set; }

        public long CreatorUserId { get; set; }
        public long IdPersonne { get; set; }

      
    }
}
