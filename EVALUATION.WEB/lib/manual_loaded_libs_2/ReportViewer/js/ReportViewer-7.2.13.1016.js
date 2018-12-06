﻿/*
* TelerikReporting v7.2.13.1016 (http://www.telerik.com/products/reporting.aspx)
* Copyright 2013 Telerik AD. All rights reserved.
*
* Telerik Reporting commercial licenses may be obtained at
* http://www.telerik.com/purchase/license-agreement/reporting.aspx
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
(function(trv, $, window, document, undefined) {
    "use strict";
    var stringFormatRegExp = /{(\w+?)}/g;
    var utils = trv.utils = {
        trim: function(s, charlist) {
            return this.rtrim(this.ltrim(s, charlist), charlist);
        },
        ltrim: function(s, charlist) {
            if (charlist === undefined) {
                charlist = "s";
            }
            return s.replace(new RegExp("^[" + charlist + "]+"), "");
        },
        rtrim: function(s, charlist) {
            if (charlist === undefined) {
                charlist = "s";
            }
            return s.replace(new RegExp("[" + charlist + "]+$"), "");
        },
        stringFormat: function(template, data) {
            var isArray = Array.isArray(data);
            return template.replace(stringFormatRegExp, function($0, $1) {
                return data[isArray ? parseInt($1) : $1];
            });
        },
        tryParseInt: function(value) {
            if (/^(\-|\+)?([0-9]+)$/.test(value)) {
                return Number(value);
            }
            return NaN;
        },
        tryParseFloat: function(value) {
            if (/^(\-|\+)?([0-9]+(\.[0-9]+)?)$/.test(value)) {
                return Number(value);
            }
            return NaN;
        },
        parseToLocalDate: function(date) {
            if (date instanceof Date) return date;
            date = new Date(date);
            return date;
        },
        adjustTimezone: function(date) {
            return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds(), date.getMilliseconds()));
        },
        unadjustTimezone: function(date) {
            return new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds(), date.getUTCMilliseconds());
        },
        reportSourcesAreEqual: function(rs1, rs2) {
            if (rs1 && rs2 && rs1.report === rs2.report) {
                var params1 = [], params2 = [];
                if (rs1.parameters) params1 = Object.getOwnPropertyNames(rs1.parameters);
                if (rs2.parameters) params2 = Object.getOwnPropertyNames(rs2.parameters);
                if (params1.length == params2.length) {
                    for (var i = params1.length - 1; i >= 0; i--) {
                        var p = params1[i];
                        var v1 = rs1.parameters[p];
                        var v2 = rs2.parameters[p];
                        if (Array.isArray(v1)) {
                            if (!Array.isArray(v2)) return false;
                            if (v1.length != v2.length) return false;
                            for (var j = v1.length - 1; j >= 0; j--) {
                                if (v1[j] !== v2[j]) return false;
                            }
                        } else if (v1 instanceof Date && v2 instanceof Date) {
                            if (v1.getTime() != v2.getTime()) {
                                return false;
                            }
                        } else if (v1 !== v2) {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    };
    trv.domUtils = function() {
        function toPixels(value) {
            return parseInt(value, 10) || 0;
        }
        return {
            getMargins: function(dom) {
                var $target = $(dom);
                return {
                    left: toPixels($target.css("marginLeft")),
                    right: toPixels($target.css("marginRight")),
                    top: toPixels($target.css("marginTop")),
                    bottom: toPixels($target.css("marginBottom"))
                };
            },
            getPadding: function(dom) {
                var $target = $(dom);
                return {
                    left: toPixels($target.css("paddingLeft")),
                    right: toPixels($target.css("paddingRight")),
                    top: toPixels($target.css("paddingTop")),
                    bottom: toPixels($target.css("paddingBottom"))
                };
            },
            getBorderWidth: function(dom) {
                var $target = $(dom);
                return {
                    left: toPixels($target.css("borderLeftWidth")),
                    right: toPixels($target.css("borderRightWidth")),
                    top: toPixels($target.css("borderTopWidth")),
                    bottom: toPixels($target.css("borderBottomWidth"))
                };
            },
            scale: function(dom, scaleX, scaleY, originX, originY) {
                scaleX = scaleX || 1;
                scaleY = scaleY || 1;
                originX = originX || 0;
                originY = originY || 0;
                var scale = utils.stringFormat("scale({0}, {1})", [ scaleX, scaleY ]), origin = utils.stringFormat("{0} {1}", [ originX, originY ]);
                $(dom).css("transform", scale).css("-moz-transform", scale).css("-ms-transform", scale).css("-webkit-transform", scale).css("-o-transform", scale).css("-moz-transform-origin", origin).css("-webkit-transform-origin", origin).css("-o-transform-origin", origin).css("-ms-transform-origin", origin).css("transform-origin", origin);
            }
        };
    }();
})(window.telerikReportViewer = window.telerikReportViewer || {}, window.jQuery, window, document);

(function(trv, $) {
    "use strict";
    var sr = {
        controllerNotInitialized: "Controller is not initialized",
        noReportInstance: "No report instance.",
        missingTemplate: "ReportViewer template is missing. Please specify the templateUrl in the options.",
        noReport: "No report",
        noReportDocument: "No report document",
        invalidParameter: "Please input a valid value",
        parameterIsEmpty: "Parameter cannot be empty",
        cannotValidateType: "Cannot validate parameter of type {type}",
        loadingFormats: "Loading...",
        loadingReport: "Loading report...",
        preparingDownload: "Preparing document to download. Please wait...",
        preparingPrint: "Preparing document to print. Please wait...",
        errorLoadingTemplates: "Error loading the report viewer's templates",
        loadingReportPagesInProgress: "{0} pages loaded so far ...",
        loadedReportPagesComplete: "Done. Total {0} pages loaded."
    };
    trv.sr = $.extend(sr, trv.sr);
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery);

(function(trv, $, undefined) {
    "use strict";
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    var JSON_MIME_TYPE = "application/json", JSON_CONTENT_TYPE = "application/json; charset=UTF-8", HTTP_GET = "GET", HTTP_POST = "POST", HTTP_PUT = "PUT", HTTP_DELETE = "DELETE";
    var defaultOptions = {};
    trv.ServiceClient = function(options) {
        options = $.extend({}, defaultOptions, options);
        var baseUrl = utils.rtrim(options.address || options.baseUrl, "\\/");
        function validateClientID(clientID) {
            if (!clientID) throw "Invalid cliendID";
        }
        function urlFromTemplate(template, args) {
            args = $.extend({}, {
                baseUrl: baseUrl
            }, args);
            return utils.stringFormat(template, args);
        }
        return {
            _urlFromTemplate: urlFromTemplate,
            registerClient: function(settings) {
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_POST,
                    url: urlFromTemplate("{baseUrl}/clients"),
                    dataType: "json"
                });
                return $.ajax(ajaxSettings);
            },
            unregisterClient: function(clientID, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_DELETE,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}", {
                        clientID: clientID
                    })
                });
                return $.ajax(ajaxSettings);
            },
            getParameters: function(clientID, report, parameterValues, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_POST,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/parameters", {
                        clientID: clientID
                    }),
                    contentType: JSON_CONTENT_TYPE,
                    dataType: "json",
                    data: JSON.stringify({
                        report: report,
                        parameterValues: parameterValues
                    })
                });
                return $.ajax(ajaxSettings);
            },
            createReportInstance: function(clientID, report, parameterValues, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_POST,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances", {
                        clientID: clientID
                    }),
                    contentType: JSON_CONTENT_TYPE,
                    dataType: "json",
                    data: JSON.stringify({
                        report: report,
                        parameterValues: parameterValues
                    })
                });
                return $.ajax(ajaxSettings);
            },
            deleteReportInstance: function(clientID, instanceID, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_DELETE,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}", {
                        clientID: clientID,
                        instanceID: instanceID
                    })
                });
                return $.ajax(ajaxSettings);
            },
            createReportDocument: function(clientID, instanceID, format, deviceInfo, settings) {
                validateClientID(clientID);
                deviceInfo = deviceInfo || {};
                deviceInfo["BasePath"] = baseUrl;
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_POST,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents", {
                        clientID: clientID,
                        instanceID: instanceID
                    }),
                    contentType: JSON_CONTENT_TYPE,
                    dataType: "json",
                    data: JSON.stringify({
                        format: format,
                        deviceInfo: deviceInfo
                    })
                });
                return $.ajax(ajaxSettings);
            },
            deleteReportDocument: function(clientID, instanceID, documentID, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_DELETE,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents/{documentID}", {
                        clientID: clientID,
                        instanceID: instanceID,
                        documentID: documentID
                    })
                });
                return $.ajax(ajaxSettings);
            },
            getDocumentInfo: function(clientID, instanceID, documentID, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_GET,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents/{documentID}/info", {
                        clientID: clientID,
                        instanceID: instanceID,
                        documentID: documentID
                    }),
                    dataType: "json"
                });
                return $.ajax(ajaxSettings);
            },
            getPage: function(clientID, instanceID, documentID, pageNumber, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_GET,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents/{documentID}/pages/{pageNumber}", {
                        clientID: clientID,
                        instanceID: instanceID,
                        documentID: documentID,
                        pageNumber: pageNumber
                    }),
                    dataType: "json"
                });
                return $.ajax(ajaxSettings);
            },
            execServerAction: function(clientID, instanceID, documentID, actionID, settings) {
                validateClientID(clientID);
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_PUT,
                    url: urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents/{documentID}/actions/{actionID}", {
                        clientID: clientID,
                        instanceID: instanceID,
                        documentID: documentID,
                        actionID: actionID
                    })
                });
                return $.ajax(ajaxSettings);
            },
            formatDocumentUrl: function(clientID, instanceID, documentID) {
                return urlFromTemplate("{baseUrl}/clients/{clientID}/instances/{instanceID}/documents/{documentID}", {
                    clientID: clientID,
                    instanceID: instanceID,
                    documentID: documentID
                });
            },
            getDocumentFormats: function(settings) {
                var ajaxSettings = $.extend({}, settings, {
                    type: HTTP_GET,
                    url: urlFromTemplate("{baseUrl}/formats")
                });
                return $.ajax(ajaxSettings);
            }
        };
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr;
    if (!sr) {
        throw "Missing telerikReportViewer.sr";
    }
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReportViewer.utils";
    }
    trv.ViewModes = {
        INTERACTIVE: "INTERACTIVE",
        PRINT_PREVIEW: "PRINT_PREVIEW"
    };
    var defaultOptions = {
        pagePollIntervalMs: 500,
        documentInfoPollIntervalMs: 2e3
    };
    function ReportViewerController(options) {
        var controller = {}, $controller = $(controller), clientId, reportInstanceId, reportDocumentId, registerClientDfd, reportInstanceDfd, getDocumentFormatsDfd, report, parameterValues, currentPageNumber, pageCount, viewMode = trv.ViewModes.INTERACTIVE, documentFormats, loader;
        options = jQuery.extend({}, defaultOptions, options);
        var client = options.serviceClient;
        if (!client) {
            throw "No serviceClient has been specified for this controller.";
        }
        clientId = options.settings.clientId();
        function setCleintId(id) {
            clientId = id;
            options.settings.clientId(clientId);
        }
        function getFormat() {
            if (viewMode === trv.ViewModes.PRINT_PREVIEW) {
                return "HTML5";
            }
            return "HTML5Interactive";
        }
        function isInitialized() {
            return Boolean(clientId);
        }
        function initializeClientAsync() {
            if (clientId) {
                return clientId;
            }
            if (registerClientDfd) {
                return registerClientDfd;
            }
            registerClientDfd = client.registerClient();
            $.when(registerClientDfd).done(function(id) {
                setCleintId(id);
                registerClientDfd = null;
            }).fail(function(xhr, status, error) {
                logError("Error registering the viewer with the service");
                registerClientDfd = null;
            });
            return registerClientDfd;
        }
        function registerInstanceAsync() {
            if (reportInstanceId) {
                return reportInstanceId;
            }
            if (reportInstanceDfd) {
                return reportInstanceDfd;
            }
            reportInstanceDfd = createReportInstanceAsync(report, parameterValues);
            $.when(reportInstanceDfd).done(function(id) {
                setReportInstance(id);
                reportInstanceDfd = null;
            }).fail(function() {
                reportInstanceDfd = null;
            });
            return reportInstanceDfd;
        }
        function clearReportState(ignoreCache) {
            if (ignoreCache) {
                deleteReportInstance();
            }
            reportDocumentId = reportInstanceId = null;
            currentPageNumber = pageCount = 0;
        }
        function setReportInstance(id) {
            reportInstanceId = id;
        }
        function deleteReportInstance() {
            if (clientId && reportInstanceId) {
                client.deleteReportInstance(clientId, reportInstanceId).fail(function(xhr, status, error) {
                    logError("Error deleting report instance: {0}", reportInstanceId);
                });
            }
        }
        function formatError(args) {
            var len = args.length;
            if (len == 1) {
                return args[0];
            }
            if (len > 1) {
                return utils.stringFormat(args[0], Array.prototype.slice.call(args, 1));
            }
            return "";
        }
        function logError() {
            controller.error(formatError(arguments));
        }
        function createReportInstanceAsync(report, parameterValues) {
            throwIfNotInitialized();
            return client.createReportInstance(clientId, report, parameterValues);
        }
        function registerDocumentAsync(format, deviceInfo) {
            throwIfNotInitialized();
            throwIfNoReportInstance();
            return client.createReportDocument(clientId, reportInstanceId, format, deviceInfo);
        }
        function getDocumentInfoRecursive(deferred, clientId, instanceId, documentId) {
            client.getDocumentInfo(clientId, instanceId, documentId).done(function(info, status, xhr) {
                if (info && info.documentReady) {
                    deferred.resolve.apply(deferred, arguments);
                } else {
                    deferred.notify.apply(deferred, arguments);
                    window.setTimeout(function() {
                        getDocumentInfoRecursive(deferred, clientId, instanceId, documentId);
                    }, options.documentInfoPollIntervalMs);
                }
            }).fail(function() {
                deferred.reject.apply(deferred, arguments);
            });
        }
        function getDocumentReadyAsync(clientId, instanceId, documentId) {
            var dfd = $.Deferred();
            getDocumentInfoRecursive(dfd, clientId, instanceId, documentId);
            return dfd.promise();
        }
        function ReportLoader(reportHost) {
            function onReportDocumentRegistered(id) {
                if (reportHost) {
                    reportDocumentId = id;
                    onBeginLoadReport();
                    getReportDocumentReady();
                }
            }
            function onBeforeLoadReport() {
                if (reportHost) {
                    reportHost.beforeLoadReport();
                }
            }
            function onBeginLoadReport() {
                if (reportHost) {
                    reportHost.beginLoadReport();
                }
            }
            function onReportLoadComplete(info) {
                if (reportHost) {
                    pageCount = info.pageCount;
                    reportHost.reportLoadComplete(info);
                }
            }
            function onReportLoadProgress(info) {
                if (reportHost) {
                    pageCount = info.pageCount;
                    reportHost.reportLoadProgress(info);
                }
            }
            function getReportDocumentReady() {
                throwIfNotInitialized();
                throwIfNoReportInstance();
                throwIfNoReportDocument();
                $.when(getDocumentReadyAsync(clientId, reportInstanceId, reportDocumentId)).done(function(info) {
                    onReportLoadComplete(info);
                }).fail(function(xhr, error, status) {
                    onError(formatXhrError(xhr, status, error));
                }).progress(function(info) {
                    onReportLoadProgress(info);
                });
            }
            function onError() {
                if (reportHost) {
                    reportHost.error(formatError(arguments));
                }
            }
            function getPageRecursive(deferred, pageNo) {
                client.getPage(clientId, reportInstanceId, reportDocumentId, pageNo).done(function(info, status, xhr) {
                    if (info && info.pageReady) {
                        deferred.resolve.apply(deferred, arguments);
                    } else {
                        deferred.notify.apply(deferred, arguments);
                        window.setTimeout(function() {
                            getPageRecursive(deferred, pageNo);
                        }, options.pagePollIntervalMs);
                    }
                }).fail(function() {
                    deferred.reject.apply(deferred, arguments);
                });
            }
            function getPageAsync(pageNo) {
                var d = $.Deferred();
                getPageRecursive(d, pageNo);
                return d.promise();
            }
            function onBeginLoadPage(pageNo) {
                if (reportHost) {
                    reportHost.beginLoadPage(pageNo);
                }
            }
            function onPageLoadComplete(pageNo, pageInfo) {
                if (reportHost) {
                    reportHost.pageReady(pageInfo);
                }
            }
            var loadPromise;
            function loadAsync() {
                if (reportInstanceId) return reportInstanceId;
                if (loadPromise) return loadPromise;
                var dfd = $.Deferred();
                loadPromise = dfd.promise();
                onBeforeLoadReport();
                var format = getFormat(), deviceInfo = {
                    ActionsAsAttributes: true
                };
                $.when(initializeClientAsync()).then(registerInstanceAsync, function(xhr, status, error) {
                    dfd.reject(xhr, status, "Error registering client instance");
                }).then(function() {
                    return registerDocumentAsync(format, deviceInfo);
                }, function(xhr, status, error) {
                    dfd.reject(xhr, status, utils.stringFormat("Error creating report instance (Report = {0})", [ report ]));
                }).then(function(id) {
                    dfd.resolve(id);
                }, function(xhr, status, error) {
                    dfd.reject(xhr, status, utils.stringFormat("Error creating report document (Report = {0}; Format = {1})", [ report, format ]));
                });
                $.when(loadPromise).done(function(id) {
                    onReportDocumentRegistered(id);
                    loadPromise = null;
                }).fail(function(xhr, status, error) {
                    onError(formatXhrError(xhr, status, error));
                    loadPromise = null;
                });
                return loadPromise;
            }
            return {
                beginLoad: function() {
                    loadAsync();
                },
                beginGetPage: function(pageNo) {
                    throwIfNotInitialized();
                    $.when(loadAsync()).then(function() {
                        onBeginLoadPage(pageNo);
                        return getPageAsync(pageNo);
                    }).done(function(info) {
                        onPageLoadComplete(pageNo, info);
                    }).fail(function(xhr, status, error) {
                        onError(formatXhrError(xhr, status, error));
                    }).progress(function() {});
                },
                dispose: function() {
                    reportHost = null;
                }
            };
        }
        function formatXhrError(xhr, status, error) {
            var err;
            try {
                var msg = JSON.parse(xhr.responseText);
                if (msg) {
                    err = msg.Message;
                    if (msg.ExceptionMessage) {
                        if (err) {
                            err += "<br/>";
                        }
                        err += msg.ExceptionMessage;
                    }
                }
            } catch (e) {
                err = xhr.responseText;
            }
            return err || error;
        }
        function getReportPage(pageNo) {
            if (loader) {
                loader.beginGetPage(pageNo);
            }
        }
        function loadReportAsync(ignoreCache) {
            if (!report) {
                logError(sr.noReport);
                return;
            }
            if (loader) {
                loader.dispose();
                loader = null;
            }
            clearReportState(ignoreCache);
            loader = new ReportLoader(controller);
            loader.beginLoad();
        }
        function onExportStarted() {
            controller.exportStarted();
        }
        function onExportDocumentReady(args) {
            controller.exportReady(args);
        }
        function onPrintStarted() {
            controller.printStarted();
        }
        function onPrintDocumentReady(args) {
            controller.printReady(args);
        }
        function printReport() {
            throwIfNoReport();
            onPrintStarted();
            exportAsync("PDF", {
                ImmediatePrint: true
            }).then(function(info) {
                var url = client.formatDocumentUrl(info.clientId, info.instanceId, info.documentId);
                onPrintDocumentReady({
                    url: url
                });

                return url;
            }, function() {
                logError();
            }).then(function (url) {

                var xhr = new XMLHttpRequest();
                xhr.open("GET", url);
                xhr.responseType = "arraybuffer";

                xhr.onload = function () {
                    if (this.status === 200) {
                        var blob = new Blob([xhr.response], { type: "application/pdf" });
                        var objectUrl = URL.createObjectURL(blob);
                        window.open(objectUrl, "_blank");
                    }
                };
                xhr.send();
            });
        }
        function exportReport(format, deviceInfo) {
            throwIfNoReport();
            onExportStarted();
            exportAsync(format, deviceInfo).then(function(info) {
                var url = client.formatDocumentUrl(info.clientId, info.instanceId, info.documentId);
                onExportDocumentReady({
                    url: url
                });
                return url;
            }, function() {
                logError();
            }).then(function(url) {
                window.open(url, "_self");
            });
        }
        function exportAsync(format, deviceInfo) {
            throwIfNoReport();
            var dfd = $.Deferred();
            var documentID;
            $.when(initializeClientAsync()).then(registerInstanceAsync).then(function() {
                return registerDocumentAsync(format, deviceInfo);
            }, function(xhr, status, error) {
                logError("Error creating report instance: Report={0}", report);
                dfd.reject();
            }).then(function(docId) {
                documentID = docId;
                return getDocumentReadyAsync(clientId, reportInstanceId, docId);
            }, function() {
                logError("Error creating report document: Report={0}; Format={1}", report, format);
                dfd.reject();
            }).then(function(info) {
                dfd.resolve({
                    clientId: clientId,
                    instanceId: reportInstanceId,
                    documentId: documentID
                });
            }, function(info) {
                logError("Error obtaining document ready state: Report={0}; Format={1}", report, format);
                dfd.reject();
            });
            return dfd.promise();
        }
        function execServerAction(actionId) {
            throwIfNoReport();
            throwIfNoReportInstance();
            throwIfNoReportDocument();
            $.when(client.execServerAction(clientId, reportInstanceId, reportDocumentId, actionId)).done(function() {
                controller.refreshReport();
            }).fail(function(xhr, status, error) {
                logError(xhr.responseText);
            });
        }
        function throwIfNotInitialized() {
            if (!isInitialized()) {
                throw sr.controllerNotInitialized;
            }
        }
        function throwIfNoReportInstance() {
            if (!reportInstanceId) {
                throw sr.noReportInstance;
            }
        }
        function throwIfNoReportDocument() {
            if (!reportDocumentId) {
                throw sr.noReportDocument;
            }
        }
        function throwIfNoReport() {
            if (!report) {
                throw sr.noReport;
            }
        }
        function getEventHandlerFromArguments(args) {
            var arg0;
            if (args && args.length) {
                arg0 = args[0];
            }
            if (typeof arg0 == "function") {
                return arg0;
            }
            return null;
        }
        function eventFactory(event, args) {
            var h = getEventHandlerFromArguments(args);
            if (h) {
                $controller.bind(event, h);
            } else {
                $controller.trigger(event, args);
            }
            return controller;
        }
        function loadParametersAsync(report, paramValues) {
            var d = new $.Deferred();
            $.when(initializeClientAsync()).then(function() {
                return client.getParameters(clientId, report, paramValues || parameterValues || {}).fail(function(xhr, status, error) {
                    logError(formatXhrError(xhr, status, error));
                });
            }, function() {
                d.reject.apply(d, arguments);
            }).then(function(args) {
                d.resolve(args);
            }, function() {
                d.reject.apply(d, arguments);
            });
            return d.promise();
        }
        function getDocumentFormatsAsync() {
            if (documentFormats) return documentFormats;
            if (getDocumentFormatsDfd) return getDocumentFormatsDfd;
            getDocumentFormatsDfd = client.getDocumentFormats().done(function(formats) {
                documentFormats = formats;
                getDocumentFormatsDfd = null;
            }).fail(function() {
                getDocumentFormatsDfd = null;
            });
            return getDocumentFormatsDfd;
        }
        function getPageForBookmark(nodes, id) {
            if (nodes) {
                for (var i = 0, len = nodes.length; i < len; i++) {
                    var node = nodes[i];
                    if (node.id == id) {
                        return node.page;
                    } else {
                        var page = getPageForBookmark(node.items, id);
                        if (page) {
                            return page;
                        }
                    }
                }
            }
            return null;
        }
        function fixDataContractJsonSerializer(arr) {
            var dict = {};
            if (Array.isArray(arr)) {
                arr.forEach(function(pair) {
                    dict[pair.Key] = pair.Value;
                });
            }
            return dict;
        }
        var actionHandlers = {
            toggleVisibility: function(args) {
                execServerAction(args.actionId);
            },
            navigateToReport: function(args) {
                loadParametersAsync(args.Report, fixDataContractJsonSerializer(args.ParameterValues)).done(function(p) {
                    var params = {};
                    $.each(p || [], function() {
                        if (Boolean(this.value)) {
                            params[this.name] = this.value;
                        }
                    });
                    controller.reportSource({
                        report: args.Report,
                        parameters: params
                    });
                });
            },
            navigateToUrl: function(args) {
                window.open(args.Url, args.Target);
            },
            navigateToBookmark: function(args) {
                var id = args, page = getPageForBookmark(id);
                controller.navigateToPage(page, id);
            }
        };
        function executeReportAction(actionType, args) {
            var handler = actionHandlers[actionType];
            if (typeof handler === "function") {
                window.setTimeout(function() {
                    handler(args);
                }, 0);
            }
        }
        $.extend(controller, {
            reportSource: function(rs) {
                if (!rs) {
                    return {
                        report: report,
                        parameters: $.extend({}, parameterValues)
                    };
                } else {
                    report = rs.report;
                    parameterValues = rs.parameters;
                    controller.reportSourceChanged();
                    return this;
                }
            },
            setParameters: function(paramValues) {
                parameterValues = paramValues;
            },
            pageCount: function() {
                return pageCount;
            },
            currentPageNumber: function(pageNo) {
                if (pageNo === undefined) return currentPageNumber;
                var num = utils.tryParseInt(pageNo);
                if (num != currentPageNumber) {
                    currentPageNumber = num;
                    this.currentPageChanged();
                }
                return this;
            },
            viewMode: function(vm) {
                if (!vm) {
                    return viewMode;
                }
                if (viewMode != vm) {
                    viewMode = vm;
                    controller.viewModeChanged(vm);
                    if (report) {
                        controller.refreshReport();
                    }
                }
                return controller;
            },
            refreshReport: function(ignoreCache) {
                return loadReportAsync(ignoreCache);
            },
            exportReport: function(format, deviceInfo) {
                exportReport(format, deviceInfo);
            },
            printReport: function() {
                printReport();
            },
            getReportPage: function(pageNumber) {
                getReportPage(pageNumber);
            },
            executeReportAction: function(actionType, args) {
                executeReportAction(actionType, args);
            },
            loadParameters: function(paramValues) {
                return loadParametersAsync(report, paramValues);
            },
            getDocumentFormats: function() {
                return getDocumentFormatsAsync();
            },
            error: function() {
                return eventFactory("trv.ERROR", arguments);
            },
            exportStarted: function() {
                return eventFactory("trv.EXPORT_STARTED", arguments);
            },
            exportReady: function() {
                return eventFactory("trv.EXPORT_DOCUMENT_READY", arguments);
            },
            printStarted: function() {
                return eventFactory("trv.PRINT_STARTED", arguments);
            },
            printReady: function() {
                return eventFactory("trv.PRINT_DOCUMENT_READY", arguments);
            },
            beforeLoadReport: function() {
                return eventFactory("trv.BEFORE_LOAD_REPORT", arguments);
            },
            beginLoadReport: function() {
                return eventFactory("trv.BEGIN_LOAD_REPORT", arguments);
            },
            reportLoadComplete: function() {
                return eventFactory("trv.REPORT_LOAD_COMPLETE", arguments);
            },
            reportLoadProgress: function() {
                return eventFactory("trv.REPORT_LOAD_PROGRESS", arguments);
            },
            beginLoadPage: function() {
                return eventFactory("trv.BEGIN_LOAD_PAGE", arguments);
            },
            pageReady: function() {
                return eventFactory("trv.PAGE_READY", arguments);
            },
            viewModeChanged: function() {
                return eventFactory("trv.VIEW_MODE_CHANGED", arguments);
            },
            reportSourceChanged: function() {
                return eventFactory("trv.REPORT_SOURCE_CHANGED", arguments);
            },
            navigateToPage: function() {
                return eventFactory("trv.NAVIGATE_TO_PAGE", arguments);
            },
            currentPageChanged: function() {
                return eventFactory("trv.CURRENT_PAGE_CHANGED", arguments);
            },
            getDocumentMapState: function() {
                return eventFactory("trv.GET_DOCUMENT_MAP_STATE", arguments);
            },
            setDocumentMapVisible: function() {
                return eventFactory("trv.SET_DOCUMENT_MAP_VISIBLE", arguments);
            },
            getParametersAreaState: function() {
                return eventFactory("trv.GET_PARAMETER_AREA_STATE", arguments);
            },
            setParametersAreaVisible: function() {
                return eventFactory("trv.SET_PARAMETER_AREA_VISIBLE", arguments);
            },
            scale: function() {
                return eventFactory("trv.PAGE_SCALE", arguments);
            },
            getScale: function() {
                return eventFactory("trv.GET_PAGE_SCALE", arguments);
            }
        });
        return controller;
    }
    trv.ReportViewerController = ReportViewerController;
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    trv.touchBehavior = function(dom, options) {
        var startDistance, ignoreTouch;
        init(dom);
        function init(element) {
            if (typeof $.fn.kendoTouch === "function") {
                $(element).mousedown(function() {
                    ignoreTouch = true;
                }).mouseup(function() {
                    ignoreTouch = false;
                }).kendoTouch({
                    multiTouch: true,
                    enableSwipe: true,
                    swipe: function(e) {
                        if (!ignoreTouch) {
                            onSwipe(e);
                        }
                    },
                    gesturestart: function(e) {
                        if (!ignoreTouch) {
                            onGestureStart(e);
                        }
                    },
                    gestureend: function(e) {
                        if (!ignoreTouch) {
                            onGestureEnd(e);
                        }
                    },
                    gesturechange: function(e) {
                        if (!ignoreTouch) {
                            onGestureChange(e);
                        }
                    },
                    doubletap: function(e) {
                        if (!ignoreTouch) {
                            onDoubleTap(e);
                        }
                    },
                    touchstart: function(e) {
                        if (!ignoreTouch) {
                            fire("touchstart");
                        }
                    }
                });
            }
        }
        function onDoubleTap(e) {
            fire("doubletap", e);
        }
        function onGestureStart(e) {
            startDistance = kendo.touchDelta(e.touches[0], e.touches[1]).distance;
        }
        function onGestureEnd(e) {}
        function onGestureChange(e) {
            var current = kendo.touchDelta(e.touches[0], e.touches[1]).distance;
            onPinch({
                distance: current,
                lastDistance: startDistance
            });
            startDistance = current;
        }
        function onSwipe(e) {
            fire("swipe", e);
        }
        function onPinch(e) {
            fire("pinch", e);
        }
        function fire(func, args) {
            var handler = options[func];
            if (typeof handler === "function") {
                handler(args);
            }
        }
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr;
    if (!sr) {
        throw "Missing telerikReportViewer.sr";
    }
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReportViewer.utils";
    }
    var domUtils = trv.domUtils;
    var touchBehavior = trv.touchBehavior;
    if (!touchBehavior) {
        throw "Missing telerikReportViewer.touch";
    }
    var defaultOptions = {};
    var scaleModes = trv.ScaleModes = {
        FIT_PAGE_WIDTH: "FIT_PAGE_WIDTH",
        FIT_PAGE: "FIT_PAGE",
        SPECIFIC: "SPECIFIC"
    };
    function PagesArea(placeholder, options) {
        options = $.extend({}, defaultOptions, options);
        var controller = options.controller;
        if (!controller) throw "No controller (telerikReportViewer.reportViewerController) has been specified.";
        var $placeholder = $(placeholder), $pageContainer = $placeholder.find(".trv-page-container"), pageContainer = $pageContainer[0], $errorMessage = $placeholder.find(".trv-error-message"), currentPageIndex = -1, pendingBookmark, pageScaleMode = scaleModes.SPECIFIC, pageScale = 1, minPageScale = .1, maxPageScale = 8, documentReady = true, navigateToPageOnDocReady, navigateToBookmarkOnDocReady;
        $(window).on("resize", function(event, args) {
            if (shouldAutosizePage()) {
                updatePageDimensions();
            }
        });
        enableTouch($placeholder);
        controller.beforeLoadReport(function() {
            if (documentReady) {
                documentReady = false;
                navigateToPageOnDocReady = 1;
                navigateToBookmarkOnDocReady = null;
            }
            clear();
            $placeholder.addClass("loading");
            showError(sr.loadingReport);
        }).beginLoadReport(function(event, args) {
            documentReady = true;
            var page = findPage(navigateToPageOnDocReady);
            if (page) {
                pageNo(page, -1);
            }
            controller.navigateToPage(navigateToPageOnDocReady, navigateToBookmarkOnDocReady);
        }).reportLoadProgress(function(event, args) {
            showError(utils.stringFormat(sr.loadingReportPagesInProgress, [ args.pageCount ]));
        }).reportLoadComplete(function(event, args) {
            showError(utils.stringFormat(sr.loadedReportPagesComplete, [ args.pageCount ]));
            window.setTimeout(showError, 2e3);
            enableInteractivity();
        }).navigateToPage(function(event, pageNumber, bookmark) {
            navigateToPage(pageNumber, bookmark);
        }).pageReady(function(event, page) {
            setPageContent(page.pageNumber, page.pageContent);
            $placeholder.removeClass("loading");
        }).error(function(event, error) {
            showError(error);
        }).exportStarted(function(event, args) {
            showError(sr.preparingDownload);
        }).exportReady(function(event, args) {
            showError();
        }).printStarted(function(event, args) {
            showError(sr.preparingPrint);
        }).printReady(function(event, args) {
            showError();
        }).scale(function(event, args) {
            setPageScale(args);
        }).getScale(function(event, args) {
            var page = getCurrentPage();
            var scale = $(page).data("pageScale") || pageScale;
            args.scale = scale;
            args.scaleMode = pageScaleMode;
        }).setDocumentMapVisible(function() {
            if (shouldAutosizePage()) {
                updatePageDimensions();
            }
        }).setParametersAreaVisible(function() {
            if (shouldAutosizePage()) {
                updatePageDimensions();
            }
        });
        function enableTouch(dom) {
            var allowSwipeLeft, allowSwipeRight;
            touchBehavior(dom, {
                swipe: function(e) {
                    var pageNumber = controller.currentPageNumber();
                    if (allowSwipeLeft && e.direction == "left") {
                        if (pageNumber < controller.pageCount()) {
                            controller.navigateToPage(pageNumber + 1);
                        }
                    } else if (allowSwipeRight && e.direction == "right") {
                        if (pageNumber > 1) {
                            controller.navigateToPage(pageNumber - 1);
                        }
                    }
                },
                pinch: function(e) {
                    var page = getCurrentPage();
                    var scale = $(page).data("pageScale") || pageScale;
                    var f = e.distance / e.lastDistance;
                    setPageScale({
                        scale: scale * f,
                        scaleMode: trv.ScaleModes.SPECIFIC
                    });
                },
                doubletap: function(e) {
                    options.commands.toggleZoomMode.exec();
                },
                touchstart: function(e) {
                    var el = $pageContainer[0];
                    allowSwipeRight = 0 == el.scrollLeft;
                    allowSwipeLeft = el.scrollWidth - el.offsetWidth == el.scrollLeft;
                }
            });
        }
        function shouldAutosizePage() {
            return -1 != [ scaleModes.FIT_PAGE, scaleModes.FIT_PAGE_WIDTH ].indexOf(pageScaleMode);
        }
        function updatePageDimensions() {
            for (var i = 0, children = pageContainer.childNodes, len = children.length; i < len; i++) {
                setPageDimensions(children[i], pageScaleMode, pageScale);
            }
        }
        function setPageScale(options) {
            pageScaleMode = options.scaleMode || pageScaleMode;
            var scale = pageScale;
            if ("scale" in options) {
                scale = options.scale;
            }
            pageScale = Math.max(minPageScale, Math.min(maxPageScale, scale));
            updatePageDimensions();
        }
        function clear() {
            disbleInteractivity();
            currentPageIndex = -1;
            pendingBookmark = undefined;
            showError();
        }
        function getCurrentPage() {
            return findPage(controller.currentPageNumber());
        }
        function findPage(pageNumber) {
            var page;
            $pageContainer.children().each(function(index, page1) {
                if (pageNo(page1) == pageNumber) {
                    page = page1;
                }
                return !page;
            });
            return page;
        }
        function navigateToPage(pageNumber, bookmark) {
            if (documentReady) {
                navigateToPageCore(pageNumber, bookmark);
            } else {
                navigateToPageOnDocumentReady(pageNumber, bookmark);
            }
        }
        function navigateToPageOnDocumentReady(pageNumber, bookmark) {
            navigateToPageOnDocReady = pageNumber;
            navigateToBookmarkOnDocReady = bookmark;
        }
        function navigateToPageCore(pageNumber, bookmark) {
            var page = findPage(pageNumber);
            if (page) {
                if (bookmark) {
                    navigateToBookmark(bookmark);
                }
            } else {
                pendingBookmark = bookmark;
                beginLoadPage(pageNumber);
            }
        }
        function navigateToBookmark(bookmark) {
            if (bookmark) {
                var el = $pageContainer.find("[data-bookmark-id=" + bookmark + "]")[0];
                if (el) {
                    var container = $pageContainer[0], offsetTop = 0, offsetLeft = 0;
                    while (el != container) {
                        if ($(el).is(".trv-page-wrapper")) {
                            var scale = $(el).data("pageScale");
                            if (typeof scale === "number") {
                                offsetTop *= scale;
                                offsetLeft *= scale;
                            }
                        }
                        offsetTop += el.offsetTop;
                        offsetLeft += el.offsetLeft;
                        el = el.offsetParent;
                    }
                    container.scrollTop = offsetTop;
                    container.scrollLeft = offsetLeft;
                }
            }
        }
        function showError(error) {
            $errorMessage.html(error);
            (error ? $.fn.addClass : $.fn.removeClass).call($placeholder, "error");
        }
        function pageNo(page, no) {
            var $page = page.$ ? page : $(page), dataKey = "pageNumber";
            if (no === undefined) {
                return $page.data(dataKey);
            }
            $page.data(dataKey, no);
            return page;
        }
        function beginLoadPage(pageNumber) {
            $placeholder.addClass("loading");
            window.setTimeout(controller.getReportPage.bind(controller, pageNumber), 1);
        }
        function setPageDimensions(page, scaleMode, scale) {
            var $target = $(page), $page = $target.find("div.trv-report-page"), $pageContent = $target.find("div.sheet"), pageContent = $pageContent[0];
            if (!pageContent) return;
            var pageWidth, pageHeight, box = $target.data("box");
            if (!box) {
                var margins = domUtils.getMargins($target), borders = domUtils.getBorderWidth($page), padding = domUtils.getPadding($page);
                box = {
                    padLeft: margins.left + borders.left + padding.left,
                    padRight: margins.right + borders.right + padding.right,
                    padTop: margins.top + borders.top + padding.top,
                    padBottom: margins.bottom + borders.bottom + padding.bottom
                };
                $target.data("box", box);
            }
            if ($target.data("pageWidth") === undefined) {
                pageWidth = pageContent.offsetWidth;
                pageHeight = pageContent.offsetHeight;
                $target.data("pageWidth", pageWidth);
                $target.data("pageHeight", pageHeight);
            } else {
                pageWidth = $target.data("pageWidth");
                pageHeight = $target.data("pageHeight");
            }
            var scrollBarV = pageHeight > pageWidth && scaleMode == scaleModes.FIT_PAGE_WIDTH ? 20 : 0, scaleW = (pageContainer.clientWidth - scrollBarV - box.padLeft - box.padRight) / pageWidth, scaleH = (pageContainer.clientHeight - 1 - box.padTop - box.padBottom) / pageHeight;
            if (scaleMode == scaleModes.FIT_PAGE_WIDTH) {
                scale = scaleW;
            } else if (!scale || scaleMode == scaleModes.FIT_PAGE) {
                scale = Math.min(scaleW, scaleH);
            }
            $target.data("pageScale", scale);
            domUtils.scale($pageContent, scale, scale);
            $page.css("height", scale * pageHeight).css("width", scale * pageWidth);
        }
        function enableInteractivity() {
            $pageContainer.on("click", "[data-reporting-action]", onInteractiveItemClick);
        }
        function disbleInteractivity() {
            $pageContainer.off("click", "[data-reporting-action]", onInteractiveItemClick);
        }
        function onInteractiveItemClick() {
            var $t = $(this);
            var actionId = $t.attr("data-reporting-action");
            var a = getAction(actionId);
            if (a) {
                var args = a.Value || {};
                args.actionId = actionId;
                controller.executeReportAction(a.Type, args);
            }
        }
        function getAction(actionId) {
            var actions = getPageActions();
            if (actions) {
                var action;
                $.each(actions, function() {
                    if (this.Id == actionId) {
                        action = this;
                    }
                    return action === undefined;
                });
                return action;
            }
            return null;
        }
        function getPageActions() {
            var pageData = getPageData();
            if (pageData) {
                return pageData.Actions;
            }
            return null;
        }
        function getPageData() {
            var $page = $(getCurrentPage());
            var data = $page.data("data");
            if (!data) {
                data = JSON.parse($page.find('script[type="text/reporting"]').html());
                $page.data("data", data);
            }
            return data;
        }
        function setPageContent(pageNumber, pageContent) {
            $pageContainer.empty();
            currentPageIndex = -1;
            var wrapper = $("<div></div>").append($.parseHTML(pageContent)), $pageContent = wrapper.find("div.sheet"), $pageStyle = wrapper.find("style"), $page = $('<div class="trv-report-page"></div>');
            $pageContent.css("margin", 0);
            $page.append($pageStyle).append($pageContent).append($('<div class="trv-page-overlay"></div>'));
            var $target = $("<div></div>").addClass("trv-page-wrapper active").data("pageNumber", pageNumber).append($page).appendTo($pageContainer);
            controller.currentPageNumber(pageNumber);
            if (controller.viewMode() == trv.ViewModes.INTERACTIVE) {
                $placeholder.removeClass("printpreview");
                $placeholder.addClass("interactive");
            } else {
                $placeholder.removeClass("interactive");
                $placeholder.addClass("printpreview");
            }
            setPageDimensions($target, pageScaleMode, pageScale);
            navigateToBookmark(pendingBookmark);
        }
    }
    var pluginName = "telerik_ReportViewer_PagesArea";
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new PagesArea(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var defaultOptions = {};
    function DocumentMapArea(placeholder, options) {
        options = $.extend({}, defaultOptions, options);
        var controller = options.controller;
        if (!controller) {
            throw "No controller (telerikReporting.reportViewerController) has been specified.";
        }
        var $placeholder = $(placeholder), $documentMap;
        init();
        function init() {
            $documentMap = $("<div></div>");
            $documentMap.appendTo(placeholder);
            attach();
        }
        function onTreeViewSelectionChanged(e) {
            var documentMapNode = this.dataItem(e.node), page = documentMapNode.page, id = documentMapNode.id;
            controller.navigateToPage(page, id);
        }
        function clearDocumentMap() {
            showDocumentMap([]);
        }
        function showDocumentMap(documentMap) {
            var hasDocumentMap = documentMap && !$.isEmptyObject(documentMap);
            if (hasDocumentMap) {
                var $treeView = $documentMap.data("kendoTreeView");
                if (!$treeView) {
                    $documentMap.kendoTreeView({
                        dataTextField: "text",
                        select: onTreeViewSelectionChanged,
                        dataSource: documentMap
                    });
                } else {
                    $treeView.setDataSource(documentMap);
                }
            }
            setVisibility(hasDocumentMap);
        }
        function setVisibility(visible) {
            controller.setDocumentMapVisible({
                visible: visible
            });
        }
        function isVisible() {
            var args = {};
            controller.getDocumentMapState(args);
            return args.visible;
        }
        function beginLoad() {
            $placeholder.addClass("loading");
        }
        function endLoad() {
            $placeholder.removeClass("loading");
        }
        var currentReport = null;
        function attach() {
            controller.beginLoadReport(function() {
                beginLoad();
                var r = controller.reportSource().report;
                var vis = currentReport == r && isVisible();
                currentReport = r;
                clearDocumentMap();
                setVisibility(vis);
            }).reportLoadComplete(function(event, args) {
                if (args.documentMapAvailable) {
                    showDocumentMap(args.bookmarkNodes);
                } else {
                    setVisibility(false);
                }
                endLoad();
            }).error(function(event, error) {
                endLoad();
                clearDocumentMap();
            }).getDocumentMapState(function(event, args) {
                args.visible = !$placeholder.hasClass("hidden");
                args.enabled = Boolean($placeholder.find("li").length);
            }).setDocumentMapVisible(function(event, args) {
                (args.visible ? $.fn.removeClass : $.fn.addClass).call($placeholder, "hidden");
            });
        }
    }
    var pluginName = "telerik_ReportViewer_DocumentMapArea";
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new DocumentMapArea(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    trv.ParameterTypes = {
        INTEGER: "System.Int64",
        FLOAT: "System.Double",
        STRING: "System.String",
        DATETIME: "System.DateTime",
        BOOLEAN: "System.Boolean"
    };
    var sr = trv.sr, utils = trv.utils;
    var multivalueUtils = function() {
        var lineSeparator = "\n";
        return {
            formatValue: function(value) {
                var text = "";
                if (value) {
                    [].concat(value).forEach(function(val) {
                        if (text.length > 0) {
                            text += lineSeparator;
                        }
                        text += val;
                    });
                }
                return text;
            },
            parseValues: function(text) {
                return ("" + text).split(lineSeparator);
            }
        };
    }();
    function integerInputBehavior(input) {
        function isValid(newValue) {
            return /^(\-|\+)?([0-9]*)$/.test(newValue);
        }
        function onKeyPress(event) {
            return isValid($(input).val() + String.fromCharCode(event.charCode));
        }
        function onPaste(event) {}
        function attach(input) {
            $(input).on("keypress", onKeyPress).on("paste", onPaste);
        }
        function detach(input) {
            $(input).off("keypress", onKeyPress).off("paste", onPaste);
        }
        attach(input);
        return {
            dispose: function() {
                detach(input);
            }
        };
    }
    function floatInputBehavior(input) {
        function isValid(newValue) {
            return /^(\-|\+)?([0-9]*(\.[0-9]*)?)$/.test(newValue);
        }
        function onKeyPress(event) {
            return isValid($(input).val() + String.fromCharCode(event.charCode));
        }
        function onPaste(event) {}
        function attach(input) {
            $(input).on("keypress", onKeyPress).on("paste", onPaste);
        }
        function detach(input) {
            $(input).off("keypress", onKeyPress).off("paste", onPaste);
        }
        attach(input);
        return {
            dispose: function() {
                detach(input);
            }
        };
    }
    trv.parameterEditors = [ {
        match: function(parameter) {
            return Boolean(parameter.availableValues) && parameter.multivalue;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder);
            $placeholder.html(options.templates["trv-parameter-editor-available-values-multiselect"]);
            var $list = $placeholder.find(".list"), $footer = $placeholder.find(".footer"), $selectAll = $placeholder.find(".select-all"), $selectNone = $placeholder.find(".select-none"), listView, parameter, updateTimeout, valueChangeCallback = options.parameterChanged, initialized;
            $selectAll.click(function() {
                setSelectedItems(parameter.availableValues.map(function(av) {
                    return av.value;
                }));
            });
            $selectNone.click(function() {
                setSelectedItems([]);
            });
            function onSelectionChanged(selection) {
                if (initialized) {
                    notifyParameterChanged(selection);
                }
                var noSelection = selection.length == 0;
                (noSelection ? $.fn.show : $.fn.hide).call($selectAll);
                (!noSelection ? $.fn.show : $.fn.hide).call($selectNone);
            }
            function notifyParameterChanged(selection) {
                var availableValues = parameter.availableValues, values = $.map(selection, function(item) {
                    return availableValues[$(item).index()].value;
                });
                if (updateTimeout) {
                    window.clearTimeout(updateTimeout);
                }
                var immediateUpdate = !parameter.autoRefresh && !parameter.childParameters;
                updateTimeout = window.setTimeout(function() {
                    valueChangeCallback(parameter, values);
                    updateTimeout = null;
                }, immediateUpdate ? 0 : 1e3);
            }
            function getSelectedItems() {
                return $(listView.element).find(".k-state-selected");
            }
            function onItemClick() {
                $(this).toggleClass("k-state-selected");
                onSelectionChanged(getSelectedItems());
            }
            function init() {
                setSelectedItems(parameter.value);
                $(listView.element).on("click", ".listviewitem", onItemClick);
                initialized = true;
            }
            function clear() {
                initialized = false;
                if (listView) {
                    $(listView.element).off("click", ".listviewitem", onItemClick);
                }
            }
            function setSelectedItems(items) {
                setSelectedItemsCore(items);
                onSelectionChanged(getSelectedItems());
            }
            function setSelectedItemsCore(items) {
                if (!Array.isArray(items)) {
                    items = [ items ];
                }
                var children = listView.element.children();
                $.each(parameter.availableValues, function(i, av) {
                    var selected = false;
                    $.each(items, function(j, v) {
                        selected = v == av.value;
                        return !selected;
                    });
                    (selected ? $.fn.addClass : $.fn.removeClass).call($(children[i]), "k-state-selected");
                });
            }
            return {
                beginEdit: function(param) {
                    clear();
                    parameter = param;
                    $list.kendoListView({
                        template: '<div class="listviewitem">${name}</div>',
                        dataSource: {
                            data: parameter.availableValues
                        },
                        selectable: false
                    });
                    listView = $list.data("kendoListView");
                    init();
                }
            };
        }
    }, {
        match: function(parameter) {
            return Boolean(parameter.availableValues) && !parameter.multivalue;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder);
            $placeholder.html(options.templates["trv-parameter-editor-available-values"]);
            var $list = $placeholder.find(".trv-parameter-editor-available-values"), listView, parameter, valueChangeCallback = options.parameterChanged;
            function onSelectionChanged(selection) {
                notifyParameterChanged(selection);
            }
            function notifyParameterChanged(selection) {
                var availableValues = parameter.availableValues, values = $.map(selection, function(item) {
                    return availableValues[$(item).index()].value;
                });
                if (Array.isArray(values)) {
                    values = values[0];
                }
                valueChangeCallback(parameter, values);
            }
            function getSelectedItems() {
                return listView.select();
            }
            function onChange() {
                onSelectionChanged(getSelectedItems());
            }
            function init() {
                setSelectedItems(parameter.value);
                listView.bind("change", onChange);
            }
            function reset() {
                if (listView) {
                    listView.unbind("change", onChange);
                }
            }
            function setSelectedItems(value) {
                var items = listView.element.children();
                $.each(parameter.availableValues, function(i, av) {
                    if (value == av.value) {
                        listView.select(items[i]);
                        return false;
                    }
                    return true;
                });
            }
            return {
                beginEdit: function(param) {
                    reset();
                    parameter = param;
                    $list.kendoListView({
                        template: '<div class="listviewitem">${name}</div>',
                        dataSource: {
                            data: parameter.availableValues
                        },
                        selectable: true
                    });
                    listView = $list.data("kendoListView");
                    init();
                }
            };
        }
    }, {
        match: function(parameter) {
            return Boolean(parameter.multivalue);
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder), parameter;
            $placeholder.html(options.templates["trv-parameter-editor-multivalue"]);
            var $textArea = $placeholder.find("textarea").on("change", function() {
                if (options.parameterChanged) {
                    options.parameterChanged(parameter, multivalueUtils.parseValues(this.value));
                }
            });
            return {
                beginEdit: function(param) {
                    parameter = param;
                    $textArea.val(multivalueUtils.formatValue(param.value));
                }
            };
        }
    }, {
        match: function(parameter) {
            return parameter.type === trv.ParameterTypes.DATETIME;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder), parameter;
            $placeholder.html(options.templates["trv-parameter-editor-datetime"]);
            var dateTimePicker = $placeholder.find("input[type=datetime]").kendoDatePicker({
                change: function() {
                    var handler = options.parameterChanged;
                    if (handler) {
                        var dtv = this.value();
                        dtv = utils.adjustTimezone(dtv);
                        handler(parameter, dtv);
                    }
                }
            }).data("kendoDatePicker");
            return {
                beginEdit: function(param) {
                    parameter = param;
                    var dt = null;
                    try {
                        if (param.value) {
                            dt = utils.unadjustTimezone(param.value);
                        }
                    } catch (e) {
                        dt = null;
                    }
                    dateTimePicker.value(dt);
                }
            };
        }
    }, {
        match: function(parameter) {
            return parameter.type === trv.ParameterTypes.STRING;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder), parameter;
            $placeholder.html(options.templates["trv-parameter-editor-text"]);
            var $input = $placeholder.find('input[type="text"]').change(function() {
                if (options.parameterChanged) {
                    options.parameterChanged(parameter, $input.val());
                }
            });
            return {
                beginEdit: function(param) {
                    parameter = param;
                    $input.val(parameter.value);
                }
            };
        }
    }, {
        match: function(parameter) {
            switch (parameter.type) {
              case trv.ParameterTypes.INTEGER:
              case trv.ParameterTypes.FLOAT:
                return true;

              default:
                return false;
            }
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder), parameter, inputBehavior;
            $placeholder.html(options.templates["trv-parameter-editor-number"]);
            var $input = $placeholder.find("input[type=number]").on("change", function() {
                if (options.parameterChanged) {
                    options.parameterChanged(parameter, $input.val());
                }
            });
            return {
                beginEdit: function(param) {
                    if (inputBehavior) {
                        inputBehavior.dispose();
                    }
                    parameter = param;
                    $input.val(parameter.value);
                    if (parameter.type === trv.ParameterTypes.INTEGER) {
                        inputBehavior = integerInputBehavior($input);
                    } else {
                        inputBehavior = floatInputBehavior($input);
                    }
                }
            };
        }
    }, {
        match: function(parameter) {
            return parameter.type === trv.ParameterTypes.BOOLEAN;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder), parameter;
            $placeholder.html(options.templates["trv-parameter-editor-boolean"]);
            var $input = $placeholder.find("input[type=checkbox]").on("change", function() {
                if (options.parameterChanged) {
                    options.parameterChanged(parameter, this.checked);
                }
            });
            return {
                beginEdit: function(param) {
                    parameter = param;
                    $input[0].checked = parameter.value === true;
                }
            };
        }
    }, {
        match: function(parameter) {
            return true;
        },
        createEditor: function(placeholder, options) {
            var $placeholder = $(placeholder);
            $placeholder.html('<div class="trv-parameter-editor-generic"></div>');
            return {
                beginEdit: function(parameter) {
                    $placeholder.find(".trv-parameter-editor-generic").html(parameter.Error ? "(error)" : parameter.value);
                }
            };
        }
    } ];
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr, utils = trv.utils;
    trv.parameterValidators = function() {
        var validators = {};
        function validateParameter(parameter, value, validatorFunc, compareFunc) {
            var values = [].concat(value).map(function(value1) {
                return checkAvailbaleValues(parameter, validatorFunc(value1), compareFunc);
            });
            if (parameter.multivalue) {
                return values;
            }
            return values[0];
        }
        function isNull(parameter, value) {
            return parameter.allowNull && -1 != [ null, "", undefined ].indexOf(value);
        }
        function checkAvailbaleValues(parameter, value, compareFunc) {
            if (parameter.availableValues) {
                var found = false;
                $.each(parameter.availableValues, function(i, av) {
                    found = compareFunc(value, av.value);
                    return !found;
                });
                if (!found) {
                    throw sr.invalidParameter;
                }
            }
            return value;
        }
        validators[trv.ParameterTypes.STRING] = {
            validate: function(parameter, value) {
                return validateParameter(parameter, value, function(value) {
                    if (!value) {
                        if (parameter.allowBlank) {
                            return "";
                        }
                        if (parameter.allowNull) {
                            return null;
                        }
                        throw sr.parameterIsEmpty;
                    }
                    return value;
                }, function(s1, s2) {
                    return s1 == s2;
                });
            }
        };
        validators[trv.ParameterTypes.FLOAT] = {
            validate: function(parameter, value) {
                return validateParameter(parameter, value, function(value) {
                    var num = utils.tryParseFloat(value);
                    if (isNaN(num)) {
                        if (isNull(parameter, value)) {
                            return null;
                        }
                        throw sr.parameterIsEmpty;
                    }
                    return num;
                }, function(f1, f2) {
                    return utils.tryParseFloat(f1) == utils.tryParseFloat(f2);
                });
            }
        };
        validators[trv.ParameterTypes.INTEGER] = {
            validate: function(parameter, value) {
                return validateParameter(parameter, value, function(value) {
                    var num = utils.tryParseInt(value);
                    if (isNaN(num)) {
                        if (isNull(parameter, value)) {
                            return null;
                        }
                        throw sr.parameterIsEmpty;
                    }
                    return num;
                }, function(n1, n2) {
                    return utils.tryParseInt(n1) == utils.tryParseFloat(n2);
                });
            }
        };
        validators[trv.ParameterTypes.DATETIME] = {
            validate: function(parameter, value) {
                return validateParameter(parameter, value, function(value) {
                    if (parameter.allowNull && (value === null || value === "" || value === undefined)) {
                        return null;
                    }
                    if (!isNaN(Date.parse(value))) {
                        return utils.parseToLocalDate(value);
                    }
                    throw sr.parameterIsEmpty;
                }, function(d1, d2) {
                    d1 = utils.parseToLocalDate(d1);
                    d2 = utils.parseToLocalDate(d2);
                    return d1.getTime() == d2.getTime();
                });
            }
        };
        validators[trv.ParameterTypes.BOOLEAN] = {
            validate: function(parameter, value) {
                return validateParameter(parameter, value, function(value) {
                    if (-1 != [ "true", "false" ].indexOf(("" + value).toLowerCase())) {
                        return Boolean(value);
                    }
                    if (isNull(parameter, value)) {
                        return null;
                    }
                    throw sr.parameterIsEmpty;
                }, function(b1, b2) {
                    return Boolean(b1) == Boolean(b2);
                });
            }
        };
        return {
            validate: function(parameter, value) {
                var v = validators[parameter.type];
                if (!v) {
                    throw utils.stringFormat(sr.cannotValidateType, parameter);
                }
                return v.validate(parameter, value);
            }
        };
    }();
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr, utils = trv.utils, parameterValidators = trv.parameterValidators;
    var defaultOptions = {};
    function ParametersArea(placeholder, options, otherOptions) {
        options = $.extend({}, defaultOptions, options, otherOptions);
        var controller = options.controller;
        if (!controller) {
            throw "No controller (telerikReporting.reportViewerController) has been specified.";
        }
        var parameterEditors = [].concat(options.parameterEditors, trv.parameterEditors);
        var recentParameterValues, parameters;
        var $placeholder = $(placeholder), $content = $placeholder.find(".trv-parameters-area-content"), $errorMessage = $placeholder.find(".trv-error-message"), $previewButton = $placeholder.find(".trv-parameters-area-preview-button");
        $previewButton.on("click", function() {
            applyParameters();
        });
        var parameterContainerTemplate = options.templates["trv-parameter"];
        function createParameterContainer() {
            return $(parameterContainerTemplate);
        }
        function createParameterUI(parameter) {
            var $container = createParameterContainer(), $header = $container.find(".trv-parameter-header"), $editorPlaceholder = $container.find(".trv-parameter-value"), $title = $container.find(".trv-parameter-title"), $error = $container.find(".trv-parameter-error"), $errorMessage = $container.find(".trv-parameter-error-message"), editorFactory = selectParameterEditorFactory(parameter);
            $title.html(parameter.text).attr("title", parameter.text);
            $errorMessage.html(parameter.Error);
            (parameter.Error ? $.fn.show : $.fn.hide).call($error);
            var editor = editorFactory.createEditor($editorPlaceholder, {
                templates: options.templates,
                parameterChanged: function(parameter, newValue) {
                    var error = null;
                    try {
                        newValue = parameterValidators.validate(parameter, newValue);
                    } catch (e) {
                        error = e;
                    }
                    parameter.Error = error;
                    if (!error) {
                        onParameterChanged(parameter, newValue);
                    }
                    (error ? $.fn.show : $.fn.hide).call($error);
                }
            });
            editor.beginEdit(parameter);
            return $container;
        }
        function selectParameterEditorFactory(parameter) {
            var factory;
            $.each(parameterEditors, function() {
                if (this && this.match(parameter)) {
                    factory = this;
                }
                return !factory;
            });
            return factory;
        }
        function showError(error) {
            $errorMessage.html(error);
            (error ? $.fn.addClass : $.fn.removeClass).call($placeholder, "error");
        }
        function showPreviewButton(parameters) {
            (allParametersAutoRefresh(parameters) ? $.fn.removeClass : $.fn.addClass).call($placeholder, "preview");
        }
        function allParametersAutoRefresh(parameters) {
            var allAuto = true;
            $.each(parameters, function() {
                return allAuto = !this.isVisible || this.autoRefresh;
            });
            return allAuto;
        }
        function fill(newParameters) {
            recentParameterValues = {};
            parameters = newParameters || [];
            var $parameterContainer, $tempContainer = $("<div></div>");
            $.each(parameters, function() {
                try {
                    this.value = parameterValidators.validate(this, this.value);
                } catch (e) {
                    this.Error = this.Error || e;
                }
                var hasError = Boolean(this.Error), hasValue = !hasError;
                if (hasValue) {
                    recentParameterValues[this.id] = this.value;
                } else {
                    this.Error = sr.invalidParameter;
                }
                if (this.isVisible) {
                    if ($parameterContainer = createParameterUI(this)) {
                        $tempContainer.append($parameterContainer);
                    }
                }
            });
            $content.empty();
            $content.append($tempContainer.children());
            showPreviewButton(parameters);
        }
        function applyParameters() {
            controller.setParameters(recentParameterValues);
            controller.refreshReport();
        }
        function allParametersValidForAutoRefresh() {
            var triggerAutoUpdate = true;
            for (var i = parameters.length - 1; triggerAutoUpdate && i >= 0; i--) {
                var p = parameters[i];
                triggerAutoUpdate = p.id in recentParameterValues && (Boolean(p.autoRefresh) || !p.isVisible);
            }
            return triggerAutoUpdate;
        }
        function tryRefreshReport() {
            if (allParametersValidForAutoRefresh()) {
                applyParameters();
            }
        }
        function onParameterChanged(parameter, newValue) {
            delete parameter["Error"];
            parameter.value = newValue;
            recentParameterValues[parameter.id] = newValue;
            if (parameter.childParameters) {
                $.each(parameter.childParameters, function(i, name) {
                    delete recentParameterValues[name];
                });
            }
            if (parameter.childParameters) {
                loadParameters(recentParameterValues);
            } else {
                tryRefreshReport();
            }
        }
        function setParametersAreaVisibility(visible) {
            controller.setParametersAreaVisible({
                visible: visible
            });
        }
        function hasVisibleParameters(params) {
            var result = false;
            $.each(params, function() {
                result = this.isVisible;
                return !result;
            });
            return result;
        }
        var loadingCount = 0;
        function beginLoad() {
            loadingCount++;
            $placeholder.addClass("loading");
        }
        function endLoad() {
            if (loadingCount > 0) {
                if (0 == --loadingCount) {
                    $placeholder.removeClass("loading");
                }
            }
        }
        function loadParameters(parameterValues) {
            beginLoad();
            $.when(controller.loadParameters(parameterValues)).done(function(parameters) {
                var needsParamsArea = hasVisibleParameters(parameters);
                if (!needsParamsArea) {
                    setParametersAreaVisibility(false);
                }
                fill(parameters);
                showError("");
                if (needsParamsArea) {
                    setParametersAreaVisibility(true);
                }
                tryRefreshReport();
                endLoad();
            }).fail(function(xhr, status, error) {
                endLoad();
                fill([]);
                showError(error);
            });
        }
        controller.reportSourceChanged(function() {
            showError();
            loadParameters(null);
        }).getParametersAreaState(function(event, args) {
            args.visible = !$placeholder.hasClass("hidden");
            args.enabled = Boolean($content.children().length);
        }).setParametersAreaVisible(function(event, args) {
            (args.visible ? $.fn.removeClass : $.fn.addClass).call($placeholder, "hidden");
        }).beforeLoadReport(function() {
            beginLoad();
        }).error(function() {
            endLoad();
        }).pageReady(function() {
            endLoad();
        });
    }
    var pluginName = "telerik_ReportViewer_ParametersArea";
    $.fn[pluginName] = function(options, otherOptions) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new ParametersArea(this, options, otherOptions));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    function uiController(options) {
        var stateFlags = {
            ExportInProgress: 1 << 0,
            PrintInProgress: 1 << 1
        };
        function getState(flags) {
            return (state & flags) != 0;
        }
        function setState(flags, value) {
            if (value) {
                state |= flags;
            } else {
                state &= ~flags;
            }
        }
        var controller = options.controller, historyManager = options.history, state = 0, refreshUI, commands = options.commands, $controller = $(controller);
        if (!controller) {
            throw "No controller (telerikReporting.ReportViewerController) has been specified.";
        }
        function getDocumentMapState() {
            var args = {};
            controller.getDocumentMapState(args);
            return args;
        }
        function getParametersAreaState() {
            var args = {};
            controller.getParametersAreaState(args);
            return args;
        }
        function updateUI() {
            if (!refreshUI) {
                refreshUI = true;
                window.setTimeout(function() {
                    try {
                        updateUICore();
                    } finally {
                        refreshUI = false;
                    }
                }, 10);
            }
        }
        function updateUICore() {
            var rs = controller.reportSource();
            var pageCount = controller.pageCount();
            var currentPageNumber = controller.currentPageNumber();
            var hasReport = rs && rs.report;
            var hasPages = hasReport && pageCount > 0;
            var nextPage = hasPages && currentPageNumber < pageCount;
            var prevPage = hasPages && currentPageNumber > 1;
            var hasPage = hasPages && currentPageNumber;
            var documentMapState = getDocumentMapState();
            var parametersAreaState = getParametersAreaState();
            commands.goToFirstPage.enabled(prevPage);
            commands.goToPrevPage.enabled(prevPage);
            commands.goToLastPage.enabled(nextPage);
            commands.goToNextPage.enabled(nextPage);
            commands.goToPage.enabled(hasPages);
            commands.print.enabled(hasReport && !getState(stateFlags.PrintInProgress));
            commands.export.enabled(hasReport && !getState(stateFlags.ExportInProgress));
            commands.refresh.enabled(hasReport);
            commands.historyBack.enabled(historyManager && historyManager.canMoveBack());
            commands.historyForward.enabled(historyManager && historyManager.canMoveForward());
            commands.toggleDocumentMap.enabled(hasReport && documentMapState.enabled).checked(documentMapState.visible);
            commands.toggleParametersArea.enabled(hasReport && parametersAreaState.enabled).checked(parametersAreaState.visible);
            commands.togglePrintPreview.enabled(hasReport).checked(controller.viewMode() == trv.ViewModes.PRINT_PREVIEW);
            commands.zoom.enabled(hasPage);
            commands.zoomIn.enabled(hasPage);
            commands.zoomOut.enabled(hasPage);
            commands.toggleZoomMode.enabled(hasPage);
            try {
                $controller.trigger("pageNumber", currentPageNumber).trigger("pageCount", pageCount);
            } finally {}
        }
        function getScaleMode() {
            var args = {};
            controller.getScale(args);
            return args.scaleMode;
        }
        controller.scale(function(event, args) {
            commands.toggleZoomMode.checked(args.scaleMode == trv.ScaleModes.FIT_PAGE);
        });
        controller.currentPageChanged(updateUI);
        controller.beforeLoadReport(updateUI);
        controller.reportLoadProgress(updateUI);
        controller.reportLoadComplete(updateUI);
        controller.reportSourceChanged(updateUI);
        controller.viewModeChanged(updateUI());
        controller.setParametersAreaVisible(updateUI);
        controller.setDocumentMapVisible(updateUI);
        controller.exportStarted(function() {
            setState(stateFlags.ExportInProgress, true);
            updateUI();
        });
        controller.exportReady(function() {
            setState(stateFlags.ExportInProgress, false);
            updateUI();
        });
        controller.printStarted(function() {
            setState(stateFlags.PrintInProgress, true);
            updateUI();
        });
        controller.printReady(function() {
            setState(stateFlags.PrintInProgress, false);
            updateUI();
        });
        updateUI();
    }
    trv.uiController = uiController;
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    trv.HistoryManager = function(options) {
        var controller = options.controller;
        if (!controller) {
            throw "No controller (telerikReporting.reportViewerController) has been specified.";
        }
        var settings = options.settings, history = settings.history() || {
            records: [],
            position: -1
        };
        controller.beforeLoadReport(function() {
            addToHistory();
        }).currentPageChanged(function() {
            updatePageInfo();
        });
        function getCurrentRecord() {
            var records = history.records;
            if (records.length > 0) {
                return records[history.position];
            }
            return null;
        }
        function pushRecord(rec) {
            var records = history.records, position = history.position;
            records = Array.prototype.slice.call(records, 0, position + 1);
            records.push(rec);
            history.records = records;
            history.position = records.length - 1;
            saveSettings();
        }
        function saveSettings() {
            settings.history(history);
        }
        function updatePageInfo() {
            var currentRecord = getCurrentRecord();
            if (currentRecord) {
                currentRecord.pageNumber = controller.currentPageNumber();
                currentRecord.viewMode = controller.viewMode();
                saveSettings();
            }
        }
        function addToHistory() {
            var currentRecord = getCurrentRecord();
            var rs = controller.reportSource();
            if (!currentRecord || !utils.reportSourcesAreEqual(currentRecord.reportSource, rs)) {
                pushRecord({
                    reportSource: rs,
                    viewMode: controller.viewMode(),
                    pageNumber: 1
                });
            }
        }
        function exec(currentRecord) {
            controller.reportSource(currentRecord.reportSource);
            controller.viewMode(currentRecord.viewMode);
            controller.navigateToPage(currentRecord.pageNumber);
        }
        function canMove(step) {
            var position = history.position, length = history.records.length, newPos = position + step;
            return 0 <= newPos && newPos < length;
        }
        function move(step) {
            var position = history.position, length = history.records.length, newPos = position + step;
            if (newPos < 0) {
                newPos = 0;
            } else if (newPos >= length) {
                newPos = length - 1;
            }
            if (newPos != position) {
                history.position = newPos;
                saveSettings();
                exec(getCurrentRecord());
            }
        }
        return {
            back: function() {
                move(-1);
            },
            forward: function() {
                move(+1);
            },
            canMoveBack: function() {
                return canMove(-1);
            },
            canMoveForward: function() {
                return canMove(1);
            },
            loadCurrent: function() {
                var rec = getCurrentRecord();
                if (rec) {
                    exec(rec);
                }
                return Boolean(rec);
            }
        };
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    var scaleTransitionMap = {};
    scaleTransitionMap[trv.ScaleModes.FIT_PAGE] = {
        scaleMode: trv.ScaleModes.FIT_PAGE_WIDTH
    };
    scaleTransitionMap[trv.ScaleModes.FIT_PAGE_WIDTH] = {
        scaleMode: trv.ScaleModes.SPECIFIC,
        scale: 1
    };
    scaleTransitionMap[trv.ScaleModes.SPECIFIC] = {
        scaleMode: trv.ScaleModes.FIT_PAGE
    };
    var scaleValues = [ .1, .25, .5, .75, 1, 1.5, 2, 4, 8 ];
    function CommandSet(options) {
        var controller = options.controller;
        if (!controller) {
            throw "No options.controller.";
        }
        var historyManager = options.history;
        if (!historyManager) {
            throw "No options.history.";
        }
        function getDocumentMapVisible() {
            var args = {};
            controller.getDocumentMapState(args);
            return Boolean(args.visible);
        }
        function getParametersAreaVisible() {
            var args = {};
            controller.getParametersAreaState(args);
            return Boolean(args.visible);
        }
        return {
            historyBack: new command(function() {
                historyManager.back();
            }),
            historyForward: new command(function() {
                historyManager.forward();
            }),
            goToPrevPage: new command(function() {
                controller.navigateToPage(controller.currentPageNumber() - 1);
            }),
            goToNextPage: new command(function() {
                controller.navigateToPage(controller.currentPageNumber() + 1);
            }),
            goToFirstPage: new command(function() {
                controller.navigateToPage(1);
            }),
            goToLastPage: new command(function() {
                controller.navigateToPage(controller.pageCount());
            }),
            goToPage: new command(function(pageNumber) {
                if (!isNaN(pageNumber)) {
                    var pageCount = controller.pageCount();
                    if (pageNumber > pageCount) {
                        pageNumber = pageCount;
                    } else if (pageNumber < 1) {
                        pageNumber = 1;
                    }
                    controller.navigateToPage(pageNumber);
                    return pageNumber;
                }
            }),
            refresh: new command(function() {
                controller.refreshReport(true);
            }),
            "export": new command(function(format) {
                if (format) {
                    controller.exportReport(format);
                }
            }),
            print: new command(function () {
                controller.printReport();
            }),
            togglePrintPreview: new command(function() {
                controller.viewMode(controller.viewMode() == trv.ViewModes.PRINT_PREVIEW ? trv.ViewModes.INTERACTIVE : trv.ViewModes.PRINT_PREVIEW);
            }),
            toggleDocumentMap: new command(function() {
                controller.setDocumentMapVisible({
                    visible: !getDocumentMapVisible()
                });
            }),
            toggleParametersArea: new command(function() {
                controller.setParametersAreaVisible({
                    visible: !getParametersAreaVisible()
                });
            }),
            zoom: new command(function(scale) {
                controller.scale({
                    scale: 1
                });
            }),
            zoomIn: new command(function() {
                zoom(1);
            }),
            zoomOut: new command(function() {
                zoom(-1);
            }),
            toggleSideMenu: new command(function() {
                $(controller).trigger("trv.TOGGLE_SIDE_MENU");
            }),
            toggleZoomMode: new command(function() {
                var args = {};
                controller.getScale(args);
                controller.scale(scaleTransitionMap[args.scaleMode]);
            })
        };
        function zoom(step) {
            var args = {};
            controller.getScale(args);
            args.scale = getZoomScale(args.scale, step);
            args.scaleMode = trv.ScaleModes.SPECIFIC;
            controller.scale(args);
        }
        function getZoomScale(scale, steps) {
            var pos = -1, length = scaleValues.length;
            for (var i = 0; i < length; i++) {
                var value = scaleValues[i];
                if (scale < value) {
                    pos = i - .5;
                    break;
                }
                if (scale == value) {
                    pos = i;
                    break;
                }
            }
            pos = pos + steps;
            if (steps >= 0) {
                pos = Math.round(pos - .49);
            } else {
                pos = Math.round(pos + .49);
            }
            if (pos < 0) {
                pos = 0;
            } else if (pos > length - 1) {
                pos = length - 1;
            }
            return scaleValues[pos];
        }
    }
    trv.CommandSet = CommandSet;
    function command(execCallback) {
        var enabledState = true;
        var checkedState = false;
        var cmd = {
            enabled: function(state) {
                if (arguments.length == 0) {
                    return enabledState;
                }
                var newState = Boolean(state);
                enabledState = newState;
                $(this).trigger("enabledChanged");
                return cmd;
            },
            checked: function(state) {
                if (arguments.length == 0) {
                    return checkedState;
                }
                var newState = Boolean(state);
                checkedState = newState;
                $(this).trigger("checkedChanged");
                return cmd;
            },
            exec: execCallback
        };
        return cmd;
    }
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr;
    if (!sr) {
        throw "Missing telerikReportViewer.sr";
    }
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    function MainMenu(dom, options) {
        var menu = $(dom).data("kendoMenu"), loadingFormats, childrenL1;
        if (!menu) {
            init();
        }
        function init() {
            $(window).resize(function() {
                adjustMenuItemsLevel1();
            });
            menu = $(dom).kendoMenu().data("kendoMenu"), menu.bind("open", onSubmenuOpen);
            attachCommands(dom, options.commands);
            window.setTimeout(adjustMenuItemsLevel1, 100);
        }
        function adjustMenuItemsLevel1() {
            if (!childrenL1) childrenL1 = dom.childNodes;
            for (var i = childrenL1.length - 1; i >= 0; i--) {
                var el = childrenL1[i];
                if (el.style) {
                    var style = el.style;
                    var isVisible = style.display !== "none";
                    if (!isVisible) {
                        style.display = "";
                    }
                    if (el.offsetTop > 0) {
                        style.display = "none";
                    } else {
                        if (isVisible) {
                            break;
                        }
                    }
                }
            }
        }
        function onSubmenuOpen(e) {
            var $item = $(e.item);
            if ($item.children("ul[data-command-list=export-format-list]").length > 0) {
                onOpenFormatsMenu($item);
            }
        }
        function onOpenFormatsMenu($item) {
            if (!loadingFormats) {
                beginLoadFormats($item);
            }
        }
        function fillFormats(formats) {
            $(dom).find("ul[data-command-list=export-format-list]").each(function() {
                var $list = $(this), $parent = $list.parents("li"), itemsToRemove = $list.children("li");
                $.each(formats, function() {
                    var format = this;
                    var li = utils.stringFormat('<li><a style="cursor: pointer;" data-command="export" data-command-parameter="{name}"><span>{localizedName}</span></a></li>', format);
                    menu.append(li, $parent);
                });
                attachCommands($parent);
                itemsToRemove.each(function() {
                    menu.remove($(this));
                });
            });
        }
        function beginLoadFormats($item) {
            loadingFormats = true;
            menu.append({
                text: sr.loadingFormats
            }, $item);
            $.when(options.controller.getDocumentFormats()).done(function(formats) {
                loadingFormats = false;
                window.setTimeout(function() {
                    fillFormats(formats);
                }, 0);
                menu.unbind("open", onSubmenuOpen);
            }).fail(function() {
                loadingFormats = false;
            });
        }
        function attachCommands(root) {
            $(root).find("a[data-command]").each(function() {
                attachCommand(this, options.commands);
            });
        }
        function attachCommand(element, commands) {
            var $element = $(element), dataCommand = $element.attr("data-command"), cmd = dataCommand ? commands[dataCommand] : null;
            if (cmd) {
                $element.click(function(e) {
                    if (cmd.enabled()) {
                        cmd.exec($(this).attr("data-command-parameter"));
                    } else {
                        e.preventDefault();
                    }
                });
                $(cmd).bind("enabledChanged", function(e) {
                    (cmd.enabled() ? $.fn.removeClass : $.fn.addClass).call($element.parents("li"), "k-state-disabled");
                }).bind("checkedChanged", function(e) {
                    (cmd.checked() ? $.fn.addClass : $.fn.removeClass).call($element.parents("li"), "k-state-selected");
                });
            }
        }
    }
    var pluginName = "telerik_ReportViewer_MainMenu";
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new MainMenu(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr;
    if (!sr) {
        throw "Missing telerikReportViewer.sr";
    }
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReporting.utils";
    }
    var loadingFormats, formatsLoaded, panelBar;
    function SideMenu(dom, options) {
        init(dom);
        function init(root) {
            panelBar = $(root).children("ul").kendoPanelBar().data("kendoPanelBar");
            panelBar.bind("expand", onSubmenuOpen);
            enableCloseOnClick(root);
            attachCommands(root);
            $(root).click(function(e) {
                if (e.target == root) {
                    $(options.controller).trigger("trv.TOGGLE_SIDE_MENU");
                }
            });
        }
        function onSubmenuOpen(e) {
            var $item = $(e.item);
            if ($item.children("ul[data-command-list=export-format-list]").length > 0) {
                onOpenFormatsMenu($item);
            }
        }
        function onOpenFormatsMenu($item) {
            if (!loadingFormats) {
                beginLoadFormats($item);
            }
        }
        function fillFormats(formats) {
            $(dom).find("ul[data-command-list=export-format-list]").each(function() {
                var $list = $(this), $parent = $list.parents("li"), itemsToRemove = $list.children("li");
                $.each(formats, function(i) {
                    var format = this;
                    var li = utils.stringFormat('<li><a style="cursor: pointer;" data-command="export" data-command-parameter="{name}"><span>{localizedName}</span></a></li>', format);
                    panelBar.append(li, $parent);
                });
                attachCommands($parent);
                enableCloseOnClick($parent);
                itemsToRemove.each(function() {
                    panelBar.remove($(this));
                });
            });
        }
        function beginLoadFormats($item) {
            loadingFormats = true;
            panelBar.append({
                text: sr.loadingFormats
            }, $item);
            $.when(options.controller.getDocumentFormats()).done(function(formats) {
                formatsLoaded = true;
                loadingFormats = false;
                window.setTimeout(function() {
                    fillFormats(formats);
                }, 0);
                panelBar.unbind("expand", onSubmenuOpen);
            }).fail(function() {
                loadingFormats = false;
            });
        }
        function enableCloseOnClick(root) {
            $(root).find("li").each(function() {
                var isLeaf = $(this).children("ul").length == 0;
                if (isLeaf) {
                    $(this).children("a").click(function() {
                        $(options.controller).trigger("trv.TOGGLE_SIDE_MENU");
                    });
                }
            });
        }
        function attachCommands(root) {
            $(root).find("a[data-command]").each(function() {
                attachCommand(this, options.commands);
            });
        }
        function attachCommand(element, model) {
            var $element = $(element), dataCommand = $element.attr("data-command"), cmd = dataCommand ? model[dataCommand] : null;
            if (cmd) {
                $element.click(function(e) {
                    if (cmd.enabled()) {
                        var param = $(this).attr("data-command-parameter");
                        window.setTimeout(function() {
                            cmd.exec(param);
                        }, 100);
                    } else {
                        e.preventDefault();
                    }
                });
                $(cmd).bind("enabledChanged", function(e) {
                    (cmd.enabled() ? $.fn.removeClass : $.fn.addClass).call($element.parents("li"), "k-state-disabled");
                });
            }
        }
    }
    var pluginName = "telerik_ReportViewer_SideMenu";
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new SideMenu(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReportViewer.utils";
    }
    trv.binder = {
        bind: function(element) {
            var args = Array.prototype.slice.call(arguments, 1);
            $(element).find("*[data-role]").each(function() {
                var $this = $(this), f = $.fn[$this.attr("data-role")];
                if (typeof f === "function") {
                    f.apply($this, args);
                }
            });
        }
    };
    function LinkButton(dom, options) {
        var cmd, $element = $(dom), dataCommand = $element.attr("data-command");
        if (dataCommand) {
            cmd = options.commands[dataCommand];
        }
        if (cmd) {
            $element.click(function(e) {
                if (cmd.enabled()) {
                    cmd.exec($(this).attr("data-command-parameter"));
                } else {
                    e.preventDefault();
                }
            });
            $(cmd).bind("enabledChanged", function(e) {
                (cmd.enabled() ? $.fn.removeClass : $.fn.addClass).call($element, "disabled");
            }).bind("checkedChanged", function(e) {
                (cmd.checked() ? $.fn.addClass : $.fn.removeClass).call($element, "checked");
            });
        }
    }
    var linkButton_pluginName = "telerik_ReportViewer_LinkButton";
    $.fn[linkButton_pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, linkButton_pluginName)) {
                $.data(this, linkButton_pluginName, new LinkButton(this, options));
            }
        });
    };
    function PageNumberInput(dom, options) {
        var $element = $(dom), $controller = $(options.controller), cmd = options.commands["goToPage"];
        function setPageNumber(value) {
            $element.val(value);
        }
        $controller.bind("pageNumber", function(e, value) {
            setPageNumber(value);
        });
        $element.change(function() {
            var val = $(this).val();
            var num = utils.tryParseInt(val);
            if (num != NaN) {
                var result = cmd.exec(num);
                setPageNumber(result);
            }
        });
        $element.keydown(function(e) {
            if (e.which == 13) {
                $(this).change();
                return e.preventDefault();
            }
        });
        function validateValue(value) {
            return /^([0-9]+)$/.test(value);
        }
        $element.keypress(function(event) {
            var newValue = $element.val() + String.fromCharCode(event.charCode);
            return validateValue(newValue);
        }).on("paste", function(event) {});
    }
    var pageNumberInput_pluginName = "telerik_ReportViewer_PageNumberInput";
    $.fn[pageNumberInput_pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pageNumberInput_pluginName)) {
                $.data(this, pageNumberInput_pluginName, new PageNumberInput(this, options));
            }
        });
    };
    function PageCountLabel(dom, options) {
        var $element = $(dom), $controller = $(options.controller);
        $controller.bind("pageCount", function(e, value) {
            $element.html(value);
        });
    }
    var pageCountLabel_pluginName = "telerik_ReportViewer_PageCountLabel";
    $.fn[pageCountLabel_pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pageCountLabel_pluginName)) {
                $.data(this, pageCountLabel_pluginName, new PageCountLabel(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    trv.PerspectiveManager = function(dom, controller) {
        var $smallMenu = $(dom).find(".trv-menu-small"), perspectives = {
            small: {
                documentMapVisible: false,
                parametersAreaVisible: false,
                onDocumentMapVisibleChanged: function(e, args) {
                    if (args.visible) {
                        controller.setParametersAreaVisible({
                            visible: false
                        });
                    }
                },
                onParameterAreaVisibleChanged: function(e, args) {
                    if (args.visible) {
                        controller.setDocumentMapVisible({
                            visible: false
                        });
                    }
                },
                onBeforeLoadReport: function() {
                    controller.setParametersAreaVisible({
                        visible: false
                    });
                    controller.setDocumentMapVisible({
                        visible: false
                    });
                },
                onNavigateToPage: function() {
                    controller.setParametersAreaVisible({
                        visible: false
                    });
                    controller.setDocumentMapVisible({
                        visible: false
                    });
                }
            },
            large: {
                documentMapVisible: true,
                parametersAreaVisible: true,
                onReportLoadComplete: function(event, args) {
                    if (args.documentMapAvailable) {
                        controller.setDocumentMapVisible({
                            visible: true
                        });
                    }
                }
            }
        }, currentPerspective;
        function init() {
            currentPerspective = getPerspective();
            getState(perspectives[currentPerspective]);
        }
        function setPerspective(perspective) {
            getState(perspectives[currentPerspective]);
            currentPerspective = perspective;
            if (currentPerspective) {
                setState(perspectives[currentPerspective]);
            }
        }
        function onDocumentMapVisibleChanged(e, args) {
            dispatch("onDocumentMapVisibleChanged", arguments);
        }
        function onParameterAreaVisibleChanged(e, args) {
            dispatch("onParameterAreaVisibleChanged", arguments);
        }
        function onBeforeLoadReport() {
            dispatch("onBeforeLoadReport", arguments);
        }
        function onNavigateToPage() {
            dispatch("onNavigateToPage", arguments);
        }
        function onReportLoadComplete() {
            dispatch("onReportLoadComplete", arguments);
        }
        function onWindowResize() {
            var perspective = getPerspective();
            if (perspective != currentPerspective) {
                setPerspective(perspective);
            }
        }
        function dispatch(func, args) {
            var activePerspective = perspectives[currentPerspective];
            var handler = activePerspective[func];
            if (typeof handler === "function") {
                handler.apply(activePerspective, args);
            }
        }
        function attach() {
            $(window).resize(onWindowResize);
            controller.setDocumentMapVisible(onDocumentMapVisibleChanged);
            controller.setParametersAreaVisible(onParameterAreaVisibleChanged);
            controller.beforeLoadReport(onBeforeLoadReport);
            controller.navigateToPage(onNavigateToPage);
            controller.reportLoadComplete(onReportLoadComplete);
        }
        function getPerspective() {
            return $smallMenu.css("display") != "none" ? "small" : "large";
        }
        function getState(state) {
            state.documentMapVisible = documentMapVisible();
            state.parametersAreaVisible = parametersAreaVisible();
        }
        function setState(state) {
            documentMapVisible(state.documentMapVisible);
            parametersAreaVisible(state.parametersAreaVisible);
        }
        function documentMapVisible() {
            if (arguments.length == 0) {
                var args1 = {};
                controller.getDocumentMapState(args1);
                return args1.visible;
            }
            controller.setDocumentMapVisible({
                visible: Boolean(arguments[0])
            });
            return this;
        }
        function parametersAreaVisible() {
            if (arguments.length == 0) {
                var args1 = {};
                controller.getParametersAreaState(args1);
                return args1.visible;
            }
            controller.setParametersAreaVisible({
                visible: Boolean(arguments[0])
            });
            return this;
        }
        init();
        return {
            attach: attach
        };
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);

(function(trv, $, window, document, undefined) {
    "use strict";
    var sr = trv.sr;
    if (!sr) {
        throw "Missing telerikReportViewer.sr";
    }
    var utils = trv.utils;
    if (!utils) {
        throw "Missing telerikReportViewer.utils";
    }
    if (!trv.ServiceClient) {
        throw "Missing telerikReportViewer.ServiceClient";
    }
    if (!trv.ReportViewerController) {
        throw "Missing telerikReportViewer.ReportViewerController";
    }
    if (!trv.HistoryManager) {
        throw "Missing telerikReportViewer.HistoryManager";
    }
    var binder = trv.binder;
    if (!binder) {
        throw "Missing telerikReportViewer.Binder";
    }
    if (!trv.CommandSet) {
        throw "Missing telerikReportViewer.commandSet";
    }
    if (!trv.uiController) {
        throw "Missing telerikReportViewer.uiController";
    }
    var templateCache = function() {
        var cache = {};
        var pending = {};
        function loadComplete(url) {
            delete pending[url];
        }
        function beginLoad(url) {
            var p = pending[url];
            if (p) {
                return p;
            }
            var dfd = $.Deferred();
            pending[url] = p = dfd.promise();
            $.when($.get(url)).done(function(html) {
                var templates = {};
                $("<div></div>").html(html).find("template").each(function(index, e) {
                    var $e = $(e);
                    templates[$e.attr("id")] = utils.trim($e.html(), "\n ");
                });
                cache[url] = templates;
                dfd.resolve(templates);
                loadComplete(url);
            }).fail(function() {
                dfd.reject();
                loadComplete(url);
            });
            return p;
        }
        return {
            load: function(url) {
                var t = cache[url];
                if (t) {
                    return t;
                }
                return beginLoad(url);
            }
        };
    }();
    function MemStorage() {
        var data = {};
        return {
            getItem: function(key) {
                return data[key];
            },
            setItem: function(key, value) {
                data[key] = value;
            },
            removeItem: function(key) {
                delete data[key];
            }
        };
    }
    function ReportViewerSettings(id, storage, defaultSettings) {
        var $this = {};
        function getItem(key) {
            var value = storage.getItem(formatKey(key));
            return value != null ? value : defaultSettings[key];
        }
        function setItem(key, value) {
            storage.setItem(formatKey(key), value);
        }
        function formatKey(key) {
            return id + "_" + key;
        }
        function value(key, args) {
            if (args.length) {
                setItem(key, args[0]);
                return $this;
            } else {
                return getItem(key);
            }
        }
        function valueFloat(key, args) {
            if (args.length) {
                setItem(key, args[0]);
                return $this;
            } else {
                return parseFloat(getItem(key));
            }
        }
        function valueObject(key, args) {
            if (args.length) {
                setItem(key, JSON.stringify(args[0]));
                return $this;
            } else {
                var value = getItem(key);
                return typeof value == "string" ? JSON.parse(value) : null;
            }
        }
        $this = $.extend($this, {
            scale: function() {
                return valueFloat("scale", arguments);
            },
            scaleMode: function() {
                return value("scaleMode", arguments);
            },
            history: function() {
                return valueObject("history", arguments);
            },
            clientId: function() {
                return value("clientId", arguments);
            }
        });
        return $this;
    }
    var defaultOptions = {
        id: null,
        serviceUrl: null,
        templateUrl: null,
        reportSource: null,
        scale: 1,
        scaleMode: trv.ScaleModes.FIT_PAGE,
        viewMode: trv.ViewModes.INTERACTIVE,
        persistSession: false,
        parameterEditors: [],
        ready: function() {}
    };
    function ReportViewer(dom, options) {
        options = jQuery.extend({}, defaultOptions, options);
        if (!options.templateUrl) {
            throw sr.missingTemplate;
        }
        var $placeholder = $(dom), templates = {}, persistanceKey = options.id || "#" + $placeholder.attr("id");
        var settings = new ReportViewerSettings(persistanceKey, options.persistSession ? window.sessionStorage : new MemStorage(), {
            scale: options.scale,
            scaleMode: options.scaleMode
        });
        var client = new trv.ServiceClient({
            address: options.serviceUrl
        });
        var controller = new trv.ReportViewerController({
            serviceClient: client,
            settings: settings
        });
        var history = new trv.HistoryManager({
            controller: controller,
            settings: settings
        });
        var commands = new trv.CommandSet({
            controller: controller,
            history: history
        });
        new trv.uiController({
            controller: controller,
            history: history,
            commands: commands
        });
        var viewer = {
            refreshReport: function() {
                controller.refreshReport();
                return viewer;
            },
            reportSource: function(rs) {
                if (rs) {
                    controller.reportSource(rs);
                    return viewer;
                }
                return controller.reportSource();
            },
            viewMode: function(vm) {
                if (vm) {
                    controller.viewMode(vm);
                    return viewer;
                }
                return controller.viewMode();
            },
            scale: function(scale) {
                if (scale) {
                    controller.scale(scale);
                    return viewer;
                }
                scale = {};
                controller.getScale(scale);
                return scale;
            }
        };
        function init() {
            $placeholder.html(templates["trv-report-viewer"]);
            binder.bind($placeholder, {
                controller: controller,
                commands: commands,
                templates: templates
            }, options);
            new trv.PerspectiveManager(dom, controller).attach();
            $(controller).bind("trv.TOGGLE_SIDE_MENU", function() {
                window.setTimeout(function() {
                    $placeholder.toggleClass("trv-side-menu-visible");
                }, 1);
            });
        }
        function start() {
            init();
            controller.scale({
                scale: settings.scale(),
                scaleMode: settings.scaleMode()
            });
            if (!history.loadCurrent()) {
                if (options.viewMode) {
                    controller.viewMode(options.viewMode);
                }
                if (options.reportSource) {
                    controller.reportSource(options.reportSource);
                }
            }
            controller.scale(function() {
                var args = {};
                controller.getScale(args);
                settings.scale(args.scale);
                settings.scaleMode(args.scaleMode);
            });
            if (typeof options.ready == "function") {
                options.ready.call(viewer);
            }
        }
        $.when(templateCache.load(options.templateUrl)).done(function(t) {
            templates = t;
            start();
        }).fail(function() {
            $placeholder.html(sr.errorLoadingTemplates);
        });
        return viewer;
    }
    var pluginName = "telerik_ReportViewer";
    jQuery.fn[pluginName] = function(options) {
        return this.each(function() {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new ReportViewer(this, options));
            }
        });
    };
})(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery, window, document);