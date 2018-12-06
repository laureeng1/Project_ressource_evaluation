
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-models', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#region Type Partenaire
    app.controller('collaboratorListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, erpDialogs) {
            var advancedTable = null;


            //// Lance une fenetre modale de modification/ajout
            //$scope.editItem = function (item) {
            //    var data = { item: item };
            //    var dlg = moduleFrmModal.Show(data);

            //    dlg.result.then(function (response) {
            //        advancedTable.refreshItems();
            //    }, function (obj) {
            //        // ne rien faire pour l'instant

            //    });
            //};

            domPolymer.addEventListener('collaborator-advanced-table-loaded', function () {
                advancedTable = document.querySelector('#collaborator-advanced-table');

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
                        fieldSearch: 'nom',
                        fieldResult: 'nom',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: true
                    },
                        {
                            title: 'Prenoms',
                            fieldSearch: 'prenoms',
                            fieldResult: 'prenoms',
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

                    moduleServiceWeb.GetUsers(
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

                //advancedTable.addEventListener('modify-item', function (e) {
                //    var msg = e.detail.msg;
                //    if (msg.idInstance !== advancedTable.idInstance)
                //        return;

                //    $scope.editItem(msg.item);
                //});
                //advancedTable.addEventListener('delete-item', function (e) {
                //    var msg = e.detail.msg;

                //    if (msg.idInstance !== advancedTable.idInstance)
                //        return;

                //    // sauvegarder l'item original
                //    var itemToSaveCopie = msg.item;

                //    // préparer l'item à sauvegarder

                //    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                //        // préparer la requête d'enregistrement
                //        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression de projet", 'Suppression effectué avec succès!', true);

                //        params.ItemsToSave = [itemToSaveCopie];

                //        // Enregistrer
                //        moduleServiceWeb.DeleteFscollaborators(params, function (response) {
                //            if (!response.HasError) {
                //                // Faire ici les traitements si aucune erreur trouvée
                //                advancedTable.refreshItems();
                //            }
                //        });
                //    }, function () {

                //    }, "Suppression de projet");
                //});

                advancedTable.addEventListener('show-details', function (e) {
                    // charger données ou affecter details à l'objet de binding   
                    var msg = e.detail.msg;

                    if (msg.idInstance !== advancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;

                    $scope.$apply(function () {
                        $scope.index = item.idRow;

                        $scope.$broadcast("collaborator-advanced-table-show-details", { detail: item });

                    });

                });

                advancedTable.refreshItems();
            });

            $scope.disponibility = function (startDate, endDate) {
                var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                // params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);
                params2.ItemToSearch = new moduleModels.ProjectTask();
                params.ItemToSearch.idCurrentCollaborator = currentCollaborator.id;
                moduleServiceWeb.GetCollaboratorTasks(
                    params,
                    function (response) {

                        if (!response.HasError) {
                            taskTable.setItems(response.Data.items, response.Data.count);
                        }
                    },
                    function (error) {

                    }
                );
            };

            var init = function () {

            };

            init();
        }
    ]);
    //#endregion


    app.controller('collaboratorTaskListCtrl', [
     '$scope',
        '$filter',
        'Security',
     'commonUtilities',
     'devEvalServices',
     'taskModal',
        'prolongationActionModal',
        'rejectionActionModal',
        'bruitActionModal',
        'devEvalModels',
     'erpDialogs',
     function ($scope, $filter, security, commonUtilities, moduleServiceWeb, taskFrmModal, prolongationActionFrmModal, rejectionActionFrmModal, bruitActionFrmModal, moduleModels, erpDialogs) {
         //$scope.events = [];
         //$scope.event = null;
         //$scope.seeList = false;
         var advancedTable = null;
         // alert(JSON.stringify(security.currentUser()));
         // security.logoutUser();
         $scope.currentLoggedUser = security.currentUser();
         //$scope.titreRdv = 'Mensuel';
         // $scope.personnelMedicalToSearch = new moduleModels.ViewPersonnelMedical();
         // $scope.patientToSearch = new moduleModels.ViewPatient();

         //periode calcul par default
         //var date = new Date();
         //var y = date.getFullYear();
         //var m = date.getMonth();
         //var d = date.getDate();
         //$scope.weeksOfMonth = getWeeksInMonth(m, y);
         //$scope.periodeDeb = $filter('dateJson')(new Date(y, m, $scope.weeksOfMonth[0].start));
         //$scope.periodeFin = $filter('dateJson')(new Date(y, m, $scope.weeksOfMonth[0].end));

         var taskTable = null;
         var currentCollaborator = null;
         $scope.collaborators = null;
         $scope.period = {
             startDate: null,
             endDate: null
         }

         $scope.status = {
             isOpen: false
         };

         $scope.statusCalendar = {
             isOpen: false
         };

         var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);
         moduleServiceWeb.GetUsers(
             params,
             function (response) {
                 if (!response.HasError) {
                     $scope.collaborators = response.Data.items;
                 }
             },
             function (error) {

             }
         );

         $scope.$on('collaborator-advanced-table-show-details', function (event, data) {
             currentCollaborator = data.detail;
             $scope.idCurrentCollaborator = currentCollaborator.id;
             $scope.isInitialized = false;
             $scope.status.isOpen = false;
             $scope.isDispo = null;
             //$scope.startDate = null;
             //$scope.endDate = null;
             $scope.period = {
                 startDate: null,
                 endDate: null
             }
             $scope.hebdoNote = "Cliquez sur le bouton pour calculer la moyenne d'une p&eacute;riode";
             $scope.hebdoNoter();
             $scope.disponibility();
         });

         var changeTitle = function (isOpen) {
             if (isOpen) {
                 $scope.title = "Liste des tâches (cliquer pour réduire)";
             } else {
                 $scope.title = "Liste des tâches (cliquer pour dérouler)";
             }
         };

         var configurerAdvancedTable = function () {
             taskTable = document.querySelector('#task-advanced-table');

             taskTable.tableOptions = {

                 tableIsSimple: false,
                 tableIsBasic: true,
                 sortDescending: true,
                 enableColModify: false,
                 enableColDelete: false,
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
                         title: 'Status',
                         fieldSearch: 'status',
                         fieldResult: 'status',
                         defaultFieldSearch: true,
                         isCriteria: true,
                         defaultSort: false
                     },
                     {
                         title: 'Note',
                         fieldSearch: 'note',
                         fieldResult: 'note',
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

                 params.ItemToSearch.idCurrentCollaborator = currentCollaborator.id;
                 moduleServiceWeb.GetCollaboratorTasks(
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
                 $scope.item = item;
                 $scope.$apply(function () {
                     $scope.index = item.idRow;
                     //$scope.taskStatus = item.status;
                     //$scope.$broadcast("task-show-details", { detail: item });
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


         /// Annulation de l'enregistrement
         $scope.refuse = function (itemToSave) {

             var data = { idProjectTask: itemToSave.id };

             var dlg = rejectionActionFrmModal.Show(data);

             dlg.result.then(function (response) {
                 if (taskTable == null) // configurer le composant
                     configurerAdvancedTable();
                 taskTable.refreshItems();
             }, function (obj) {
                 // ne rien faire pour l'instant
             });
         };

         $scope.prolongation = function (itemToSave) {

             var data = { projectTask: itemToSave };

             var dlg = prolongationActionFrmModal.Show(data);

             dlg.result.then(function (response) {
                 if (taskTable == null) // configurer le composant
                     configurerAdvancedTable();
                 taskTable.refreshItems();
             }, function (obj) {
                 // ne rien faire pour l'instant
             });
         };

         $scope.noise = function (itemToSave) {

             var data = { projectTask: itemToSave };

             var dlg = bruitActionFrmModal.Show(data);

             dlg.result.then(function (response) {
                 if (taskTable == null) // configurer le composant
                     configurerAdvancedTable();
                 taskTable.refreshItems();
             }, function (obj) {
                 // ne rien faire pour l'instant
             });
         };

         $scope.start = function (itemToSave) {
             // préparer la requête d'enregistrement
             var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Démarrer une tâche", 'La tâche a été démarrée avec succès!', true);
             params.IdCurrentUser = $scope.currentLoggedUser.IdUtilisateur;
             // Mettre à jour le status de la tâche
             //console.log(params);
             itemToSave.status = 'en cours';
             params.ItemsToSave = [itemToSave];

             // Enregistrer
             moduleServiceWeb.SaveProjectTasks(params, function (response) {
                 if (!response.HasError) {
                     // Faire ici les traitements si aucune erreur trouvée
                     if (taskTable == null) // configurer le composant
                         configurerAdvancedTable();
                     taskTable.refreshItems();
                 }
             });

         };

         // Suspendre la tâche
         $scope.pend = function (itemToSave) {

             // préparer la requête d'enregistrement
             var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suspendre une tâche", 'La tâche a été suspendue avec succès!', true);
             params.IdCurrentUser = $scope.currentLoggedUser.IdUtilisateur;
             // Mettre à jour le status de la tâche
             //console.log(params);
             itemToSave.status = 'suspendue';
             params.ItemsToSave = [itemToSave];

             // Enregistrer
             moduleServiceWeb.SaveProjectTasks(params, function (response) {
                 if (!response.HasError) {
                     // Faire ici les traitements si aucune erreur trouvée
                     if (taskTable == null) // configurer le composant
                         configurerAdvancedTable();
                     taskTable.refreshItems();
                 }
             });

         };

         $scope.accept = function (itemToSave) {

             erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {

                 // préparer la requête d'enregistrement
                 var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Valider une tâche", 'La tâche a été validée avec succès!', true);
                 params.IdCurrentUser = $scope.currentLoggedUser.IdUtilisateur;
                 // Mettre à jour le status de la tâche
                 itemToSave.status = 'clôturée';
                 params.ItemsToSave = [itemToSave];

                 // Enregistrer
                 moduleServiceWeb.SaveProjectTasks(params, function (response) {
                     if (!response.HasError) {
                         // Faire ici les traitements si aucune erreur trouvée
                         if (taskTable == null) // configurer le composant
                             configurerAdvancedTable();
                         taskTable.refreshItems();
                     }
                 });
             }, function () {

             }, "Valider une tâche");
         };

         $scope.abort = function (itemToSave) {

             erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {

                 // préparer la requête d'enregistrement
                 var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Annuler une tâche", 'La tâche a été annulée avec succès!', true);
                 params.IdCurrentUser = $scope.currentLoggedUser.IdUtilisateur;
                 // Mettre à jour le status de la tâche
                 itemToSave.status = 'annulée';
                 params.ItemsToSave = [itemToSave];

                 // Enregistrer
                 moduleServiceWeb.SaveProjectTasks(params, function (response) {
                     if (!response.HasError) {
                         // Faire ici les traitements si aucune erreur trouvée
                         if (taskTable == null) // configurer le composant
                             configurerAdvancedTable();
                         taskTable.refreshItems();
                     }
                 });
             }, function () {

             }, "Annuler une tâche");
         };

         // Fullcalendar

         ///* event source that contains custom events on the scope */
         //var loadTask = function () {
         //    $scope.event = null;
         //    var params = new commonUtilities.RequestSw(0, 0, true, 0, false, null, null, true);

         //    params.ItemToSearch = new moduleModels.ProjectTask();
         //    //if (!commonUtilities.IsUndefinedOrNull($scope.personnelMedicalToSearch.IdPersonnelMedical))
         //    //    params.ItemToSearch.IdMedecin = $scope.personnelMedicalToSearch.IdPersonnelMedical;
         //    if (!commonUtilities.IsUndefinedOrNull($scope.idCurrentCollaborator))
         //        params.ItemToSearch.IdCurrentCollaborator = $scope.idCurrentCollaborator;
         //    params.SearchByPeriode = true;
         //    params.DateDebutRdv = $scope.periodeDeb;
         //    params.DateFinRdv = $scope.periodeFin;

         //    moduleServiceWeb.GetCollaboratorTasks(
         //        params,
         //        function (response) {
         //            $scope.events.length = 0;
         //            $scope.dataResult = Enumerable.From(response.Data.Items).Select(function (z) {
         //                var y = new moduleModels.ProjectTask(z);
         //                y.id = z.Id;
         //                y.start = toDate(z.Deadline, "h:m", $filter('jsonDateUtc')(z.Deadline));
         //                y.end = toDate(z.Deadline, "h:m", $filter('jsonDateUtc')(z.Deadline));
         //                y.title = z.Label;
         //                // y.details = z.Identite;
         //                if (z.Statut == "en cours") {
         //                    y.color = "#FFA500";
         //                }
         //                if (z.Statut == "en validation") {
         //                    y.color = "#FFA500";
         //                }
         //                if (z.Statut == "annulée") {
         //                    y.color = "#FFA500";
         //                }
         //                if (z.Statut == "suspendue") {
         //                    y.color = "#FFA500";
         //                }
         //                $scope.events.push(y);
         //                return y;
         //            }).ToArray();
         //        },
         //        function (error) {

         //        }
         //    );
         //};

         ///* config object */
         //$scope.uiConfig = {
         //    calendar: {
         //        height: 450,
         //        editable: true,
         //        header: {
         //            left: '',
         //            center: 'title',
         //            right: ''
         //        },
         //        //eventClick: $scope.alertOnEventClick,
         //        //eventDrop: $scope.alertOnDrop,
         //        //eventResize: $scope.alertOnResize,
         //        //eventMouseover: $scope.alertOnMouseOver,
         //        dayNames: ["Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi"],
         //        dayNamesShort: ["Dim", "Lun", "Mar", "Mer", "Jeu", "Vend", "Sam"],
         //        monthNames: ["Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"],
         //        montNamesShort: ["Jan", "Feb", "Mar", "Avr", "Mai", "Jun", "Jul", "Aou", "Sep", "Oct", "Nov", "Dec"]
         //    }
         //};

         ///*calculate week of month*/

         //function getWeeksInMonth(month, year) {
         //    var weeks = [],
         //        firstDate = new Date(year, month, 1),
         //        lastDate = new Date(year, month + 1, 0),
         //        numDays = lastDate.getDate();

         //    var start = 1;
         //    var end = 7 - firstDate.getDay();
         //    while (start <= numDays) {
         //        weeks.push({ start: start, end: end });
         //        start = end + 1;
         //        end = end + 7;
         //        if (end > numDays)
         //            end = numDays;
         //    }
         //    return weeks;
         //}

         ///* event sources array*/
         //$scope.eventSources = [$scope.events];

         ///* Change View */
         ////$scope.changeView = function (view, calendar) {
         ////    calendar.fullCalendar('changeView', view);
         ////};

         //$scope.today = function (calendar) {
         //    calendar.fullCalendar('today');
         //};

         //$scope.renderCalender = function (calendar) {
         //    if (calendar) {
         //        calendar.fullCalendar('render');
         //    }
         //};



         $scope.disponibility = function () {
             var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);
             // params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);
             params2.ItemToSearch = new moduleModels.ProjectTask();

             params2.ItemToSearch.idCurrentCollaborator = currentCollaborator.id;
             // alert(JSON.stringify(params2.ItemToSearch));
             if ($scope.period.startDate !== null && $scope.period.endDate === null) {
                 params2.ItemToSearch.deadline = new Date("January 31 2999 12:30");
                 params2.ItemToSearch.dateStarted = $scope.period.startDate;
             }
             else if ($scope.period.startDate === null && $scope.period.endDate !== null) {
                 params2.ItemToSearch.deadline = $scope.period.endDate;
                 params2.ItemToSearch.dateStarted = new Date("January 31 1980 12:30");
             } else if ($scope.period.startDate !== null && $scope.period.endDate !== null) {
                 params2.ItemToSearch.deadline = $scope.period.endDate;
                 params2.ItemToSearch.dateStarted = $scope.period.startDate;
             } else {
                 params2.ItemToSearch.deadline = new Date("January 31 2999 12:30");
                 params2.ItemToSearch.dateStarted = new Date("January 31 1990 12:30");
             }
             //alert(JSON.stringify(params2.ItemToSearch));
             moduleServiceWeb.GetvCollaboratorTasksByPeriod(
                 params2,
                 function (response) {
                     if (!response.HasError) {
                         if (response.Data.items.length > 0)
                             $scope.isDispo = false;
                         else {
                             $scope.isDispo = true;
                         }
                     }
                 },
                 function (error) {
                 }
             );
         };

         $scope.hebdoNoter = function () {
             var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);
             // params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);
             params2.ItemToSearch = new moduleModels.ProjectTask();
             params2.ItemToSearch.idCurrentCollaborator = currentCollaborator.id;

             if ($scope.period.startDate !== null && $scope.period.endDate === null) {
                 params2.ItemToSearch.deadline = new Date("January 31 2999 12:30");
                 params2.ItemToSearch.dateStarted = $scope.period.startDate;
             }
             else if ($scope.period.startDate === null && $scope.period.endDate !== null) {
                 params2.ItemToSearch.deadline = $scope.period.endDate;
                 params2.ItemToSearch.dateStarted = new Date("January 31 1980 12:30");
             } else if ($scope.period.startDate !== null && $scope.period.endDate !== null) {
                 params2.ItemToSearch.deadline = $scope.period.endDate;
                 params2.ItemToSearch.dateStarted = $scope.period.startDate;
             } else {
                 params2.ItemToSearch.deadline = new Date("January 31 2999 12:30");
                 params2.ItemToSearch.dateStarted = new Date("January 31 1990 12:30");
             }

             moduleServiceWeb.GetvCollaboratorTasksByPeriod(
                 params2,
                 function (response) {
                     if (!response.HasError) {
                         if (response.Data.items.length > 0) {
                             var cumulNotes = 0.0;
                             response.Data.items.forEach(el => {
                                 cumulNotes = cumulNotes + el.note;
                             });
                             $scope.hebdoNote = cumulNotes / response.Data.items.length;
                         } else {
                             $scope.hebdoNote = "Aucune moyenne trouvée pour cette période.";
                         }
                     }
                 },
                 function (error) {
                 }
             );
         };


     }
    ]);




    //app.controller('collaboratorTaskListCtrl2', [
    //     '$scope',
    //     'commonUtilities',
    //     'devEvalServices',
    //    'taskModal',
    //     'erpDialogs',
    //     function ($scope, commonUtilities, moduleServiceWeb, taskFrmModal, erpDialogs) {
    //         var taskTable = null;
    //         var currentCollaborator = null;
    //         $scope.status = {
    //             isOpen: false
    //         };
    //         $scope.$on('collaborator-advanced-table-show-details', function (event, data) {
    //             // alert(JSON.stringify(data.detail));
    //             currentCollaborator = data.detail;
    //             // $scope.collaborator = currentCollaborator;
    //             $scope.isInitialized = false;
    //             $scope.status.isOpen = false;
    //         });
    //         var changeTitle = function (isOpen) {
    //             if (isOpen) {
    //                 $scope.title = "Liste des tâches (cliquer pour réduire)";
    //             } else {
    //                 $scope.title = "Liste des tâches (cliquer pour dérouler)";
    //             }
    //         };
    //         var configurerAdvancedTable = function () {
    //             taskTable = document.querySelector('#task-advanced-table');
    //             taskTable.tableOptions = {
    //                 tableIsSimple: false,
    //                 tableIsBasic: true,
    //                 sortDescending: true,
    //                 enableColModify: true,
    //                 enableColDelete: true,
    //                 multiChecked: true,
    //                 paginationParams: {
    //                     perPage: 15,
    //                     currentPage: 1,
    //                     count: 0
    //                 },
    //                 columns: [
    //                      {
    //                          title: 'Libelle',
    //                          fieldSearch: 'label',
    //                          fieldResult: 'label',
    //                          defaultFieldSearch: true,
    //                          isCriteria: true,
    //                          defaultSort: false
    //                      },
    //                     {
    //                         title: 'Durée planifiée',
    //                         fieldSearch: 'timePlanned',
    //                         fieldResult: 'timePlanned',
    //                         defaultFieldSearch: true,
    //                         isCriteria: true,
    //                         defaultSort: false
    //                     },
    //                     {
    //                         title: 'Durée restant',
    //                         fieldSearch: 'timeRemaining',
    //                         fieldResult: 'timeRemaining',
    //                         defaultFieldSearch: true,
    //                         isCriteria: true,
    //                         defaultSort: false
    //                     },
    //                     {
    //                         title: 'Date de fin',
    //                         fieldSearch: 'deadline',
    //                         fieldResult: 'deadline',
    //                         defaultFieldSearch: true,
    //                         isCriteria: true,
    //                         defaultSort: false
    //                     },
    //                     {
    //                         title: 'Status',
    //                         fieldSearch: 'status',
    //                         fieldResult: 'status',
    //                         defaultFieldSearch: true,
    //                         isCriteria: true,
    //                         defaultSort: false
    //                     }
    //                 ]
    //             };
    //             taskTable.addEventListener('load-items', function (e) {
    //                 var msg = e.detail.msg;
    //                 if (msg.idInstance !== taskTable.idInstance)
    //                     return;
    //                 var index = msg.paginationParams.positionDebut - 1;
    //                 var size = msg.paginationParams.perPage;
    //                 var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
    //                 params.ItemToSearch = taskTable.factorRequest({}, msg.criterias);
    //                 // alert(currentCollaborator.id);
    //                 params.ItemToSearch.idCurrentCollaborator = currentCollaborator.id;
    //                 // alert(JSON.stringify(params));
    //                 moduleServiceWeb.GetCollaboratorTasks(
    //                     params,
    //                     function (response) {
    //                         if (!response.HasError) {
    //                             taskTable.setItems(response.Data.items, response.Data.count);
    //                         }
    //                     },
    //                     function (error) {
    //                     }
    //                 );
    //             });
    //             taskTable.addEventListener('modify-item', function (e) {
    //                 var msg = e.detail.msg;
    //                 if (msg.idInstance !== taskTable.idInstance)
    //                     return;
    //                 $scope.editItem(msg.item);
    //             });
    //             //taskTable.addEventListener('show-details', function (e) {
    //             //    // charger données ou affecter details à l'objet de binding   
    //             //    var msg = e.detail.msg;
    //             //    if (msg.idInstance !== taskTable.idInstance)
    //             //        return;
    //             //    var item = e.detail.msg.currentItem;
    //             //    $scope.$apply(function () {
    //             //        $scope.index = item.idRow;
    //             //        $scope.taskStatus = item.status;
    //             //        $scope.$broadcast("task-show-details", { detail: item });
    //             //    });
    //             //});
    //         };
    //         $scope.$watch("status.isOpen", function (newValue, oldValue) {
    //             changeTitle($scope.status.isOpen);
    //             if (!$scope.isInitialized && $scope.status.isOpen) {
    //                 if (taskTable == null) // configurer le composant
    //                     configurerAdvancedTable();
    //                 taskTable.loadItems();
    //                 $scope.isInitialized = true;
    //             }
    //         });
    //         /// Lance une fenetre modale de modification/ajout
    //         //$scope.editItem = function (item) {
    //         //    var data = { item: item };
    //         //    //var dlg = trancheModal.Show(data);
    //         //    dlg.result.then(function (response) {
    //         //        trancheTable.refreshItems();
    //         //    }, function (obj) {
    //         //        // ne rien faire pour l'instant
    //         //    });
    //         //};
    //         // Lance une fenetre modale de modification/ajout
    //         $scope.editItem = function (item) {
    //             var data = { item: item, idCollaborator: currentCollaborator.id };
    //             var dlg = taskFrmModal.Show(data);
    //             dlg.result.then(function (response) {
    //                 taskTable.refreshItems();
    //             }, function (obj) {
    //                 // ne rien faire pour l'instant
    //             });
    //         };
    //     }
    //]);

    //app.controller('collaboratorListTaskDetailsCtrl', [
    //      '$scope',
    //      'commonUtilities',
    //      'devEvalServices',
    //      'rejectionActionModal',
    //      'prolongationActionModal',
    //      'erpDialogs',
    //      function ($scope, commonUtilities, moduleServiceWeb, rejectionActionFrmModal, prolongationActionFrmModal, erpDialogs) {

    //          var currentTask = null;
    //          var taskTable = document.querySelector('#tache-advanced-table');
    //          // $scope.collaboratorActionsList = null;

    //          $scope.status = {
    //              isOpen: false
    //          };

    //          $scope.$on('task-show-details', function (event, data) {
    //              currentTask = data.detail;
    //              var params = new commonUtilities.RequestSw(0, 30, false, 0, false, null, null, true);
    //              params.ItemToSearch = taskTable.factorRequest({}, []);
    //              params.ItemToSearch.idcollaboratorTask = currentTask.id;
    //              //alert('task-advanced-table-show-details');

    //              params.ItemToSearch.idcollaboratorTask = currentTask.id;
    //              moduleServiceWeb.GetCollaboratorTaskActions(
    //                  params,
    //                  function (response) {
    //                      if (!response.HasError) {
    //                          // actionTable.setItems(response.Data.items, response.Data.count);
    //                          $scope.collaboratorActionsList = response.Data.items;
    //                          // alert(JSON.stringify($scope.collaboratorActionsList));
    //                      }
    //                  },
    //                  function (error) {

    //                  }
    //              );
    //          });

    //          // Valider et cloturer la tâche
    //          $scope.submit = function (itemToSave) {

    //              if ($scope.DoSaveItem) {
    //                  // sauvegarder l'item original
    //                  var itemToSaveCopie = angular.copy(itemToSave);

    //                  // préparer l'item à sauvegarder

    //                  // préparer la requête d'enregistrement
    //                  var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);

    //                  // Mettre à jour le status de la tâche
    //                  //console.log(params);
    //                  itemToSave.status = 'en validation';
    //                  params.ItemsToSave = [itemToSave];

    //                  // Enregistrer
    //                  moduleServiceWeb.SavecollaboratorTasks(params, function (response) {
    //                      if (!response.HasError) {
    //                          // Faire ici les traitements si aucune erreur trouvée
    //                          $modalInstance.close(response.Data);
    //                      }
    //                  });
    //              } else {
    //                  $modalInstance.close(itemToSave);
    //              }
    //          };

    //          /// Annulation de l'enregistrement
    //          $scope.refuse = function () {

    //              var data = { idcollaboratorTask: currentTask.id };

    //              var dlg = rejectionActionFrmModal.Show(data);

    //              dlg.result.then(function (response) {
    //                  taskTable.refreshItems();
    //              }, function (obj) {
    //                  // ne rien faire pour l'instant
    //              });
    //          };

    //          $scope.prolongation = function () {

    //              var data = { collaboratorTask: currentTask };

    //              var dlg = prolongationActionFrmModal.Show(data);

    //              dlg.result.then(function (response) {
    //                  taskTable.refreshItems();
    //              }, function (obj) {
    //                  // ne rien faire pour l'instant
    //              });
    //          };

    //          $scope.start = function () {

    //              // sauvegarder l'item original
    //              var itemToSave = angular.copy(currentTask);

    //              // préparer la requête d'enregistrement
    //              var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Démarrer une tâche", 'La tâche a été démarrée avec succès!', true);

    //              // Mettre à jour le status de la tâche
    //              //console.log(params);
    //              itemToSave.status = 'en cours';
    //              params.ItemsToSave = [itemToSave];

    //              // Enregistrer
    //              moduleServiceWeb.SavecollaboratorTasks(params, function (response) {
    //                  if (!response.HasError) {
    //                      // Faire ici les traitements si aucune erreur trouvée
    //                      taskTable.refreshItems();
    //                  }
    //              });

    //          };

    //          // Suspendre la tâche
    //          $scope.pend = function () {

    //              // sauvegarder l'item original
    //              var itemToSave = angular.copy(currentTask);

    //              // préparer la requête d'enregistrement
    //              var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suspendre une tâche", 'La tâche a été suspendue avec succès!', true);

    //              // Mettre à jour le status de la tâche
    //              //console.log(params);
    //              itemToSave.status = 'suspendue';
    //              params.ItemsToSave = [itemToSave];

    //              // Enregistrer
    //              moduleServiceWeb.SavecollaboratorTasks(params, function (response) {
    //                  if (!response.HasError) {
    //                      // Faire ici les traitements si aucune erreur trouvée
    //                      taskTable.refreshItems();
    //                  } 
    //              });

    //          };

    //          $scope.accept = function () {

    //              erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageEvent, function () {
    //                  // sauvegarder l'item original
    //                  var itemToSave = angular.copy(currentTask);

    //                  // préparer la requête d'enregistrement
    //                  var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Valider une tâche", 'La tâche a été validée avec succès!', true);

    //                  // Mettre à jour le status de la tâche
    //                  itemToSave.status = 'clôturée';
    //                  params.ItemsToSave = [itemToSave];

    //                  // Enregistrer
    //                  moduleServiceWeb.SavecollaboratorTasks(params, function (response) {
    //                      if (!response.HasError) {
    //                          // Faire ici les traitements si aucune erreur trouvée
    //                          advancedTable.refreshItems();
    //                      }
    //                  });
    //              }, function () {

    //              }, "Valider une tâche");


    //          };

    //          // Valider et cloturer la tâche
    //          //$scope.accept = function (itemToSave) {

    //          //    if ($scope.DoSaveItem) {
    //          //        // sauvegarder l'item original
    //          //        var itemToSaveCopie = angular.copy(itemToSave);

    //          //        // préparer l'item à sauvegarder

    //          //        // préparer la requête d'enregistrement
    //          //        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Enregistrer une tâche", 'Enregistrement effectué avec succès!', true);

    //          //        // Mettre à jour le status de la tâche
    //          //        //console.log(params);
    //          //        itemToSave.status = 'clôturée';
    //          //        params.ItemsToSave = [itemToSave];

    //          //        // Enregistrer
    //          //        moduleServiceWeb.SavecollaboratorTasks(params, function (response) {
    //          //            if (!response.HasError) {
    //          //                // Faire ici les traitements si aucune erreur trouvée
    //          //                $modalInstance.close(response.Data);
    //          //            }
    //          //        });
    //          //    } else {
    //          //        $modalInstance.close(itemToSave);
    //          //    }
    //          //};


    //      }
    //]);




});




