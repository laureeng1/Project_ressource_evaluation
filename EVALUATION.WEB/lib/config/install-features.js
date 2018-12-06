'use strict';

/* Install features */

document.addEventListener('polymer-elements-are-initialized', function (e) {
    require(['app'], function (app) {
        angular.bootstrap(wrap(window.document), ['app']);
    });
    
});

/* ----- Configuration des chemins de librairies ----- */
require.config({
    baseUrl: "",
    paths: {
        'erp-scripts': '/shared/scripts',
        'polymer-utilities': '/lib/components/common/utilities'
    },
    shim: {
        'polymer-utilities': ['erp-scripts']
    }
});

require(['polymer-utilities'], function () {

    /* ----- Configuration des chemins de librairies ----- */
    require.config({
        baseUrl: "",
        paths: {
            'jquery': '/lib/bower_components/jquery/dist/jquery',
            'jquery-base64': HelpersErp.getUrlByManualLoadedLibsBase('jquery-base64-master/jquery.base64.min'),
            'angular': '/lib/bower_components/angular/angular',
            'angular-route': '/lib/bower_components/angular-route/angular-route',
            'angular-sanitize': '/lib/bower_components/angular-sanitize/angular-sanitize',
            'angular-ui-router': '/lib/bower_components/angular-ui-router/release/angular-ui-router',
            'angular-translate': '/lib/template/js/angular/angular-translate',
            'angular-resource': '/lib/bower_components/angular-resource/angular-resource',
            'angular-dialog-service': '/lib/bower_components/angular-dialog-service/dialogs.min',
            'angular-animate': '/lib/bower_components/angular-animate/angular-animate',
            'angular-cookies': '/lib/bower_components/angular-cookies/angular-cookies',
            'angular-translate-storage-local': '/lib/bower_components/angular-translate-storage-local/angular-translate-storage-local',
            'angular-translate-storage-cookie': '/lib/bower_components/angular-translate-storage-cookie/angular-translate-storage-cookie',
            'angular-couch-potato': '/lib/bower_components/angular-couch-potato/dist/angular-couch-potato',
            'oc-lazy-load': '/lib/bower_components/oclazyload/dist/ocLazyLoad',
            'ui-bootstrap': '/lib/manual_loaded_libs/template-libs/ui-bootstrap-tpls.min',
            'ng-storage': '/lib/bower_components/ngstorage/ngstorage',
            'ui-jq': '/lib/manual_loaded_libs/template-libs/ui-jq',
            'ui-load': '/lib/manual_loaded_libs/template-libs/ui-load',
            'ui-validate': '/lib/manual_loaded_libs/template-libs/ui-validate',
            'linq-js': '/lib/manual_loaded_libs/linq.js_ver2.2.0.2/linq.min',
            'angular-idle': HelpersErp.getUrlByManualLoadedLibsBase('ng-idle-develop/angular-idle'),
            'jquery-gritter': HelpersErp.getUrlByManualLoadedLibsBase('gritter/js/jquery.gritter'),
            'report-viewer': HelpersErp.getUrlByManualLoadedLibsBase('ReportViewer/js/ReportViewer-7.2.13.1016'),
            'kendo-all': HelpersErp.getUrlByManualLoadedLibsBase('kendo/kendo.all.min'),
            'html2-canvas': HelpersErp.getUrlByManualLoadedLibsBase('html2canvas/html2canvas'),
            'jsPDF-master': HelpersErp.getUrlByManualLoadedLibsBase('jsPDF-master/jspdf'),
            'jspdf-plugin-from-html': HelpersErp.getUrlByManualLoadedLibsBase('jsPDF-master/jspdf.plugin.from_html'),
            'jspdf-debug': HelpersErp.getUrlByManualLoadedLibsBase('jsPDF-master/dist/jspdf.debug')
        },
        shim: {
            'angular': ['jquery'],
            'jquery-base64': ['jquery'],
            'jquery-gritter': ['jquery'],
            'linq-js': ['jquery'],
            'html2-canvas': ['jquery'],
            'jsPDF-master': ['jquery'],
            'jspdf-debug': ['jquery'],
            'jspdf-plugin-from-html': ['jsPDF-master'],
            'angular-sanitize': ['angular'],
            'angular-route': ['angular'],
            'angular-resource': ['angular'],
            'angular-ui-router': ['angular'],
            'angular-translate': ['angular'],
            'angular-animate': ['angular'],
            'angular-cookies': ['angular'],
            'ui-bootstrap': ['angular'],
            'ng-storage': ['angular'],
            'ui-jq': ['angular', 'ui-load'],
            'ui-load': ['angular'],
            'ui-validate': ['angular'],
            'angular-translate-storage-local': ['angular'],
            'angular-translate-storage-cookie': ['angular'],
            'angular-couch-potato': ['angular', 'angular-route', 'angular-ui-router'],
            'angular-dialog-service': ['angular'],
            'oc-lazy-load': ['angular'],
            'angular-idle': ['angular'],
            'report-viewer': [],
            'kendo-all': [],

        }
    });

    /* ----- Configuration des chemins des fichiers globaux à l'erp ----- */
    require.config({
        baseUrl: "",
        paths: {
            'app': '/app/app',
            'definitions': HelpersErp.getUrlByConfigBase('definitions'),
            'app-controllers': '/app/controllers',
            'utilities': HelpersErp.getUrlBySharedBase('utilities'),
            'erp-directives': HelpersErp.getUrlBySharedBase('directives'),
            'erp-filters': HelpersErp.getUrlBySharedBase('filters'),
            'parameters': HelpersErp.getUrlByConfigBase('parameters'),
            'erp-services': HelpersErp.getUrlBySharedBase('services'),
            'erp-modal-services': HelpersErp.getUrlBySharedBase('modal-services'),
            'erp-models': HelpersErp.getUrlBySharedBase('models'),
            'admin-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_ADMIN),
            'sa-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_SA),
            'caisse-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_CAISSE),
            'treso-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_TRESORERIE),
            'gc-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_GC),
            'mg-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_MG),
            'sb-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_SB),
            'his-install-features': HelpersErp.getUrlByConfigBase('install-features', MODULE_ERP_HIS),
            'erp-install-components': HelpersErp.getUrlByConfigBase('install-components')
        },
        shim: {
            'app': ['polymer-utilities', 'admin-install-features', 'sa-install-features', 'caisse-install-features', 'treso-install-features', 'gc-install-features', 'mg-install-features', 'sb-install-features', 'his-install-features'],
            'app-controllers': ['admin-install-features'],
            'definitions': ['angular'],
            'utilities': ['jquery'],
            'erp-directives': ['angular'],
            'erp-filters': ['angular'],
            'admin-install-features': ['angular'],
            'parameters': ['angular']
        }
    });
    
    // préparer le dom des polymers
    var element = document.createElement('link');
    element.rel = "import";
    element.href = HelpersErp.getUrlByWebComponentsLibBase('dom-polymer/dom-polymer.html');
    document.head.appendChild(element);
});