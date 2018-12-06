
define(['app', 'utilities', 'angular-dialog-service', 'dev-eval-services', 'dev-eval-models', 'dev-eval-modal-services'], function (app) {

    'use strict';

    //#region User
    app.controller('userListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'userModal',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, moduleFrmModal, erpDialogs) {
            var userAdvancedTable = null;

            //$scope.roleCheck = function () {
            //    var result = false;
            //    $scope.currentLoggedUser.Permissions.forEach(ur => {
            //        if ('app.devEval.app.devEval.admin' === ur) {
            //            result = true;
            //        }
            //    });
            //    // alert(result);
            //    return result;
            //};

            //if (!$scope.roleCheck()) {
            //    $state.go("app.devEval.tasks");
            //}

            domPolymer.addEventListener('user-advanced-table-loaded', function () {
                userAdvancedTable = document.querySelector('#user-advanced-table');

                userAdvancedTable.tableOptions = {
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
                        },
                        {
                            title: 'Email',
                            fieldSearch: 'email',
                            fieldResult: 'email',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        },
                        {
                            title: 'Pseudo',
                            fieldSearch: 'userName',
                            fieldResult: 'userName',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        },
                        {
                            title: 'Tel',
                            fieldSearch: 'phoneNumber',
                            fieldResult: 'phoneNumber',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        }]
                };

                userAdvancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    // alert(JSON.stringify(msg));
                    if (msg.idInstance !== userAdvancedTable.idInstance)
                        return;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = userAdvancedTable.factorRequest({}, msg.criterias);
                    // alert(JSON.stringify(params));
                    moduleServiceWeb.GetUsers(
                        params,
                        function (response) {
                            if (!response.HasError) {
                                // console.log(response.Data.items);
                                userAdvancedTable.setItems(response.Data.items, response.Data.count);
                            }
                        },
                        function (error) {

                        }
                    );
                });

                userAdvancedTable.addEventListener('modify-item', function (e) {
                    var msg = e.detail.msg;
                    if (msg.idInstance !== userAdvancedTable.idInstance)
                        return;

                    $scope.editItem(msg.item);
                });
                userAdvancedTable.addEventListener('delete-item', function (e) {
                    var msg = e.detail.msg;

                    if (msg.idInstance !== userAdvancedTable.idInstance)
                        return;

                    // sauvegarder l'item original
                    var itemToSaveCopie = msg.item;

                    // préparer l'item à sauvegarder

                    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                        // préparer la requête d'enregistrement
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression d'utilisateurs", 'Suppression effectué avec succès!', true);

                        params.ItemsToSave = [itemToSaveCopie];

                        // Enregistrer
                        moduleServiceWeb.DeleteFsusers(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                userAdvancedTable.refreshItems();
                            }
                        });
                    }, function () {

                    }, "Suppression d'utilisateur");
                });

                userAdvancedTable.addEventListener('show-details', function (e) {
                    // charger données ou affecter details à l'objet de binding   
                    var msg = e.detail.msg;

                    if (msg.idInstance !== userAdvancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;

                    $scope.$apply(function () {
                        $scope.index = item.idRow;

                        $scope.$broadcast("user-advanced-table-show-details", { detail: item });

                    });

                });

                userAdvancedTable.refreshItems();
            });

            // Lance une fenetre modale de modification/ajout
            $scope.editItem = function (item) {
                var data = { item: item };
                var dlg = moduleFrmModal.Show(data);

                dlg.result.then(function (response) {
                    userAdvancedTable.refreshItems();
                }, function (obj) {
                    // ne rien faire pour l'instant

                });
            };

            var init = function () {

            };

            init();
        }
    ]);
    //#endregion

    //#region UserRoles
    app.controller('userRoleListCtrl', [
         '$scope',
         'commonUtilities',
         'devEvalServices',
         'devEvalModels',
         'erpDialogs',
         function ($scope, commonUtilities, moduleServiceWeb, moduleModels, erpDialogs) {
             var currentUser = null;

             $scope.roles = null;

             $scope.userRoles = [];

             var loadUserRoles = function () {
                 var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

                 params2.ItemToSearch = new moduleModels.UserRoles();
                 params2.ItemToSearch.UserId = currentUser.id;

                 moduleServiceWeb.GetUserRoles(
                     params2,
                     function (response) {
                         if (!response.HasError) {
                             $scope.userRoles = [];
                             response.Data.items.forEach(ur => {
                                 $scope.userRoles.push(ur.roleId);
                             });
                         }
                     },
                     function (error) {
                     }
                 );

             };

             var addUserRole = function (roleId) {
                 var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

                 var itemToSave = new moduleModels.UserRoles();
                 itemToSave.RoleId = roleId;
                 itemToSave.UserId = currentUser.id;

                 params.ItemsToSave = [itemToSave];

                 moduleServiceWeb.SaveUserRoles(
                     params,
                     function (response) {
                         if (!response.HasError) {
                             loadUserRoles();
                         }
                     },
                     function (error) {
                     }
                 );

             };

             var removeUserRole = function (roleId) {
                 var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);
                 var itemToSave = new moduleModels.UserRoles();
                 itemToSave.RoleId = roleId;
                 itemToSave.UserId = currentUser.id;
                 // itemToSave.IsDeleted = true;
                 params2.ItemsToSave = [itemToSave];
                 //params2.ItemToSearch = new moduleModels.UserRoles();
                 //params2.ItemToSearch.UserId = currentUser.id;
                 //params2.ItemToSearch.RoleId = roleId;
                 moduleServiceWeb.DeleteUserRoles(
                     params2,
                     function (response) {
                         if (!response.HasError) {
                             loadUserRoles();
                         }
                     },
                     function (error) {
                     }
                 );

             }

             $scope.status = {
                 isOpen: false
             };
             $scope.$on('user-advanced-table-show-details', function (event, data) {
                 currentUser = data.detail;
                 // alert(JSON.stringify(currentUser));
                 loadUserRoles();
                 $scope.idUser = currentUser.id;
                 $scope.isInitialized = false;
                 $scope.status.isOpen = false;
             });

             var changeTitle = function (isOpen) {
                 if (isOpen) {
                     $scope.title = "Liste des rôles (cliquer pour réduire)";
                 } else {
                     $scope.title = "Liste des rôles (cliquer pour dérouler)";
                 }
             };

             $scope.userRoleChecked = function (roleId) {
                 var result = false;
                 $scope.userRoles.forEach(ur => {
                     if (roleId === ur) {
                         result = true;
                     }
                 });
                 return result;
             };

             $scope.changeUserRoles = function (roleId) {
                 //alert(JSON.stringify(event));
                 // console.log(event);
                 if ($scope.userRoleChecked(roleId)) {
                     removeUserRole(roleId);
                     //alert("Supprimer roleId " + roleId);
                 } else {
                     addUserRole(roleId);
                     // alert("Ajouter roleId " + roleId);
                 }
             };

             $scope.$watch("status.isOpen", function (newValue, oldValue) {
                 changeTitle($scope.status.isOpen);

                 if (!$scope.isInitialized && $scope.status.isOpen) {
                     //if (taskTable == null) // configurer le composant
                     //    configurerAdvancedTable();

                     //taskTable.loadItems();
                     $scope.isInitialized = true;
                 }
             });


             var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

             moduleServiceWeb.GetRoles(
                 params,
                 function (response) {
                     if (!response.HasError) {
                         $scope.roles = response.Data.items;
                         // alert(JSON.stringify($scope.roles));
                     }
                 },
                 function (error) {

                 }
             );

         }
    ]);
    //#endregion

    //#region Role
    app.controller('roleListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'roleModal',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, moduleFrmModal, erpDialogs) {
            var roleAdvancedTable = null;

            domPolymer.addEventListener('role-advanced-table-loaded', function () {
                roleAdvancedTable = document.querySelector('#role-advanced-table');

                roleAdvancedTable.tableOptions = {
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
                        title: 'Nom Technique',
                        fieldSearch: 'name',
                        fieldResult: 'name',
                        defaultFieldSearch: true,
                        isCriteria: true,
                        defaultSort: true
                    },
                        {
                            title: 'Nom public',
                            fieldSearch: 'displayName',
                            fieldResult: 'displayName',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        }]
                };

                roleAdvancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    // alert(JSON.stringify(msg));
                    if (msg.idInstance !== roleAdvancedTable.idInstance)
                        return;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = roleAdvancedTable.factorRequest({}, msg.criterias);
                    // alert(JSON.stringify(params));
                    moduleServiceWeb.GetRoles(
                        params,
                        function (response) {
                            if (!response.HasError) {
                                // console.log(response.Data.items);
                                roleAdvancedTable.setItems(response.Data.items, response.Data.count);
                            }
                        },
                        function (error) {

                        }
                    );
                });

                roleAdvancedTable.addEventListener('modify-item', function (e) {
                    var msg = e.detail.msg;
                    if (msg.idInstance !== roleAdvancedTable.idInstance)
                        return;

                    $scope.editItem(msg.item);
                });
                roleAdvancedTable.addEventListener('delete-item', function (e) {
                    var msg = e.detail.msg;

                    if (msg.idInstance !== roleAdvancedTable.idInstance)
                        return;

                    // sauvegarder l'item original
                    var itemToSaveCopie = msg.item;

                    // préparer l'item à sauvegarder

                    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                        // préparer la requête d'enregistrement
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression d'utilisateurs", 'Suppression effectué avec succès!', true);
                        itemToSaveCopie.IsDeleted = true;
                        params.ItemsToSave = [itemToSaveCopie];

                        // Enregistrer
                        moduleServiceWeb.SaveRoles(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                roleAdvancedTable.refreshItems();
                            }
                        });
                    }, function () {

                    }, "Suppression de r&ocirc;le");
                });

                roleAdvancedTable.addEventListener('show-details', function (e) {
                    // charger données ou affecter details à l'objet de binding   
                    var msg = e.detail.msg;

                    if (msg.idInstance !== roleAdvancedTable.idInstance)
                        return;

                    var item = e.detail.msg.currentItem;

                    $scope.$apply(function () {
                        $scope.index = item.idRow;

                        $scope.$broadcast("role-advanced-table-show-details", { detail: item });

                    });

                });

                roleAdvancedTable.refreshItems();
            });

            // Lance une fenetre modale de modification/ajout
            $scope.editItem = function (item) {
                var data = { item: item };
                var dlg = moduleFrmModal.Show(data);

                dlg.result.then(function (response) {
                    roleAdvancedTable.refreshItems();
                }, function (obj) {
                    // ne rien faire pour l'instant

                });
            };

            var init = function () {

            };

            init();
        }
    ]);
    //#endregion


    //#region RolePermission
    app.controller('rolePermissionListCtrl', [
         '$scope',
         'commonUtilities',
         'devEvalServices',
         'devEvalModels',
         'erpDialogs',
         function ($scope, commonUtilities, moduleServiceWeb, moduleModels, erpDialogs) {
             var currentRole = null;

             $scope.permissions = null;

             $scope.rolePermissions = [];

             var loadRolePermissions = function () {
                 var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

                 params2.ItemToSearch = new moduleModels.RolePermissions();
                 params2.ItemToSearch.RoleId = currentRole.id;

                 moduleServiceWeb.GetRolePermissions(
                     params2,
                     function (response) {
                         if (!response.HasError) {
                             $scope.rolePermissions = [];
                             response.Data.items.forEach(ur => {
                                 $scope.rolePermissions.push(ur.permissionId);
                             });
                         }
                     },
                     function (error) {
                     }
                 );

             };

             var addRolePermission = function (permissionId) {
                 var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

                 var itemToSave = new moduleModels.RolePermissions();
                 itemToSave.RoleId = currentRole.id;
                 itemToSave.PermissionId = permissionId;
                 // alert(JSON.stringify(itemToSave));
                 params.ItemsToSave = [itemToSave];

                 moduleServiceWeb.SaveRolePermissions(
                     params,
                     function (response) {
                         if (!response.HasError) {
                             loadRolePermissions();
                         }
                     },
                     function (error) {
                     }
                 );

             };

             var removeRolePermission = function (permissionId) {
                 //var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

                 //params2.ItemToSearch = new moduleModels.UserRoles();
                 //params2.ItemToSearch.PermissionId = permissionId;
                 //params2.ItemToSearch.RoleId = currentRole.id;

                 var params2 = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);
                 var itemToSave = new moduleModels.RolePermissions();
                 itemToSave.RoleId = currentRole.id;
                 itemToSave.PermissionId = permissionId;
                 params2.ItemsToSave = [itemToSave];

                 moduleServiceWeb.DeleteRolePermissions(
                     params2,
                     function (response) {
                         if (!response.HasError) {
                             loadRolePermissions();
                         }
                     },
                     function (error) {
                     }
                 );

             }

             $scope.status = {
                 isOpen: false
             };
             $scope.$on('role-advanced-table-show-details', function (event, data) {
                 currentRole = data.detail;
                 // alert(JSON.stringify(currentUser));
                 loadRolePermissions();
                 //$scope.idUser = currentRole.id;
                 $scope.isInitialized = false;
                 $scope.status.isOpen = false;
             });

             var changeTitle = function (isOpen) {
                 if (isOpen) {
                     $scope.title = "Liste des permissions (cliquer pour réduire)";
                 } else {
                     $scope.title = "Liste des permissions (cliquer pour dérouler)";
                 }
             };

             $scope.rolePermissionChecked = function (permissionId) {
                 var result = false;
                 $scope.rolePermissions.forEach(ur => {
                     if (permissionId === ur) {
                         result = true;
                     }
                 });
                 // alert(result);
                 return result;
             };

             $scope.changeRolePermission = function (permissionId) {
                 //alert(JSON.stringify(event));
                 // console.log(event);
                 if ($scope.rolePermissionChecked(permissionId)) {
                     removeRolePermission(permissionId);
                     //alert("Supprimer roleId " + permissionId);
                 } else {
                     addRolePermission(permissionId);
                     //alert("Ajouter roleId " + permissionId);
                 }
             };

             $scope.$watch("status.isOpen", function (newValue, oldValue) {
                 changeTitle($scope.status.isOpen);

                 if (!$scope.isInitialized && $scope.status.isOpen) {
                     //if (taskTable == null) // configurer le composant
                     //    configurerAdvancedTable();

                     //taskTable.loadItems();
                     $scope.isInitialized = true;
                 }
             });


             var params = new commonUtilities.RequestSw(0, 20, false, 1, false, null, null, true);

             moduleServiceWeb.GetPermissions(
                 params,
                 function (response) {
                     if (!response.HasError) {
                         $scope.permissions = response.Data.items;
                         // alert(JSON.stringify($scope.roles));
                     }
                 },
                 function (error) {

                 }
             );

         }
    ]);
    //#endregion

    //#region Permission
    app.controller('permissionListCtrl', [
        '$scope',
        'commonUtilities',
        'devEvalServices',
        'permissionModal',
        'erpDialogs',
        function ($scope, commonUtilities, moduleServiceWeb, moduleFrmModal, erpDialogs) {
            var permissionsAdvancedTable = null;

            domPolymer.addEventListener('permission-advanced-table-loaded', function () {
                permissionsAdvancedTable = document.querySelector('#permission-advanced-table');

                permissionsAdvancedTable.tableOptions = {
                    tableIsSimple: true,
                    tableIsBasic: false,
                    sortDescending: true,
                    enableColModify: true,
                    enableColDelete: true,
                    multiChecked: true,
                    paginationParams: {
                        perPage: 25,
                        currentPage: 1,
                        count: 0
                    },
                    columns: [
                        {
                            title: 'Nom technique',
                            fieldSearch: 'name',
                            fieldResult: 'name',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        },
                        {
                            title: 'Nom public',
                            fieldSearch: 'displayName',
                            fieldResult: 'displayName',
                            defaultFieldSearch: false,
                            isCriteria: false,
                            defaultSort: false
                        }]
                };

                permissionsAdvancedTable.addEventListener('load-items', function (e) {
                    var msg = e.detail.msg;
                    // alert(JSON.stringify(msg));
                    if (msg.idInstance !== permissionsAdvancedTable.idInstance)
                        return;

                    var index = msg.paginationParams.positionDebut - 1;
                    var size = msg.paginationParams.perPage;
                    var params = new commonUtilities.RequestSw(index, size, msg.takeAll, 0, false, null, null, true);
                    params.ItemToSearch = permissionsAdvancedTable.factorRequest({}, msg.criterias);
                    // alert(JSON.stringify(params));
                    moduleServiceWeb.GetPermissions(
                        params,
                        function (response) {
                            if (!response.HasError) {
                                // console.log(response.Data.items);
                                permissionsAdvancedTable.setItems(response.Data.items, response.Data.count);
                            }
                        },
                        function (error) {

                        }
                    );
                });

                permissionsAdvancedTable.addEventListener('modify-item', function (e) {
                    var msg = e.detail.msg;
                    if (msg.idInstance !== permissionsAdvancedTable.idInstance)
                        return;

                    $scope.editItem(msg.item);
                });
                permissionsAdvancedTable.addEventListener('delete-item', function (e) {
                    var msg = e.detail.msg;

                    if (msg.idInstance !== permissionsAdvancedTable.idInstance)
                        return;

                    // sauvegarder l'item original
                    var itemToSaveCopie = msg.item;

                    // préparer l'item à sauvegarder

                    erpDialogs.Confirm(commonUtilities.GlobalEnum.MessageDelete, function () {
                        // préparer la requête d'enregistrement
                        var params = new commonUtilities.RequestSw(0, 1, false, 1, true, "Suppression d'utilisateurs", 'Suppression effectué avec succès!', true);

                        itemToSaveCopie.IsDeleted = true;
                        params.ItemsToSave = [itemToSaveCopie];

                        // Enregistrer
                        moduleServiceWeb.SavePermissions(params, function (response) {
                            if (!response.HasError) {
                                // Faire ici les traitements si aucune erreur trouvée
                                permissionsAdvancedTable.refreshItems();
                            }
                        });
                    }, function () {

                    }, "Suppression de permissions");
                });



                permissionsAdvancedTable.refreshItems();
            });

            // Lance une fenetre modale de modification/ajout
            $scope.editItem = function (item) {
                var data = { item: item };
                var dlg = moduleFrmModal.Show(data);

                dlg.result.then(function (response) {
                    permissionsAdvancedTable.refreshItems();
                }, function (obj) {
                    // ne rien faire pour l'instant

                });
            };

            var init = function () {

            };

            init();
        }
    ]);
    //#endregion




});




