define(['app', 'parameters'], function (app) {
    'use strict';


    app.factory("crudServices", [
        "$resource", "urlSw", function ($resource, urlSw) {
            var url = urlSw.getUrl(urlSw.UrlServiceBase, ":service", ":method");

            return $resource(url, {}, {

                // CrudTypePartenaire
                GetFsTypePartenaireById: { method: "GET", params: { service: "FsGeneratedCtrl", method: "GetFsTypePartenaireById", id:"@id"} },
                DeleteFsTypePartenaires: { method: "POST", params: { service: "FsGeneratedCtrl", method: "DeleteFsTypePartenaires" } },

                GetFsTypePartenairesByCriteria: { method: "POST", params: { service: "FsGeneratedCtrl", method: "GetFsTypePartenairesByCriteria" } },
                SaveFsTypePartenaires: { method: "POST", params: { service: "FsGeneratedCtrl", method: "SaveFsTypePartenaires" } },
       
            });
        }
    ]);
});