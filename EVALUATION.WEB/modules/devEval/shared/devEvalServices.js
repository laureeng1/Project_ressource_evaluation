define(['app', 'parameters'], function (app) {
    'use strict';

    app.factory("devEvalServices", [
        "$resource", "urlSw", function ($resource, urlSw) {
            var url = urlSw.getUrl(urlSw.UrlServiceBase, ":service", ":method");

            return $resource(url, {}, {

                Signin: { method: "POST", params: { service: "dev_eval", method: "Signin" } },

                // CrudProject
                // GetFsProjectById: { method: "GET", params: { service: "dev_eval", method: "GetFsProjectById", id: "@id" } },
                DeleteProjects: { method: "POST", params: { service: "dev_eval", method: "DeleteCustomProjects" } },
                GetProjects: { method: "POST", params: { service: "dev_eval", method: "GetProjects" } },
                SaveProjects: { method: "POST", params: { service: "dev_eval", method: "SaveProjects" } },

                // CrudProjectTasks
                // GetFsProjectById: { method: "GET", params: { service: "dev_eval", method: "GetFsProjectById", id: "@id" } },
                DeleteFsProjectTasks: { method: "POST", params: { service: "dev_eval", method: "DeleteCustomProjectTasks" } },

                GetProjectTasks: { method: "POST", params: { service: "dev_eval", method: "GetProjectTasks" } },
                SaveProjectTasks: { method: "POST", params: { service: "dev_eval", method: "SaveProjectTasks" } },

                GetProjectCollaboratorTasks: { method: "POST", params: { service: "dev_eval", method: "GetProjectCollaboratorTasks" } },

                GetCollaboratorTasks: { method: "POST", params: { service: "dev_eval", method: "GetCollaboratorTasks" } },
                GetvCollaboratorTasksByPeriod: { method: "POST", params: { service: "dev_eval", method: "GetvCollaboratorTasksByPeriod" } },

                GetProjectTaskActions: { method: "POST", params: { service: "dev_eval", method: "GetProjectTaskActions" } },

                SaveProjectTaskActions: { method: "POST", params: { service: "dev_eval", method: "SaveProjectTaskActions" } },

                // CrudUsers
                // GetFsProjectById: { method: "GET", params: { service: "dev_eval", method: "GetFsProjectById", id: "@id" } },
                DeleteFsUsers: { method: "POST", params: { service: "dev_eval", method: "DeleteCustomAbpUsers" } },

                GetUsers: { method: "POST", params: { service: "dev_eval", method: "GetAbpUsers" } },
                SaveUsers: { method: "POST", params: { service: "dev_eval", method: "SaveAbpUsers" } },

                GetRoles: { method: "POST", params: { service: "dev_eval", method: "GetRoles" } },
                CreateRole: { method: "POST", params: { service: "dev_eval", method: "CreateRole" } },
                SetupRole: { method: "POST", params: { service: "dev_eval", method: "SetupRole" } },
                SaveRoles: { method: "POST", params: { service: "dev_eval", method: "SaveRoles" } },

                GetUserRoles: { method: "POST", params: { service: "dev_eval", method: "GetUserRoles" } },
                SaveUserRoles: { method: "POST", params: { service: "dev_eval", method: "SaveUserRoles" } },
                DeleteUserRoles: { method: "POST", params: { service: "dev_eval", method: "DeleteUserRoles" } },

                GetRolePermissions: { method: "POST", params: { service: "dev_eval", method: "GetRolePermissions" } },
                SaveRolePermissions: { method: "POST", params: { service: "dev_eval", method: "SaveRolePermissions" } },
                DeleteRolePermissions: { method: "POST", params: { service: "dev_eval", method: "DeleteRolePermissions" } },

                GetPermissions: { method: "POST", params: { service: "dev_eval", method: "GetPermissions" } },
                SavePermissions: { method: "POST", params: { service: "dev_eval", method: "SavePermissions" } },



            });
        }
    ]);
});