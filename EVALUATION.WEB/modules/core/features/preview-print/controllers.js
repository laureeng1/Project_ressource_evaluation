define(['app', 'utilities', 'angular-dialog-service'], function(app) {
    'use strict';

    /* Controllers */

    app.controller('PreviewPrintCtrl', ['$scope', '$document', '$modalInstance', 'data', 'urlSw', '$timeout', function($scope, $document, $modalInstance, data, urlSw, $timeout) {

        var reportLibrary = 'Reports.Library';

        var showReport = function(folder, reportClass, parametersData, moduleAbrege) {
			moduleAbrege = !moduleAbrege ? '' : '.' + moduleAbrege;
				
            var reportToShow = reportLibrary + moduleAbrege + "." + folder + "." + reportClass + ", " + reportLibrary + moduleAbrege;

            $("#reportViewer").telerik_ReportViewer({
                serviceUrl: urlSw.getReportingUrl(urlSw.UrlReportingBase),
                templateUrl: HelpersErp.getUrlByManualLoadedLibsBase('ReportViewer/templates/telerikReportViewerTemplate.html'),
                reportSource: {
                    report: reportToShow,
                    parameters: parametersData
                },
                viewMode: "ViewModes.PRINT_PREVIEW",
                scaleMode: "ScaleModes.FIT_PAGE",
                scale: "1.0"
            });
        };

        $scope.cancel = function() {
            $modalInstance.dismiss('canceled');
        };

        $scope.init = function() {
            showReport(data.folder, data.reportClass, data.parametersData, data.moduleAbrege);
        };

    }]);

});