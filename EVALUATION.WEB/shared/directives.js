
if (!String.prototype.contains) {
    String.prototype.contains = function () {
        return String.prototype.indexOf.apply(this, arguments) !== -1;
    };
}

define(["definitions", "utilities", "erp-filters", "parameters"], function () {
    "use strict";

    // définition des intercepteurs
    CoreDirective
        .factory("httpInterceptor", [
            "$q", "$rootScope", "$log", "commonUtilities", function($q, $rootScope, $log, commonUtilities) {

                var numLoadings = 0;

                return {
                    request: function(config) {

                        if (commonUtilities.IsUndefinedOrNull(config.data) || (config.data && (config.data.ShowLoader || (config.data.request && config.data.request.ShowLoader)))) {
                            numLoadings++;
                            // Show loader
                            $rootScope.$broadcast("loader_show");

                            // afficher la donnée reçue dans la console;
                            if (!commonUtilities.IsUndefinedOrNull(config.data) && (config.data && (config.data.ShowLoader || (config.data.request && config.data.request.ShowLoader)))) {
                                //commonUtilities.writeInConsole("Donnees envoyees : ");
                                //commonUtilities.writeInConsole(config.data);
                            }
                        }

                        config.headers = config.headers || {};
                        var authData = sessionStorage.getItem('authorizationData');
                        if (authData != null) {
                            //var auth = JSON.parse(authData);
                            //config.headers.Authorization = 'Bearer ' + auth.token;
                            config.headers.Authorization = 'Bearer ' + authData;
                        }


                        return config || $q.when(config);

                    },
                    response: function(response) {
                        if (response && response.config && (commonUtilities.IsUndefinedOrNull(response.config.data) || (response.config.data.ShowLoader || (response.config.data.request && response.config.data.request.ShowLoader)))) {
                            if ((--numLoadings) === 0) {
                                // Hide loader
                                $rootScope.$broadcast("loader_hide");
                            }

                            // afficher la donnée reçue dans la console;
                            if (!commonUtilities.IsUndefinedOrNull(response.config.data) && (response.config.data.ShowLoader || response.config.data.request.ShowLoader)) {
                                //commonUtilities.writeInConsole(response.data.WebServiceName);
                                //commonUtilities.writeInConsole(response.data);
                            }
                        }

                        // gestion des notificatons et erreurs
                        var responseSw = response.data;
                        var request = response.config.data == null ? null : (response.config.data.request != null ? response.config.data.request : response.config.data);
                        if (request != null) {
                            // Afficher notification si demandée
                            if (request.IsNotificationToShow && responseSw.HasError === false) {
                                commonUtilities.ShowMessage(request.TitleNotificationToShow, request.NotificationToShow);
                            }
                            if (responseSw.HasError === true) {
                                var messageErr = responseSw.Message;

                                if (request.ShowErrorInAlert === true) {
                                    if (messageErr.indexOf(commonUtilities.GlobalEnum.CustomException) > -1) {
                                        var customMessage = messageErr.replace(commonUtilities.GlobalEnum.CustomException, "");
                                        
                                        $rootScope.$broadcast("show-error", { Title: request.TitleNotificationToShow, Message: customMessage, isCustomMessage: true });
                                    } else {
                                        if (messageErr.indexOf(commonUtilities.GlobalEnum.CustomRegleGestionException) > -1) {
                                            // ne rien faire
                                        } else {
                                            
                                            $rootScope.$broadcast("show-error", { Title: "Erreur", Message: messageErr, isCustomMessage: false });
                                        }
                                            
                                    }
                                } else {
                                    if (request.ShowErrorInAlert === false) // peut être null
                                    {
                                        //console.log(messageErr);
                                    }
                                }
                            }
                        }
                        // fin gestion des notificatons et erreurs

                        return response || $q.when(response);

                    },
                    responseError: function(response) {

                        if (response && response.config && (commonUtilities.IsUndefinedOrNull(response.config.data) || (response.config.data.ShowLoader || (commonUtilities.IsUndefinedOrNull(response.config.data.request) || response.config.data.request.ShowLoader)))) {
                            if ((--numLoadings) === 0) {
                                // Hide loader
                                $rootScope.$broadcast("loader_hide");
                            }

                            // afficher la donnée reçue dans la console;
                            /*if (!commonUtilities.IsUndefinedOrNull(response.config.data) && (response.config.data.ShowLoader || response.config.data.request.ShowLoader)) {
                                //commonUtilities.writeInConsole(response.data.WebServiceName);
                                //commonUtilities.writeInConsole(response.data);
                             }*/
                        }

                        // gestion des erreurs

                        //var request = !response || !response.config || !response.config.data || response.config.data.request ? response.config.data.request : null;
                        var request = !response || !response.config || response.config.data ? (response.config.data.request ? response.config.data.request : response.config.data) : null;
                        if (request != null) {
                            // Afficher message d'erreur suivant le mode demandé  

                            var messageErr = null;
                            var customMessage = null;
                            if (response.status === 0 && response.statusText === "") {
                                $rootScope.$broadcast("limited-network");
                                messageErr = "La connexion est momentanément interrompue!";
                            } else {
                                messageErr = "Erreur :  status = " + response.status + ", statusText = " + response.statusText + " !";
                                customMessage = response.statusText.replace("Level 1:", "");
                            }
                               
                            if (request.ShowErrorInAlert === true) {
                                $rootScope.$broadcast("show-error", { Title: "Erreur", Message: customMessage, isCustomMessage: false });
                            } else {
                                if (request.ShowErrorInAlert === false) // peut être null
                                {
                                    //console.log(messageErr);
                                }
                            }
                        }
                        // fin gestion des erreurs

                        return $q.reject(response);
                    }
                };
            }
        ]);

    CoreDirective
        .factory("noCacheInterceptor", ["$log", "$injector", function ($log, $injector) {
            var noCacheFolders = ["views", "scripts", "lib","modules","app","shared","config"];

            var shouldApplyNoCache = function (config) {
              
                for (var i = 0; i < noCacheFolders.length; i++) {
                    var folder = noCacheFolders[i];
                    var arrayUrl = config.url.split('/');
                    if (arrayUrl.length > 1) {

                        if (arrayUrl.indexOf(folder) === 1) {
                            //console.log(folder);
                            return true;
                        }
                    }
                    
                }
                return false;
            };

            var applyNoCache = function (config) {
                var arrayUrl = config.url.split('?');
                if (arrayUrl.length > 1) {
                    config.url += "&";
                } else {
                    
                    config.url += "?";
                }
 

                if (MODE === "DEV") {
                    config.url += 'bust=' + new Date().getTime();
                }
                else {
                    config.url += 'bust=' + VERSION_CODE;
                }
 
            };

            var interceptor = {
                request: function (config) {
                    if (shouldApplyNoCache(config)) {
                        applyNoCache(config);
                    }
                    return config;
                }
            };

            return interceptor;
        }]);
  
    EVALUATIONErpDirective.directive("stopEvent", function() {
        return {
            restrict: "A",
            link: function(scope, element, attr) {
                element.bind("click", function(e) {
                    e.stopPropagation();
                });
            }
        };
    });

    EVALUATIONErpDirective.directive("applyVisibilityForGroup", [
        "$http", "commonUtilities", "Security", function($http, commonUtilities, Security) {
            return {
                restrict: "A",
                link: function(scope, element, attrs) {
                    var currentGroupUser = Security.currentGroupUser();

                    if (!currentGroupUser) {
                        $(element).remove();
                        return;
                    }

                    var groupsExistants = ["gestionnaire", "sam", "prestataire"];
                    var libelleGroupe = groupsExistants[currentGroupUser.IdGroupe - 1];

                    var groupsAutorises = attrs.applyVisibilityForGroup.split(/[|]/);

                    for (var i = 0; i < groupsAutorises.length; i++)
                        groupsAutorises[i] = groupsAutorises[i].trim();

                    if (groupsAutorises.indexOf(libelleGroupe) == -1)
                        $(element).remove();

                    //$(element).remove();
                }
            };

        }
    ]);

    EVALUATIONErpDirective.directive("clickOnce", [
        "$http", function($http) {
            return {
                restrict: "A",
                link: function(scope, element, attrs) {

                    var oldNgClick = attrs.ngClick != undefined ? attrs.ngClick : attrs.ngSubmit;
                    scope.isLoading = function() {
                        return $http.pendingRequests.length > 0;
                    };

                    scope.$watch(scope.isLoading, function(value) {
                        if (value) {
                            element.attr("disabled", "disabled");
                            $(element).click(function(event) {
                                event.preventDefault();
                            });
                        } else {

                            $(element).unbind("click");

                            //if (oldNgClick) {
                            //    attrs.$set('ngClick', oldNgClick);
                            //    element.bind('click', function () {
                            //        scope.$apply(oldNgClick);
                            //    });
                            //} else {
                            //    $(element).unbind('click');
                            //}
                            element.removeAttr("disabled");
                        }
                    });
                }
            };

        }
    ]);

    EVALUATIONErpDirective.directive("modifyReadOnly", [
        "$http", function($http) {
            return {
                restrict: "A",
                link: function(scope, element, attrs) {
                    if (!scope.IsNewItem) {
                        element.attr("disabled", "disabled");
                    } else {
                        element.removeAttr("disabled");
                    }
                }
            };

        }
    ]);

    EVALUATIONErpDirective.directive("loader", [
        "$rootScope", function($rootScope) {
            return function($scope, element, attrs) {
                $scope.$on("loader_show", function() {
                    return $(element).show();
                    //return $(element).addClass("panel-loader-circular");
                });
                return $scope.$on("loader_hide", function() {
                    return $(element).hide();
                    //return $(element).removeClass("panel-loader-circular");
                });
            };
        }
    ]);

    EVALUATIONErpDirective.directive("appFilereader", [
        "$rootScope", "commonUtilities", "$q", function($rootScope, commonUtilities, $q) {
            var slice = Array.prototype.slice;

            var URL = window.URL || window.webkitURL;

            /**
		     * Receives an Image Object (can be JPG OR PNG) and returns a new Image Object compressed
		     * @param {Image} sourceImgObj The source Image Object
		     * @param {Integer} quality The output quality of Image Object
		     * @return {Image} result_image_obj The compressed Image Object
		     */
            var jicCompress = function(sourceImgObj, options) {
                var outputFormat = options.resizeType;
                var quality = options.resizeQuality * 100 || 70;
                var mimeType = "image/jpeg";
                if (outputFormat !== undefined && outputFormat === "png") {
                    mimeType = "image/png";
                }


                var maxHeight = options.resizeMaxHeight || 500;
                var maxWidth = options.resizeMaxWidth || 350;

                var height = sourceImgObj.height;
                var width = sourceImgObj.width;

                // calculate the width and height, constraining the proportions
                if (width > height) {
                    if (width > maxWidth) {
                        height = Math.round(height *= maxWidth / width);
                        width = maxWidth;
                    }
                } else {
                    if (height > maxHeight) {
                        width = Math.round(width *= maxHeight / height);
                        height = maxHeight;
                    }
                }

                var cvs = document.createElement("canvas");
                cvs.width = width; //sourceImgObj.naturalWidth;
                cvs.height = height; //sourceImgObj.naturalHeight;
                var ctx = cvs.getContext("2d").drawImage(sourceImgObj, 0, 0, width, height);
                var newImageData = cvs.toDataURL(mimeType, quality / 100);
                var resultImageObj = new Image();
                resultImageObj.src = newImageData;
                return resultImageObj.src;

            };

            var createImage = function(url, callback) {
                var image = new Image();
                image.onload = function() {
                    callback(image);
                };
                image.src = url;
            };

            return {
                restrict: "A",
                require: "?ngModel",
                link: function(scope, element, attrs, ngModel) {

                    var doResizing = function(imageResult, callback) {
                        createImage(imageResult.url, function(image) {
                            var dataUrLcompressed = jicCompress(image, scope);

                            imageResult.compressed = {
                                dataURL: dataUrLcompressed,
                                type: dataUrLcompressed.match(/:(.+\/.+);/)[1]
                            };
                            callback(imageResult);
                        });
                    };

                    var applyScope = function(imageResult) {
                        scope.$apply(function() {
                            if (attrs.multiple) {
                                scope.image.push(imageResult);
                            } else {
                                scope.image = imageResult;
                                ngModel.$setViewValue(imageResult.compressed.dataURL);
                            }
                        });
                    };

                    var readFile = function(file) {
                        var deferred = $q.defer();

                        var reader = new FileReader();
                        reader.onload = function(e) {
                            deferred.resolve(e.target.result);
                        };
                        reader.onerror = function(e) {
                            deferred.reject(e);
                        };

                        reader.readAsDataURL(file);

                        return deferred.promise;
                    }

                    if (!ngModel) return;

                    ngModel.$render = function() {};

                    element.bind("change", function(e) {
                        var elt = e.target;
                        if (!elt.value) return;

                        var eventNameToListenTo = commonUtilities.IsUndefinedOrNull(elt.id) ? "changed" : elt.id + "-changed";

                        $rootScope.$emit(eventNameToListenTo, { detail: { fileName: elt.value } });

                        if (elt.accept.contains("image")) {
                            var files = e.target.files;
                            for (var i = 0; i < files.length; i++) {
                                //create a result object for each file in files
                                var imageResult = {
                                    file: files[i],
                                    url: URL.createObjectURL(files[i])
                                };

                                readFile(files[i]).then(function(dataUrl) {
                                    imageResult.dataURL = dataUrl;
                                });

                                if (!(scope.resizeMaxHeight || scope.resizeMaxWidth)) {
                                    scope.resizeMaxWidth = 500;
                                    scope.resizeMaxHeight = 350;
                                }
                                doResizing(imageResult, function(result) {
                                    applyScope(result);
                                });
                            }
                        } else {
                            elt.disabled = true;
                            $q.all(slice.call(elt.files, 0).map(readFile))
                                .then(function(values) {
                                    if (elt.multiple) {
                                        ngModel.$setViewValue(values);
                                    } else {
                                        ngModel.$setViewValue(values.length ? values[0] : null);
                                    }
                                    elt.value = null;
                                    elt.disabled = false;
                                });
                        }
                    }); //change
                } //link
            }; //return
        }
    ]);

    EVALUATIONErpDirective.directive("formatDate", function() {

        return {
            require: "ngModel",

            link: function(scope, element, attr, ngModelController) {
                ngModelController.$formatters.unshift(function(valueFromModel) {

                    if (angular.isUndefined(valueFromModel)) {
                        return valueFromModel;
                    }

                    var date = new Date(parseInt(valueFromModel.substr(6)));
                    //console.log(valueFromModel);
                    return date.toLocaleDateString();
                });
            }
        };
    });

    EVALUATIONErpDirective.directive("dateFormat", function() {
        return {
            require: "ngModel",
            link: function(scope, element, attrs, ctrl) {
                ctrl.$formatters.splice(0, ctrl.$formatters.length);
                ctrl.$parsers.splice(0, ctrl.$parsers.length);
                ctrl.$formatters.push(function(modelValue) {
                    if (!modelValue) {
                        return null;
                    }
                    return new Date(modelValue).toISOString().slice(0, 10);
                });
                ctrl.$parsers.push(function(modelValue) {
                    return modelValue;
                });
            }
        };
    });

    EVALUATIONErpDirective.directive('dateFormatJson', function ($filter, commonUtilities) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {

                ngModel.$formatters.splice(0, ngModel.$formatters.length);
                ngModel.$parsers.splice(0, ngModel.$parsers.length);
                ngModel.$formatters.push(function (modelValue) {
                    if (!modelValue) {
                        return null;
                    }
                    var dateFormatted = "";

                    if (modelValue.contains("\/Date(")) {
                        dateFormatted = $filter("jsonDate")(modelValue, "yyyy-MM-dd");
                    } else {
                        var dateJson = "\/Date(" + (commonUtilities.formatUTCDate(modelValue)) + ")\/";
                        dateFormatted = $filter("jsonDate")(dateJson, "yyyy-MM-dd");
                    }
                    return dateFormatted;

                });

                //format text from the user (view to model)
                ngModel.$parsers.push(function (value) {
                    var date = new Date(value);
                    if (!isNaN(date.getTime())) {
                        //return moment(date).format();
                        var dateJson = $filter("dateJson")(date);
                        return dateJson;
                    }
                });
            }
        }
    });

    EVALUATIONErpDirective.directive("formattedDate", [
        "$filter", "commonUtilities", function($filter, commonUtilities) {
            return {
                link: function(scope, element, attrs, ctrl) {
                    ctrl.$formatters.unshift(function(modelValue) {
                        if (commonUtilities.IsUndefinedOrNull(modelValue))
                            return "";

                        ////console.log('$formatters');
                        ////console.log(modelValue);
                        var dateFormatted = $filter("date")(modelValue, "yyyy-MM-dd");
                        ////console.log(dateFormatted);
                        return dateFormatted;
                    });

                    ctrl.$parsers.unshift(function(viewValue) {
                        if (commonUtilities.IsUndefinedOrNull(viewValue))
                            return null;

                        ////console.log('$parsers');
                        ////console.log(viewValue);
                        var dateFormatted = new Date(Date.parse(viewValue));
                        ////console.log(dateFormatted);
                        return dateFormatted;
                    });
                },
                restrict: "A",
                require: "ngModel"
            };
        }
    ]);

    EVALUATIONErpDirective.directive("formattedDateJson", [
        "$filter", "commonUtilities", function($filter, commonUtilities) {
            return {
                link: function(scope, element, attrs, ctrl) {
                    ctrl.$formatters.unshift(function(modelValue) {
                        if (commonUtilities.IsUndefinedOrNull(modelValue))
                            return "";

                        var dateFormatted = "";

                        if (modelValue.contains("\/Date(")) {
                            dateFormatted = $filter("jsonDate")(modelValue, "yyyy-MM-dd");
                        } else {
                            var dateJson = "\/Date(" + (commonUtilities.formatUTCDate(modelValue)) + ")\/";
                            dateFormatted = $filter("jsonDate")(dateJson, "yyyy-MM-dd");
                        }
                        return dateFormatted;
                    });

                    ctrl.$parsers.unshift(function(viewValue) {
                        var dateValue = viewValue;
                        if (commonUtilities.IsUndefinedOrNull(dateValue))
                            dateValue = null;
                        var dateTrans = new Date(Date.parse(dateValue));
                        var dateFormatted = $filter("dateJson")(dateTrans);
                        return dateFormatted;
                    });

                },
                restrict: "A",
                require: "ngModel"
            };
        }
    ]);

    EVALUATIONErpDirective.directive("formattedDateTimeJson", [
        "$filter", "commonUtilities", function ($filter, commonUtilities) {
            return {
                link: function (scope, element, attrs, ctrl) {
                    ctrl.$formatters.unshift(function (modelValue) {
                        if (commonUtilities.IsUndefinedOrNull(modelValue))
                            return "";

                        var dateFormatted = "";

                        if (modelValue.contains("\/Date(")) {
                            dateFormatted = $filter("jsonDate")(modelValue, "yyyy-MM-dd");
                        } else {
                            var dateJson = "\/Date(" + (commonUtilities.formatUTCDate(modelValue)) + ")\/";
                            dateFormatted = $filter("jsonDate")(dateJson, "yyyy-MM-dd");
                        }
                        return dateFormatted;
                    });

                    ctrl.$parsers.unshift(function (viewValue) {
                        var dateValue = viewValue;
                        if (commonUtilities.IsUndefinedOrNull(dateValue))
                            dateValue = null;
                        var dateTrans = new Date(Date.parse(dateValue));
                        var dateFormatted = $filter("dateJson")(dateTrans);
                        return dateFormatted;
                    });

                },
                restrict: "A",
                require: "ngModel"
            };
        }
    ]);

    EVALUATIONErpDirective.directive("formattedMoney", [
        "$filter", "commonUtilities", function($filter, commonUtilities) {
            return {
                link: function(scope, element, attrs, ctrl) {
                    ctrl.$formatters.unshift(function(modelValue) {
                        if (commonUtilities.IsUndefinedOrNull(modelValue))
                            return "";

                        var moneyFormatted = $filter("formatMillier")(modelValue);
                        return moneyFormatted;
                    });

                    ctrl.$parsers.unshift(function(viewValue) {
                        var moneyValue = viewValue;
                        if (commonUtilities.IsUndefinedOrNull(moneyValue))
                            return null;

                        var moneyFormatted = $filter("formatMillierRec")(moneyValue);
                        return moneyFormatted;
                    });
                },
                restrict: "A",
                require: "ngModel"
            };
        }
    ]);

    EVALUATIONErpDirective.directive("encodedData", [
        "commonUtilities",
        function(commonUtilities) {
            return {
                link: function(scope, element, attrs, ctrl) {

                    ctrl.$parsers.unshift(function(viewValue) {
                        var dataValue = viewValue;
                        if (commonUtilities.IsUndefinedOrNull(dataValue))
                            dataValue = "";

                        var encoded = commonUtilities.encode(dataValue);
                        ////console.log(encoded);
                        return encoded;
                    });
                },
                restrict: "A",
                require: "ngModel"
            };
        }
    ]);

    EVALUATIONErpDirective.directive("input", [
        "commonUtilities", function(commonUtilities) {
            var isOk = function(element, attrs) {
                if (element === null || element === undefined)
                    return false;

                if (attrs === null || attrs === undefined)
                    return false;

                return true;
            }

            return {
                restrict: "E",
                link: function(scope, element, attrs, ngModel) {
                    if (!isOk(element, attrs))
                        return;

                    /*
                        -ajouter des limites sur les input de type 'date'
                    */
                    if (attrs.type === "date") {
                        element.attr("min", "1800-01-01");
                        element.attr("max", "9999-01-01");
                    }

                    /*
                        -
                    */
                    if (attrs.type === "file") {
                        if (attrs.accept && attrs.accept.contains("image")) {
                            element.attr("accept", "image/jpeg, image/png");
                            element.attr("title", "jpeg, png");
                            element.attr("tooltip-placement", "bottom");
                        }
                        //element.attr("ui-jq", "filestyle");
                        //element.attr("data-icon", "false");
                        //element.attr("data-classbutton", "btn btn-default");
                        //element.attr("data-classinput", "form-control inline v-middle input-sm");
                    }
                }
            }

        }
    ]);

    EVALUATIONErpDirective.directive("button", function() {
        return {
            restrict: "E",
            link: function(scope, element, attrs) {
                if (element === null || element === undefined)
                    return;

                if (attrs === null || attrs === undefined)
                    return;

                var att = document.createAttribute("click-once");

                //if (attrs.type === "submit") {
                //    element[0].setAttributeNode(att);
                //    //element.attr(att);
                //}
            }
        };
    });

   

    EVALUATIONErpDirective.
        directive("uiModule", [
            "MODULE_CONFIG", "uiLoad", "$compile", function(MODULE_CONFIG, uiLoad, $compile) {
                return {
                    restrict: "A",
                    compile: function(el, attrs) {
                        var contents = el.contents().clone();
                        return function(scope, el, attrs) {
                            el.contents().remove();
                            uiLoad.load(MODULE_CONFIG[attrs.uiModule])
                                .then(function() {
                                    $compile(contents)(scope, function(clonedElement, scope) {
                                        el.append(clonedElement);
                                    });
                                });
                        }
                    }
                };
            }
        ])
        .directive("uiShift", [
            "$timeout", function($timeout) {
                return {
                    restrict: "A",
                    link: function(scope, el, attr) {
                        // get the $prev or $parent of this el
                        var _el = $(el),
                            _window = $(window),
                            prev = _el.prev(),
                            parent,
                            width = _window.width();

                        !prev.length && (parent = _el.parent());

                        function sm() {
                            $timeout(function() {
                                var method = attr.uiShift;
                                var target = attr.target;
                                _el.hasClass("in") || _el[method](target).addClass("in");
                            });
                        }

                        function md() {
                            parent && parent["prepend"](el);
                            !parent && _el["insertAfter"](prev);
                            _el.removeClass("in");
                        }

                        (width < 768 && sm()) || md();

                        _window.resize(function() {
                            if (width !== _window.width()) {
                                $timeout(function() {
                                    (_window.width() < 768 && sm()) || md();
                                    width = _window.width();
                                });
                            }
                        });
                    }
                };
            }
        ])
        .directive("uiToggleClass", [
            "$timeout", "$document", function($timeout, $document) {
                return {
                    restrict: "AC",
                    link: function(scope, el, attr) {
                        el.on("click", function(e) {
                            e.preventDefault();
                            var classes = attr.uiToggleClass.split(","),
                                targets = (attr.target && attr.target.split(",")) || Array(el),
                                key = 0;
                            angular.forEach(classes, function(_class) {
                                var target = targets[(targets.length && key)];
                                (_class.indexOf("*") !== -1) && magic(_class, target);
                                $(target).toggleClass(_class);
                                key++;
                            });
                            $(el).toggleClass("active");

                            function magic(_class, target) {
                                var patt = new RegExp("\\s" +
                                    _class.
                                    replace(/\*/g, "[A-Za-z0-9-_]+").
                                    split(" ").
                                    join("\\s|\\s") +
                                    "\\s", "g");
                                var cn = " " + $(target)[0].className + " ";
                                while (patt.test(cn)) {
                                    cn = cn.replace(patt, " ");
                                }
                                $(target)[0].className = $.trim(cn);
                            }
                        });
                    }
                };
            }
        ])
        .directive("uiNav", [
            "$timeout", function($timeout) {
                return {
                    restrict: "AC",
                    link: function(scope, el, attr) {
                        var _window = $(window);
                        var _mb = 768;
                        // unfolded
                        $(el).on("click", "a", function(e) {
                            var _this = $(this);
                            _this.parent().siblings(".active").toggleClass("active");
                            _this.parent().toggleClass("active");
                            _this.next().is("ul") && e.preventDefault();
                            _this.next().is("ul") || ((_window.width() < _mb) && $(".app-aside").toggleClass("show"));
                        });

                        // folded
                        var wrap = $(".app-aside"), next;
                        $(el).on("mouseenter", "a", function(e) {
                            if (!$(".app-aside-fixed.app-aside-folded").length || (_window.width() < _mb)) return;
                            var _this = $(this);

                            next && next.trigger("mouseleave.nav");

                            if (_this.next().is("ul")) {
                                next = _this.next();
                            } else {
                                return;
                            }

                            next.appendTo(wrap).css("top", _this.offset().top - _this.height());
                            next.on("mouseleave.nav", function(e) {
                                next.appendTo(_this.parent());
                                next.off("mouseleave.nav");
                                _this.parent().removeClass("active");
                            });
                            _this.parent().addClass("active");

                        });

                        wrap.on("mouseleave", function(e) {
                            next && next.trigger("mouseleave.nav");
                        });
                    }
                };
            }
        ])
        .directive("uiScroll", [
            "$location", "$anchorScroll", function($location, $anchorScroll) {
                return {
                    restrict: "AC",
                    link: function(scope, el, attr) {
                        el.on("click", function(e) {
                            $location.hash(attr.uiScroll);
                            $anchorScroll();
                        });
                    }
                };
            }
        ])
        .directive("uiFullscreen", [
            "uiLoad", function(uiLoad) {
                return {
                    restrict: "AC",
                    template: "<i class=\"fa fa-expand fa-fw text\"></i><i class=\"fa fa-compress fa-fw text-active\"></i>",
                    link: function(scope, el, attr) {
                        el.addClass("hide");
                        uiLoad.load(HelpersErp.getUrlByTemplateLibBase("screenfull.min.js")).then(function() {
                            if (screenfull.enabled) {
                                el.removeClass("hide");
                            }
                            el.on("click", function() {
                                var target;
                                attr.target && (target = $(attr.target)[0]);
                                el.toggleClass("active");
                                screenfull.toggle(target);
                            });
                        });
                    }
                };
            }
        ])
        .directive("uiButterbar", [
            "$rootScope", "$location", "$anchorScroll", function($rootScope, $location, $anchorScroll) {
                return {
                    restrict: "AC",
                    template: "<span class=\"bar\"></span>",
                    link: function(scope, el, attrs) {
                        el.addClass("butterbar hide");
                        scope.$on("$stateChangeStart", function(event) {
                            $location.hash("app");
                            $anchorScroll();
                            el.removeClass("hide").addClass("active");
                        });
                        scope.$on("$stateChangeSuccess", function(event, toState, toParams, fromState) {
                            event.targetScope.$watch("$viewContentLoaded", function() {
                                el.addClass("hide").removeClass("active");
                            });
                        });
                    }
                };
            }
        ]);

    EVALUATIONErpDirective.config([
        "$httpProvider", "dialogsProvider", function ($httpProvider, dialogsProvider) {
            dialogsProvider.useBackdrop("static");
            dialogsProvider.useEscClose(true);
            dialogsProvider.useCopy(false);
            dialogsProvider.setSize("sm");

            $httpProvider.interceptors.push("httpInterceptor");
            

        }
    ]);

});