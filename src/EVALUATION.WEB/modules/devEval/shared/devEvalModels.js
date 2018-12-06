//define(['app', 'utilities'], function () {
//    'use strict';

//    /* Models */

//    app.service('devEvalModels', [
//        'commonUtilities', function (commonUtilities) {
//            var mainSelf = this;

//            mainSelf.UserRoles = function (obj) {

//                var self = this;

//                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

//                self.Id = obj.Id;
//                self.UserId = obj.UserId;
//                self.RoleId = obj.RoleId;
//            };

//        }

//    ]);


//});


define(['app', 'utilities'], function (app) {
    'use strict';

    app.service('devEvalModels', [
        'commonUtilities', function (commonUtilities) {
            var mainSelf = this;



            mainSelf.UserRoles = function (obj) {

                var self = this;

                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

                self.Id = obj.Id;
                self.UserId = obj.UserId;
                self.RoleId = obj.RoleId;
            };

            mainSelf.RolePermissions = function (obj) {

                var self = this;

                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

                self.Id = obj.Id;
                self.RoleId = obj.RoleId;
                self.PermissionId = obj.PermissionId;
            };

            mainSelf.ProjectTask = function (obj) {

                var self = this;

                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

                self.Id = obj.Id;
                self.IdCurrentCollaborator = obj.IdCurrentCollaborator;
                self.Label = obj.Label;
                self.TimePlannedTime = obj.TimePlannedTime;
                self.TimeRemainingVarchar = obj.TimeRemainingVarchar;
                self.TimeElapsedVarchar = obj.TimeElapsedVarchar;
                self.Deadline = obj.Deadline;
                self.DateStarted = obj.DateStarted;
            };

            mainSelf.Permissions = function (obj) {

                var self = this;

                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

                self.Id = obj.Id;
                self.Name = obj.Name;
                self.DisplayName = obj.DisplayName;
            };

        }

    ]);

});