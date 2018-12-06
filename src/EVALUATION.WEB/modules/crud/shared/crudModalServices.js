define(['app', 'angular-dialog-service'], function (app) {
    'use strict';

    app.service("crudTypePartenaireModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("typePartenaire/crudTypePartenaireModal.html", MODULE_ERP_CRUD),
                "crudTypePartenaireModalCtrl",
                data, { size: "sm" },
                [HelpersErp.getUrlByFeaturesBase("typePartenaire/crudTypePartenaireModalCtrl.js", MODULE_ERP_CRUD)]);
        };
    }]);

    
});