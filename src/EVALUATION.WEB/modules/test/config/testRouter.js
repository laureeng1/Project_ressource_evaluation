define(['definitions'], function () {
    'use strict';

    /* CRUD Router */

    erpRouter.config(['$stateProvider', function ($stateProvider) {
        $stateProvider
            .state('app.crud', {
                url: '/crud',
                template: '<div ui-view class="fade-in-up"></div>'
            })
            .state('app.crud.typePartenaire', {
                 url: '/typePartenaire',
                 templateUrl: HelpersErp.getUrlByFeaturesBase('typePartenaire/crudTypePartenaireList.html', MODULE_ERP_CRUD),
                 resolve: {
                     loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                         // you can lazy load files for an existing module
                         return $ocLazyLoad.load({
                             files: [HelpersErp.getUrlByFeaturesBase('typePartenaire/crudTypePartenaireListCtrl.js', MODULE_ERP_CRUD)]
                         });
                     }]
                 }
             })
    }]);
  
});