define(['app', 'Core-models', 'Core-scripts', 'utilities', 'erp-modal-services', 'Core-modal-services', 'Core-services', 'parameters'], function (app) {
    'use strict';

    /* Controllers */

    app.controller('CoreSigninCtrl', ['$scope', '$q', '$http', 'urlSw', 'securityService', 'userService', 'userGestionnaireService', 'userGarantService', 'userPrestataireService', 'commonUtilities', '$location', '$rootScope', '$window', '$state', 'Security', 'CoreModel', 'erpDialogs', 'CoreEditPassword','CoreChoiceModal',
        function ($scope, $q, $http, urlSw, securityService, userService, userGestionnaireService, userGarantService, userPrestataireService, commonUtilities, $location, $rootScope, $window, $state, security, CoreModel, erpDialogs, CoreEditPassword, CoreChoiceModal) {

            var user = null;
            var dlg = null;

            var _authentication = {
                isAuth: false,
                userName: "",
                useRefreshTokens: false
            };

            var loadUserOtherInfos = function () {
                security.SetCurrentUser(user);
                $state.go("app.dashboard");
                security.initSession(user);
            }

            $scope.submitForm = function (userToLogin) {
                // vérifier credentials    
               /* var data = "grant_type=password&username=" + userToLogin.UserName + "&password=" + userToLogin.Password;
                //var deferred = $q.defer();
    
                $http.post(urlSw.UrlServiceToken + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (result) {
    
                    //if (userToLogin.useRefreshTokens) {
                       
                   
                    var auth = { token: result.Data.access_token, UserName: userToLogin.UserName, expires: result.Data.expires_in };
                    sessionStorage.setItem('authorizationData', result.Data.access_token);
                    //sessionStorage.setItem('authorizationData', JSON.stringify(auth));

                    // storage.bind($scope, 'varName');
                   // }
                    //else {
                    //    window.sessionStorage["authorizationData"]={ token: response.Data.access_token, UserName: userToLogin.UserName, useRefreshTokens: false };
                    //}
                    //_authentication.isAuth = true;
                    //_authentication.userName = userToLogin.UserName;
                    //_authentication.useRefreshTokens = userToLogin.useRefreshTokens;
    
                    //deferred.resolve(result);
    
                }).error(function (err, status) {
                
                    //deferred.reject(err);
                });


                var params = new commonUtilities.RequestSw(0, 1, false, 1, false, null, null, true);
                params.ItemToSearch = userToLogin;
                securityService.Signin(params, function (response) {
                    //console.log(response);
                    if (!response.Data.hasError && response.Data.items.length > 0) {
                        user = response.Data.items[0].user;
                        user.Permissions = response.Data.items[0].codeClaims;
                        user.IdCurrentTenant = response.Data.idCurrentTenant;
                        if (user.userPrestataires != null && user.userPrestataires.length > 1) {
                            var data = { item: user };
                            var dlg = CoreChoiceModal.Show(data);

                            dlg.result.then(function (obj) {
                                user = obj;
                                loadUserOtherInfos();
                            }, function () {

                            });

                        }
                        else if (user.userPrestataires != null && user.userPrestataires.length === 1) {

                            user.idPrestataireMedical = user.userPrestataires[0].idPrestataireMedical;
                            user.nomPrestataireMedical = user.userPrestataires[0].raisonSociale;
                            loadUserOtherInfos();
                        }
                        else {

                            loadUserOtherInfos();
                        }
                        //loadUserOtherInfos();
                    } else {
                        erpDialogs.Notify(response.Data.message, "Erreur");
                    }
                    ////console.log(response);                  
                });

                */
                //TODO: Connexion
                user = {Nom:'',Prenoms:'',IdUtilisateur:1, Permissions:[]};
                loadUserOtherInfos();
            };

            var _logOut = function () {

                sessionStorage.removeItem("authorizationData");

                _authentication.isAuth = false;
                _authentication.userName = "";
                _authentication.useRefreshTokens = false;

            };
        }]);



});
