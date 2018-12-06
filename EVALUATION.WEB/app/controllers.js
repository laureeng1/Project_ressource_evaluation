define(['angular-translate', 'utilities', 'angular-cookies', 'Core-scripts', 'erp-modal-services', 'erp-services'], function () {
    'use strict';
    /* Controllers */

    angular.module('app.controllers', ['pascalprecht.translate', 'ngCookies'])
        .controller('AppCtrl', [
            '$scope', '$translate', '$localStorage', '$window', 'Security', '$modal',
            function ($scope, $translate, $localStorage, $window, security, $modal) {

                // add 'ie' classes to html
                var isIE = !!navigator.userAgent.match(/MSIE/i);
                isIE && angular.element($window.document.body).addClass('ie');
                isSmartDevice($window) && angular.element($window.document.body).addClass('smart');

                // config
                $scope.app = {
                    name: 'EVALUATION APP',
                    version: '1.0',
                    client: '',
                    // for chart colors
                    color: {
                        primary: '#7266ba',
                        info: '#23b7e5',
                        success: '#27c24c',
                        warning: '#fad733',
                        danger: '#f05050',
                        light: '#e8eff0',
                        dark: '#3a3f51',
                        black: '#1c2b36'
                    },
                    settings: {
                        themeID: 1,
                        navbarHeaderColor: 'bg-black',
                        navbarCollapseColor: 'bg-black',
                        asideColor: 'bg-light dker b-r',
                        headerFixed: true,
                        asideFixed: true,
                        asideFolded: false
                    }
                };

                // save settings to local storage
                if (angular.isDefined($localStorage.settings)) {
                    $scope.app.settings = $localStorage.settings;
                } else {
                    $localStorage.settings = $scope.app.settings;
                }
                $scope.$watch('app.settings', function () { $localStorage.settings = $scope.app.settings; }, true);

                // angular translate
                $scope.langs = { fr_FR: 'Français' };
                $scope.selectLang = $scope.langs[$translate.proposedLanguage()] || "Français";
                $scope.setLang = function (langKey) {
                    // set the current lang
                    $scope.selectLang = $scope.langs[langKey];
                    // You can change the language during runtime
                    $translate.use(langKey);
                };

                function isSmartDevice($window) {
                    // Adapted from http://www.detectmobilebrowsers.com
                    var ua = $window['navigator']['userAgent'] || $window['navigator']['vendor'] || $window['opera'];
                    // Checks for iOs, Android, Blackberry, Opera Mini, and Windows mobile devices
                    return (/iPhone|iPod|iPad|Silk|Android|BlackBerry|Opera Mini|IEMobile/).test(ua);
                }

                //#region timer
                function closeModals() {
                    if ($scope.warning) {
                        $scope.warning.close();
                        $scope.warning = null;
                    }

                    if ($scope.timedout) {
                        $scope.timedout.close();
                        $scope.timedout = null;
                    }
                }

                $scope.$on("IdleStart", function () {
                    closeModals();
                    if (security.IsAuthentified()) {
                        $scope.warning = $modal.open({
                            templateUrl: "warning-dialog.html",
                            windowClass: "modal-danger"
                        });
                    }

                });

                $scope.$on("IdleEnd", function () {
                    closeModals();
                });

                $scope.$on("IdleTimeout", function () {
                    closeModals();
                    if (security.IsAuthentified()) {
                        security.SetTimeOutStatut(true);
                        security.showLockScreen();
                    }
                });



                if (security.IsTimedOut())
                    security.showLockScreen();

                document.body.style.zoom = "100%";

                //#endregion
            }
        ])
        .controller('MainViewCtrl', [
            '$scope', 'Security', 'erpDialogs', 'CoreEditPassword', '$state', '$window', '$rootScope', '$templateCache', function ($scope, security, erpDialogs, CoreEditPassword, $state, $window, $rootScope, $templateCache) {
                var mainSelf = this;
                mainSelf.user = security.currentUser();
                $scope.IsNetworkUnlimited = true;
                mainSelf.pageError = function () {
                    /*security.logoutUser();
                    erpDialogs.Error("Page Introuvable", "Erreur 404");*/
                    $state.go("app.error");
                };

                mainSelf.logout = function () {


                    $rootScope.$on('$viewContentLoaded', function () {

                        //$templateCache.removeAll();
                    });

                    security.logout();
                };



                $scope.$on('unlimited-network', function () {
                    ////console.log('connected');
                    $scope.IsNetworkUnlimited = true;
                });

                $scope.$on('limited-network', function () {
                    ////console.log('disconnected');
                    $scope.IsNetworkUnlimited = true;
                });



                $scope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
                    /*if (!security.hasPermission(toState.name) && toState.name != 'access.signin' && toState.name != 'app.error' && toState.name != 'app.notification') {
                        event.preventDefault();
                        mainSelf.pageError();
                    }*/
                });


                $scope.$on('$stateNotFound', function (event, transition) {
                    event.preventDefault();
                    mainSelf.pageError();

                });

                $scope.editPassword = function () {
                    var data = { item: security.currentUser() };
                    var dlg = CoreEditPassword.Show(data);
                    dlg.result.then(function (response) { }, function () { });
                }



            }
        ])
        .controller('NavCtrl', ['$scope', '$rootScope', 'commonUtilities', 'adminGeneratedCtrlService', 'CoreModel', 'Security', 'erpMenu',
        function ($scope, $rootScope, commonUtilities, adminGeneratedCtrlService, CoreModel, security, erpMenu) {

            erpMenu.getMenu().success(function (response) {
                $scope.menu = response.Data.menuElement;
            });
        }
    ])
        .controller('NotificationCtrl', ['$scope', '$rootScope', 'commonUtilities', 'securityService', 'CoreModel', 'editnotificationModal', 'Security', '$state',
            function ($scope, $rootScope, commonUtilities, moduleServiceWeb, CoreModel, editnotificationModal, security, $state) {
                // Create a proxy to signalr hub on web server. It reference the hub.
                var notifications = $.connection.notificationHub;

                var userId = security.currentUser().id;

                var loadContent = function (userId) {
                    var params = new commonUtilities.RequestSw(0, 1, true, 0, false, null, null, true);
                    params.itemtoSearch = {};
                    params.itemtoSearch.UserId = userId;
                    params.itemtoSearch.IsClicked = false;

                  
                };
                loadContent(userId);
                       
                // Notify to client with the recent updates from hub that broadcast messages.
                notifications.client.updateUserInformation = function (serverResponse) {
                    $scope.notifications = serverResponse;
                    
                    //$scope.notifList = angular.copy(Enumerable.From($scope.notifications).Where("$.UserId == " + userId + "&& $.IsClicked == " + false).Select("$"));
                   // $scope.notifList = angular.copy(Enumerable.From($scope.notifications).Where("$.UserId == " + userId).Select("$"));

                    $scope.notifList = angular.copy(Enumerable.From($scope.notifications)).Where(function (x) {
                        x.notificationId = x.NotificationId;
                        x.notificationName = x.NotificationName;
                        x.link = x.Link;
                        x.userId = x.UserId;
                        x.isClicked = x.IsClicked;
                        x.notificationContent = x.notificationContent;
                        
                        return x.UserId === userId;
                    }).Select(function (x) {
                        return x;
                    }).ToArray();

                     $scope.notificationsNbTotal = $scope.notifList.length;
                   

                    if (!commonUtilities.IsUndefinedOrNull($scope.notifications) && $scope.notificationsNbTotal > 0) {

                        var nbMessageAnc = commonUtilities.clone($scope.notificationsNbTotal);

                        if ($scope.notificationsNbTotal > nbMessageAnc) {
                            $scope.setAlert(true);
                            // signaler le nombre de notifications en cours 
                           // alert('changes triggered by ' + serverResponse + ' operation');
                            commonUtilities.ShowMessage("Notifications", "Vous avez " + $scope.notificationsNbTotal + " notification(s) en attente.");
                        }
                        if ($scope.notificationsNbTotal === 0)
                            $scope.setAlert(false);
                    }
                };

                $scope.showNotifications = function (itemToSave) {
                    var no = itemToSave;
                        var dlg = editnotificationModal.Show(no);
                    if (itemToSave.isClicked === false) {

                       
                        dlg.result.then(function (noToMarquerCommeLue) {
                            // marquer comme lue
                            //console.log(noToMarquerCommeLue);

                            var params = new commonUtilities.RequestSw();
                            //noToMarquerCommeLue.isClicked = true;
                            params.ItemsToSave = [];
                            params.ItemsToSave.push(noToMarquerCommeLue);

                        });
                
                        
                    }
                };

                $scope.getAllMyNotification = function () {
                    var params = new commonUtilities.RequestSw(0, 1, true, 0, false, null, null, true);
                    params.itemtoSearch = {};
                    params.itemtoSearch.UserId = userId;
                    params.itemtoSearch.IsClicked = false;
                   
                }

                // Connect to signalr hub
                $.connection.hub.start().done(function () {
                }).fail(function (error) {
                    alert(error);
                });

                //Afficher le modal pour marquer la notification comme lue

            }])
        // Flot Chart controller 
        .controller('FlotChartDemoCtrl', [
            '$scope', 'commonUtilities', 'dashboardService',function ($scope, commonUtilities, moduleServiceWeb) {
                $scope.d = [[1, 6.5], [2, 6.5], [3, 7], [4, 8], [5, 7.5], [6, 7], [7, 6.8], [8, 7], [9, 7.2], [10, 7], [11, 6.8], [12, 7]];

                $scope.d0_1 = [[0, 7], [1, 6.5], [2, 12.5], [3, 7], [4, 9], [5, 6], [6, 11], [7, 6.5], [8, 8], [9, 7]];

                $scope.d0_2 = [[0, 4], [1, 4.5], [2, 7], [3, 4.5], [4, 3], [5, 3.5], [6, 6], [7, 3], [8, 4], [9, 3]];

                $scope.d1_1 = [[10, 120], [20, 70], [30, 70], [40, 60]];

                $scope.d1_2 = [[10, 50], [20, 60], [30, 90], [40, 35]];

                $scope.d1_3 = [[10, 80], [20, 40], [30, 30], [40, 20]];

                $scope.d2 = [];

                $scope.refreshDemandePrestataire = false;

                for (var i = 0; i < 20; ++i) {
                    $scope.d2.push([i, Math.sin(i)]);
                }

                $scope.d3 = [
                    { label: "iPhone5S", data: 40 },
                    { label: "iPad Mini", data: 10 },
                    { label: "iPad Mini Retina", data: 20 },
                    { label: "iPhone4S", data: 12 },
                    { label: "iPad Air", data: 18 }
                ];

                $scope.getRandomData = function () {
                    var data = [],
                        totalPoints = 150;
                    if (data.length > 0)
                        data = data.slice(1);
                    while (data.length < totalPoints) {
                        var prev = data.length > 0 ? data[data.length - 1] : 50,
                            y = prev + Math.random() * 10 - 5;
                        if (y < 0) {
                            y = 0;
                        } else if (y > 100) {
                            y = 100;
                        }
                        data.push(y);
                    }
                    // Zip the generated y values with the x values
                    var res = [];
                    for (var i = 0; i < data.length; ++i) {
                        res.push([i, data[i]])
                    }
                    return res;
                }

                $scope.d4 = $scope.getRandomData();
              


            

                //Search input prestataire
       
                var selectionnerPrestataire = function (item) {
                    $scope.currentPrestataire = item;
                }


           
             


              
             


                var init = function () {
                   
                }

                init();




            }
        ]);
});