
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#endRegion Type partenaire Modal edit

    app.controller('permissionModalCtrl', [
       '$scope',
       '$modalInstance',
       '$rootScope',
       'commonUtilities',
       'devEvalServices',
       'erpDialogs',
       'erpModels',
       'data',
       function ($scope, $modalInstance, $rootScope, commonUtilities, moduleServiceWeb, erpDialogs, erpModels, data) {

           var dlg = null;
           var searchInput = null;

           $scope.item = data.item || {};
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
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer l'item à sauvegarder

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une permission", 'Enregistrement effectué avec succès!', true);
                   //console.log(params);
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SavePermissions(params, function (response) {
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




