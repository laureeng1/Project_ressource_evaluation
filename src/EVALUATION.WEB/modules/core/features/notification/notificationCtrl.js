define(['app', 'Core-models', 'Core-scripts', 'utilities', 'erp-modal-services', 'Core-modal-services'], function (app) {
    'use strict';

    //#region notification
    app.controller('notificationCtrl', [
        '$scope',
        '$rootScope',
        'CoreModel',
        'commonUtilities',
        'securityService',
        'erpDialogs',
        'Security',
        '$state',
        function ($scope, $rootScope, moduleModels, commonUtilities, moduleServiceWeb, erpDialogs,security, $state) {
            var advancedTable = null;

            /// Lance une fenetre modale de modification/ajout
            $scope.editItem = function (itemToSave) {
                var params = new commonUtilities.RequestSw();
                params.ItemsToSave = [itemToSave];
                 moduleServiceWeb.NotificationIsClicked(
                    params, function (response) {
                        if (!response.HasError) {
                            $state.go(itemToSave.link);
                        }
                    },
                    function (error) {
                    }
                );
            };

            domPolymer.addEventListener('notification-advanced-table-loaded', function () {
                advancedTable = document.querySelector('#notification-advanced-table');

                advancedTable.tableOptions = {
                    tableIsSimple: true,
                    tableIsBasic: false,
                    sortDescending: true,
                    enableColModify: true,
                    enableColDelete: false,
                    multiChecked: false,
                    paginationParams: {
                        perPage: 5,
                        currentPage: 1,
                        count: 0
                    },
                    columns: [
                        {
                            title: 'Nom de la notification',
                            fieldSearch: 'notificationName',
                            fieldResult: 'notificationName',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        },
                        {
                            title: 'Lien',
                            fieldSearch: 'link',
                            fieldResult: 'link',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        },
                        {
                            title: 'Date de création',
                            fieldSearch: 'dateCreation',
                            fieldResult: 'dateCreation',
                            defaultFieldSearch: true,
                            isCriteria: true,
                            defaultSort: false
                        }
                    ]
                };
                advancedTable.addEventListener('load-items', function (e) {

                    if (e.detail.msg.idInstance != advancedTable.idInstance)
                        return;

                    var msg = e.detail.msg;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.itemtoSearch = {};
                   
                    params.itemtoSearch.UserId = security.currentUser().id;
                    params.itemtoSearch.IsClicked = false;
                    moduleServiceWeb.GetNotificationsByCriteria(
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
                    if (e.detail.msg.idInstance != advancedTable.idInstance)
                        return;

                    var msg = e.detail.msg;
                    $scope.editItem(msg.item);
                });
                advancedTable.addEventListener('delete-item', function (e) {
                    var msg = e.detail.msg;

                    // sauvegarder l'item original
                    var itemToSaveCopie = msg.item;

                    // préparer l'item à sauvegarder

                    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                        // préparer la requête d'enregistrement
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression utilisateur", 'Suppression effectuée avec succès!', true);

                        params.ItemsToSave = [itemToSaveCopie];

                        // Enregistrer
                        moduleServiceWeb.DeleteSecuriteUtisateur(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                advancedTable.refreshItems();
                            }
                        });
                    }, function () {

                    }, "Suppression utilisateur");
                });
                advancedTable.addEventListener('show-details', function (e) {
                    var msg = e.detail.msg;

                    if (e.detail.msg.idInstance !== advancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;
                });
                advancedTable.refreshItems();
            });
            var init = function () {
            };
            init();
        }
    ]);
    //#endregion
});




