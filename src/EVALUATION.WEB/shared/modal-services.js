
define(['definitions', 'utilities', 'oc-lazy-load'], function () {
    'use strict';

    /* Modals Services */

    EVALUATIONErpModals.service('erpDialogs', ['dialogs', 'commonUtilities', '$modal', function (dialogs, commonUtilities, $modal) {
        var mainSelf = this;

        mainSelf.Error = function (msg, title) {
            title = commonUtilities.IsUndefinedOrNull(title) ? 'Erreur' : title;
            return dialogs.error(title, msg);
        };

        mainSelf.Notify = function (msg, title) {
            title = commonUtilities.IsUndefinedOrNull(title) ? 'Attention' : title;
            return dialogs.notify(title, msg);
        };

        mainSelf.Confirm = function (msg, callBackConfirm, callBackCancel, title) {
            title = commonUtilities.IsUndefinedOrNull(title) ? 'Veillez confirmer' : title;
            var dlg = dialogs.confirm(title, msg);
            dlg.result.then(function (btn) {
                callBackConfirm();
            }, function () {
                callBackCancel();
            });
        };


        mainSelf.Create = function (url, ctrlr, data, opts, urlctrls) {
            var copy = (angular.isDefined(opts) && angular.isDefined(opts.copy)) ? opts.copy : true;

            var lopts = {};
            opts = angular.isDefined(opts) ? opts : {};
            lopts.kb = (angular.isDefined(opts.keyboard)) ? opts.keyboard : true; // values: true,false
            lopts.bd = (angular.isDefined(opts.backdrop)) ? opts.backdrop : "static"; // values: 'static',true,false
            lopts.ws = (angular.isDefined(opts.size) && (angular.equals(opts.size, "sm") || angular.equals(opts.size, "md") || angular.equals(opts.size, "lg"))) ? opts.size : "lg"; // values: 'sm', 'md', 'lg'
            lopts.wc = (angular.isDefined(opts.windowClass)) ? opts.windowClass : "dialogs-default"; // additional CSS class(es) to be added to a modal window

            opts = lopts;
            return $modal.open({
                templateUrl: url,
                controller: ctrlr,
                keyboard: opts.kb,
                backdrop: opts.bd,
                windowClass: opts.wc,
                size: opts.ws,
                resolve: {
                    data: function () {
                        if (copy)
                            return angular.copy(data);
                        else
                            return data;
                    },
                    loadMyCtrl: ["$ocLazyLoad", function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: urlctrls
                        });
                    }]
                }
            }); // end modal.open
        };

        mainSelf.CreateLarge = function (url, ctrlr, data, opts, urlctrls) {
            var copy = (angular.isDefined(opts) && angular.isDefined(opts.copy)) ? opts.copy : true;

            var lopts = {};
            opts = angular.isDefined(opts) ? opts : {};
            lopts.kb = (angular.isDefined(opts.keyboard)) ? opts.keyboard : true; // values: true,false
            lopts.bd = (angular.isDefined(opts.backdrop)) ? opts.backdrop : 'static'; // values: 'static',true,false
            lopts.ws = (angular.isDefined(opts.size) && (angular.equals(opts.size, 'sm') || angular.equals(opts.size, 'lg'))) ? opts.size : 'lg'; // values: 'sm', 'lg'
            lopts.wc = (angular.isDefined(opts.windowClass)) ? opts.windowClass : 'large-Modal'; // additional CSS class(es) to be added to a modal window

            opts = lopts;
            return $modal.open({
                templateUrl: url,
                controller: ctrlr,
                keyboard: opts.kb,
                backdrop: opts.bd,
                windowClass: opts.wc,
                size: opts.ws,
                resolve: {
                    data: function () {
                        if (copy)
                            return angular.copy(data);
                        else
                            return data;
                    },
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        // you can lazy load files for an existing module
                        return $ocLazyLoad.load({
                            files: urlctrls
                        });
                    }]
                }
            }); // end modal.open
        };

    }]);

    EVALUATIONErpModals.service('erpProvider', ['commonUtilities', function (commonUtilities) {
        var mainSelf = this;

        //#region get pays

        mainSelf.getPays = function (callback) {
            var response = [
                {
                    "code": "135",
                    "name": "A\u00e7ores"
                },
                {
                    "code": "144",
                    "name": "Afghanistan (Etat Islamique Transitoire)"
                },
                {
                    "code": "167",
                    "name": "Afrique du Sud"
                },
                {
                    "code": "174",
                    "name": "Algerie"
                },
                {
                    "code": "133",
                    "name": "Andorre (E)"
                },
                {
                    "code": "134",
                    "name": "Andorre (F)"
                },
                {
                    "code": "4",
                    "name": "Angola"
                },
                {
                    "code": "225",
                    "name": "Côte d\'Ivoire"
                }
            ];

            if (typeof (callback) == 'function') callback(response);
            return response;
            //var method = 'GET';
            //var api_name = "...";
            //var api_key =   "...";
            //var url = "http://www.citysearch-api.com/fr/pays?login=" + api_name + "&apiKey=" + api_key;
            //http.open(method, url);
            //// Déclaration de la fonction à appeler pour traiter le retour Ajax
            //http.onreadystatechange = function() {
            //    // Si l'état = 4 ...
            //    if(http.readyState == 4){
            //        // On stocke la réponse Ajax dans la variable "response"
            //        var response = http.responseText;
            //        callback(response);
            //    }
            //};
        };

        //#endregion

    }]);

   EVALUATIONErpModals.service("frmShowNotifications", [
        "dialogs", "erpDialogs", function (dialogs, erpDialogs) {
            var mainSelf = this;

            mainSelf.Show = function (data) {
                return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("editPassword/CoreEditPassword.html", MODULE_ERP_CORE),
                    "CoreEditPasswordCtrl",
                    data, { size: "sm" },
                    [HelpersErp.getUrlByFeaturesBase("editPassword/CoreEditPasswordCtrl.js", MODULE_ERP_CORE)]);
            };
        }
    ]);

    EVALUATIONErpModals.service("CoreEditPassword", [
        "dialogs", "erpDialogs", function (dialogs, erpDialogs) {
            var mainSelf = this;

            mainSelf.Show = function (data) {
                return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("editPassword/CoreEditPassword.html", MODULE_ERP_CORE),
                    "CoreEditPasswordCtrl",
                    data, { size: "sm" },
                    [HelpersErp.getUrlByFeaturesBase("editPassword/CoreEditPasswordCtrl.js", MODULE_ERP_CORE)]);
            };
        }
    ]);

    EVALUATIONErpModals.service("editnotificationModal", ["dialogs", "erpDialogs", function (dialogs, erpDialogs) {
        var mainSelf = this;

        mainSelf.Show = function (data) {
            return erpDialogs.Create(HelpersErp.getUrlByFeaturesBase("notification/editnotificationModal.html", MODULE_ERP_CORE),
                "editnotificationModalCtrl",
                data, { size: "lg", keyboard: false },
                [HelpersErp.getUrlByFeaturesBase("notification/editnotificationModalCtrl.js", MODULE_ERP_CORE)]);
        };
    }]);


});

