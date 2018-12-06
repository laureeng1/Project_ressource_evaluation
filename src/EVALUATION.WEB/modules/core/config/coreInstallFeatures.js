
define([], function () {
    'use strict';
    /* Core Install features */
    require.config({
        baseUrl: "",
        paths: {
            'Core-router': HelpersErp.getUrlByConfigBase('CoreRouter', MODULE_ERP_CORE),
            'Core-controllers': HelpersErp.getUrlBySharedBase('CoreControllers', MODULE_ERP_CORE),
            'Core-directives': HelpersErp.getUrlBySharedBase('CoreDirectives', MODULE_ERP_CORE),
            'Core-filters': HelpersErp.getUrlBySharedBase('CoreFilters', MODULE_ERP_CORE),
            'Core-models': HelpersErp.getUrlBySharedBase('CoreModels', MODULE_ERP_CORE),
            'Core-scripts': HelpersErp.getUrlBySharedBase('CoreScripts', MODULE_ERP_CORE),
            'Core-services': HelpersErp.getUrlBySharedBase('CoreServices', MODULE_ERP_CORE),
            'Core-modal-services': HelpersErp.getUrlBySharedBase('CoreModalServices', MODULE_ERP_CORE),
            'preview-print-service': HelpersErp.getUrlByFeaturesBase('preview-print/services', MODULE_ERP_CORE)
        },
        shim: {
            'Core-router': ['angular']
        },
        deps: ['Core-router']
    });
});
