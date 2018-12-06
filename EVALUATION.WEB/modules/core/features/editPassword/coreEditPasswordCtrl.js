define(['app', 'Core-models', 'Core-scripts','utilities', 'erp-modal-services', 'Core-modal-services'], function (app) {
    'use strict';


   

    //#region editPassword
 app.controller('CoreEditPasswordCtrl', [
  '$scope',
  '$modalInstance',
  '$rootScope',
  'CoreModel',
  'commonUtilities',
  'securityService',
  'erpDialogs',
  'data',
  function ($scope, $modalInstance, $rootScope, moduleModels, commonUtilities, moduleServiceWeb, erpDialogs,data) {

      $scope.item = data.item || {};
      $scope.IsNewItem = commonUtilities.IsUndefinedOrNull(data.item);

      /// Annulation de l'enregistrement
      $scope.cancel = function () {

          $modalInstance.dismiss('canceled');
      };

      $scope.save = function (itemToSave) {
         
          var params = new commonUtilities.RequestSw(0, 1, false, 1, true, 'Modifier mot de passe', 'Modification effectuée avec succès!', true);
          if (itemToSave.NewPassword !== itemToSave.ConfirmNewPassword) {
              erpDialogs.Notify("Votre nouveau mot de passe est different de la confirmation de mot de passe", "Erreur");
              return;
          }
             
          params.ItemsToSave = [itemToSave];

          moduleServiceWeb.EditUserPassword(
              params,
              function (response) {
                  if (!response.HasError) {
                      $modalInstance.close(response.Data.Items);
                  }
              },
              function (error) {

              }
          );
      };
  }
    ]);

    //#end region

});
