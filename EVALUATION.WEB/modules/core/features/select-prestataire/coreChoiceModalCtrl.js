define(['app', 'Core-models', 'Core-scripts', 'utilities', 'erp-modal-services', 'Core-modal-services', 'Core-services', 'parameters'], function (app) {
    'use strict';

    /* Controllers */

    app.controller('CoreChoiceModalCtrl', ['$scope', '$q', '$http', 'urlSw', 'securityService', 'userService', 'userGestionnaireService', 'userGarantService', 'userPrestataireService', 'commonUtilities', '$location', '$rootScope', '$window', '$state', 'Security', 'CoreModel', 'erpDialogs', 'CoreEditPassword','data','$modalInstance',
        function ($scope, $q, $http, urlSw, securityService, userService, userGestionnaireService, userGarantService, userPrestataireService, commonUtilities, $location, $rootScope, $window, $state, security, CoreModel, erpDialogs, CoreEditPassword, data, $modalInstance) {

            $scope.user = null;
            
            var _authentication = {
                isAuth: false,
                userName: "",
                useRefreshTokens: false
            };

            //$scope.blockesc = function(keyEvent) {
            //    if (keyEvent.keyCode === 27) {
            //        //$window.event.returnValue = false;
            //        //console.log(keyEvent);
            //        alert(keyEvent);
            //        //return;
            //    }
            //}


            /*var loadUserOtherInfos = function () {
                security.SetCurrentUser($scope.user);
                $state.go("app.dashboard");
                security.initSession($scope.user);
            }*/

            $scope.selectionnerPrestataire = function (item) {
                $scope.currentPrestataire = item;
                $scope.user.idPrestataireMedical = item.idPrestataireMedical;
                $scope.user.nomPrestataireMedical = item.raisonSociale;
            };

            $scope.submitForm = function (userToLogin) {
                if($scope.currentPrestataire ==null)
                {
                    erpDialogs.Notify("Veuillez sélectionner un élément de la liste");
                    return;
                }
                //loadUserOtherInfos();
                $modalInstance.close($scope.user);
            };

            var init = function()
            {
                $scope.user = data.item;
                $scope.listePrestataire = $scope.user.userPrestataires;
            }

            init();
        }]);



});
