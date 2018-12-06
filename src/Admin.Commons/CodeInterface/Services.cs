  /*

app.factory("adminGeneratedCtrlService", ["$resource", "urlSw", function ($resource, urlSw) {
        var url = urlSw.getUrl(urlSw.UrlAdminBase, ":service", ":method");

        return $resource(url, {}, {

         // AbpClaims
         GetAbpClaimsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpClaimsById", id:"@id"} },
         DeleteAbpClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpClaims" } },            

         GetAbpClaimsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpClaimsByCriteria" } },
         SaveAbpClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpClaims" } },            

         // AbpEditions
         GetAbpEditionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpEditionsById", id:"@id"} },
         DeleteAbpEditions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpEditions" } },            

         GetAbpEditionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpEditionsByCriteria" } },
         SaveAbpEditions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpEditions" } },            

         // AbpFeatures
         GetAbpFeaturesById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpFeaturesById", id:"@id"} },
         DeleteAbpFeatures: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpFeatures" } },            

         GetAbpFeaturesByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpFeaturesByCriteria" } },
         SaveAbpFeatures: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpFeatures" } },            

         // AbpNotifications
         GetAbpNotificationsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpNotificationsById", id:"@id"} },
         DeleteAbpNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpNotifications" } },            

         GetAbpNotificationsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpNotificationsByCriteria" } },
         SaveAbpNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpNotifications" } },            

         // AbpNotificationSubscriptions
         GetAbpNotificationSubscriptionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpNotificationSubscriptionsById", id:"@id"} },
         DeleteAbpNotificationSubscriptions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpNotificationSubscriptions" } },            

         GetAbpNotificationSubscriptionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpNotificationSubscriptionsByCriteria" } },
         SaveAbpNotificationSubscriptions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpNotificationSubscriptions" } },            

         // AbpOrganizationUnits
         GetAbpOrganizationUnitsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpOrganizationUnitsById", id:"@id"} },
         DeleteAbpOrganizationUnits: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpOrganizationUnits" } },            

         GetAbpOrganizationUnitsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpOrganizationUnitsByCriteria" } },
         SaveAbpOrganizationUnits: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpOrganizationUnits" } },            

         // AbpPermissions
         GetAbpPermissionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpPermissionsById", id:"@id"} },
         DeleteAbpPermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpPermissions" } },            

         GetAbpPermissionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpPermissionsByCriteria" } },
         SaveAbpPermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpPermissions" } },            

         // AbpRoleClaims
         GetAbpRoleClaimsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpRoleClaimsById", id:"@id"} },
         DeleteAbpRoleClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpRoleClaims" } },            

         GetAbpRoleClaimsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpRoleClaimsByCriteria" } },
         SaveAbpRoleClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpRoleClaims" } },            

         // AbpRoles
         GetAbpRolesById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpRolesById", id:"@id"} },
         DeleteAbpRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpRoles" } },            

         GetAbpRolesByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpRolesByCriteria" } },
         SaveAbpRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpRoles" } },            

         // AbpTenantNotifications
         GetAbpTenantNotificationsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpTenantNotificationsById", id:"@id"} },
         DeleteAbpTenantNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpTenantNotifications" } },            

         GetAbpTenantNotificationsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpTenantNotificationsByCriteria" } },
         SaveAbpTenantNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpTenantNotifications" } },            

         // AbpTenants
         GetAbpTenantsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpTenantsById", id:"@id"} },
         DeleteAbpTenants: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpTenants" } },            

         GetAbpTenantsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpTenantsByCriteria" } },
         SaveAbpTenants: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpTenants" } },            

         // AbpUserAccounts
         GetAbpUserAccountsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserAccountsById", id:"@id"} },
         DeleteAbpUserAccounts: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserAccounts" } },            

         GetAbpUserAccountsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserAccountsByCriteria" } },
         SaveAbpUserAccounts: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserAccounts" } },            

         // AbpUserClaims
         GetAbpUserClaimsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserClaimsById", id:"@id"} },
         DeleteAbpUserClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserClaims" } },            

         GetAbpUserClaimsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserClaimsByCriteria" } },
         SaveAbpUserClaims: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserClaims" } },            

         // AbpUserLoginAttempts
         GetAbpUserLoginAttemptsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserLoginAttemptsById", id:"@id"} },
         DeleteAbpUserLoginAttempts: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserLoginAttempts" } },            

         GetAbpUserLoginAttemptsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserLoginAttemptsByCriteria" } },
         SaveAbpUserLoginAttempts: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserLoginAttempts" } },            

         // AbpUserLogins
         GetAbpUserLoginsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserLoginsById", id:"@id"} },
         DeleteAbpUserLogins: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserLogins" } },            

         GetAbpUserLoginsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserLoginsByCriteria" } },
         SaveAbpUserLogins: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserLogins" } },            

         // AbpUserNotifications
         GetAbpUserNotificationsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserNotificationsById", id:"@id"} },
         DeleteAbpUserNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserNotifications" } },            

         GetAbpUserNotificationsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserNotificationsByCriteria" } },
         SaveAbpUserNotifications: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserNotifications" } },            

         // AbpUserRoles
         GetAbpUserRolesById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserRolesById", id:"@id"} },
         DeleteAbpUserRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUserRoles" } },            

         GetAbpUserRolesByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUserRolesByCriteria" } },
         SaveAbpUserRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUserRoles" } },            

         // AbpUsers
         GetAbpUsersById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetAbpUsersById", id:"@id"} },
         DeleteAbpUsers: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteAbpUsers" } },            

         GetAbpUsersByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetAbpUsersByCriteria" } },
         SaveAbpUsers: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveAbpUsers" } },            

         // Permissions
         GetPermissionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetPermissionsById", id:"@id"} },
         DeletePermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeletePermissions" } },            

         GetPermissionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetPermissionsByCriteria" } },
         SavePermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SavePermissions" } },            

         // Projects
         GetProjectsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetProjectsById", id:"@id"} },
         DeleteProjects: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteProjects" } },            

         GetProjectsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetProjectsByCriteria" } },
         SaveProjects: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveProjects" } },            

         // ProjectTaskActions
         GetProjectTaskActionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetProjectTaskActionsById", id:"@id"} },
         DeleteProjectTaskActions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteProjectTaskActions" } },            

         GetProjectTaskActionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetProjectTaskActionsByCriteria" } },
         SaveProjectTaskActions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveProjectTaskActions" } },            

         // ProjectTasks
         GetProjectTasksById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetProjectTasksById", id:"@id"} },
         DeleteProjectTasks: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteProjectTasks" } },            

         GetProjectTasksByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetProjectTasksByCriteria" } },
         SaveProjectTasks: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveProjectTasks" } },            

         // RolePermissions
         GetRolePermissionsById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetRolePermissionsById", id:"@id"} },
         DeleteRolePermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteRolePermissions" } },            

         GetRolePermissionsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetRolePermissionsByCriteria" } },
         SaveRolePermissions: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveRolePermissions" } },            

         // Roles
         GetRolesById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetRolesById", id:"@id"} },
         DeleteRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteRoles" } },            

         GetRolesByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetRolesByCriteria" } },
         SaveRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveRoles" } },            

         // UserRoles
         GetUserRolesById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetUserRolesById", id:"@id"} },
         DeleteUserRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeleteUserRoles" } },            

         GetUserRolesByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetUserRolesByCriteria" } },
         SaveUserRoles: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SaveUserRoles" } },            

         // vCollaboratorTasks
         GetvCollaboratorTasksById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetvCollaboratorTasksById", id:"@id"} },
         DeletevCollaboratorTasks: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeletevCollaboratorTasks" } },            

         GetvCollaboratorTasksByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetvCollaboratorTasksByCriteria" } },
         SavevCollaboratorTasks: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SavevCollaboratorTasks" } },            

         // vProjectTasksWithCollaborator
         GetvProjectTasksWithCollaboratorById: { method: "GET", params: { service: "AdminGeneratedCtrl", method: "GetvProjectTasksWithCollaboratorById", id:"@id"} },
         DeletevProjectTasksWithCollaborators: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "DeletevProjectTasksWithCollaborators" } },            

         GetvProjectTasksWithCollaboratorsByCriteria: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "GetvProjectTasksWithCollaboratorsByCriteria" } },
         SavevProjectTasksWithCollaborators: { method: "POST", params: { service: "AdminGeneratedCtrl", method: "SavevProjectTasksWithCollaborators" } },            
    });
}]);

*/
