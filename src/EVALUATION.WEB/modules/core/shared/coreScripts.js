define(['definitions', 'utilities', 'parameters', 'Core-services', 'erp-models', 'Core-models', 'angular-idle', 'angular-dialog-service', 'erp-modal-services'], function () {
    'use strict';

    /* Services */
    CoreServices.service('Security', [
        '$rootScope',
        '$location',
        'urlSw',
        'commonUtilities',
        '$state',
        'Idle',
        'erpDialogs',
        'CoreLockScreenModal',
        'securityService',
        'allPermissionService',
        '$templateCache',
        function ($rootScope, $location, urlSw, commonUtilities, $state, idle, erpDialogs, CoreLockScreenModal, securityService, allPermissionService, $templateCache) {
            var mainSelf = this;

            mainSelf.currentUser = function () {
                var user = window.sessionStorage['currentUser'];
                if (commonUtilities.IsUndefinedOrNull(user))
                    return null;

                return JSON.parse(user);
            };

          
          


            mainSelf.logoutUser = function () {
                var params = new commonUtilities.RequestSw(0, 1, false, 0, false, null, null, true);
                params.ItemToSearch = mainSelf.currentUser();
                /*securityService.LogoutUser(params, function(response) {
                    mainSelf.SetCurrentUser(null);
                    mainSelf.SetAllPermissions(null);
                    $rootScope.$broadcast("logged_out");
                    $state.go("access.signin");
                });*/
                mainSelf.SetCurrentUser(null);
                mainSelf.SetAllPermissions(null);
                sessionStorage.removeItem("authorizationData");
                $rootScope.$broadcast("logged_out");
                $state.go("access.signin", {}, {reload:true});
               
            };

            mainSelf.logout = function (callback) {
                var msg = 'Vous serez complètement déconnecté de l\'application et vous pourriez perdre des données non enregistrées.<br/> Voulez-vous néanmoins continuer?';
                erpDialogs.Confirm(msg,
                    function () {
                        if (typeof (callback) != 'function') {
                            mainSelf.logoutUser();
                            $rootScope.$on('$viewContentLoaded', function () {

                                //$templateCache.removeAll();
                            });
                        }

                        else { callback(); }
                    }, function () { }, 'Déconnexion');
            };

            mainSelf.IsAuthentified = function () {
                return mainSelf.currentUser() != null;
            };

            mainSelf.IsTimedOut = function() {

                return mainSelf.currentUser() != null && mainSelf.currentUser().IsTimedOut != null && mainSelf.currentUser().IsTimedOut;
            };

            mainSelf.SetTimeOutStatut = function(boolVal) {
                if (mainSelf.IsAuthentified()) {
                    var user = mainSelf.currentUser();
                    user.IsTimedOut = boolVal;
                    mainSelf.SetCurrentUser(user);
                }
            };

            mainSelf.SetCurrentUser = function (user) {
                if (!commonUtilities.IsUndefinedOrNull(user)) {
                    user.Password = "";
                    user.Permissions.push("app.dashboard");
                    user.TimeSession = 10000;
                    mainSelf.SetAllPermissions(allPermissionService);
                    window.sessionStorage["currentUser"] = JSON.stringify(user);
                    idle.setIdle(user.TimeSession * 60);
                    $rootScope.$broadcast('current-user-changed', { user: user });
                } else {
                    window.sessionStorage.removeItem("currentUser");
                   
                }
            };

          

            //#region session management
            mainSelf.initSession = function(user) {
                if (commonUtilities.IsUndefinedOrNull(user)) return;
                //var timeOut = (user.TimeSession == null || user.TimeSession == 'undefined') ? 60 : user.TimeSession;
                //idle.idleDuration(timeOut);
                idle.watch();
            };

            mainSelf.stopSession = function() {
                idle.unwatch();
            };

            //var dlg = null;

            mainSelf.showLockScreen = function() {
                mainSelf.stopSession();

                //if (dlg !== null) return;

                var dlg = CoreLockScreenModal.Show(mainSelf.currentUser());

                dlg.result.then(function(response) {
                    // marquer comme lue
                    mainSelf.SetTimeOutStatut(false);
                    dlg = null;
                }, function() {
                    // ne rien faire;
                });
            };
            //#endregion

            //#Region permission

            mainSelf.SetAllPermissions = function (permissions) {
                if (!commonUtilities.IsUndefinedOrNull(permissions)) {
                    window.sessionStorage["allPermissions"] = JSON.stringify(permissions);
                    idle.setIdle(permissions.TimeSession * 60);
                } else {
                    window.sessionStorage.removeItem("allPermissions");
                }
            };

            mainSelf.allPermissions = function () {
                var permissions = window.sessionStorage['allPermissions'];
                if (commonUtilities.IsUndefinedOrNull(permissions))
                    return null;
                return JSON.parse(permissions);
            };



            mainSelf.hasPermission = function (permissionName) {
                if (commonUtilities.IsUndefinedOrNull(mainSelf.allPermissions) || commonUtilities.IsUndefinedOrNull(mainSelf.currentUser())
                    || commonUtilities.IsUndefinedOrNull(mainSelf.currentUser().Permissions))
                    return false;
                return !commonUtilities.IsUndefinedOrNull(mainSelf.getByValue(mainSelf.allPermissions(), permissionName, null))
                    && !commonUtilities.IsUndefinedOrNull(mainSelf.getByValue(mainSelf.currentUser().Permissions, permissionName, null));
            };

            mainSelf.hasButtonPermission = function (permissionName) {
                if (commonUtilities.IsUndefinedOrNull(mainSelf.allPermissions) || commonUtilities.IsUndefinedOrNull(mainSelf.currentUser())
                    || commonUtilities.IsUndefinedOrNull(mainSelf.currentUser().Permissions))
                    return false;
                return !commonUtilities.IsUndefinedOrNull(mainSelf.getByValue(mainSelf.currentUser().Permissions, permissionName, null));
            };

            mainSelf.hasAnyOfPermissions = function (permissionList) {

                if (commonUtilities.IsUndefinedOrNull(permissionList) || permissionList.length <= 0) {
                    return true;
                }

                for (var i = 0; i < permissionList.length; i++) {
                    if (hasPermission(permissionList[i])) {
                        return true;
                    }
                }

                return false;

            };

            mainSelf.hasAllPermissions = function () {
                var allPermissions = mainSelf.allPermissions();
                if (commonUtilities.IsUndefinedOrNull(allPermissions)) {
                    return true;
                }

                for (var i = 0; i < allPermissions.length; i++) {
                    if (!hasPermission(allPermissions[i])) {
                        return false;
                    }
                }

                return true;

            };

            

            //#End Region


            mainSelf.getByValue = function (input,value,column) {
                var i = 0, len = input.length;
                for (; i < len; i++) {
                    if (column===null) {
                        if (angular.equals(input[i],value)) {
                            return input[i];
                        }
                    }
                    else {
                        if (angular.equals(input[i][column], value)) {
                            return input[i][column];
                        }
                    }
               
                }
                return null;
            }

         

            $rootScope.$on("show-error", function (event, args) {
                if (args.isCustomMessage) {                    
                    erpDialogs.Notify(args.Message, args.Title);
                } else {
                    erpDialogs.Error(args.Message, args.Title);
                }
            });
        }
    ]);

    CoreServices.service('GestionErreur', [
        'erpDialogs',
        'commonUtilities',
        function (erpDialogs, commonUtilities) {
            var mainSelf = this;

            mainSelf.IsCustomError = function (message) {
                return message.indexOf(commonUtilities.GlobalEnum.CustomException) > -1;
            }

        }
    ]);

    CoreServices.service('CoreLockScreenModal', ['erpDialogs', function (erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase('lockScreen/CoreLockScreenModal.html', MODULE_ERP_CORE),
                                        'CoreLockScreenModalCtrl',
                                        data, { size: 'lg' },
                                        [HelpersErp.getUrlByFeaturesBase('lockScreen/CoreLockScreenModalCtrl.js', MODULE_ERP_CORE)]);
        };
    }]);

   
    CoreServices.service("reportingServiceUtility", [
    "urlSw",
    "commonUtilities", function (urlSw, commonUtilities) {
        var mainSelf = this;

        mainSelf.displayReport = function (reportName, parameters) {

            if (commonUtilities.IsUndefinedOrNull(parameters) || commonUtilities.IsUndefinedOrNull(reportName))
                return;

            var url = urlSw.getReportRdlUrlBase() + reportName + "&rs:Command=Render&" + parameters;

            window.open(url);

        };

        mainSelf.displayReportWithoutParameters = function (reportName) {

            if (commonUtilities.IsUndefinedOrNull(reportName))
                return;

            var url = urlSw.getReportRdlUrlBase() + reportName + "&rs:Command=Render";

            window.open(url);

        };
    }
    ]);
  
});
