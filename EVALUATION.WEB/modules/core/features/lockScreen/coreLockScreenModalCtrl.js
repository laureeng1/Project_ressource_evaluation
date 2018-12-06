define(["app", "erp-models", "Core-scripts", "utilities", "erp-services", "Core-models", "Core-services", "security-services"], function (app) {
    "use strict";

    app.controller("CoreLockScreenModalCtrl", [
        "$scope",
        "$rootScope",
        "$modalInstance",
        "$timeout",
        "commonUtilities",
        "Security",
        "securityService",
        "CoreModel",
        function
        (
            $scope,
            $rootScope,
            $modalInstance,
            $timeout,
            commonUtilities,
            security,
            securityService,
            CoreModel
        ) {
            $scope.item = security.currentUser();
            var connectedUser = null;

            $scope.authentify = function() {
                // vérifier credentials        
                var params = new commonUtilities.RequestSw(0, 1, false, 0, false, null, null, true);
                params.ItemToSearch = $scope.item;
                //params.Navigator = new CoreModel.Navigator(navigator);

                securityService.AuthentifyUser(params, function (response) {

                    if (response.HasError)
                        return;
                              
                    if (response.Data != null && response.Data.IsAuthentify === true) {

                        connectedUser = response.Data.Items[0];

                        security.SetCurrentUser(connectedUser);

                        security.initSession(connectedUser);

                        $modalInstance.close(response.Data);


                    }
                });
            };

            $scope.logout = function() {
                security.logout(function() {
                    $modalInstance.dismiss("canceled");
                    security.logoutUser();
                });
            };
           

            function startTime() {
                var today = new Date();
                var h = today.getHours();
                var m = today.getMinutes();
                var s = today.getSeconds();
                // add a zero in front of numbers<10
                m = checkTime(m);
                s = checkTime(s);
                $scope.displayTime = h + ":" + m + ":" + s;
                $timeout(function() {
                    startTime();
                }, 500);
            }

            function checkTime(i) {
                if (i < 10) {
                    i = "0" + i;
                }
                return i;
            }

            startTime();

        }
    ]);
});