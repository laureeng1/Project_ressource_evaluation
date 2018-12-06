define(['app', 'angular-dialog-service', 'erp-modal-services'], function (app) {
    'use strict';

    /* Modals Services */
    app.service("CoreChoiceModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("select-prestataire/CoreChoiceModal.html", MODULE_ERP_CORE),
                "CoreChoiceModalCtrl",
                data, { size: "md", keyboard: false },
                [HelpersErp.getUrlByFeaturesBase("select-prestataire/CoreChoiceModalCtrl.js", MODULE_ERP_CORE)]);
        };
    }]);
});

