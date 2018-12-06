
define([], function () {
    'use strict';

    /* ADMIN Install features */

    require.config({
        baseUrl: "",
        paths: {
            'test-router': HelpersErp.getUrlByConfigBase('testRouter', MODULE_ERP_TEST),
            'test-controllers': HelpersErp.getUrlBySharedBase('testControllers', MODULE_ERP_TEST),
            'test-directives': HelpersErp.getUrlBySharedBase('testDirectives', MODULE_ERP_TEST),
            'test-filters': HelpersErp.getUrlBySharedBase('testFilters', MODULE_ERP_TEST),
            'test-models': HelpersErp.getUrlBySharedBase('testModels', MODULE_ERP_TEST),
            'test-scripts': HelpersErp.getUrlBySharedBase('testScripts', MODULE_ERP_TEST),
            'test-services': HelpersErp.getUrlBySharedBase('testServices', MODULE_ERP_TEST),
            'test-modal-services': HelpersErp.getUrlBySharedBase('testModalServices', MODULE_ERP_TEST)
        },
        shim: {
            'test-router': ['angular']
        },
        deps: ['test-router']
    });
});
