using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Admin.Common.Domain;
using EVALUATION.CORE.Dto;
using EVALUATION.SERVICE.Manager;
using Microsoft.Ajax.Utilities;

namespace EVALUATION.WEB.Models
{
    public class ProjectsViewModels : DtoBase
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long IdResponsible { get; set; }

        public bool? IsDeleted { get; set; }


        public override object ConvertToDTO()
        {
            ProjectsDto dto = new ProjectsDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (!string.IsNullOrEmpty(this.Name))
                dto.Name = this.Name;

            if (!string.IsNullOrEmpty(this.Description))
                dto.Description = this.Description;

            if (this.IdResponsible != 0)
                dto.IdResponsible = this.IdResponsible;

            if (this.IdResponsible != 0)
                dto.IdResponsible = this.IdResponsible;

            //dto.IsDeleted = this.IsDeleted;

            return dto;
        }
    }

    public class ProjectTasksViewModels : DtoBase
    {
        public long Id { get; set; }

        public long IdProject { get; set; }

        public long IdCurrentCollaborator { get; set; }

        public string Sequence { get; set; }

        public string Label { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public TimeSpan TimePlannedTime { get; set; }

        public string TimeElapsedVarchar { get; set; }

        public string TimeRemainingVarchar { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDeleted { get; set; }

        //public DateTime DateCreation { get; set; }

        //public DateTime DateMajTime { get; set; }

        //public long CreatedBy { get; set; }

        //public long ModifiedBy { get; set; }

        //public string DataKey { get; set; }

        //public int IdTenant { get; set; }

        //public List<AbpUserProjectTasksViewModels> AbpUserProjectTasks { get; set; }

        public override object ConvertToDTO()
        {
            ProjectTasksDto dto = new ProjectTasksDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.IdProject != 0)
                dto.IdProject = this.IdProject;

            if (this.IdCurrentCollaborator != 0)
                dto.IdCurrentCollaborator = this.IdCurrentCollaborator;

            if (!string.IsNullOrEmpty(this.Sequence))
                dto.Sequence = this.Sequence;

            if (!string.IsNullOrEmpty(this.Label))
                dto.Label = this.Label;

            if (!string.IsNullOrEmpty(this.Priority))
                dto.Priority = this.Priority;

            if (!string.IsNullOrEmpty(this.Status))
                dto.Status = this.Status;

            if (this.TimePlannedTime != default(TimeSpan))
                dto.TimePlannedTime = this.TimePlannedTime;

            if (!string.IsNullOrEmpty(this.TimeElapsedVarchar))
                dto.TimeElapsedVarchar = this.TimeElapsedVarchar;

            if (!string.IsNullOrEmpty(this.TimeRemainingVarchar))
                dto.TimeRemainingVarchar = this.TimeRemainingVarchar;

            if (this.Deadline != default(DateTime))
                dto.Deadline = this.Deadline;

            //if (this.IsDeleted != 0 && !(this.Status))
            dto.IsDeleted = this.IsDeleted;


            return dto;
        }
    }

    public class vProjectTasksWithCollaboratorViewModels : DtoBase
    {
        public long Id { get; set; }

        public long IdProject { get; set; }

        public long IdCurrentCollaborator { get; set; }

        public string Sequence { get; set; }

        public string Label { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public TimeSpan TimePlannedTime { get; set; }

        public string TimeElapsedVarchar { get; set; }

        public string TimeRemainingVarchar { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDeleted { get; set; }

        //public DateTime DateCreation { get; set; }

        //public DateTime DateMajTime { get; set; }

        //public long CreatedBy { get; set; }

        //public long ModifiedBy { get; set; }

        //public string DataKey { get; set; }

        //public int IdTenant { get; set; }

        public string UserFullname { get; set; }

        public override object ConvertToDTO()
        {
            vProjectTasksWithCollaboratorDto dto = new vProjectTasksWithCollaboratorDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.IdProject != 0)
                dto.IdProject = this.IdProject;

            if (this.IdCurrentCollaborator != 0)
                dto.IdCurrentCollaborator = this.IdCurrentCollaborator;

            if (!string.IsNullOrEmpty(this.Sequence))
                dto.Sequence = this.Sequence;

            if (!string.IsNullOrEmpty(this.Label))
                dto.Label = this.Label;

            if (!string.IsNullOrEmpty(this.Priority))
                dto.Priority = this.Priority;

            if (!string.IsNullOrEmpty(this.Status))
                dto.Status = this.Status;

            if (this.TimePlannedTime != default(TimeSpan))
                dto.TimePlannedTime = this.TimePlannedTime;

            if (!string.IsNullOrEmpty(this.TimeElapsedVarchar))
                dto.TimeElapsedVarchar = this.TimeElapsedVarchar;

            if (!string.IsNullOrEmpty(this.TimeRemainingVarchar))
                dto.TimeRemainingVarchar = this.TimeRemainingVarchar;

            if (this.Deadline != default(DateTime))
                dto.Deadline = this.Deadline;

            if (!string.IsNullOrEmpty(this.UserFullname))
                dto.UserFullname = this.UserFullname;

            return dto;
        }

    }

    public class vCollaboratorTasksViewModels : DtoBase
    {
        public long Id { get; set; }

        public long IdProject { get; set; }

        public long IdCurrentCollaborator { get; set; }

        public string Sequence { get; set; }

        public string ProjectName { get; set; }

        public string Label { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public TimeSpan TimePlannedTime { get; set; }

        public string TimeElapsedVarchar { get; set; }

        public string TimeRemainingVarchar { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime DateStarted { get; set; }

        public bool IsDeleted { get; set; }

        //public DateTime DateCreation { get; set; }

        //public DateTime DateMajTime { get; set; }

        //public long CreatedBy { get; set; }

        //public long ModifiedBy { get; set; }

        //public string DataKey { get; set; }

        //public int IdTenant { get; set; }

        public string UserFullname { get; set; }

        public override object ConvertToDTO()
        {
            vCollaboratorTasksDto dto = new vCollaboratorTasksDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.IdProject != 0)
                dto.IdProject = this.IdProject;

            if (this.IdCurrentCollaborator != 0)
                dto.IdCurrentCollaborator = this.IdCurrentCollaborator;

            if (!string.IsNullOrEmpty(this.Sequence))
                dto.Sequence = this.Sequence;

            if (!string.IsNullOrEmpty(this.ProjectName))
                dto.ProjectName = this.ProjectName;

            if (!string.IsNullOrEmpty(this.Label))
                dto.Label = this.Label;

            if (!string.IsNullOrEmpty(this.Priority))
                dto.Priority = this.Priority;

            if (!string.IsNullOrEmpty(this.Status))
                dto.Status = this.Status;

            if (this.TimePlannedTime != default(TimeSpan))
                dto.TimePlannedTime = this.TimePlannedTime;

            if (!string.IsNullOrEmpty(this.TimeElapsedVarchar))
                dto.TimeElapsedVarchar = this.TimeElapsedVarchar;

            if (!string.IsNullOrEmpty(this.TimeRemainingVarchar))
                dto.TimeRemainingVarchar = this.TimeRemainingVarchar;

            if (this.Deadline != default(DateTime))
                dto.Deadline = this.Deadline;

            if (this.DateStarted != default(DateTime))
                dto.DateStarted = this.DateStarted;

            if (!string.IsNullOrEmpty(this.UserFullname))
                dto.UserFullname = this.UserFullname;

            return dto;
        }

    }

    public class ProjectTaskActionsViewModels : DtoBase
    {
        public long Id { get; set; }

        public long IdProjectTask { get; set; }

        public string Description { get; set; }

        //public DateTime DatetimeStart { get; set; }

        //public DateTime DatetimeEnd { get; set; }

        public TimeSpan OvertimeTime { get; set; }

        public TimeSpan DurationTime { get; set; }

        public DateTime DateOfDay { get; set; }

        public DateTime NewDeadline { get; set; }

        public string ActionType { get; set; }

        public override object ConvertToDTO()
        {
            ProjectTaskActionsDto dto = new ProjectTaskActionsDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.IdProjectTask != 0)
                dto.IdProjectTask = this.IdProjectTask;

            if (!string.IsNullOrEmpty(this.Description))
                dto.Description = this.Description;

            if (this.OvertimeTime != default(TimeSpan))
                dto.OvertimeTime = this.OvertimeTime;

            if (this.DurationTime != default(TimeSpan))
                dto.DurationTime = this.DurationTime;

            if (this.DateOfDay != default(DateTime))
                dto.DateOfDay = this.DateOfDay;

            if (this.NewDeadline != default(DateTime))
                dto.NewDeadline = this.NewDeadline;

            if (!string.IsNullOrEmpty(this.ActionType))
                dto.ActionType = this.ActionType;

            return dto;
        }
    }

    public class AbpUsersViewModels : DtoBase
    {

        public long Id { get; set; }
        // public int? IdRole { get; set; }

        public string AuthenticationSource { get; set; }
        public string Nom { get; set; }
        public string Prenoms { get; set; }

        public string Password { get; set; }

        //public bool IsEmailConfirmed { get; set; }

        //public string EmailConfirmationCode { get; set; }
        //public string PasswordResetCode { get; set; }
        //public DateTime DateDebutValidite { get; set; }
        //public DateTime DateFinValidite { get; set; }
        //public DateTime LockoutEndDateUtc { get; set; }
        //public int AccessFailedCount { get; set; }
        //public bool IsLockoutEnabled { get; set; }
        public string PhoneNumber { get; set; }
        //public bool IsPhoneNumberConfirmed { get; set; }
        //public string SecurityStamp { get; set; }
        //public bool IsTwoFactorEnabled { get; set; }
        //public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        // public DateTime LastLoginTime { get; set; }
        //public long IdPersonne { get; set; }
        //public long IdGarant { get; set; }
        //public bool IsDeleted { get; set; }
        //public long DeleterUserId { get; set; }
        //public long LastModifierUserId { get; set; }
        //public DateTime CreationTime { get; set; }
        //public long CreatorUserId { get; set; }

        //AbpPermissions { get; set; }
        //AbpRoles_CreatedBy { get; set; }
        //AbpRoles_ModifiedBy { get; set; }
        //AbpUserClaims { get; set; }
        //AbpUserProjectTasks { get; set; }
        //AbpUserRoles { get; set; }
        //AbpUsers_CreatorUserId1 { get; set; }
        //AbpUsers_CreatorUserId { get; set; }
        //AbpUsers_DeleterUserId1 { get; set; }
        //AbpUsers_DeleterUserId { get; set; }
        //AbpUsers_LastModifierUserId1 { get; set; }
        //AbpUsers_LastModifierUserId { get; set; }
        //Projects { get; set; }
        //ProjectTasks { get; set; }

        //public DateTime DateCreation { get; set; }

        //public DateTime DateMajTime { get; set; }

        //public long CreatedBy { get; set; }

        //public long ModifiedBy { get; set; }

        //public string DataKey { get; set; }

        //public int IdTenant { get; set; }

        public override object ConvertToDTO()
        {
            AbpUsersDto dto = new AbpUsersDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            //if (this.IdRole != 0)
            //    dto.IdRole = this.IdRole;

            if (!string.IsNullOrEmpty(this.AuthenticationSource))
                dto.AuthenticationSource = this.AuthenticationSource;

            if (!string.IsNullOrEmpty(this.Nom))
                dto.Nom = this.Nom;

            if (!string.IsNullOrEmpty(this.Prenoms))
                dto.Prenoms = this.Prenoms;

            if (!string.IsNullOrEmpty(this.Password))
                dto.Password = this.Password;


            if (!string.IsNullOrEmpty(this.PhoneNumber))
                dto.PhoneNumber = this.PhoneNumber;


            if (!string.IsNullOrEmpty(this.UserName))
                dto.UserName = this.UserName;

            if (!string.IsNullOrEmpty(this.Email))
                dto.Email = this.Email;

            return dto;
        }
    }

    public class RolePermissionsViewModels : DtoBase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public override object ConvertToDTO()
        {
            RolePermissionsDto dto = new RolePermissionsDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.RoleId != 0)
                dto.RoleId = this.RoleId;

            if (this.PermissionId != 0)
                dto.PermissionId = this.PermissionId;

            return dto;
        }
    }

    public class RolesViewModels : DtoBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public override object ConvertToDTO()
        {
            RolesDto dto = new RolesDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (!string.IsNullOrEmpty(this.Name))
                dto.Name = this.Name;

            if (!string.IsNullOrEmpty(this.DisplayName))
                dto.DisplayName = this.DisplayName;

            return dto;
        }

    }

    public class PermissionsViewModels : DtoBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }


        public override object ConvertToDTO()
        {
            PermissionsDto dto = new PermissionsDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (!string.IsNullOrEmpty(this.Name))
                dto.Name = this.Name;

            if (!string.IsNullOrEmpty(this.DisplayName))
                dto.DisplayName = this.DisplayName;

            return dto;
        }

    }

    public class UserRolesViewModels : DtoBase
    {
        public long Id { get; set; }

        public int RoleId { get; set; }

        public long UserId { get; set; }


        public override object ConvertToDTO()
        {
            UserRolesDto dto = new UserRolesDto();

            if (this.Id != 0)
                dto.Id = this.Id;

            if (this.RoleId != 0)
                dto.RoleId = this.RoleId;

            if (this.UserId != 0)
                dto.UserId = this.UserId;


            return dto;
        }

    }

}