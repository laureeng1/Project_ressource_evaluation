
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#region TaskList
    app.controller('taskListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'Security',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, security, erpDialogs) {
            var advancedTable = null;
            $scope.currentLoggedUser = security.currentUser();
            domPolymer.addEventListener('task-advanced-table-loaded', function () {
                advancedTable = document.querySelector('#task-advanced-table');

                advancedTable.tableOptions = {

                    tableIsSimple: false,
                    tableIsBasic: false,
                    sortDescending: true,
                    enableColModify: false,
                    enableColDelete: false,
                    multiChecked: false,
                    paginationParams: {
                        perPage: 10,
                        currentPage: 1,
                        count: 0
                    },
                    columns: [{
                        title: 'Projet',
                        fieldSearch: 'projectName',
                        fieldResult: 'projectName',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: false
                    }, {
                        title: 'Tâche',
                        fieldSearch: 'label',
                        fieldResult: 'label',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: false
                    },
                        {
                            title: 'Durée planifiée',
                            fieldSearch: 'timePlannedTime',
                            fieldResult: 'timePlannedTime',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        },
                        {
                            title: 'Durée écoulée',
                            fieldSearch: 'timeElapsedVarchar',
                            fieldResult: 'timeElapsedVarchar',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        },
                        {
                            title: 'Durée restant',
                            fieldSearch: 'timeRemainingVarchar',
                            fieldResult: 'timeRemainingVarchar',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        },
                         {
                             title: 'Date de fin',
                             fieldSearch: 'deadline',
                             fieldResult: 'deadline',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         },
                         {
                             title: 'Assignée à',
                             fieldSearch: 'userFullname',
                             fieldResult: 'userFullname',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         },
                         {
                             title: 'Status',
                             fieldSearch: 'status',
                             fieldResult: 'status',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         }]
                };

                advancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = advancedTable.factorRequest({}, msg.criterias);
                    // params.ItemToSearch.idCurrentCollaborator = $scope.currentLoggedUser.IdUtilisateur;
                    moduleServiceWeb.GetCollaboratorTasks(
                        params,
                        function (response) {

                            if (!response.HasError) {
                                advancedTable.setItems(response.Data.items, response.Data.count);
                            }
                        },
                        function (error) {

                        }
                    );
                });

                advancedTable.addEventListener('show-details', function (e) {
                    // charger données ou affecter details à l'objet de binding   
                    var msg = e.detail.msg;

                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;

                    $scope.$apply(function () {
                        $scope.index = item.idRow;

                        $scope.$broadcast("task-advanced-table-show-details", { detail: item });

                    });

                });

                advancedTable.refreshItems();
            });



            var init = function () {

            };

            init();
        }
    ]);
    //#endregion

    app.controller('collaboratorActionListCtrl', [
         '$scope',
         'commonUtilities',
         'devEvalServices',
         'collaboratorActionModal',
         'erpDialogs',
         function ($scope, commonUtilities, moduleServiceWeb, collaboratorActionFrmModal, erpDialogs) {
             var actionTable = null;
             var currentTask = null;
             var advancedTable = document.querySelector('#task-advanced-table');
             $scope.collaboratorActionsList = null;

             $scope.status = {
                 isOpen: false
             };

             $scope.$on('task-advanced-table-show-details', function (event, data) {
                 currentTask = data.detail;
                 $scope.taskStatus = currentTask.status;
                 $scope.isInitialized = false;
                 $scope.status.isOpen = false;
             });

             $scope.submit = function () {

                 erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {
                     // sauvegarder l'item original
                     var itemToSave = angular.copy(currentTask);

                     // préparer la requête d'enregistrement
                     var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Soumettre en validation une tâche", 'La tâche a été suspendue avec succès!', true);

                     // Mettre à jour le status de la tâche
                     itemToSave.status = 'en validation';
                     params.ItemsToSave = [itemToSave];

                     // Enregistrer
                     moduleServiceWeb.SaveProjectTasks(params, function (response) {
                         if (!response.HasError) {
                             // Faire ici les traitements si aucune erreur trouvée
                             advancedTable.refreshItems();
                         }
                     });
                 }, function () {

                 }, "Soumettre une tâche à validation");


             };

             var changeTitle = function (isOpen) {
                 if (isOpen) {
                     $scope.title = "Liste des activités (cliquer pour réduire)";
                 } else {
                     $scope.title = "Liste des activités (cliquer pour dérouler)";
                 }
             };

             var configurerAdvancedTable = function () {
                 actionTable = document.querySelector('#collaborator-action-advanced-table');

                 actionTable.tableOptions = {

                     tableIsSimple: true,
                     tableIsBasic: true,
                     sortDescending: true,
                     enableColModify: true,
                     enableColDelete: true,
                     multiChecked: true,
                     paginationParams: {
                         perPage: 5,
                         currentPage: 1,
                         count: 0
                     },
                     columns: [

                          {
                              title: 'Description',
                              fieldSearch: 'description',
                              fieldResult: 'description',
                              defaultFieldSearch: true,
                              isCriteria: true,
                              defaultSort: false
                          },
                         {
                             title: 'Date',
                             fieldSearch: 'actionDate',
                             fieldResult: 'actionDate',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         },
                         {
                             title: 'Durée',
                             fieldSearch: 'durationTime',
                             fieldResult: 'durationTime',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         }
                     ]
                 };

                 actionTable.addEventListener('load-items', function (e) {
                     var msg = e.detail.msg;
                     if (msg.idInstance !== actionTable.idInstance)
                         return;

                     var index = msg.paginationParams.positionDebut - 1;
                     var size = msg.paginationParams.perPage;
                     var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                     params.ItemToSearch = actionTable.factorRequest({ actionType: 'collaborator' }, msg.criterias);

                     params.ItemToSearch.idProjectTask = currentTask.id;
                     moduleServiceWeb.GetProjectTaskActions(
                         params,
                         function (response) {
                             if (!response.HasError) {
                                 actionTable.setItems(response.Data.items, response.Data.count);
                             }
                         },
                         function (error) {

                         }
                     );

                 });

                 actionTable.addEventListener('modify-item', function (e) {
                     var msg = e.detail.msg;
                     if (msg.idInstance !== actionTable.idInstance)
                         return;
                     $scope.editItem(msg.item);
                 });

                 actionTable.addEventListener('delete-item', function (e) {
                     var msg = e.detail.msg;

                     if (msg.idInstance !== actionTable.idInstance)
                         return;

                     // sauvegarder l'item original
                     var itemToSaveCopie = msg.item;

                     // préparer l'item à sauvegarder

                     erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                         // préparer la requête d'enregistrement
                         var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression d' actions", 'Suppression effectué avec succès!', true);

                         params.ItemsToSave = [itemToSaveCopie];

                         // Enregistrer
                         moduleServiceWeb.DeleteFsProjects(params, function (response) {
                             if (!response.HasError) {
                                 // Faire ici les traitements si aucune erreur trouvée
                                 actionTable.refreshItems();
                             }
                         });
                     }, function () {

                     }, "Suppression d'action");
                 });

             };

             $scope.$watch("status.isOpen", function (newValue, oldValue) {
                 changeTitle($scope.status.isOpen);

                 if (!$scope.isInitialized && $scope.status.isOpen) {
                     if (actionTable == null) // configurer le composant
                         configurerAdvancedTable();

                     actionTable.loadItems();
                     $scope.isInitialized = true;
                 }
             });



             /// Lance une fenetre modale de modification/ajout
             //$scope.editItem = function (item) {
             //    var data = { item: item };
             //    //var dlg = trancheModal.Show(data);

             //    dlg.result.then(function (response) {
             //        trancheTable.refreshItems();
             //    }, function (obj) {
             //        // ne rien faire pour l'instant
             //    });
             //};

             // Lance une fenetre modale de modification/ajout
             $scope.editItem = function (item) {

                 // item.idProject = currentProjet.id;

                 var data = { item: item, idProjectTask: currentTask.id };

                 var dlg = collaboratorActionFrmModal.Show(data);

                 dlg.result.then(function (response) {
                     actionTable.refreshItems();
                     advancedTable.refreshItems();
                 }, function (obj) {
                     // ne rien faire pour l'instant
                 });
             };


         }
    ]);





});








