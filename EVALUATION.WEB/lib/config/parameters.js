
define(['definitions', 'utilities'], function () {
    'use strict';

    /* Parameters */    
    
    parameters.service('urlSw', ['commonUtilities', function (commonUtilities) {
        var self = this;

        self.useHostedWcf = false;        

        //self.UrlHostedWcfBase = 'http://localhost:1648';
        //self.UrlHostedWcfBase = 'http://geovani-pc:9080';
        //self.UrlHostedWcfBase = 'http://192.168.1.38:9898';
        self.UrlHostedWcfBase = 'http://localhost:9898';
        self.UrlHostedReportingBase = 'http://localhost:9896';
        //self.UrlHostedReportingBase = 'http://localhost:9896';

        self.urlSb = 'http://localhost:13660';
        //self.urlSb = 'http://192.168.173.1:13660';
        //self.UrlMgBase = "http://localhost:6384";
        self.UrlMgBase = "http://localhost:33386";
        //self.UrlMgBase = "http://192.168.173.1:6384";    
        self.UrlAdminBase = "http://localhost:18864";
        //self.UrlAdminBase = "http://192.168.173.1:18864";
        //self.UrlAdminBase = 'http://localhost:9898'; //  utiliser pour ne pas ouvrir le projet admin pour l'authentification. un web service est deja hebergé
        self.UrlGsBase = "http://localhost:10486";
        //self.UrlGsBase = "http://192.168.173.1:10486";
        self.UrlImaliTresoBase = "http://localhost:5968";
        self.UrlHisSaBase = "http://localhost:44591";
        self.UrlHisBase = 'http://localhost:5094';
        //self.UrlReportingBase = 'http://192.168.173.1:19162';
        self.UrlReportingBase = 'http://localhost:19162';
        //self.UrlReportingBase = 'http://localhost:9797';
        //self.UrlReportingBase = 'http://localhost:19162';
        self.UrlComptaBase = 'http://localhost:5029';
        self.UrlSaBase = 'http://localhost:44591';
        self.UrlCaisseBase = 'http://localhost:47761';
        self.UrlTresoBase = 'http://localhost:5968';
        self.UrlGcBase = 'http://localhost:3255';

        self.getUrl = function (base, uri, method) {
            var host = '';
            var svc = '';

            if (self.useHostedWcf) {
                base = self.UrlHostedWcfBase;
                host = '/Hosts';
                svc = '.svc';
            }
            var url = base + host + '/' + uri + svc + '/' + method;
            commonUtilities.writeInConsole(url);
            return url;
        };

        self.getReportingUrl = function () {

            var base = !self.useHostedWcf ? self.UrlReportingBase : self.UrlHostedReportingBase;

            var url = base + '/api/reports/';
            commonUtilities.writeInConsole(url);
            return url;
        };
    }]);
});

