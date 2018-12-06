using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Common.Domain;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;

namespace EVALUATION.Web.Models
{
    public class AbpClaimsViewModel : DtoBase
    {
        public long IdAbpClaims { get; set; }
        public string CodeAbpClaims { get; set; }
        public string CodeParent { get; set; }
        public string LibelleAbpClaims { get; set; }
        public string Descriptions { get; set; }
        public override object ConvertToDTO()
        {
            var dto = new AbpClaimsDto();
            if (this.IdAbpClaims != 0)
                dto.IdAbpClaims = this.IdAbpClaims;

            if (!string.IsNullOrEmpty(this.CodeAbpClaims))
                dto.CodeAbpClaims = this.CodeAbpClaims;

            if (!string.IsNullOrEmpty(this.CodeParent))
                dto.CodeParent = this.CodeParent;

            if (!string.IsNullOrEmpty(this.LibelleAbpClaims))
                dto.LibelleAbpClaims = this.LibelleAbpClaims;

            if (!string.IsNullOrEmpty(this.Descriptions))
                dto.Descriptions = this.Descriptions;
            return dto;
        }
    }
    public class AbpPermissionsViewModel : DtoBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public int? RoleId { get; set; }
        public long? UserId { get; set; }
        public string Discriminator { get; set; }
        
        public override object ConvertToDTO()
        {
            var dto = new AbpPermissionsDto();
            if (this.Id != 0)
                dto.Id = this.Id;
          

            if (!string.IsNullOrEmpty(this.Name))
                dto.Name = this.Name;

            if (!string.IsNullOrEmpty(this.Discriminator))
                dto.Discriminator = this.Discriminator;

            
            return dto;
        }
    }
    public class RoleViewModel : DtoBase
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string TypeDeRole { get; set; }

        public string DisplayName { get; set; }
     //   public List<AbpPermissionsViewModel> AbpPermissionsViewModels { get; set; }

        public bool? Isdeleted { get; set; }

        public List<RoleClaimsViewModel> RoleClaimsViewModels { get; set; }

     
        public override object ConvertToDTO()
        {
            var dto = new AbpRolesDto();
        
            if (this.RoleId != 0)
                dto.RoleId = this.RoleId;

            if (!string.IsNullOrEmpty(this.Name))
                dto.Name = this.Name;
            if (!string.IsNullOrEmpty(this.DisplayName))
                dto.DisplayName = this.DisplayName;
            if (!string.IsNullOrEmpty(this.TypeDeRole))
                dto.TypeDeRole = this.TypeDeRole;
            if (this.RoleClaimsViewModels != null)
            {
                dto.AbpRoleClaims = new List<AbpRoleClaimsDto>();
                foreach (var item in this.RoleClaimsViewModels)
                {
                    dto.AbpRoleClaims.Add((AbpRoleClaimsDto)item.ConvertToDTO());
                }
            }

            if (this.Isdeleted != null)
                dto.IsDeleted = this.Isdeleted ?? false;

           
            return dto;
        }
    }


    public class UserViewModel : DtoBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public bool? Isdeleted { get; set; }

        public List<UserClaimsViewModel> UserClaimsViewModel { get; set; }
        public override object ConvertToDTO()
        {
            var dto = new AbpUsersDto();

            if (this.Id != 0)
                dto.Id = this.Id;


          /*  if (this.UserId != 0)
                dto.Id = this.UserId;*/

            if (!string.IsNullOrEmpty(this.Name))
                dto.UserName = this.Name;
            if (!string.IsNullOrEmpty(this.DisplayName))
    
            if (this.UserClaimsViewModel != null)
            {
                dto.AbpUserClaims = new List<AbpUserClaimsDto>();
                foreach (var item in this.UserClaimsViewModel)
                {
                    dto.AbpUserClaims.Add((AbpUserClaimsDto)item.ConvertToDTO());
                }
            }

            if (this.Isdeleted != null)
                dto.IsDeleted = this.Isdeleted ?? false;
            return dto;
        }
    }
  
 
    public class AbpUserRolesViewModel:DtoBase
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public override object ConvertToDTO()
        {
            var dto = new AbpUserRolesDto();
            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.UserId != 0)
                dto.UserId = this.UserId;

            if (this.RoleId != 0)
                dto.RoleId = this.RoleId;

            return dto;
        }
    }

 

 


  


 

 
    public class UtilisateurViewModel : DtoBase
    {
        public long Id { get; set; }
        public long IdPersonne { get; set; }
        public long IdGarant { get; set; }
        public long IdPrestataireMedical { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prenoms")]
        public string Prenoms { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsPhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime? DateDebutValidite { get; set; }

        public DateTime? DateFinValidite { get; set; }
        public bool? IsReinitialiserAccessFailed { get; set; }
        public bool? IsLockoutEnabled { get; set; }
        public List<AbpUserRolesViewModel> ListAbpUserRolesViewModels { get; set; }
        public List<UserClaimsViewModel> UserClaimsViewModels { get; set; }
        public List<UserGestionnaireTenantsViewModel> ListUserGestionnaireTenantsViewModels { get; set; }

        public override object ConvertToDTO()
        {
            var dto = new AbpUsersDto();
            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.IsReinitialiserAccessFailed != null)
                dto.IsReinitialiserAccessFailed = this.IsReinitialiserAccessFailed??false;


            if (this.IdPrestataireMedical!=0)
            {
                //dto.PrestataireId = this.IdPrestataireMedical;
            }
            if (this.IdGarant!=0)
            {
                dto.IdGarant = this.IdGarant;
            }
            if (this.IsLockoutEnabled != null)
                dto.IsLockoutEnabled = this.IsLockoutEnabled;


            if (this.DateDebutValidite != null)
                dto.DateDebutValidite = this.DateDebutValidite;

            if (this.DateFinValidite != null)
                dto.DateFinValidite = this.DateFinValidite;

            if (!string.IsNullOrEmpty(this.Nom))
                dto.Nom = this.Nom;

            if (!string.IsNullOrEmpty(this.Prenoms))
                dto.Prenoms = this.Prenoms;

            if (!string.IsNullOrEmpty(this.Password))
                dto.Password = this.Password;
            if (this.IsEmailConfirmed != null)
            {
                dto.IsEmailConfirmed = (bool)this.IsEmailConfirmed;
            }
            if (this.IsPhoneNumberConfirmed != null)
            {
                dto.IsPhoneNumberConfirmed = (bool)this.IsPhoneNumberConfirmed;
            }
               
            if (!string.IsNullOrEmpty(this.PhoneNumber))
                dto.PhoneNumber = this.PhoneNumber;
                      
            if (!string.IsNullOrEmpty(this.UserName))
                dto.UserName = this.UserName;

            if (!string.IsNullOrEmpty(this.Email))
                dto.Email = this.Email;

            if (this.ListAbpUserRolesViewModels != null)
            {
                dto.AbpUserRoles = new List<AbpUserRolesDto>();
                foreach (var item in this.ListAbpUserRolesViewModels)
                {
                    dto.AbpUserRoles.Add((AbpUserRolesDto)item.ConvertToDTO());
                }
            }
            if (this.UserClaimsViewModels != null)
            {
                dto.AbpUserClaims = new List<AbpUserClaimsDto>();
                foreach (var item in this.UserClaimsViewModels)
                {
                    dto.AbpUserClaims.Add((AbpUserClaimsDto)item.ConvertToDTO());
                }
            }
            if (this.ListUserGestionnaireTenantsViewModels != null)
            {
                dto.AbpUserAccounts = new List<AbpUserAccountsDto>();
                foreach (var item in this.ListUserGestionnaireTenantsViewModels)
                {
                    dto.AbpUserAccounts.Add((AbpUserAccountsDto)item.ConvertToDTO());
                }
            }

            return dto;
        }
    }

    public class UtilisateurGarantAdminViewModel : DtoBase
    {
        public long Id { get; set; }
        public long IdGarant { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prenoms")]
        public string Prenoms { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsPhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime? DateDebutValidite { get; set; }

        public DateTime? DateFinValidite { get; set; }

        public bool? IsLockoutEnabled { get; set; }

        public List<AbpUserRolesViewModel> ListAbpUserRolesViewModels { get; set; }
        public List<UserClaimsViewModel> UserClaimsViewModels { get; set; }
       
        public override object ConvertToDTO()
        {
            var dto = new AbpUsersDto();
            if (this.Id != 0)
                dto.Id = this.Id;
            if (this.IdGarant != 0)
            {
                dto.IdGarant = this.IdGarant;
            }

            if (this.IsLockoutEnabled != null)
                dto.IsLockoutEnabled = this.IsLockoutEnabled;


            if (this.DateDebutValidite != null)
                dto.DateDebutValidite = this.DateDebutValidite;

            if (this.DateFinValidite != null)
                dto.DateFinValidite = this.DateFinValidite;

            if (!string.IsNullOrEmpty(this.Nom))
                dto.Nom = this.Nom;

            if (!string.IsNullOrEmpty(this.Prenoms))
                dto.Prenoms = this.Prenoms;

            if (!string.IsNullOrEmpty(this.Password))
                dto.Password = this.Password;
            if (this.IsEmailConfirmed != null)
            {
                dto.IsEmailConfirmed = (bool)this.IsEmailConfirmed;
            }
            if (this.IsPhoneNumberConfirmed != null)
            {
                dto.IsPhoneNumberConfirmed = (bool)this.IsPhoneNumberConfirmed;
            }

            if (!string.IsNullOrEmpty(this.PhoneNumber))
                dto.PhoneNumber = this.PhoneNumber;

            if (!string.IsNullOrEmpty(this.UserName))
                dto.UserName = this.UserName;

            if (!string.IsNullOrEmpty(this.Email))
                dto.Email = this.Email;

            if (this.ListAbpUserRolesViewModels != null)
            {
                dto.AbpUserRoles = new List<AbpUserRolesDto>();
                foreach (var item in this.ListAbpUserRolesViewModels)
                {
                    dto.AbpUserRoles.Add((AbpUserRolesDto)item.ConvertToDTO());
                }
            }
            if (this.UserClaimsViewModels != null)
            {
                dto.AbpUserClaims = new List<AbpUserClaimsDto>();
                foreach (var item in this.UserClaimsViewModels)
                {
                    dto.AbpUserClaims.Add((AbpUserClaimsDto)item.ConvertToDTO());
                }
            }

            return dto;
        }
    }

    public class UserGestionnaireTenantsViewModel:DtoBase
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public long IdGarant { get; set; }

        public override object ConvertToDTO()
        {
            var dto = new AbpUserAccountsDto();
            if (this.Id != 0)
                dto.Id = this.Id;
            if (this.UserId != 0)            
                dto.UserId = this.UserId;
            if (this.IdGarant != 0)            
                dto.IdTenant = this.IdGarant;
            

            if (!string.IsNullOrEmpty(this.UserName))
                dto.UserName = this.UserName;

            if (!string.IsNullOrEmpty(this.EmailAdress))
                dto.EmailAddress = this.EmailAdress;

            return dto;
        }
    }

    public class RoleClaimsViewModel:DtoBase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public string CodeAbpClaims { get; set; }
        public override object ConvertToDTO()
        {
            var dto = new AbpRoleClaimsDto();
            if (this.Id != 0)
                dto.Id = this.Id;
            if (this.RoleId != 0)
                dto.RoleId = this.RoleId;
            if (!string.IsNullOrEmpty(this.ClaimType))
                dto.ClaimType = this.ClaimType;

          

            if (!string.IsNullOrEmpty(this.ClaimValue))
                dto.ClaimValue = this.CodeAbpClaims;
            return dto;
        }
    }
    public class UserClaimsViewModel : DtoBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public string CodeAbpClaims { get; set; }
        public override object ConvertToDTO()
        {
            var dto = new AbpUserClaimsDto();
            if (this.Id != 0)
                dto.Id = this.Id;
            if (this.UserId != 0)
                dto.UserId = this.UserId;
            if (!string.IsNullOrEmpty(this.ClaimType))
                dto.ClaimType = this.ClaimType;

           

            if (!string.IsNullOrEmpty(this.ClaimValue))
                dto.ClaimValue = this.CodeAbpClaims;
            return dto;
        }
    }

  

    //public class ViewPoolMedicalViewModel : DtoBase
    //{
    //    public int IdPersonne { get; set; }
    //    public int IdPersonnePhysique { get; set; }
    //    public string Email { get; set; }
    //    public string Nom { get; set; }
    //    public string Prenoms { get; set; }
    //    public string Civilite { get; set; }
    //    public string Sexe { get; set; }
    //    public string Photo { get; set; }
    //    public string Matricule { get; set; }
    //    public string Grade { get; set; }

    //    public override object ConvertToDTO()
    //    {
    //        var dto = new ViewPoolMedicalDto(); ;
    //        if (this.IdPersonne != 0)
    //            dto.IdPersonne = this.IdPersonne;
    //        if (this.IdPersonnePhysique != 0)
    //            dto.IdPersonnePhysique = this.IdPersonnePhysique;

    //        if (!string.IsNullOrEmpty(this.Email))
    //            dto.Email = this.Email;

    //        if (!string.IsNullOrEmpty(this.Nom))
    //            dto.Nom = this.Nom;

    //        if (!string.IsNullOrEmpty(this.Prenoms))
    //            dto.Prenoms = this.Prenoms;

    //        if (!string.IsNullOrEmpty(this.Civilite))
    //            dto.Civilite = this.Civilite;
    //        if (!string.IsNullOrEmpty(this.Sexe))
    //            dto.Sexe = this.Sexe;
    //        if (!string.IsNullOrEmpty(this.Photo))
    //            dto.Photo = this.Photo;
    //        if (!string.IsNullOrEmpty(this.Matricule))
    //            dto.Matricule = this.Matricule;
    //        if (!string.IsNullOrEmpty(this.Grade))
    //            dto.Grade = this.Grade;


    //        return dto;
    //    }

    //}

 


  

  


  

}