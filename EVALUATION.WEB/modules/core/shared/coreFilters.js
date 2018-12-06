"use strict";

/* Filters */

define(["app", "definitions", "utilities"], function (app) {

    //var EVALUATIONErpFilters = definitions.EVALUATIONErpFilters;

    app.filter('selected', [
        '$filter', function($filter) {
            return function(files) {
                return $filter('filter')(files, {
                    selected: true
                });
            };
        }
    ]);

});