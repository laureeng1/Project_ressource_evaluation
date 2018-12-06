define(['definitions'], function () {
    'use strict';

    /* CRUD Router */

    erpRouter.config(['$stateProvider', function ($stateProvider) {
        $stateProvider
            .state('app.devEval', {
                url: '/devEval',
                template: '<div ui-view class="fade-in-up"></div>'
            })
            .state('app.devEval.projects', {
                url: '/projects',
                templateUrl: HelpersErp.getUrlByFeaturesBase('project/projectList.html', MODULE_ERP_DEV_EVAL),
                resolve: {
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: [HelpersErp.getUrlByFeaturesBase('project/projectListCtrl.js', MODULE_ERP_DEV_EVAL)]
                        });
                    }]
                }
            })
            .state('app.devEval.collaborators', {
                url: '/collaborators',
                templateUrl: HelpersErp.getUrlByFeaturesBase('collaborator/collaboratorList.html', MODULE_ERP_DEV_EVAL),
                resolve: {
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: [HelpersErp.getUrlByFeaturesBase('collaborator/collaboratorListCtrl.js', MODULE_ERP_DEV_EVAL)]
                        });
                    }]
                }
            })
            .state('app.devEval.tasks', {
                url: '/tasks',
                templateUrl: HelpersErp.getUrlByFeaturesBase('task/taskList.html', MODULE_ERP_DEV_EVAL),
                resolve: {
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: [HelpersErp.getUrlByFeaturesBase('task/taskListCtrl.js', MODULE_ERP_DEV_EVAL)]
                        });
                    }]
                }
            })
            .state('app.devEval.admin', {
                url: '/admin',
                templateUrl: HelpersErp.getUrlByFeaturesBase('auth/adminPanel.html', MODULE_ERP_DEV_EVAL),
                resolve: {
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: [HelpersErp.getUrlByFeaturesBase('auth/adminPanelCtrl.js', MODULE_ERP_DEV_EVAL)]
                        });
                    }]
                }
            })
    }]);

});