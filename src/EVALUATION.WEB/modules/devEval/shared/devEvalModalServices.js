define(['app', 'angular-dialog-service'], function (app) {
    'use strict';

    app.service("projectModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("project/projectModal.html", MODULE_ERP_DEV_EVAL),
                "projectModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("project/projectModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("taskModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("task/taskModal.html", MODULE_ERP_DEV_EVAL),
                "taskModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("task/taskModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("collaboratorActionModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("collaboratorAction/collaboratorActionModal.html", MODULE_ERP_DEV_EVAL),
                "collaboratorActionModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("collaboratorAction/collaboratorActionModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("rejectionActionModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("managerAction/rejectionActionModal.html", MODULE_ERP_DEV_EVAL),
                "rejectionActionModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("managerAction/rejectionActionModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("prolongationActionModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("managerAction/prolongationActionModal.html", MODULE_ERP_DEV_EVAL),
                "prolongationActionModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("managerAction/prolongationActionModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("bruitActionModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("managerAction/bruitActionModal.html", MODULE_ERP_DEV_EVAL),
                "bruitActionModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("managerAction/bruitActionModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("userModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("auth/userModal.html", MODULE_ERP_DEV_EVAL),
                "userModalCtrl",
                data, { size: "lg" },
                [HelpersErp.getUrlByFeaturesBase("auth/userModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("roleModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("auth/roleModal.html", MODULE_ERP_DEV_EVAL),
                "roleModalCtrl",
                data, { size: "md" },
                [HelpersErp.getUrlByFeaturesBase("auth/roleModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);

    app.service("permissionModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("auth/permissionModal.html", MODULE_ERP_DEV_EVAL),
                "permissionModalCtrl",
                data, { size: "md" },
                [HelpersErp.getUrlByFeaturesBase("auth/permissionModalCtrl.js", MODULE_ERP_DEV_EVAL)]);
        };
    }]);


});