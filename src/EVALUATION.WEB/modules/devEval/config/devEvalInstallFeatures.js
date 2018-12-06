
define([], function () {
    'use strict';
    /* DevEval Install features */
    require.config({
        baseUrl: "",
        paths: {
            'dev-eval-router': HelpersErp.getUrlByConfigBase('devEvalRouter', MODULE_ERP_DEV_EVAL),
            'dev-eval-controllers': HelpersErp.getUrlBySharedBase('devEvalControllers', MODULE_ERP_DEV_EVAL),
            'dev-eval-directives': HelpersErp.getUrlBySharedBase('devEvalDirectives', MODULE_ERP_DEV_EVAL),
            'dev-eval-filters': HelpersErp.getUrlBySharedBase('devEvalFilters', MODULE_ERP_DEV_EVAL),
            'dev-eval-models': HelpersErp.getUrlBySharedBase('devEvalModels', MODULE_ERP_DEV_EVAL),
            'dev-eval-scripts': HelpersErp.getUrlBySharedBase('devEvalScripts', MODULE_ERP_DEV_EVAL),
            'dev-eval-services': HelpersErp.getUrlBySharedBase('devEvalServices', MODULE_ERP_DEV_EVAL),
            'dev-eval-modal-services': HelpersErp.getUrlBySharedBase('devEvalModalServices', MODULE_ERP_DEV_EVAL)
        },
        shim: {
            'dev-eval-router': ['angular']
        },
        deps: ['dev-eval-router']
    });
});
