define(['app','parameters','definitions', 'utilities', 'oc-lazy-load', 'erp-services'], function () {
    'use strict';

    /* Services */
    serviceGlobal.service('erpMenu', ['$http', 'urlSw', function ($http, urlSw) {
        var mainSelf = this;

        mainSelf.getMenu = function () {

            var hostedWcfAdressBase = window.location.protocol + "//" + window.location.hostname;
            /*Adresse services*/
            var urlServiceBase = hostedWcfAdressBase + ":" + window.location.port + "/app/";

            return $http.get(urlServiceBase + 'menu/menu.json?bust='+new Date().getTime(), {
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).success(function (response) {
                return response.data;

            });
            
            
        };


        


    }]);



});

