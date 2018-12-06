define(['definitions', 'utilities'], function () {
    'use strict';

    /* Parameters */

    parameters.service('constantesDefinitions', [
        function () {
            var self = this;

        }
    ]);
    
    parameters.service('urlSw', ['commonUtilities', function (commonUtilities) {
        var self = this;

        self.useHostedWcf = false;
        self.useNodeApi = true;



        //self.HostedWcfIpBase = "http://147.135.253.152";
       
        self.HostedWcfIpBase = "http://localhost";

        self.HostedWcfAdressBase = window.location.protocol + "//" + window.location.hostname;
        /*Adresse services*/
        self.UrlServiceBase = self.HostedWcfAdressBase + ":" + window.location.port + "/api";
        self.UrlServiceToken = self.HostedWcfAdressBase + ":" + window.location.port;

        self.UrlReportingBase = self.HostedWcfIpBase + ":19162/api";

        /* Url du serveur des reports */
        self.UrlReportRdl = self.HostedWcfAdressBase;

        /* Url du service web */
        self.UrlHostedReportingBase = self.HostedWcfAdressBase;

        self.ReportServerName = "ReportServer";
        self.ReportFolder = "REPORT_ERP_V3_SCCONAS";

        self.getUrl = function (base, uri, method) {
            var port = '';

            if (self.useHostedWcf) {

                if (self.useNodeApi) {
                    base = "/api";
                } else {
                    switch (base) {
                        case self.UrlServiceBase:
                            port = '59425';
                            break;
                        default:
                    }
                    base = commonUtilities.hostAdresse() + ':' + port;

                }
            }

            var url = base + '/'+uri+'/' + method;
            commonUtilities.writeInConsole(url);
            return url;
        };

        self.getReportingUrl = function (base) {

            var url = base + '/Reports/';
            return url;
        };

        self.getReportRdlUrlBase = function () {

            var base = !self.useHostedWcf ? self.UrlReportRdl : self.UrlHostedReportingBase;

            var url = base + "/" + self.ReportServerName + "/Pages/ReportViewer.aspx?%2f" + self.ReportFolder + "%2f";

            commonUtilities.writeInConsole(url);

            return url;
        }

    }]);
});