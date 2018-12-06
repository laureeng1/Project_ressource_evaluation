
define(['app', 'utilities', 'angular-dialog-service', 'crud-models', 'crud-services', 'crud-modal-services'], function (app) {

    'use strict';

   

    //#region Type Partenaire
    app.controller('crudTypePartenaireListCtrl', [
        '$scope',
        'commonUtilities',
        'crudServices',
        'crudModels',
        'crudTypePartenaireModal',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, moduleModels, moduleFrmModal, erpDialogs) {
            var advancedTable = null;

            /// Lance une fenetre modale de modification/ajout
            $scope.editItem = function (item) {
                var data = { item: item };
                var dlg = moduleFrmModal.Show(data);

                dlg.result.then(function (response) {
                    advancedTable.refreshItems();
                }, function (obj) {
                    // ne rien faire pour l'instant
                });
            };

            domPolymer.addEventListener('typePatenaire-advanced-table-loaded', function () {
                advancedTable = document.querySelector('#typePatenaire-advanced-table');

                advancedTable.tableOptions = {
                    

                    tableIsSimple: true,
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
                        title: 'Libelle',
                        fieldSearch: 'Libelle',
                        fieldResult: 'Libelle',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: false
                    }]
                };

                advancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    
                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = advancedTable.factorRequest(new moduleModels.FsTypePartenaire(), msg.criterias);

                    /*moduleServiceWeb.GetFsTypePartenairesByCriteria(
                        params,
                        function (response) {

                            if (!response.HasError) {
                                advancedTable.setItems(response.Data.Items, response.Count);
                            }
                        },
                        function (error) {

                        }
                    );*/
                });

                advancedTable.addEventListener('modify-item', function (e) {
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
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression type partenaire", 'Suppression effectué avec succès!', true);

                        params.ItemsToSave = [itemToSaveCopie];

                        // Enregistrer
                        moduleServiceWeb.DeleteFsTypePartenaires(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                advancedTable.refreshItems();
                            } 
                        });
                    }, function () {

                    }, "Suppression type partenaire");
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




   