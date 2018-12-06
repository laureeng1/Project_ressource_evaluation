
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#endRegion Type partenaire Modal edit

    app.controller('bruitActionModalCtrl', [
       '$scope',
       '$modalInstance',
       '$rootScope',
       'commonUtilities',
       'devEvalServices',
        'Security',
       'erpDialogs',
       'erpModels',
       'data',
       function ($scope, $modalInstance, $rootScope, commonUtilities, moduleServiceWeb, security, erpDialogs, erpModels, data) {

           var dlg = null;
           var searchInput = null;
           $scope.currentLoggedUser = security.currentUser();
           $scope.item = data.item || {};

           $scope.currentDeadline = data.projectTask.deadline;
           $scope.currentTimePlanned = data.projectTask.timePlanned;
           //if ((commonUtilities.IsUndefinedOrNull($scope.item.idProjectTask) || $scope.item.idProjectTask === 0) && !commonUtilities.IsUndefinedOrNull(data.idProjectTask))
           $scope.item.idProjectTask = data.projectTask.id;
           $scope.item.actionType = 'bruit';
           $scope.item.IsNewItem = commonUtilities.IsUndefinedOrNull(data.item);
           $scope.DoSaveItem = commonUtilities.IsUndefinedOrNull(data.DoSaveItem) || data.DoSaveItem == true ? true : false;


           /// Charger éventuellement des données
           /// data peut contenir un ensemble de données utiles pour initialiser l'interface
           $scope.loadContent = function (callback) {
               //Charger des eléments en avant l'affichage du modal
               callback(data);
           };

           /// Annulation de l'enregistrement
           $scope.cancel = function () {
               $modalInstance.dismiss('canceled');
           };

           // Enregistrer item
           $scope.save = function (itemToSave) {
               if ($scope.DoSaveItem) {
                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Bruit d'une tâche", 'bruit effectué avec succès!', true);
                   //console.log(params);
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SaveProjectTaskActions(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée
                           $modalInstance.close(response.Data);
                       }
                   });
               } else {
                   $modalInstance.close(itemToSave);
               }
           };

           var init = function () {
               $scope.loadContent(function (data) {
                   // autres initialisations
               });
           };

           init();
       }
    ]);




    //#endRegion

});




