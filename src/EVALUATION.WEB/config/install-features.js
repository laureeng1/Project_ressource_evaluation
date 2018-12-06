"use strict";
var MODE = "";


/***
* !!!!! A LIRE AVANT UN DEPLOIEMENT !!!!!
*
* Variable à incrémenter à chaque nouvelle version pour éviter les problèmes de cache: VERSION_CODE.
*
* En production décommenter MODE="PROD" 
*
*
****/


var VERSION_CODE = "1.0.0.20";

MODE = "PROD";
//MODE = "DEV";

var MODULE_ERP_CORE = "Core", MODULE_ERP_CRUD = "crud", MODULE_ERP_TEST = "test", MODULE_ERP_DEV_EVAL = "devEval";



if (!String.prototype.contains) {
    String.prototype.contains = function () {
        return String.prototype.indexOf.apply(this, arguments) !== -1;
    };
}
var HelpersErpModule = function () {
    var d = this, g = "/";
    d.clone = function (a) {
        if (typeof (a) != "object" || a == null) {
            return a;
        }
        var b = new a.constructor();
        for (var c in a) {
            b[c] = d.clone(a[c]);
        }
        return b;
    };
    var e = function (a, b, c) {
        var f = d.clone(c);
        if (f == undefined || f == "") f = ""; else f = "modules/" + f;
        return g + f + (f == "" ? "" : "/") + a + b;
        //modules/config/devEvalInstallFeatures/
    };
    d.getUrlByConfigBase = function (a, b) {
        var c = "config/";
        return e(c, a, b);
        // 'dev-eval-install-features': HelpersErp.getUrlByConfigBase("devEvalInstallFeatures", MODULE_ERP_DEV_EVAL)
    };
    d.getUrlByFeaturesBase = function (a, b) {
        var c = "features/";
        return e(c, a, b);
    };
    d.getUrlByFrmMainviewsBase = function (a, b) {
        var c = "features/frm-mainviews/";
        return e(c, a, b);
    };
    d.getUrlByFrmModalsBase = function (a, b) {
        var c = "features/frm-modals/";
        return e(c, a, b);
    };
    d.getUrlBySharedBase = function (a, b) {
        var c = "shared/";
        return e(c, a, b);
    };
    d.getUrlByTestsBase = function (a, b) {
        var c = "tests/";
        return e(c, a, b);
    };
    d.getUrlByTemplateLibBase = function (a) {
        var b = "lib/manual_loaded_libs/template-libs/";
        return e(b, a);
    };
    d.getUrlByManualLoadedLibsBase = function (a) {
        var b = "lib/manual_loaded_libs/";
        return e(b, a);
    };
    d.getUrlByAppBase = function (a) {
        var b = "app/";
        return e(b, a);
    };
    d.getUrlByContentBase = function (a) {
        var b = "Content/";
        return e(b, a);
    };
    d.getUrlByBowerComponentsBase = function (a) {
        var b = "lib/bower_components/";
        return e(b, a);
    };
    d.getUrlByWebComponentsLibBase = function (a) {
        var b = "lib/components/widgets/";
        return e(b, a);
    };
    d.getUrlByPolymerJSLibBase = function (a) {
        var b = "lib/components/vendors/bower_components/";
        return e(b, a);
    };
    d.loadHtml = function (a) {
        var b = document.createElement("link");
        b.rel = "import";
        b.href = a;
        document.head.appendChild(b);
    };
}, HelpersErp = new HelpersErpModule();


require.config({
    baseUrl: "",
    waitSeconds: 0,
    //urlArgs: "bust=" + "20-02-2015 02:56:00",
    //urlArgs: "bust=" + new Date().getTime(),
    //urlArgs: "bust=" + VERSION_CODE,
    urlArgs: MODE == "DEV" ? "bust=" + new Date().getTime() : "bust=" + VERSION_CODE,
    paths: {
        'jquery': "/lib/bower_components/jquery/dist/jquery",
        'jquery-base64': HelpersErp.getUrlByManualLoadedLibsBase("jquery-base64-master/jquery.base64.min"),
        'angular': "/lib/bower_components/angular/angular",
        'angular-route': "/lib/bower_components/angular-route/angular-route",
        'angular-sanitize': "/lib/bower_components/angular-sanitize/angular-sanitize",
        'angular-ui-router': "/lib/bower_components/angular-ui-router/release/angular-ui-router",
        'angular-translate': "/lib/template/js/angular/angular-translate",
        'angular-resource': "/lib/bower_components/angular-resource/angular-resource",
        'angular-dialog-service': "/lib/bower_components/angular-dialog-service/dialogs.min",
        'angular-animate': "/lib/bower_components/angular-animate/angular-animate",
        'angular-cookies': "/lib/bower_components/angular-cookies/angular-cookies",
        'angular-translate-storage-local': "/lib/bower_components/angular-translate-storage-local/angular-translate-storage-local",
        'angular-translate-storage-cookie': "/lib/bower_components/angular-translate-storage-cookie/angular-translate-storage-cookie",
        'angular-couch-potato': "/lib/bower_components/angular-couch-potato/dist/angular-couch-potato",
        'oc-lazy-load': "/lib/bower_components/oclazyload/dist/ocLazyLoad",
        'ui-bootstrap': "/lib/manual_loaded_libs/template-libs/ui-bootstrap-tpls.min",
        'ng-storage': "/lib/bower_components/ngstorage/ngstorage",
        'ui-jq': "/lib/manual_loaded_libs/template-libs/ui-jq",
        'ui-load': "/lib/manual_loaded_libs/template-libs/ui-load",
        'ui-validate': "/lib/manual_loaded_libs/template-libs/ui-validate",
        'linq-js': "/lib/manual_loaded_libs/linq.js_ver2.2.0.2/linq.min",
        'date-format-js': "/lib/bower_components/date.format",
        'angular-idle': HelpersErp.getUrlByManualLoadedLibsBase("ng-idle-develop/angular-idle"),
        'jquery-gritter': HelpersErp.getUrlByManualLoadedLibsBase("gritter/js/jquery.gritter"),
        'report-viewer': HelpersErp.getUrlByManualLoadedLibsBase("ReportViewer/js/ReportViewer-7.2.13.1016"),
        'kendo-all': HelpersErp.getUrlByManualLoadedLibsBase("kendo/kendo.all.min"),
        'html2-canvas': HelpersErp.getUrlByManualLoadedLibsBase("html2canvas/html2canvas"),
        'jsPDF-master': HelpersErp.getUrlByManualLoadedLibsBase("jsPDF-master/jspdf"),
        'jspdf-plugin-from-html': HelpersErp.getUrlByManualLoadedLibsBase("jsPDF-master/jspdf.plugin.from_html"),
        'jspdf-debug': HelpersErp.getUrlByManualLoadedLibsBase("jsPDF-master/dist/jspdf.debug"),
        'ng-tags-input': HelpersErp.getUrlByManualLoadedLibsBase("ng-tags-input/ng-tags-input"),
        'angular-multi-select': HelpersErp.getUrlByManualLoadedLibsBase("angular-multi-select-master/angular-multi-select"),
        'moment': HelpersErp.getUrlByManualLoadedLibsBase("fullcalendar-2.2.3/moment.min"),
        'calendar': HelpersErp.getUrlByManualLoadedLibsBase("ui-calendar-master/src/calendar"),
        'fullcalendar': HelpersErp.getUrlByManualLoadedLibsBase("fullcalendar-2.2.3/fullcalendar"),
        'culture': HelpersErp.getUrlByManualLoadedLibsBase("kendo/cultures/kendo.culture.fr-FR.min"),
        'app': "/app/app",
        'definitions': HelpersErp.getUrlByConfigBase("definitions"),
        'app-controllers': "/app/controllers",
        'utilities': HelpersErp.getUrlBySharedBase("utilities"),
        'erp-directives': HelpersErp.getUrlBySharedBase("directives"),
        'erp-filters': HelpersErp.getUrlBySharedBase("filters"),
        'parameters': HelpersErp.getUrlByConfigBase("parameters"),
        'erp-services': HelpersErp.getUrlBySharedBase("services"),
        'erp-modal-services': HelpersErp.getUrlBySharedBase("modal-services"),
        'erp-models': HelpersErp.getUrlBySharedBase("models"),
        //pivottable
        'pivot-jquery-ui': 'lib/bower_components/pivottable/jquery-ui/jquery-ui',
        'pivottable': 'lib/bower_components/pivottable/pivottable/dist/pivot',
        'angular-pivottable': 'lib/bower_components/pivottable/angular-pivottable/dist/angular-pivot',
        // js-xlsx
        'jszip': 'lib/bower_components/js-xlsx/dist/jszip',
        'shim': 'lib/bower_components/js-xlsx/dist/shim.min',
        'xlsx': 'lib/bower_components/js-xlsx/dist/xlsx.Core.min',
        'erp-install-components': HelpersErp.getUrlByConfigBase("install-components"),
        //inserer le module 
        'core-install-features': HelpersErp.getUrlByConfigBase("CoreInstallFeatures", MODULE_ERP_CORE),
        'test-install-features': HelpersErp.getUrlByConfigBase("testInstallFeatures", MODULE_ERP_TEST),
        'dev-eval-install-features': HelpersErp.getUrlByConfigBase("devEvalInstallFeatures", MODULE_ERP_DEV_EVAL)
    },
    shim: {
        'angular': ["jquery"],
        'jquery-base64': ["jquery"],
        'jquery-gritter': ["jquery"],
        'linq-js': ["jquery"],
        'html2-canvas': ["jquery"],
        'jsPDF-master': ["jquery"],
        'jspdf-debug': ["jquery"],
        'jspdf-plugin-from-html': ["jsPDF-master"],
        'angular-sanitize': ["angular"],
        'angular-route': ["angular"],
        'angular-resource': ["angular"],
        'angular-ui-router': ["angular"],
        'angular-translate': ["angular"],
        'angular-animate': ["angular"],
        'angular-cookies': ["angular"],
        'ui-bootstrap': ["angular"],
        'ng-storage': ["angular"],
        'ui-jq': ["angular", "ui-load"],
        'ui-load': ["angular"],
        'ui-validate': ["angular"],
        'angular-translate-storage-local': ["angular"],
        'angular-translate-storage-cookie': ["angular"],
        'angular-couch-potato': ["angular", "angular-route", "angular-ui-router"],
        'angular-dialog-service': ["angular"],
        'oc-lazy-load': ["angular"],
        'angular-idle': ["angular"],
        'report-viewer': [],
        'kendo-all': [],
        'date-format-js': ["jquery"],
        'ng-tags-input': [],
        'angular-multi-select': [],
        'moment': [],
        'calendar': [],
        'fullcalendar': [],
        'culture': [],
        'pivot-jquery-ui': [],
        'pivottable': [],
        'angular-pivottable': ['angular'],
        //inserer le module 
        'app': ["core-install-features", "test-install-features", "dev-eval-install-features"],
        'app-controllers': ["core-install-features"],
        'definitions': ["angular"],
        'utilities': ["jquery"],
        'erp-directives': ["angular"],
        'erp-filters': ["angular"],
        'core-install-features': ["angular"],
        'parameters': ["angular"]
    }
});

require(["app"], function (b) {
    document.addEventListener("polymer-elements-are-initialized", function (a) {
        angular.element(document).ready(function () {
            angular.bootstrap(wrap(document), ["app"]);
        });
    });
    HelpersErp.loadHtml(HelpersErp.getUrlByWebComponentsLibBase("advanced-table/advanced-table.html"));
    HelpersErp.loadHtml(HelpersErp.getUrlByWebComponentsLibBase("search-input/search-input.html"));
    HelpersErp.loadHtml(HelpersErp.getUrlByWebComponentsLibBase("tree-view/tree-view.html"));
    HelpersErp.loadHtml(HelpersErp.getUrlByWebComponentsLibBase("dom-polymer/dom-polymer.html"));



});