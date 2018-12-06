
define([], function () {
    'use strict';

    /* ADMIN Install features */

    require.config({
        baseUrl: "",
        paths: {
            'crud-router': HelpersErp.getUrlByConfigBase('crudRouter', MODULE_ERP_CRUD),
            'crud-controllers': HelpersErp.getUrlBySharedBase('crudControllers', MODULE_ERP_CRUD),
            'crud-directives': HelpersErp.getUrlBySharedBase('crudDirectives', MODULE_ERP_CRUD),
            'crud-filters': HelpersErp.getUrlBySharedBase('crudFilters', MODULE_ERP_CRUD),
            'crud-models': HelpersErp.getUrlBySharedBase('crudModels', MODULE_ERP_CRUD),
            'crud-scripts': HelpersErp.getUrlBySharedBase('crudScripts', MODULE_ERP_CRUD),
            'crud-services': HelpersErp.getUrlBySharedBase('crudServices', MODULE_ERP_CRUD),
            'crud-modal-services': HelpersErp.getUrlBySharedBase('crudModalServices', MODULE_ERP_CRUD)
        },
        shim: {
            'crud-router': ['angular']
        },
        deps: ['crud-router']
    });
});
