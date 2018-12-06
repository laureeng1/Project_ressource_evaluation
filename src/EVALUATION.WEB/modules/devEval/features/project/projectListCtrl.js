
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#region Type Partenaire
    app.controller('projectListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'projectModal',
        'Security',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, moduleFrmModal, security, erpDialogs) {
            var advancedTable = null;

            var currentLoggedUser = security.currentUser();
            //alert(JSON.stringify(currentLoggedUser));
            // Use $state.go to redirect if user has not permissions

            //alert(JSON.stringify(currentUser));
            //$scope.roleCheck = function () {
            //    var result = false;
            //    currentLoggedUser.Permissions.forEach(ur => {
            //        if ('app.devEval.projects' === ur) {
            //            result = true;
            //        }
            //    });
            //    // alert(result);
            //    return result;
            //};

            //if (!$scope.roleCheck()) {
            //    $state.go("app.devEval.tasks");
            //}


            // Lance une fenetre modale de modification/ajout
            $scope.editItem = function (item) {
                var data = { item: item };
                var dlg = moduleFrmModal.Show(data);

                dlg.result.then(function (response) {
                    advancedTable.refreshItems();
                }, function (obj) {
                    // ne rien faire pour l'instant

                });
            };

            domPolymer.addEventListener('project-advanced-table-loaded', function () {
                advancedTable = document.querySelector('#project-advanced-table');

                advancedTable.tableOptions = {

                    tableIsSimple: false,
                    tableIsBasic: false,
                    sortDescending: true,
                    enableColModify: true,
                    enableColDelete: true,
                    multiChecked: true,
                    paginationParams: {
                        perPage: 5,
                        currentPage: 1,
                        count: 0
                    },
                    columns: [{
                        title: 'Nom',
                        fieldSearch: 'name',
                        fieldResult: 'name',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: true
                    },
                        {
                            title: 'Description',
                            fieldSearch: 'description',
                            fieldResult: 'description',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        }]
                };

                advancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    //alert(JSON.stringify(msg));
                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = advancedTable.factorRequest({}, msg.criterias);

                    moduleServiceWeb.GetProjects(
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

                advancedTable.addEventListener('modify-item', function (e) {
                    var msg = e.detail.msg;
                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    $scope.editItem(msg.item);
                });

                advancedTable.addEventListener('delete-item', function (e) {
                    var msg = e.detail.msg;

                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    // sauvegarder l'item original
                    var itemToSaveCopie = msg.item;

                    // préparer l'item à sauvegarder

                    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                        // préparer la requête d'enregistrement
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression de projet", 'Suppression effectué avec succès!', true);
                        // itemToSaveCopie.isDeleted = true;
                        params.ItemsToSave = [itemToSaveCopie];
                        params.IdCurrentUser = currentLoggedUser.IdUtilisateur;
                        // Enregistrer
                        moduleServiceWeb.DeleteProjects(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                advancedTable.refreshItems();
                            }
                        });
                    }, function () {

                    }, "Suppression de projet");
                });

                advancedTable.addEventListener('show-details', function (e) {
                    // charger données ou affecter details à l'objet de binding   
                    var msg = e.detail.msg;

                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;

                    $scope.$apply(function () {
                        $scope.index = item.idRow;

                        $scope.$broadcast("project-advanced-table-show-details", { detail: item });

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


    app.controller('projectListTaskCtrl', [
         '$scope',
         'commonUtilities',
         'devEvalServices',
         'taskModal',
         'erpDialogs',
         function ($scope, commonUtilities, moduleServiceWeb, taskFrmModal, erpDialogs) {
             var taskTable = null;
             var currentProjet = null;

             $scope.status = {
                 isOpen: false
             };

             $scope.$on('project-advanced-table-show-details', function (event, data) {
                 currentProjet = data.detail;
                 $scope.idProject = currentProjet.id;
                 $scope.isInitialized = false;
                 $scope.status.isOpen = false;
             });

             var changeTitle = function (isOpen) {
                 if (isOpen) {
                     $scope.title = "Liste des tâches (cliquer pour réduire)";
                 } else {
                     $scope.title = "Liste des tâches (cliquer pour dérouler)";
                 }
             };

             var configurerAdvancedTable = function () {
                 taskTable = document.querySelector('#tache-advanced-table');

                 taskTable.tableOptions = {

                     tableIsSimple: false,
                     tableIsBasic: true,
                     sortDescending: true,
                     enableColModify: true,
                     enableColDelete: true,
                     multiChecked: true,
                     paginationParams: {
                         perPage: 15,
                         currentPage: 1,
                         count: 0
                     },
                     columns: [

                          {
                              title: 'Libelle',
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
                         }, {
                             title: 'Durée réalisée',
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
                             title: 'Prolongation',
                             fieldSearch: 'prolongation',
                             fieldResult: 'prolongation',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         }, {
                             title: 'Bruit',
                             fieldSearch: 'bruit',
                             fieldResult: 'bruit',
                             defaultFieldSearch: true,
                             isCriteria: true,
                             defaultSort: false
                         }, {
                             title: 'Note',
                             fieldSearch: 'note',
                             fieldResult: 'note',
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
                         }

                     ]
                 };

                 taskTable.addEventListener('load-items', function (e) {
                     var msg = e.detail.msg;
                     if (msg.idInstance !== taskTable.idInstance)
                         return;

                     var index = msg.paginationParams.positionDebut - 1;
                     var size = msg.paginationParams.perPage;
                     var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                     params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);

                     params.ItemToSearch.idProject = currentProjet.id;
                     moduleServiceWeb.GetProjectCollaboratorTasks(
                         params,
                         function (response) {
                             if (!response.HasError) {
                                 taskTable.setItems(response.Data.items, response.Data.count);
                             }
                         },
                         function (error) {

                         }
                     );

                 });

                 taskTable.addEventListener('modify-item', function (e) {
                     var msg = e.detail.msg;
                     if (msg.idInstance !== taskTable.idInstance)
                         return;
                     $scope.editItem(msg.item);
                 });

                 taskTable.addEventListener('show-details', function (e) {
                     // charger données ou affecter details à l'objet de binding   
                     var msg = e.detail.msg;

                     if (msg.idInstance !== taskTable.idInstance)
                         return;

                     var item = e.detail.msg.currentItem;

                     $scope.$apply(function () {
                         $scope.index = item.idRow;
                         $scope.taskStatus = item.status;
                         $scope.$broadcast("task-show-details", { detail: item });
                     });

                 });

             };

             $scope.$watch("status.isOpen", function (newValue, oldValue) {
                 changeTitle($scope.status.isOpen);

                 if (!$scope.isInitialized && $scope.status.isOpen) {
                     if (taskTable == null) // configurer le composant
                         configurerAdvancedTable();

                     taskTable.loadItems();
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

                 var data = { item: item, idProject: currentProjet.id };

                 var dlg = taskFrmModal.Show(data);

                 dlg.result.then(function (response) {
                     taskTable.refreshItems();
                 }, function (obj) {
                     // ne rien faire pour l'instant
                 });
             };






         }
    ]);

    app.controller('projectListTaskDetailsCtrl', [
          '$scope',
          'commonUtilities',
          'devEvalServices',
          'rejectionActionModal',
          'prolongationActionModal',
          'bruitActionModal',
          'erpDialogs',
          function ($scope, commonUtilities, moduleServiceWeb, rejectionActionFrmModal, prolongationActionFrmModal, bruitActionFrmModal, erpDialogs) {

              var currentTask = null;
              var taskTable = document.querySelector('#tache-advanced-table');
              // $scope.collaboratorActionsList = null;

              $scope.status = {
                  isOpen: false
              };

              $scope.$on('task-show-details', function (event, data) {
                  currentTask = data.detail;
                  var params = new commonUtilities.RequestSw(0, 30, false, 0, false, null, null, true);
                  params.ItemToSearch = taskTable.factorRequest({}, []);
                  params.ItemToSearch.idProjectTask = currentTask.id;
                  //alert('task-advanced-table-show-details');

                  params.ItemToSearch.idProjectTask = currentTask.id;
                  moduleServiceWeb.GetProjectTaskActions(
                      params,
                      function (response) {
                          if (!response.HasError) {
                              // actionTable.setItems(response.Data.items, response.Data.count);
                              $scope.collaboratorActionsList = response.Data.items;
                              // alert(JSON.stringify($scope.collaboratorActionsList));
                          }
                      },
                      function (error) {

                      }
                  );
              });

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

                  var data = { idProjectTask: currentTask.id };

                  var dlg = rejectionActionFrmModal.Show(data);

                  dlg.result.then(function (response) {
                      taskTable.refreshItems();
                  }, function (obj) {
                      // ne rien faire pour l'instant
                  });
              };

              $scope.prolongation = function () {

                  var data = { projectTask: currentTask };

                  var dlg = prolongationActionFrmModal.Show(data);

                  dlg.result.then(function (response) {
                      taskTable.refreshItems();
                  }, function (obj) {
                      // ne rien faire pour l'instant
                  });
              };

              $scope.noise = function () {

                  var data = { projectTask: currentTask };

                  var dlg = bruitActionFrmModal.Show(data);

                  dlg.result.then(function (response) {
                      taskTable.refreshItems();
                  }, function (obj) {
                      // ne rien faire pour l'instant
                  });
              };

              $scope.start = function () {

                  // sauvegarder l'item original
                  var itemToSave = angular.copy(currentTask);

                  // préparer la requête d'enregistrement
                  var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Démarrer une tâche", 'La tâche a été démarrée avec succès!', true);

                  // Mettre à jour le status de la tâche
                  //console.log(params);
                  itemToSave.status = 'en cours';
                  params.ItemsToSave = [itemToSave];

                  // Enregistrer
                  moduleServiceWeb.SaveProjectTasks(params, function (response) {
                      if (!response.HasError) {
                          // Faire ici les traitements si aucune erreur trouvée
                          taskTable.refreshItems();
                      }
                  });

              };

              // Suspendre la tâche
              $scope.pend = function () {

                  // sauvegarder l'item original
                  var itemToSave = angular.copy(currentTask);

                  // préparer la requête d'enregistrement
                  var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suspendre une tâche", 'La tâche a été suspendue avec succès!', true);

                  // Mettre à jour le status de la tâche
                  //console.log(params);
                  itemToSave.status = 'suspendue';
                  params.ItemsToSave = [itemToSave];

                  // Enregistrer
                  moduleServiceWeb.SaveProjectTasks(params, function (response) {
                      if (!response.HasError) {
                          // Faire ici les traitements si aucune erreur trouvée
                          taskTable.refreshItems();
                      }
                  });

              };

              $scope.accept = function () {

                  erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {
                      // sauvegarder l'item original
                      var itemToSave = angular.copy(currentTask);

                      // préparer la requête d'enregistrement
                      var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Valider une tâche", 'La tâche a été validée avec succès!', true);

                      // Mettre à jour le status de la tâche
                      itemToSave.status = 'clôturée';
                      params.ItemsToSave = [itemToSave];

                      // Enregistrer
                      moduleServiceWeb.SaveProjectTasks(params, function (response) {
                          if (!response.HasError) {
                              // Faire ici les traitements si aucune erreur trouvée
                              advancedTable.refreshItems();
                          }
                      });
                  }, function () {

                  }, "Valider une tâche");


              };

              $scope.abort = function () {

                  erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {

                      var itemToSave = angular.copy(currentTask);
                      // préparer la requête d'enregistrement
                      var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Annuler une tâche", 'La tâche a été annulée avec succès!', true);

                      // Mettre à jour le status de la tâche
                      itemToSave.status = 'annulée';
                      params.ItemsToSave = [itemToSave];

                      // Enregistrer
                      moduleServiceWeb.SaveProjectTasks(params, function (response) {
                          if (!response.HasError) {
                              // Faire ici les traitements si aucune erreur trouvée
                              taskTable.refreshItems();
                          }
                      });
                  }, function () {

                  }, "Annuler une tâche");
              };

              // Valider et cloturer la tâche
              //$scope.accept = function (itemToSave) {

              //    if ($scope.DoSaveItem) {
              //        // sauvegarder l'item original
              //        var itemToSaveCopie = angular.copy(itemToSave);

              //        // préparer l'item à sauvegarder

              //        // préparer la requête d'enregistrement
              //        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);

              //        // Mettre à jour le status de la tâche
              //        //console.log(params);
              //        itemToSave.status = 'clôturée';
              //        params.ItemsToSave = [itemToSave];

              //        // Enregistrer
              //        moduleServiceWeb.SaveProjectTasks(params, function (response) {
              //            if (!response.HasError) {
              //                // Faire ici les traitements si aucune erreur trouvée
              //                $modalInstance.close(response.Data);
              //            }
              //        });
              //    } else {
              //        $modalInstance.close(itemToSave);
              //    }
              //};


          }
    ]);




});




