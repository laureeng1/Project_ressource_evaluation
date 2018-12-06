  /*
         mainSelf.AbpClaims = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.IdAbpClaims = obj.IdAbpClaims;
            self.CodeParent = obj.CodeParent;
            self.CodeAbpClaims = obj.CodeAbpClaims;
            self.LibelleAbpClaims = obj.LibelleAbpClaims;
            self.Descriptions = obj.Descriptions;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpEditions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.DisplayName = obj.DisplayName;
            self.IsDeleted = obj.IsDeleted;
            self.DeleterUserId = obj.DeleterUserId;
            self.LastModifierUserId = obj.LastModifierUserId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpFeatures = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.Value = obj.Value;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.EditionId = obj.EditionId;
            self.Discriminator = obj.Discriminator;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpNotifications = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.NotificationName = obj.NotificationName;
            self.Data = obj.Data;
            self.DataTypeName = obj.DataTypeName;
            self.EntityTypeName = obj.EntityTypeName;
            self.EntityTypeAssemblyQualifiedName = obj.EntityTypeAssemblyQualifiedName;
            self.EntityId = obj.EntityId;
            self.Severity = obj.Severity;
            self.UserIds = obj.UserIds;
            self.ExcludedUserIds = obj.ExcludedUserIds;
            self.TenantIds = obj.TenantIds;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpNotificationSubscriptions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.NotificationName = obj.NotificationName;
            self.EntityTypeName = obj.EntityTypeName;
            self.EntityTypeAssemblyQualifiedName = obj.EntityTypeAssemblyQualifiedName;
            self.EntityId = obj.EntityId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpOrganizationUnits = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.ParentId = obj.ParentId;
            self.Code = obj.Code;
            self.DisplayName = obj.DisplayName;
            self.IsDeleted = obj.IsDeleted;
            self.LastModifierUserId = obj.LastModifierUserId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpPermissions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.IsGranted = obj.IsGranted;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.RoleId = obj.RoleId;
            self.UserId = obj.UserId;
            self.IdHabilitation = obj.IdHabilitation;
            self.Discriminator = obj.Discriminator;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpRoleClaims = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.RoleId = obj.RoleId;
            self.ClaimType = obj.ClaimType;
            self.ClaimValue = obj.ClaimValue;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpRoles = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.RoleId = obj.RoleId;
            self.DisplayName = obj.DisplayName;
            self.IsStatic = obj.IsStatic;
            self.IsDefault = obj.IsDefault;
            self.Name = obj.Name;
            self.IsDeleted = obj.IsDeleted;
            self.ModifiedBy = obj.ModifiedBy;
            self.CreatedBy = obj.CreatedBy;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
            self.TypeDeRole = obj.TypeDeRole;
        };

         mainSelf.AbpTenantNotifications = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.NotificationName = obj.NotificationName;
            self.Data = obj.Data;
            self.DataTypeName = obj.DataTypeName;
            self.EntityTypeName = obj.EntityTypeName;
            self.EntityTypeAssemblyQualifiedName = obj.EntityTypeAssemblyQualifiedName;
            self.EntityId = obj.EntityId;
            self.Severity = obj.Severity;
            self.CreationTime = obj.CreationTime;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpTenants = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.IdTenant = obj.IdTenant;
            self.Name = obj.Name;
            self.IsActive = obj.IsActive;
            self.TenancyName = obj.TenancyName;
            self.DomainName = obj.DomainName;
            self.ConnectionString = obj.ConnectionString;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
        };

         mainSelf.AbpUserAccounts = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.UserLinkId = obj.UserLinkId;
            self.UserName = obj.UserName;
            self.EmailAddress = obj.EmailAddress;
            self.LastLoginTime = obj.LastLoginTime;
            self.IsDeleted = obj.IsDeleted;
            self.DeleterUserId = obj.DeleterUserId;
            self.LastModifierUserId = obj.LastModifierUserId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.Entite = obj.Entite;
            self.IdEntite = obj.IdEntite;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUserClaims = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.ClaimType = obj.ClaimType;
            self.ClaimValue = obj.ClaimValue;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUserLoginAttempts = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.TenancyName = obj.TenancyName;
            self.UserId = obj.UserId;
            self.UserNameOrEmailAddress = obj.UserNameOrEmailAddress;
            self.ClientIpAddress = obj.ClientIpAddress;
            self.ClientName = obj.ClientName;
            self.BrowserInfo = obj.BrowserInfo;
            self.Result = obj.Result;
            self.CreationTime = obj.CreationTime;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUserLogins = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.IdUtilisateur = obj.IdUtilisateur;
            self.LoginProvider = obj.LoginProvider;
            self.ProviderKey = obj.ProviderKey;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUserNotifications = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.TenantNotificationId = obj.TenantNotificationId;
            self.State = obj.State;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUserRoles = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.RoleId = obj.RoleId;
            self.CreationTime = obj.CreationTime;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.AbpUsers = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.AuthenticationSource = obj.AuthenticationSource;
            self.Nom = obj.Nom;
            self.Prenoms = obj.Prenoms;
            self.Password = obj.Password;
            self.IsEmailConfirmed = obj.IsEmailConfirmed;
            self.EmailConfirmationCode = obj.EmailConfirmationCode;
            self.PasswordResetCode = obj.PasswordResetCode;
            self.DateDebutValidite = obj.DateDebutValidite;
            self.DateFinValidite = obj.DateFinValidite;
            self.LockoutEndDateUtc = obj.LockoutEndDateUtc;
            self.AccessFailedCount = obj.AccessFailedCount;
            self.IsLockoutEnabled = obj.IsLockoutEnabled;
            self.PhoneNumber = obj.PhoneNumber;
            self.IsPhoneNumberConfirmed = obj.IsPhoneNumberConfirmed;
            self.SecurityStamp = obj.SecurityStamp;
            self.IsTwoFactorEnabled = obj.IsTwoFactorEnabled;
            self.IsActive = obj.IsActive;
            self.UserName = obj.UserName;
            self.Email = obj.Email;
            self.LastLoginTime = obj.LastLoginTime;
            self.IdPersonne = obj.IdPersonne;
            self.IdGarant = obj.IdGarant;
            self.IsDeleted = obj.IsDeleted;
            self.DeleterUserId = obj.DeleterUserId;
            self.LastModifierUserId = obj.LastModifierUserId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.Permissions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.DisplayName = obj.DisplayName;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.Projects = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.Description = obj.Description;
            self.IdResponsible = obj.IdResponsible;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.ProjectTaskActions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.IdProjectTask = obj.IdProjectTask;
            self.Description = obj.Description;
            self.Overtime = obj.Overtime;
            self.OvertimeTime = obj.OvertimeTime;
            self.NewDeadline = obj.NewDeadline;
            self.ActionType = obj.ActionType;
            self.Duration = obj.Duration;
            self.DurationTime = obj.DurationTime;
            self.ActionDate = obj.ActionDate;
            self.DateOfDay = obj.DateOfDay;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.ProjectTasks = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.IdProject = obj.IdProject;
            self.IdCurrentCollaborator = obj.IdCurrentCollaborator;
            self.Sequence = obj.Sequence;
            self.Label = obj.Label;
            self.Priority = obj.Priority;
            self.TimePlanned = obj.TimePlanned;
            self.TimePlannedTime = obj.TimePlannedTime;
            self.TimeElapsed = obj.TimeElapsed;
            self.TimeElapsedVarchar = obj.TimeElapsedVarchar;
            self.TimeRemaining = obj.TimeRemaining;
            self.TimeRemainingVarchar = obj.TimeRemainingVarchar;
            self.DateStarted = obj.DateStarted;
            self.Deadline = obj.Deadline;
            self.Status = obj.Status;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.RolePermissions = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.RoleId = obj.RoleId;
            self.PermissionId = obj.PermissionId;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.Roles = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.Name = obj.Name;
            self.DisplayName = obj.DisplayName;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.UserRoles = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.UserId = obj.UserId;
            self.RoleId = obj.RoleId;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };

         mainSelf.vCollaboratorTasks = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.IdProject = obj.IdProject;
            self.IdCurrentCollaborator = obj.IdCurrentCollaborator;
            self.UserFullname = obj.UserFullname;
            self.Sequence = obj.Sequence;
            self.ProjectName = obj.ProjectName;
            self.Label = obj.Label;
            self.Priority = obj.Priority;
            self.Status = obj.Status;
            self.TimePlannedTime = obj.TimePlannedTime;
            self.TimeElapsedVarchar = obj.TimeElapsedVarchar;
            self.TimeRemainingVarchar = obj.TimeRemainingVarchar;
            self.DateStarted = obj.DateStarted;
            self.Deadline = obj.Deadline;
            self.Prolongation = obj.Prolongation;
            self.Bruit = obj.Bruit;
            self.Note = obj.Note;
            self.IsDeleted = obj.IsDeleted;
        };

         mainSelf.vProjectTasksWithCollaborator = function(obj) {

            var self = this;            
            
            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.IdProject = obj.IdProject;
            self.IdCurrentCollaborator = obj.IdCurrentCollaborator;
            self.UserFullname = obj.UserFullname;
            self.Sequence = obj.Sequence;
            self.ProjectName = obj.ProjectName;
            self.Label = obj.Label;
            self.Priority = obj.Priority;
            self.Status = obj.Status;
            self.TimePlannedTime = obj.TimePlannedTime;
            self.TimeElapsedVarchar = obj.TimeElapsedVarchar;
            self.TimeRemainingVarchar = obj.TimeRemainingVarchar;
            self.Deadline = obj.Deadline;
            self.Prolongation = obj.Prolongation;
            self.Bruit = obj.Bruit;
            self.Note = obj.Note;
            self.IsDeleted = obj.IsDeleted;
        };


*/
