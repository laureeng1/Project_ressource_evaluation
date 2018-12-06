define(['definitions', 'parameters', 'utilities'], function () {
    'use strict';

    /* Services */
    CoreServices.factory('securityService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var url = urlSw.getUrl(urlSw.UrlServiceBase, ':service', ':method');

            return $resource(url, {}, {
                Signin: { method: "POST", params: { service: "accounts", method: "signin" } },
                LogoutUser: {method: "POST", params: {service: "Security", method: "LogoutUser"}},
                EditUserPassword: { method: "POST", params: { service: "accounts", method: "EditUserPassword" } },
                NotificationIsClicked: { method: "POST", params: { service: "accounts", method: "NotificationIsClicked" } },
                GetNotificationsByCriteria: { method: "POST", params: { service: "accounts", method: "GetNotificationsByCriteria" } }
            });
        }]);
    CoreServices.factory('userService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var customUser = {};

            return customUser;

            
        }]);
    CoreServices.factory('userGestionnaireService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var customUserGestionnaire = {};

            return customUserGestionnaire;


        }]);
    CoreServices.factory('userGarantService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var customPersonne = {};


              
            return customPersonne;


        }]);
    CoreServices.factory('userPrestataireService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var customPersonne = {};
    
            return customPersonne;


        }]);
    CoreServices.factory('allPermissionService', ['$resource', 'urlSw', 'commonUtilities',
       function ($resource, urlSw, commonUtilities) {
           var allPermissions = [];

           return allPermissions;

       }]);
    CoreServices.factory('GetTenant', ['$resource', 'urlSw', 'commonUtilities',
      function ($resource, urlSw, commonUtilities) {
          return "RMO";


      }]);
    CoreServices.factory('adminGeneratedCtrlService', ['$resource', 'urlSw', 'commonUtilities',
        function ($resource, urlSw, commonUtilities) {
            var url = urlSw.getUrl(urlSw.UrlServiceBase, ":service", ":method");

            return $resource(url, {}, {

                GetTest: { method: "GET", params: { service: "dashboard", method: "GetTest" } },


            });
        }]);
    CoreServices.factory('dashboardService', ['$resource', 'urlSw', 'commonUtilities',
    function ($resource, urlSw, commonUtilities) {
        var url = urlSw.getUrl(urlSw.UrlServiceBase, ':service', ':method');

        return $resource(url, {}, {
            GetTest: { method: "GET", params: { service: "dashboard", method: "GetTest" } },
 



        });
    }]);
});

