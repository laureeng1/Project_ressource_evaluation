define(['angular-translate', 'angular-cookies', 'admin-scripts', 'erp-modal-services'], function () {
    'use strict';

    /* Controllers */

    angular.module('app.controllers', ['pascalprecht.translate', 'ngCookies'])
        .controller('AppCtrl', [
            '$scope', '$translate', '$localStorage', '$window', 'Security', '$modal',
            function ($scope, $translate, $localStorage, $window, Security, $modal) {

                // add 'ie' classes to html
                var isIE = !!navigator.userAgent.match(/MSIE/i);
                isIE && angular.element($window.document.body).addClass('ie');
                isSmartDevice($window) && angular.element($window.document.body).addClass('smart');

                // config
                $scope.app = {
                    name: 'Atlantis ERP',
                    version: '1.0.0',
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
                        themeID: 8,
                        navbarHeaderColor: 'bg-info dker',
                        navbarCollapseColor: 'bg-info dker',
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
                $scope.$watch('app.settings', function() { $localStorage.settings = $scope.app.settings; }, true);

                // angular translate
                $scope.langs = { fr_FR: 'Français', en: 'English', de_DE: 'German', it_IT: 'Italian' };
                $scope.selectLang = $scope.langs[$translate.proposedLanguage()] || "Français";
                $scope.setLang = function(langKey) {
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

                $scope.$on('$idleStart', function () {
                    closeModals();
                    if (Security.IsAuthentified()) {
                        $scope.warning = $modal.open({
                            templateUrl: 'warning-dialog.html',
                            windowClass: 'modal-danger'
                        });
                    }

                });

                $scope.$on('$idleEnd', function () {
                    closeModals();
                });

                $scope.$on('$idleTimeout', function () {
                    closeModals();
                    if (Security.IsAuthentified()) {
                        Security.SetTimeOutStatut(true);
                        Security.showLockScreen();
                    }
                });

                if (Security.IsTimedOut())
                    Security.showLockScreen();                
                
                //#endregion
            }
        ])
        .controller('MainViewCtrl', [
            '$scope', 'Security', 'erpDialogs', function($scope, Security, erpDialogs) {
                this.user = Security.currentUser();

                this.logout = function() {
                    Security.logout();
                };

                $scope.$on('unlimited-network', function () {
                    //console.log('connected');
                    $scope.IsNetworkUnlimited = true;
                });

                $scope.$on('limited-network', function () {
                    //console.log('disconnected');
                    $scope.IsNetworkUnlimited = false;
                });
            }
        ])
    adminControllers.controller('NotificationCtrl', ['$scope', '$rootScope', 'commonUtilities', 'Notification', 'adminModel', 'Security', function ($scope, $rootScope, commonUtilities, Notification, adminModel, Security) {

        var dlg = null;
        var nbMessage = 0;
        var delay = 10000;
        var stopped = true;
        $scope.notifications = [];
    
        $scope.loadData = function () {
        
            if (!Security.IsAuthentified()) {
                $scope.stop();
                return;
            }            
        
            var params = new commonUtilities.RequestSw(0, 3, false, 0, false, null, null, false, false);
            params.Notification = new adminModel.Notification();
            params.Notification.AffichageTermine = false;
            params.Notification.IdUtilisateurCible = Security.currentUser().IdUtilisateur;

            Notification.query({ request: params }, function (response) {
                $rootScope.$broadcast("unlimited-network");

                $scope.notifications = response.Data.Notifications;

                if (!commonUtilities.IsUndefinedOrNull($scope.notifications) && $scope.notifications.length > 0) {
                
                    var nbMessageAnc = commonUtilities.clone(nbMessage);
                    nbMessage = $scope.notifications.length;

                    if (nbMessage > nbMessageAnc) {
                        $scope.setAlert(true);
                    
                        // signaler le nombre de notifications en cours 
                        commonUtilities.ShowMessage("Notifications", "Vous avez " + $scope.notifications.length + " notification(s) en attente.");
                    }

                    if (nbMessage == 0)
                        $scope.setAlert(false);                                
                }
            
                if (!stopped) {
                    setTimeout($scope.loadData, delay);
                }
            }, function (error) {
                $rootScope.$broadcast("limited-network");

                if (!stopped) {
                    setTimeout($scope.loadData, delay);
                }
            });
        };
    
        $scope.start = function () {
            stopped = false;
            $scope.loadData();
        };

        $scope.stop = function () {
            stopped = true;
        };
    
        $scope.startAlert = function () {
            //jQuery('#btn_notifications').pulsate({
            //    color: "#E74955"
            //});
        };

        $scope.stopAlert = function () {
            //jQuery('#btn_notifications').pulsate("destroy");
        };

        $scope.restartAlert = function () {
            $scope.stopAlert();
            $scope.startAlert();
        };

        $scope.setAlert = function (alert) {
            if (alert) {
                $scope.restartAlert();
            } else {
                $scope.stopAlert();
            }
        };
    
        $scope.showNotifications = function(no)
        {        
            dlg = FormShowNotifications.Create(no);
            dlg.result.then(function (noToMarquerCommeLue) {
                // marquer comme lue
                console.log(noToMarquerCommeLue);
            
                var params = new commonUtilities.RequestSw();
                noToMarquerCommeLue.AffichageTermine = true;
                params.Notifications = [];
                params.Notifications.push(noToMarquerCommeLue);
            
                Notification.save({ request: params }, function (response) {
                    // recharger les notifications

                    var notSaved = response.Data.Notifications[0];
                    for (var i = 0; i < $scope.notifications.length; i++) {
                        var not = $scope.notifications[i];
                    
                        if (not.IdNotification == notSaved.IdNotification) {
                            $scope.notifications.slice(i, 1);
                            break;
                        }                        
                    }
                });
            }, function () {
                // ne rien faire;
            });
        };

        if (Security.IsAuthentified()) {
            $scope.start();
            return;
        }        
    }])
        // Flot Chart controller 
        .controller('FlotChartDemoCtrl', [
            '$scope', function($scope) {
                $scope.d = [[1, 6.5], [2, 6.5], [3, 7], [4, 8], [5, 7.5], [6, 7], [7, 6.8], [8, 7], [9, 7.2], [10, 7], [11, 6.8], [12, 7]];

                $scope.d0_1 = [[0, 7], [1, 6.5], [2, 12.5], [3, 7], [4, 9], [5, 6], [6, 11], [7, 6.5], [8, 8], [9, 7]];

                $scope.d0_2 = [[0, 4], [1, 4.5], [2, 7], [3, 4.5], [4, 3], [5, 3.5], [6, 6], [7, 3], [8, 4], [9, 3]];

                $scope.d1_1 = [[10, 120], [20, 70], [30, 70], [40, 60]];

                $scope.d1_2 = [[10, 50], [20, 60], [30, 90], [40, 35]];

                $scope.d1_3 = [[10, 80], [20, 40], [30, 30], [40, 20]];

                $scope.d2 = [];

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

                $scope.getRandomData = function() {
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
            }
        ]);
});
