define(['app', 'erp-models', 'utilities', 'erp-services'], function (app) {
    'use strict';

/* Controllers */

    app.controller('editnotificationModalCtrl', ['$scope', '$modalInstance', '$state', 'data', function ($scope, $modalInstance, $state, data) {

    $scope.no = data;
    //console.log($scope.no);
    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };

    $scope.marquerCommeLue = function () {
        $scope.no.isClicked = true;
        $modalInstance.close($scope.no);
    };

    $scope.suivreLien = function () {     
        $state.go($scope.no.link);
        $scope.marquerCommeLue();
    };
}]);

});