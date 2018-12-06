
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#endRegion Type partenaire Modal edit

    app.controller('taskModalCtrl', [
        '$scope',
        '$modalInstance',
        '$rootScope',
        '$timeout',
        'Security',
       'commonUtilities',
       'devEvalServices',
       'erpDialogs',
       'data',
       function ($scope, $modalInstance, $rootScope, $timeout, security, commonUtilities, moduleServiceWeb, erpDialogs, data) {

           //var dlg = null;
           //var searchInput = null;
           //var currentProject = null;
           var currentLoggedUser = security.currentUser();

           //var taskTable = document.querySelector('#tache-advanced-table');

           $scope.item = data.item || {};
           if (!commonUtilities.IsUndefinedOrNull($scope.item.idProject) && $scope.item.idProject !== 0 && $scope.item.idProject !== data.idProject)
               return;
           if ((commonUtilities.IsUndefinedOrNull($scope.item.idProject) || $scope.item.idProject === 0) &&
               !commonUtilities.IsUndefinedOrNull(data.idProject)) {
               $scope.item.idProject = data.idProject;
           }
           // else {
           //    alert("data does'nt contains idProject");
           //}

           $scope.item.status = commonUtilities.IsUndefinedOrNull($scope.item.status) ? 'brouillon' : $scope.item.status;
           $scope.item.IsNewItem = commonUtilities.IsUndefinedOrNull(data.item);
           $scope.DoSaveItem = commonUtilities.IsUndefinedOrNull(data.DoSaveItem) || data.DoSaveItem == true ? true : false;
           // $scope.item.timePlanned = 3600;
           // $scope.item.timeElapsed = 2450;
           $scope.collaborators = null;

           var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

           //params.ItemToSearch = searchInput.factorRequest({}, []);

           // var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
           //params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);

           //params.ItemToSearch.idProject = currentProjet.idProject;

           moduleServiceWeb.GetUsers(
               params,
               function (response) {
                   if (!response.HasError) {
                       $scope.collaborators = response.Data.items;
                       // alert(JSON.stringify($scope.collaborators));
                   }
               },
               function (error) {

               }
           );

           //$scope.$on('project-advanced-table-show-details', function (event, data) {
           //    currentProject = data.detail;
           //    $scope.idProject = currentProject.idProject;
           //});

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

           // Valider et cloturer la tâche
           $scope.submit = function (itemToSave) {

               if ($scope.DoSaveItem) {
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer l'item à sauvegarder

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);

                   // Mettre à jour le status de la tâche
                   //console.log(params);
                   itemToSave.status = 'en validation';
                   params.ItemsToSave = [itemToSave];
                   params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                   // Enregistrer
                   moduleServiceWeb.SaveProjectTasks(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée
                           $modalInstance.close(response.Data);
                       }
                   });
               } else {
                   $modalInstance.close(itemToSave);
               }
           };

           // Valider et cloturer la tâche
           $scope.start = function (itemToSave) {

               if ($scope.DoSaveItem) {
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer l'item à sauvegarder

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Démarrer une tâche", 'La tâche a été démarrée avec succès!', true);
                   params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                   // Mettre à jour le status de la tâche
                   //console.log(params);
                   itemToSave.status = 'démarrée';
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SaveProjectTasks(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée
                           $modalInstance.close(response.Data);
                       }
                   });
               } else {
                   $modalInstance.close(itemToSave);
               }
           };

           /// Annulation de l'enregistrement
           $scope.refuse = function () {
               $modalInstance.dismiss('canceled');
           };

           /// Annulation de l'enregistrement
           // Valider et cloturer la tâche
           $scope.pend = function (itemToSave) {

               if ($scope.DoSaveItem) {
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer l'item à sauvegarder

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);
                   params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                   // Mettre à jour le status de la tâche
                   //console.log(params);
                   itemToSave.status = 'suspendue';
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SaveProjectTasks(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée
                           $modalInstance.close(response.Data);
                       }
                   });
               } else {
                   $modalInstance.close(itemToSave);
               }
           };

           // Valider et cloturer la tâche
           $scope.accept = function (itemToSave) {

               if ($scope.DoSaveItem) {
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer l'item à sauvegarder

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);
                   params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                   // Mettre à jour le status de la tâche
                   //console.log(params);
                   itemToSave.status = 'clôturée';
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SaveProjectTasks(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée
                           $modalInstance.close(response.Data);
                       }
                   });
               } else {
                   $modalInstance.close(itemToSave);
               }
           };


           // Enregistrer item
           $scope.save = function (itemToSave) {

               if ($scope.DoSaveItem) {
                   // sauvegarder l'item original
                   var itemToSaveCopie = angular.copy(itemToSave);

                   // préparer la requête d'enregistrement
                   var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);
                   params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                   //console.log(params);
                   params.ItemsToSave = [itemToSave];

                   // Enregistrer
                   moduleServiceWeb.SaveProjectTasks(params, function (response) {
                       if (!response.HasError) {
                           // Faire ici les traitements si aucune erreur trouvée

                           // Sauvegarde du collaborateur affecté
                           //console.log(params);
                           $modalInstance.close(response.Data);
                           params.ItemsToSave = [itemToSave];
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




