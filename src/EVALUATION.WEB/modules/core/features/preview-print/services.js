define(['app', 'angular-dialog-service', 'erp-modal-services'], function(app) {
    'use strict';

    
    app.service('formPreviewPrint', ['dialogs', 'erpDialogs', function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase('preview-print/preview-print.html', MODULE_ERP_CORE),
                                        'PreviewPrintCtrl',
                                        data, { size: 'lg' },
                                        [HelpersErp.getUrlByFeaturesBase('preview-print/controllers.js', MODULE_ERP_CORE)]);
        };
    }]);


    


});