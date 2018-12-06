
define
    ([
        'angular-dialog-service',
        'angular-resource',
        'angular-translate',
        'angular-ui-router',
        'angular-cookies',
        'angular-animate',
        'angular-sanitize',
        'html2-canvas',
        'jspdf-debug',
        'ng-storage',
        'ui-bootstrap',
        'ui-jq',
        'ui-load',
        'ui-validate',
        'app-controllers',
        'definitions',
        'utilities',
        'erp-directives',
        'Core-directives',
        'Core-scripts',
        'parameters',
        'linq-js',
        'oc-lazy-load',
        'angular-idle',
        'report-viewer',
        'kendo-all',
        'date-format-js',
        'ng-tags-input',
        'angular-multi-select',
        'moment',
        'calendar',
        'fullcalendar',
        'culture',
        'pivot-jquery-ui',
        'pivottable',
        'angular-pivottable',
        'jszip',
         'shim',
         'xlsx'
    ],
function () {
    
    'use strict';
    
        // Declare app level module which depends on filters, and services
        var app = angular.module('app', [
                'ui.bootstrap',
                'dialogs.main',
                'ngSanitize',
                'pascalprecht.translate',
                'ngAnimate',
                'ngCookies',
                'ngStorage',
                'ui.router',
                'ui.load',
                'ui.jq',
                'ui.validate',
                'app.controllers',
                'parameters',
                'EVALUATIONErpFilters',
                'EVALUATIONErpDirective',
                'EVALUATIONErpModals',
                'modelGlobal',
                'serviceGlobal',
                'CoreDirective',
                'CoreModels',
                'CoreServices',
                'CoreControllers',
                'CoreRouter',
                'utilities',
                'ngResource',
                'oc.lazyLoad',
                'erpRouter',
                'ngIdle',
                'ngTagsInput',
                'multi-select',
                'ui.calendar',
                'angular-pivottable',
            ]).run(
                [
                '$rootScope', '$state', '$stateParams', '$http', 'commonUtilities', 'Idle', '$location', '$timeout', '$templateCache',
                function ($rootScope, $state, $stateParams, $http, commonUtilities, Idle, $location, $timeout, $templateCache) {

                    $rootScope.$on('$viewContentLoaded', function () {

                        //$templateCache.removeAll();
                    });

                    $timeout(function () {
                            if (window.sessionStorage['currentUser'] == null) {
                                //$state.go("access.signin");
                                //$rootScope.$broadcast("logged_out");
                                $location.path("/access/signin");
                                return;
                            }else{
                               /* $state.transitionTo($state.current, $stateParams, {
                                    reload: true,
                                    inherit: false,
                                    notify: true
                                });*/
                                $state.go($state.current);
                            }
                        }, 1000);

						
                        // angular-ui-project recommends assigning these services to the root
                        // scope.  Others have argued that doing so can lead to obscured
                        // dependencies and that making services directly available to html and
                        // directives is unclean.  In any case, the ui-router demo assumes these
                        // are available in the DOM, therefore they should be on $rootScope.
                        $rootScope.$state = $state;
                        $rootScope.$stateParams = $stateParams;

                        // remarque : les transform sont ex�cut�s avant les intercepteurs
                        $http.defaults.transformRequest.unshift(commonUtilities.transRequest);
                        $http.defaults.transformResponse.unshift(commonUtilities.transResponse);

                        //initialise le timer
                        Idle.watch();
                    }
                ]
            )
            .config([
                '$ocLazyLoadProvider', '$controllerProvider', '$compileProvider', '$filterProvider', '$provide',
            function ($ocLazyLoadProvider, $controllerProvider, $compileProvider, $filterProvider, $provide) {

                    $ocLazyLoadProvider.config({
                        loadedModules: ['app'],
                        jsLoader: require,
                        debug: true
                    });

                    // lazy controller, directive and service
                    app.controller = $controllerProvider.register;
                    app.directive = $compileProvider.directive;
                    app.filter = $filterProvider.register;
                    app.factory = $provide.factory;
                    app.service = $provide.service;
                    app.constant = $provide.constant;
                    app.value = $provide.value;

                }
            ])
            .config(
                [
                    "KeepaliveProvider",
                    "IdleProvider",
                    function (keepaliveProvider, idleProvider) {

                        idleProvider.idle(1200); //seconde 
                        idleProvider.timeout(15); //second
                        //$keepaliveProvider.interval(10);
                    }
                ]
            )
            .config([
                '$translateProvider', function($translateProvider) {

                    //// Register a loader for the static files
                    //// So, the module will search missing translation tables under the specified urls.
                    //// Those urls are [prefix][langKey][suffix].
                    //$translateProvider.useStaticFilesLoader({
                    //    prefix: '/app/l10n/',
                    //    suffix: '.json'
                    //});

                    //francais
                    $translateProvider.translations('fr_FR', {
                            "header": {
                                "navbar": {
                                    "UPLOAD": "Upload",
                                    "new": {
                                        "NEW": "New",
                                        "PROJECT": "Projects",
                                        "TASK": "Task",
                                        "USER": "User",
                                        "EMAIL": "Email"
                                    },
                                    "NOTIFICATIONS": "Notifications"
                                }
                            },
                            "aside": {
                                "nav": {
                                    "HEADER": "Navigation",
                                    "REPORTING": "Reporting",
                                    "DASHBOARD": "Tableau de bord",
                                    "CALENDAR": "Calendrier",
                                    "EMAIL": "Courrier",
                                    "WIDGETS": "Widgets",
                                    "components": {
                                        "COMPONENTS": "Composants",
                                        "ui_kits": {
                                            "UI_KITS": "UI Kits",
                                            "BUTTONS": "Boutons",
                                            "ICONS": "Icons",
                                            "GRID": "Grille",
                                            "BOOTSTRAP": "Bootstrap",
                                            "SORTABLE": "Sortable",
                                            "PORTLET": "Portlet",
                                            "TIMELINE": "Timeline",
                                            "VECTOR_MAP": "Vector Map",
                                            "IMALI_TRESO": "Imali Tr�so",
                                            "MOYENS_GENERAUX": "Moyens g�n�raux",
                                            "SUIVI_BUDGETAIRE": "Suivi budg�taire",
                                            "CLINIQUE": "Clinique",
                                            "COMPTABILITE": "Comptabilit�",
                                            "GESTION_DE_STOCK": "Gestion de stock",
                                            "AIDE": "Aide",
                                            "Core": "Coreistration"
                                        },
                                        "table": {
                                            "TABLE": "Table",
                                            "TABLE_STATIC": "Table static",
                                            "DATATABLE": "Datatable",
                                            "FOOTABLE": "Footable"
                                        },
                                        "form": {
                                            "FORM": "Forme",
                                            "FORM_ELEMENTS": "Form elements",
                                            "FORM_VALIDATION": "Form validation",
                                            "FORM_WIZARD": "Form wizard"
                                        },
                                        "CHART": "Chart",
                                        "pages": {
                                            "PAGES": "Pages",
                                            "PROFILE": "Profile",
                                            "POST": "Post",
                                            "SEARCH": "Search",
                                            "INVOICE": "Invoice",
                                            "LOCK_SCREEN": "Lock screen",
                                            "SIGNIN": "Signin",
                                            "SIGNUP": "Signup",
                                            "FORGOT_PASSWORD": "Forgot password",
                                            "404": "404"
                                        }
                                    },
                                    "your_stuff": {
                                        "YOUR_STUFF": "Your Stuff",
                                        "PROFILE": "Profil",
                                        "DOCUMENTS": "Documents"
                                    }
                                },
                                "MILESTONE": "Milestone",
                                "RELEASE": "Release"
                            },
                            'DIALOGS_ERROR': "Erreur",
                            'DIALOGS_ERROR_MSG': "Une erreur inconnue est survenue.",
                            'DIALOGS_CLOSE': "Fermer",
                            'DIALOGS_PLEASE_WAIT': "Veillez patienter",
                            'DIALOGS_PLEASE_WAIT_ELIPS': "Veillez patienter...",
                            'DIALOGS_PLEASE_WAIT_MSG': "Veillez attendre la fin de l\'operation.",
                            'DIALOGS_PERCENT_COMPLETE': "% Complete",
                            'DIALOGS_NOTIFICATION': "Notification",
                            'DIALOGS_NOTIFICATION_MSG': "Notification d\'une application inconnue.",
                            'DIALOGS_CONFIRMATION': "Confirmation",
                            'DIALOGS_CONFIRMATION_MSG': "Confirmation requise.",
                            'DIALOGS_OK': "OK",
                            'DIALOGS_YES': "Oui",
                            'DIALOGS_NO': "Non"
                        }
                    );

                    $translateProvider.translations('en', {
                            "header": {
                                "navbar": {
                                    "UPLOAD": "Upload",
                                    "new": {
                                        "NEW": "New",
                                        "PROJECT": "Projects",
                                        "TASK": "Task",
                                        "USER": "User",
                                        "EMAIL": "Email"
                                    },
                                    "NOTIFICATIONS": "Notifications"
                                }
                            },
                            "aside": {
                                "nav": {
                                    "HEADER": "Navigation",
                                    "DASHBOARD": "Dashboard",
                                    "CALENDAR": "Calendar",
                                    "EMAIL": "Email",
                                    "WIDGETS": "Widgets",
                                    "components": {
                                        "COMPONENTS": "Components",
                                        "ui_kits": {
                                            "UI_KITS": "UI Kits",
                                            "BUTTONS": "Buttons",
                                            "ICONS": "Icons",
                                            "GRID": "Grid",
                                            "BOOTSTRAP": "Bootstrap",
                                            "SORTABLE": "Sortable",
                                            "PORTLET": "Portlet",
                                            "TIMELINE": "Timeline",
                                            "VECTOR_MAP": "Vector Map"
                                        },
                                        "table": {
                                            "TABLE": "Table",
                                            "TABLE_STATIC": "Table static",
                                            "DATATABLE": "Datatable",
                                            "FOOTABLE": "Footable"
                                        },
                                        "form": {
                                            "FORM": "Form",
                                            "FORM_ELEMENTS": "Form elements",
                                            "FORM_VALIDATION": "Form validation",
                                            "FORM_WIZARD": "Form wizard"
                                        },
                                        "CHART": "Chart",
                                        "pages": {
                                            "PAGES": "Pages",
                                            "PROFILE": "Profile",
                                            "POST": "Post",
                                            "SEARCH": "Search",
                                            "INVOICE": "Invoice",
                                            "LOCK_SCREEN": "Lock screen",
                                            "SIGNIN": "Signin",
                                            "SIGNUP": "Signup",
                                            "FORGOT_PASSWORD": "Forgot password",
                                            "404": "404"
                                        }
                                    },
                                    "your_stuff": {
                                        "YOUR_STUFF": "Your Stuff",
                                        "PROFILE": "Profile",
                                        "DOCUMENTS": "Documents"
                                    }
                                },
                                "MILESTONE": "Milestone",
                                "RELEASE": "Release"
                            },
                            DIALOGS_ERROR: "Error",
                            DIALOGS_ERROR_MSG: "An unknown error has occurred.",
                            DIALOGS_CLOSE: "Close",
                            DIALOGS_PLEASE_WAIT: "Please Wait",
                            DIALOGS_PLEASE_WAIT_ELIPS: "Please Wait...",
                            DIALOGS_PLEASE_WAIT_MSG: "Waiting on operation to complete.",
                            DIALOGS_PERCENT_COMPLETE: "% Complete",
                            DIALOGS_NOTIFICATION: "Notification",
                            DIALOGS_NOTIFICATION_MSG: "Unknown application notification.",
                            DIALOGS_CONFIRMATION: "Confirmation",
                            DIALOGS_CONFIRMATION_MSG: "Confirmation required.",
                            DIALOGS_OK: "OK",
                            DIALOGS_YES: "Yes",
                            DIALOGS_NO: "No"
                        }
                    );

                    $translateProvider.translations('de_DE', {
                            "header": {
                                "navbar": {
                                    "UPLOAD": "Upload",
                                    "new": {
                                        "NEW": "Neu",
                                        "PROJECT": "Projekte",
                                        "TASK": "Aufgabe",
                                        "USER": "Benutzer",
                                        "EMAIL": "E-Mail"
                                    },
                                    "NOTIFICATIONS": "Benachrichtigungen"
                                }
                            },
                            "aside": {
                                "nav": {
                                    "HEADER": "Navigation",
                                    "DASHBOARD": "Armaturenbrett",
                                    "CALENDAR": "Kalender",
                                    "EMAIL": "E-Mail",
                                    "WIDGETS": "Widgets",
                                    "components": {
                                        "COMPONENTS": "Komponenten",
                                        "ui_kits": {
                                            "UI_KITS": "UI Kits",
                                            "BUTTONS": "Kn�pfe",
                                            "ICONS": "Icons",
                                            "GRID": "Grid",
                                            "BOOTSTRAP": "Bootstrap",
                                            "SORTABLE": "Sortable",
                                            "PORTLET": "Portlet",
                                            "TIMELINE": "Timeline",
                                            "VECTOR_MAP": "Vektorkarte"
                                        },
                                        "table": {
                                            "TABLE": "Tabelle",
                                            "TABLE_STATIC": "Tabelle statisch",
                                            "DATATABLE": "Datatable",
                                            "FOOTABLE": "Footable"
                                        },
                                        "form": {
                                            "FORM": "Form",
                                            "FORM_ELEMENTS": "Formularelemente",
                                            "FORM_VALIDATION": "Best�tigung",
                                            "FORM_WIZARD": "Form wizard"
                                        },
                                        "CHART": "Diagramm",
                                        "pages": {
                                            "PAGES": "Seiten",
                                            "PROFILE": "Profil",
                                            "POST": "Post",
                                            "SEARCH": "Suchen",
                                            "INVOICE": "Rechnung",
                                            "LOCK_SCREEN": "Sperrbildschirm",
                                            "SIGNIN": "Registrieren",
                                            "SIGNUP": "Anmelden",
                                            "FORGOT_PASSWORD": "Passwort vergessen",
                                            "404": "404"
                                        }
                                    },
                                    "your_stuff": {
                                        "YOUR_STUFF": "Ihr Material",
                                        "PROFILE": "Profil",
                                        "DOCUMENTS": "Dokumente"
                                    }
                                },
                                "MILESTONE": "Meilenstein",
                                "RELEASE": "Freisetzung"
                            },
                            DIALOGS_ERROR: "Error",
                            DIALOGS_ERROR_MSG: "An unknown error has occurred.",
                            DIALOGS_CLOSE: "Close",
                            DIALOGS_PLEASE_WAIT: "Please Wait",
                            DIALOGS_PLEASE_WAIT_ELIPS: "Please Wait...",
                            DIALOGS_PLEASE_WAIT_MSG: "Waiting on operation to complete.",
                            DIALOGS_PERCENT_COMPLETE: "% Complete",
                            DIALOGS_NOTIFICATION: "Notification",
                            DIALOGS_NOTIFICATION_MSG: "Unknown application notification.",
                            DIALOGS_CONFIRMATION: "Confirmation",
                            DIALOGS_CONFIRMATION_MSG: "Confirmation required.",
                            DIALOGS_OK: "OK",
                            DIALOGS_YES: "Yes",
                            DIALOGS_NO: "No"
                        }
                    );

                    $translateProvider.translations('it_IT', {
                            "header": {
                                "navbar": {
                                    "UPLOAD": "Caricare",
                                    "new": {
                                        "NEW": "Nuovo",
                                        "PROJECT": "Progetti",
                                        "TASK": "Compito",
                                        "USER": "Utente",
                                        "EMAIL": "Email"
                                    },
                                    "NOTIFICATIONS": "Notifiche"
                                }
                            },
                            "aside": {
                                "nav": {
                                    "HEADER": "Navigazione",
                                    "DASHBOARD": "Cruscotto",
                                    "CALENDAR": "Calendario",
                                    "EMAIL": "Email",
                                    "WIDGETS": "Widgets",
                                    "components": {
                                        "COMPONENTS": "Componenti",
                                        "ui_kits": {
                                            "UI_KITS": "Kit UI",
                                            "BUTTONS": "Pulsanti",
                                            "ICONS": "Icone",
                                            "GRID": "Griglia",
                                            "BOOTSTRAP": "Bootstrap",
                                            "SORTABLE": "Ordinabili",
                                            "PORTLET": "Portlet",
                                            "TIMELINE": "Cronologia",
                                            "VECTOR_MAP": "Vector Map"
                                        },
                                        "table": {
                                            "TABLE": "Tavolo",
                                            "TABLE_STATIC": "Tabella statico",
                                            "DATATABLE": "Datatable",
                                            "FOOTABLE": "Footable"
                                        },
                                        "form": {
                                            "FORM": "Forma",
                                            "FORM_ELEMENTS": "Elementi del modulo",
                                            "FORM_VALIDATION": "Validazione dei form",
                                            "FORM_WIZARD": "Creazione guidata maschera"
                                        },
                                        "CHART": "Grafico",
                                        "pages": {
                                            "PAGES": "Pagine",
                                            "PROFILE": "Profilo",
                                            "POST": "Messaggio",
                                            "SEARCH": "Cerca",
                                            "INVOICE": "Fattura",
                                            "LOCK_SCREEN": "Blocca schermo",
                                            "SIGNIN": "Registrati",
                                            "SIGNUP": "Iscriviti",
                                            "FORGOT_PASSWORD": "Password dimenticata",
                                            "404": "404"
                                        }
                                    },
                                    "your_stuff": {
                                        "YOUR_STUFF": "Le tue cos",
                                        "PROFILE": "Profilo",
                                        "DOCUMENTS": "Documenti"
                                    }
                                },
                                "MILESTONE": "Pietra miliare",
                                "RELEASE": "Rilascio"
                            },
                            DIALOGS_ERROR: "Error",
                            DIALOGS_ERROR_MSG: "An unknown error has occurred.",
                            DIALOGS_CLOSE: "Close",
                            DIALOGS_PLEASE_WAIT: "Please Wait",
                            DIALOGS_PLEASE_WAIT_ELIPS: "Please Wait...",
                            DIALOGS_PLEASE_WAIT_MSG: "Waiting on operation to complete.",
                            DIALOGS_PERCENT_COMPLETE: "% Complete",
                            DIALOGS_NOTIFICATION: "Notification",
                            DIALOGS_NOTIFICATION_MSG: "Unknown application notification.",
                            DIALOGS_CONFIRMATION: "Confirmation",
                            DIALOGS_CONFIRMATION_MSG: "Confirmation required.",
                            DIALOGS_OK: "OK",
                            DIALOGS_YES: "Yes",
                            DIALOGS_NO: "No"
                        }
                    );

                    // Tell the module what language to use by default
                    $translateProvider.preferredLanguage('fr_FR');

                    // Tell the module to store the language in the local storage
                    $translateProvider.useLocalStorage();

                }
            ])
            .config(['$httpProvider', function ($httpProvider) {
                // Make sure we only apply this during development
                // You can adjust this check as is relevant to your development environment
                $httpProvider.interceptors.push("noCacheInterceptor");

                }
            ])
            /**
     * jQuery plugin config use ui-jq directive , config the js and css files that required
     * key: function name of the jQuery plugin
     * value: array of the css js file located
     */
            .constant('JQ_CONFIG', {
                    easyPieChart: [HelpersErp.getUrlByTemplateLibBase('charts/easypiechart/jquery.easy-pie-chart.js')],
                    sparkline: [HelpersErp.getUrlByTemplateLibBase('charts/sparkline/jquery.sparkline.min.js')],
                    plot: [
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.resize.js'),
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.tooltip.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.spline.js'),
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.orderBars.js'),
                        HelpersErp.getUrlByTemplateLibBase('charts/flot/jquery.flot.pie.min.js')
                    ],
                    slimScroll: [HelpersErp.getUrlByTemplateLibBase('slimscroll/jquery.slimscroll.min.js')],
                    sortable: [HelpersErp.getUrlByTemplateLibBase('sortable/jquery.sortable.js')],
                    nestable: [
                        HelpersErp.getUrlByTemplateLibBase('nestable/jquery.nestable.js'),
                        HelpersErp.getUrlByTemplateLibBase('nestable/nestable.css')
                    ],
                    filestyle: [HelpersErp.getUrlByTemplateLibBase('file/bootstrap-filestyle.min.js')],
                    slider: [
                        HelpersErp.getUrlByTemplateLibBase('slider/bootstrap-slider.js'),
                        HelpersErp.getUrlByTemplateLibBase('slider/slider.css')
                    ],
                    chosen: [
                        HelpersErp.getUrlByTemplateLibBase('chosen/chosen.jquery.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('chosen/chosen.css')
                    ],
                    TouchSpin: [
                        HelpersErp.getUrlByTemplateLibBase('spinner/jquery.bootstrap-touchspin.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('spinner/jquery.bootstrap-touchspin.css')
                    ],
                    wysiwyg: [
                        HelpersErp.getUrlByTemplateLibBase('wysiwyg/bootstrap-wysiwyg.js'),
                        HelpersErp.getUrlByTemplateLibBase('wysiwyg/jquery.hotkeys.js')
                    ],
                    dataTable: [
                        HelpersErp.getUrlByTemplateLibBase('datatables/jquery.dataTables.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('datatables/dataTables.bootstrap.js'),
                        HelpersErp.getUrlByTemplateLibBase('datatables/dataTables.bootstrap.css')
                    ],
                    vectorMap: [
                        HelpersErp.getUrlByTemplateLibBase('jvectormap/jquery-jvectormap.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('jvectormap/jquery-jvectormap-world-mill-en.js'),
                        HelpersErp.getUrlByTemplateLibBase('jvectormap/jquery-jvectormap-us-aea-en.js'),
                        HelpersErp.getUrlByTemplateLibBase('jvectormap/jquery-jvectormap.css')
                    ],
                    footable: [
                        HelpersErp.getUrlByTemplateLibBase('footable/footable.all.min.js'),
                        HelpersErp.getUrlByTemplateLibBase('footable/footable.Core.css')
                    ]
                }
            )
            .constant('MODULE_CONFIG', {
                    select2: [
                        HelpersErp.getUrlByTemplateLibBase('select2/select2.css'),
                        HelpersErp.getUrlByTemplateLibBase('select2/select2-bootstrap.css'),
                        HelpersErp.getUrlByTemplateLibBase('select2/select2.min.js'),
                        HelpersErp.getUrlByBowerComponentsBase('ui-select2/src/select2.js')
                    ]
                }
            );

        erpRouter.config(
            [
                '$stateProvider', '$urlRouterProvider', '$locationProvider',
            function ($stateProvider, $urlRouterProvider, $locationProvider) {

                    $urlRouterProvider.otherwise('/access/signin');

                    $stateProvider
                        .state('app', {
                            abstract: true,
                            url: '/ui',
                            controller: 'MainViewCtrl',
                            templateUrl: HelpersErp.getUrlByAppBase('app.html')
                        })
                        .state('app.dashboard', {
                            url: '/dashboard',
                            templateUrl: HelpersErp.getUrlByAppBase('/dashboard/app_dashboard.html')
                        }) // others
                        .state('app.error', {
                             url: '/error',
                             templateUrl: HelpersErp.getUrlByAppBase('/error/app_error.html')
                         }) // others
                        .state('access', {
                            url: '/access',
                            template: '<div ui-view class="fade-in-right-big smooth"></div>'
                        })
                        .state('access.signin', {
                            url: '/signin',
                            controller: 'CoreSigninCtrl',
                            templateUrl: HelpersErp.getUrlByFeaturesBase('signin/CoreSignin.html', MODULE_ERP_CORE),
                            resolve: {
                                loadMyCtrl: [
                                '$ocLazyLoad', function ($ocLazyLoad) {
                                        // you can lazy load files for an existing module
                                        return $ocLazyLoad.load({
                                            files: [HelpersErp.getUrlByFeaturesBase('signin/CoreSigninCtrl.js', MODULE_ERP_CORE)]
                                        });
                                    }
                                ]
                            }
                        })
                        .state('app.notification',{
                                url: '/notification',
                                controller: 'notificationCtrl',
                                templateUrl: HelpersErp.getUrlByFeaturesBase('notification/notification.html',MODULE_ERP_CORE),
                                resolve: {
                                    loadMyCtrl: [
                                        '$ocLazyLoad', function ($ocLazyLoad) {
                                            // you can lazy load files for an existing module
                                            return $ocLazyLoad.load({
                                                files: [HelpersErp.getUrlByFeaturesBase('notification/notificationCtrl.js',MODULE_ERP_CORE)]
                                            });
                                        }
                                    ]
                                }
                            });

                }
            ]
        );

        return app;
    });