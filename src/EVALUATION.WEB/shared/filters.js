"use strict";

/* Filters */

define(["definitions", "utilities"], function (definitions) {

    //var EVALUATIONErpFilters = definitions.EVALUATIONErpFilters;


    EVALUATIONErpFilters.filter('getByValue', function () {
        return function (input,value,column) {
            var i = 0, len = input.length;
            for (; i < len; i++) {
                if (column==null) {
                    if (+input[i] == +value) {
                        return input[i];
                    }
                }
                else {
                    if (+input[i][column] == +value) {
                        return input[i][column];
                    }
                }
               
            }
            return null;
        }
    });

    EVALUATIONErpFilters.filter("genre", ["commonUtilities", function (commonUtilities) {
        return function (code) {

                if (commonUtilities.IsUndefinedOrNull(code))
                    return "";

                if (code === 1 || code === 0) {
                    return code === 1 ? "Masculin" : "Féminin";
                }

                if (code === "M" || code === "F") {
                    return code === "M" ? "Masculin" : "Féminin";
                }
            }
        }
    ]);

    EVALUATIONErpFilters.filter("fromNow", [function () {
        return function(date) {
            return moment(date).fromNow();
        };
    }]);

    EVALUATIONErpFilters.filter('stringToDate', function () {
        return function (input) {
            if (!input)
                return null;

            var date = moment(input);
            return date.isValid() ? date.toDate() : null;
        };
    });

    EVALUATIONErpFilters.filter("jsonDate", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input, format) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;

            return $filter("date")(parseInt(input.substr(6)), format);
        };
    }]);

    EVALUATIONErpFilters.filter("nDate", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input, format) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;
            var d = new Date(input).toISOString().slice(0, 10);
            var dFormatted = $filter("date")(d, format);
            return dFormatted;
        };
    }]);

    EVALUATIONErpFilters.filter("jsonDateUtc", [
        "$filter", "commonUtilities", function ($filter, commonUtilities) {
            return function (input) {
                if (commonUtilities.IsUndefinedOrNull(input))
                    return null;

                var dateStr = $filter("jsonDate")(input, "yyyy-MM-ddThh:mm:ssZ");
                return new Date(Date.parse(dateStr));
            };
        }
    ]);

    EVALUATIONErpFilters.filter("dateJson", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input) {

            if (commonUtilities.IsUndefinedOrNull(input))
                return null;

            return "\/Date(" + (commonUtilities.formatUTCDate(input)) + ")\/";
        };
    }]);

    EVALUATIONErpFilters.filter("computeDateToNowJsonFormat", ["commonUtilities", "$filter", function (commonUtilities, $filter) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return "";

            var yyyyMMdd = $filter("date")(parseInt(input.substr(6)), "yyyy/MM/dd");
            var debut = commonUtilities.formatYYYYMMDDToDate(yyyyMMdd);
            var now = commonUtilities.currentDate();
            var time = commonUtilities.dateDiffFormatee(debut, now);

            return time;
        };
    }]);

    EVALUATIONErpFilters.filter("computeDateToNow", ["commonUtilities", "$filter", function (commonUtilities, $filter) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return "";

            var debut = new Date(input);
            var now = commonUtilities.currentDate();
            var time = commonUtilities.dateDiffFormatee(debut, now);

            return time;
        };
    }]);

    EVALUATIONErpFilters.filter("shortMessage", ["commonUtilities", function (commonUtilities) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return "";

            var messageAbrege = input.length > 30 ? input.substring(0, 30) + "..." : input;
            return messageAbrege;
        };
    }]);


    EVALUATIONErpFilters.filter("jsonDateUtc", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;

            var dateStr = $filter("jsonDate")(input, "yyyy-MM-ddThh:mm:ssZ");
            return new Date(Date.parse(dateStr));
        };
    }]);

    EVALUATIONErpFilters.filter("utcJsonDate", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;
            var parsedDate = $.fullCalendar.parseDate(input);
            var date = $.fullCalendar.formatDate(parsedDate, "yyyy/MM/dd");
            date = $filter("dateJson")(date);
            return (date);
        };
    }]);

    EVALUATIONErpFilters.filter("formatMillier", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;

            return commonUtilities.formatMillier(input);
        };
    }]);

    EVALUATIONErpFilters.filter("formatMillierRec", ["$filter", "commonUtilities", function ($filter, commonUtilities) {
        return function (input) {
            if (commonUtilities.IsUndefinedOrNull(input))
                return null;

            return commonUtilities.formatMillierRec(input);
        };
    }]);
});
