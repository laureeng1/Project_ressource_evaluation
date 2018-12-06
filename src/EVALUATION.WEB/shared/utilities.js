"use strict";

/* Utilities */

if (!String.prototype.contains) {
    String.prototype.contains = function () {
        return String.prototype.indexOf.apply(this, arguments) !== -1;
    };
}

if (!Number.prototype.trim) {
    Number.prototype.trim = function () {
        return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, '');
    };
}

if (!Number.prototype.replace) {
    Number.prototype.replace = function () {
        return this.replace(' ', '');
    };
}

var toDate = function (value) {
    var dateRegExp = /^\/Date\((.*?)\)\/$/;
    var date = dateRegExp.exec(value);
    return new Date(parseInt(date[1]));
};

define(["jquery", "jquery-base64", "jquery-gritter", "definitions"], function($) {
    utilities.service("commonUtilities", [
        "$filter","$location",
        function ($filter,$location) {
            var mainSelf = this;

            // foreach sur fonction async
            // charger les imputations de chaque fiche d'engagement

            //var parameters = new Array();
            //for (var n = 0; n < listeIdFicheEngagement.length; n++) {
            //    var imp = new modelSbModel.ImputationBudgetaire(listeIdFicheEngagement[n].IdImputationBudgetaire);

            //    var request = new commonUtilities.RequestSw(0, 1, false, 1);
            //    request.ImputationBudgetaire = imp;
            //    parameters.push(request);
            //}

            //if (parameters.length > 0) {
            //    var bfAsync = new commonUtilities.BoucleFuncAsyncClass();
            //    bfAsync.start(modelSbProvider.GetAllImputationsBudgetaireByCriteria, self.UpdateFichesEngagements, parameters);
            //}
            mainSelf.hostAdresse = function() {
                return $location.host();
            }
            mainSelf.leftPad = function (variable, targetLength, padding) {
                var output = variable + '';
                for (var i = 0; i <= targetLength; i++){
                    output = (mainSelf.IsUndefinedOrNull(padding) ? '0' : padding) + output;
                }
                /*while (output.length < targetLength) {
                    output = (mainSelf.IsUndefinedOrNull(padding) ? '0' : padding) + output;
                }*/
                return output;
            }

            mainSelf.SortOrder = {
                Ascending: "Ascending",
                Descending: "Descending"
            };

            mainSelf.GlobalEnum = {
                CustomException: "-CUSTOM-EXCEPTION",
                CustomRegleGestionException: "-CUSTOM-REGLE-GESTION-EXCEPTION",
                MessageDelete: "Voulez vous vraiment faire cette suppression ?"
            };

            mainSelf.RoleVariableEnvEnum = {
                VariableAControler: "Variable à contrôler",
                VariableDeReference: "Variable de référence"
            };

            mainSelf.OperatorEnum = {
                EQUAL: "EQUAL",
                NOTEQUAL: "NOT EQUAL",
                BETWEEN: "BETWEEN",
                STARSTWITH: "STARTS WITH",
                ENDSWITH: "ENDS WITH",
                CONTAINS: "CONTAINS",
                LESS: "LESS",
                LESSOREQUAL: "LESS OR EQUAL",
                MORE: "MORE",
                MOREOREQUAL: "MORE OR EQUAL"
            };

            mainSelf.formatMillier = function(nombre) {
                nombre += "";
                var sep = " ";
                var reg = /(\d+)(\d{3})/;

                while (reg.test(nombre)) {
                    nombre = nombre.replace(reg, "$1" + sep + "$2");
                }

                return nombre;
            };

            mainSelf.formatMillierRec = function(nombre) {
                nombre += "";
                var reg = new RegExp("\\ ", "g");
                nombre = nombre.trim().replace(reg, "");

                return nombre;
            };

            mainSelf.ConvertBase64ToFile = function(base, fileName) {
                

                var byteCharacters = atob(base);
                var byteNumbers = new Array(byteCharacters.length);
                for (var i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }
                var byteArray = new Uint8Array(byteNumbers);
                var contentType = "application/octet-stream";
                var urlCreator = window.URL || window.webkitURL || window.mozURL || window.msURL;
                var blob = new Blob([byteArray], { type: contentType });
                var url = urlCreator.createObjectURL(blob);
                var a = document.createElement("a");
                document.body.appendChild(a);
                a.style = "display: none";
                a.href = url;
                a.download = fileName; //you may assign this value from header as well 
                a.click();
                window.URL.revokeObjectURL(url);
            }

            mainSelf.ConvertBase64FileToURL = function (base, fileName) {


                var byteCharacters = atob(base);
                var byteNumbers = new Array(byteCharacters.length);
                for (var i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }
                var byteArray = new Uint8Array(byteNumbers);
                var contentType = "application/octet-stream";
                var urlCreator = window.URL || window.webkitURL || window.mozURL || window.msURL;
                var blob = new Blob([byteArray], { type: contentType });
                var url = urlCreator.createObjectURL(blob);
                return url;
            }

            mainSelf.dateJsonFormat = function(date) {
                if (mainSelf.IsUndefinedOrNull(date))
                    return null;

                return "\/Date(" + (mainSelf.formatUTCDate(date)) + ")\/";
            };

            // json format
            mainSelf.getAgeFromJson = function(dateNaissance) {
                var birthDay = $filter("jsonDateUtc")(dateNaissance);
                return mainSelf.currentDate().getFullYear() - birthDay.getFullYear();
            };

            mainSelf.addDays = function(date, days) {
                var dat = new Date(date);
                dat.setDate(dat.getDate() + days);
                return new Date(dat).toISOString().slice(0, 10);;
            };

            mainSelf.getLastDaysOfMonth = function(date) {
                var currentDate;
                var dat = new Date(date);
                if (dat.getMonth() == 11) {
                    currentDate = new Date(dat.getFullYear() + 1, 0, 1);
                } else {
                    currentDate = new Date(dat.getFullYear(), dat.getMonth() + 1, 1);
                }
                var y = currentDate.getFullYear(), m = currentDate.getMonth();
                //var firstDay = new Date(y, m, 1);
                var lastDay = new Date(y, m + 1, 0);
                return new Date(lastDay).toISOString().slice(0, 10);;
            };


            mainSelf.getGenre = function(genre) {
                return $filter("genre")(genre);
            };

            //format date dd/mm/aaaa
            mainSelf.getAge = function(dateNaissance) {

                //var dateNaissance = document.getElementById(id_naissance).value;

                var elemN = dateNaissance.split("/");
                var jourN = elemN[0];
                var moisN = elemN[1];
                var anneeN = elemN[2];

                var dateDay = new Date();
                var jourDay = dateDay.getDate();
                var moisDay = dateDay.getMonth() + 1;
                var anneeDay = dateDay.getFullYear();

                //calcul age
                var ans;
                var mois;
                var age = "";

                if (moisDay >= moisN) {
                    ans = anneeDay - anneeN;
                    mois = moisDay - moisN;
                } else {
                    ans = (anneeDay - anneeN) - 1;
                    mois = moisDay + (12 - moisN);
                }
                if (jourDay < jourN) {
                    mois = mois - 1;
                    if (moisDay < moisN) {
                        ans = ans - 1;
                    }
                }

                if (ans > 0 && ans <= 1) age += ans + " an ";
                if (ans > 1) age += ans + " ans ";
                //if (mois > 0) age += mois + ' mois ';
                if (mois > 0 && ans < 1) age += mois + " mois "; //considerer les mois uniquements quand l'age est inferieurs a 1

                return age;
            };

            //format date mm/dd/aaaa
            mainSelf.getAgeEng = function(dateNaissance) {

                //var dateNaissance = document.getElementById(id_naissance).value;

                var elemN = dateNaissance.split("/");
                var jourN = elemN[1];
                var moisN = elemN[0];
                var anneeN = elemN[2];

                var dateDay = new Date();
                var jourDay = dateDay.getDate();
                var moisDay = dateDay.getMonth() + 1;
                var anneeDay = dateDay.getFullYear();

                //calcul age
                var ans;
                var mois;
                var age = "";

                if (moisDay >= moisN) {
                    ans = anneeDay - anneeN;
                    mois = moisDay - moisN;
                } else {
                    ans = (anneeDay - anneeN) - 1;
                    mois = moisDay + (12 - moisN);
                }
                if (jourDay < jourN) {
                    mois = mois - 1;
                    if (moisDay < moisN) {
                        ans = ans - 1;
                    }
                }

                if (ans > 0 && ans <= 1) age += ans + " an ";
                if (ans > 1) age += ans + " ans ";
                //if (mois > 0) age += mois + ' mois ';
                if (mois > 0 && ans < 1) age += mois + " mois "; //considerer les mois uniquements quand l'age est inferieurs a 1

                return age;
            };
            //fin format age

            mainSelf.BoucleFuncAsyncClass = function() {
                var self = this;

                var results = new Array();
                self.response = null;
                self.callback = null;
                self.searchFunc = null;
                var listeOfParameters = null;

                self.BouclerFuncAsync = function() {
                    var request = listeOfParameters == null ? null : (listeOfParameters.length > 0 ? listeOfParameters.shift() : null);

                    if (request != null) {
                        self.searchFunc(request, self.BouclerFuncAsyncRappel);
                    } else {

                        self.callback(new mainSelf.ResponseSw(null, 0, 0, 0, 0, "", true));
                    }
                };

                self.BouclerFuncAsyncRappel = function(response) {
                    if (response.HasError) {
                        //console.log(response.Message);
                        self.response = response;

                        self.callback(self.response);
                    } else {

                        if (!mainSelf.IsUndefinedOrNull(response.Response)) {
                            for (var i = 0; i < response.Response.length; i++) {
                                var rp = response.Response[i];
                                results.push(rp);
                            }
                        }

                        if (listeOfParameters.length > 0)
                            self.BouclerFuncAsync();
                        else {
                            self.response.Response = results;
                            self.callback(self.response);
                        }
                    }
                };

                self.start = function(searchFunc, callback, parameters) {

                    results = new Array();

                    self.response = new mainSelf.ResponseSw(null, 0, 0, 0, 0, "", false);
                    self.callback = callback;
                    listeOfParameters = parameters;
                    self.searchFunc = searchFunc;

                    self.BouclerFuncAsync();
                };
            };

            //#region date formatting
            mainSelf.dateJsonFormat = function(date) {
                if (mainSelf.IsUndefinedOrNull(date))
                    return null;

                return "\/Date(" + (mainSelf.formatUTCDate(date)) + ")\/";
            };


            mainSelf.getNbJours = function(date) {
                return new Date(date.getFullYear(), date.getMonth() + 1, -1).getDate() + 1;
            };

            mainSelf.getAge = function(dateNaissance) {

                //var dateNaissance = document.getElementById(id_naissance).value;

                var elemN = dateNaissance.split("/");
                var jourN = elemN[0];
                var moisN = elemN[1];
                var anneeN = elemN[2];

                var dateDay = new Date();
                var jourDay = dateDay.getDate();
                var moisDay = dateDay.getMonth() + 1;
                var anneeDay = dateDay.getFullYear();

                //calcul age
                var ans;
                var mois;
                var age = "";

                if (moisDay >= moisN) {
                    ans = anneeDay - anneeN;
                    mois = moisDay - moisN;
                } else {
                    ans = (anneeDay - anneeN) - 1;
                    mois = moisDay + (12 - moisN);
                }
                if (jourDay < jourN) {
                    mois = mois - 1;
                    if (moisDay < moisN) {
                        ans = ans - 1;
                    }
                }

                if (ans > 0 && ans <= 1) age += ans + " an ";
                if (ans > 1) age += ans + " ans ";
                //if (mois > 0) age += mois + ' mois ';
                if (mois > 0 && ans < 1) age += mois + " mois "; //considerer les mois uniquements quand l'age est inferieurs a 1

                return age;
            };

            mainSelf.toDate = function(value) {
                var dateRegExp = /^\/Date\((.*?)\)\/$/;
                var date = dateRegExp.exec(value);
                return new Date(parseInt(date[1]));
            };
           

            mainSelf.formatUTCDate = function(d1) {
                if (mainSelf.IsUndefinedOrNull(d1))
                    return null;

                var d = new Date(d1);
                var str = Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds(), 0);
                return str;
            };

            mainSelf.currentDate = function() {
                return new Date();
            };

            mainSelf.currentDateJson = function() {
                return $filter("dateJson")(mainSelf.currentDate());
            };

            mainSelf.dateDiffFormatee = function(date1, date2) {
                var diff = mainSelf.dateDiff(date1, date2);
                var dateFormatee = null;

                if (diff.day == 0 && diff.hour == 0 && diff.min == 0) {
                    dateFormatee = "A l'instant";
                } else {
                    if (diff.day == 0 && diff.hour == 0) {
                        dateFormatee = diff.min + " mins";
                    } else {
                        if (diff.day == 0) {
                            dateFormatee = diff.hour + " hrs " + diff.min + " mins";
                        } else {
                            dateFormatee = diff.day + " jrs " + diff.hour + " hrs " + diff.min + " mins";
                        }
                    }
                }

                return dateFormatee;
            };

            mainSelf.dateJsonDiff = function(dateInf, dateSup) {
                var date1 = $filter("jsonDateUtc")(dateInf);
                var date2 = $filter("jsonDateUtc")(dateSup);
                var diff = mainSelf.dateDiff(date1, date2);

                return diff;
            };

            mainSelf.dateDiff = function(date1, date2) {
                var diff = {}; // Initialisation du retour
                var tmp = date2 - date1;

                tmp = Math.floor(tmp / 1000); // Nombre de secondes entre les 2 dates
                diff.sec = tmp % 60; // Extraction du nombre de secondes

                tmp = Math.floor((tmp - diff.sec) / 60); // Nombre de minutes (partie entière)
                diff.min = tmp % 60; // Extraction du nombre de minutes

                tmp = Math.floor((tmp - diff.min) / 60); // Nombre d'heures (entières)
                diff.hour = tmp % 24; // Extraction du nombre d'heures

                tmp = Math.floor((tmp - diff.hour) / 24); // Nombre de jours restants
                diff.day = tmp;

                return diff;
            };

            // entrée date (Coordinated Universal Time) - resultat en format yyyy/mm/dd
            // à utiliser pour les formats de date en html5
            mainSelf.dateToFormatYYYYMMDD = function(value) {
                if (mainSelf.IsUndefinedOrNull(value))
                    return null;

                var valueInDate = (new Date(value));
                var d = valueInDate.getDate();
                var m = (valueInDate.getMonth() + 1).toString();
                if (m.length == 1)
                    m = "0" + m;
                var y = valueInDate.getFullYear();
                return y + "/" + m + "/" + d;

                //return (new Date(value)).getDate();
            };

            // entrée date (Coordinated Universal Time) - resultat en format yyyy-mm-dd
            mainSelf.dateToFormatYYYYMMDD2 = function(value) {
                if (mainSelf.IsUndefinedOrNull(value))
                    return null;

                var valueInDate = (new Date(value));
                var d = valueInDate.getDate();
                var m = (valueInDate.getMonth() + 1).toString();
                if (m.length == 1)
                    m = "0" + m;
                var y = valueInDate.getFullYear();
                return y + "-" + m + "-" + d;

                //return (new Date(value)).getDate();
            };

            // resultat en format yyyy/mm/dd - entrée date (Coordinated Universal Time)
            // à utiliser pour les formats de date en html5
            mainSelf.formatYYYYMMDDToDate = function(date) {
                if (!mainSelf.IsUndefinedOrNull(date)) {

                    return new Date(Date.parse(date));
                } else {
                    return null;
                }
            };

            // resultat en format yyyy-mm-dd - entrée date (Coordinated Universal Time)
            mainSelf.formatYYYYMMDDToDate2 = function(date) {
                if (!mainSelf.IsUndefinedOrNull(date)) {

                    return new Date(Date.parse(date));
                } else {
                    return null;
                }
            };

            mainSelf.formattedDateddmmyyyy = function (d) {
                let month = String(d.getMonth() + 1);
                let day = String(d.getDate());
                const year = String(d.getFullYear());

                if (month.length < 2) month = '0' + month;
                if (day.length < 2) day = '0' + day;

                return `${day}/${month}/${year}`;
            }
            //#endregion

            mainSelf.clone = function(srcInstance) {

                //var copy = null;

                //try {
                //    copy = JSON.parse(JSON.stringify(obj));
                //} catch(ex) {
                //    alert("SVP, Utilisez un navigateur IE > 7 pour la bonne exécution du programme!");
                //}

                //return copy;

                /*Si l'instance source n'est pas un objet ou qu'elle ne vaut rien c'est une feuille donc on la retourne*/
                if (typeof (srcInstance) != "object" || srcInstance == null) {
                    return srcInstance;
                }

                /*On appel le constructeur de l'instance source pour crée une nouvelle instance de la même classe*/
                var newInstance = new srcInstance.constructor();
                /*On parcourt les propriétés de l'objet et on les recopies dans la nouvelle instance*/
                for (var i in srcInstance) {
                    newInstance[i] = mainSelf.clone(srcInstance[i]);
                }
                /*On retourne la nouvelle instance*/
                return newInstance;
            };

            mainSelf.IsUndefinedOrNull = function(object) {
                return object == null || object == "undefined" || object==="";
            };

            mainSelf.RemoveItem = function(array, key, value) {

                mainSelf.writeInConsole("remove item");

                var cloneArray = typeof (array) === "function" ? array() : array;

                for (var j = 0; j < cloneArray.length; j++) {
                    if (cloneArray[j][key] == value) {
                        array.splice(j, 1);
                        break;
                    }
                }
            };

            mainSelf.GetItem = function(array, key, value) {

                var cloneArray = typeof (array) === "function" ? array() : array;

                if (mainSelf.IsUndefinedOrNull(cloneArray))
                    return null;

                for (var i = 0; i < cloneArray.length; i++) {
                    if (cloneArray[i][key] == value) {
                        return cloneArray[i];
                    }
                }

                return null;
            };

            mainSelf.GetItems = function(array, key, value) {

                var cloneArray = typeof (array) === "function" ? array() : array;

                if (mainSelf.IsUndefinedOrNull(cloneArray))
                    return null;

                var liste = new Array();
                for (var i = 0; i < cloneArray.length; i++) {
                    if (cloneArray[i][key] == value) {
                        liste.push(cloneArray[i]);
                    }
                }

                return liste;
            };

            mainSelf.TakeItem = function(array, key, value) {

                var item = mainSelf.GetItem(array, key, value);
                mainSelf.RemoveItem(array, key, value);

                return item;
            };

            mainSelf.ResponseSw = function(data, indexDebut, indexFin, count, message, hasError) {
                var self = this;

                self.Data = data;
                self.IndexDebut = indexDebut || 0;
                self.IndexFin = indexFin || 0;
                self.Count = count || 0;
                self.Message = message || "";
                self.HasError = hasError || false;
            };

            mainSelf.RequestSw = function(index, size, takeAll, deepth, isNotificationToShow, titleNotificationToShow, notificationToShow, showErrorInAlert, showLoader,mustFilterByTenant) {
                var self = this;

                self.Index = index || 0;
                self.Size = size || 10;
                self.TakeAll = takeAll || false;
                self.Deepth = mainSelf.IsUndefinedOrNull(deepth) ? 0 : deepth;
                self.IsNotificationToShow = isNotificationToShow || false;
                self.TitleNotificationToShow = titleNotificationToShow || "";
                self.NotificationToShow = notificationToShow || "";
                self.ShowErrorInAlert = showErrorInAlert == true ? true : (showErrorInAlert == false ? false : null);
                self.ShowLoader = mainSelf.IsUndefinedOrNull(showLoader) ? true : showLoader;
                self.Navigator = navigator;
                self.MustFilterByTenant = mustFilterByTenant || true;
            };

            mainSelf.customFilterable = function() {
                var obj = {
                    messages: {
                        and: "et",
                        extra: false,
                        clear: "Effacer",
                        filter: "Appliquer",
                        info: "Filtrer par:",
                        isFalse: "False",
                        or: "ou",
                        selectValue: "Sélectionner la catégorie",
                        cancel: "Annuler",
                        operator: "Sélectionner l'opérateur",
                        value: "Sélectionner la valeur"

                    },
                    operators: {
                        string: {
                            eq: "Egal à",
                            neq: "Différent de",
                            startswith: "Commence avec",
                            contains: "Contient",
                            doesnotcontain: "Ne contient pas",
                            endswith: "Se termine avec"
                        },
                        number: {
                            gte: "Supérieur ou égal à",
                            gt: "Plus grand que",
                            lte: "Inférieur ou égal à",
                            lt: "Plus petit que"
                        }
                    }
                };

                return obj;
            };

            // début définition
            mainSelf.writeInConsole = function(text) {
                if (typeof console !== "undefined") {
                    //console.log(text);
                } else {
                    //alert(text);
                }
            };

            mainSelf.utf8_encode = function(argString) {
                //  discuss at: http://phpjs.org/functions/utf8_encode/
                // original by: Webtoolkit.info (http://www.webtoolkit.info/)
                // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
                // improved by: sowberry
                // improved by: Jack
                // improved by: Yves Sucaet
                // improved by: kirilloid
                // bugfixed by: Onno Marsman
                // bugfixed by: Onno Marsman
                // bugfixed by: Ulrich
                // bugfixed by: Rafal Kukawski
                // bugfixed by: kirilloid
                //   example 1: utf8_encode('Kevin van Zonneveld');
                //   returns 1: 'Kevin van Zonneveld'

                if (argString === null || typeof argString === "undefined") {
                    return "";
                }

                var string = (argString + ""); // .replace(/\r\n/g, "\n").replace(/\r/g, "\n");
                var utftext = "",
                    start,
                    end,
                    stringl = 0;

                start = end = 0;
                stringl = string.length;
                for (var n = 0; n < stringl; n++) {
                    var c1 = string.charCodeAt(n);
                    var enc = null;

                    if (c1 < 128) {
                        end++;
                    } else if (c1 > 127 && c1 < 2048) {
                        enc = String.fromCharCode(
                            (c1 >> 6) | 192, (c1 & 63) | 128
                        );
                    } else if ((c1 & 0xF800) != 0xD800) {
                        enc = String.fromCharCode(
                            (c1 >> 12) | 224, ((c1 >> 6) & 63) | 128, (c1 & 63) | 128
                        );
                    } else { // surrogate pairs
                        if ((c1 & 0xFC00) != 0xD800) {
                            throw new RangeError("Unmatched trail surrogate at " + n);
                        }
                        var c2 = string.charCodeAt(++n);
                        if ((c2 & 0xFC00) != 0xDC00) {
                            throw new RangeError("Unmatched lead surrogate at " + (n - 1));
                        }
                        c1 = ((c1 & 0x3FF) << 10) + (c2 & 0x3FF) + 0x10000;
                        enc = String.fromCharCode(
                            (c1 >> 18) | 240, ((c1 >> 12) & 63) | 128, ((c1 >> 6) & 63) | 128, (c1 & 63) | 128
                        );
                    }
                    if (enc !== null) {
                        if (end > start) {
                            utftext += string.slice(start, end);
                        }
                        utftext += enc;
                        start = end = n + 1;
                    }
                }

                if (end > start) {
                    utftext += string.slice(start, stringl);
                }

                return utftext;
            };
            //#region encode
            mainSelf.base64Encode = function(str) {
                //return base64.encode(str);
                return $.base64.encode(str);
            };

            mainSelf.base64Decode = function(str) {
                //return base64.decode(str);
                return $.base64.decode(str);
            };

            //custom
            mainSelf.encode = function(str) {
                var response = mainSelf.base64Encode(str);
                return mainSelf.base64Encode(mainSelf.base64Encode(response));
            };

            mainSelf.decode = function(str) {
                var response = mainSelf.base64Decode(str);
                return mainSelf.base64Decode(mainSelf.base64Decode(response));
            };
            //#endregion
            mainSelf.md5 = function(str) {
                //  discuss at: http://phpjs.org/functions/md5/
                // original by: Webtoolkit.info (http://www.webtoolkit.info/)
                // improved by: Michael White (http://getsprink.com)
                // improved by: Jack
                // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
                //    input by: Brett Zamir (http://brett-zamir.me)
                // bugfixed by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
                //  depends on: utf8_encode
                //   example 1: md5('Kevin van Zonneveld');
                //   returns 1: '6e658d4bfcb59cc13f96c14450ac40b9'

                var xl;

                var rotateLeft = function(lValue, iShiftBits) {
                    return (lValue << iShiftBits) | (lValue >>> (32 - iShiftBits));
                };

                var addUnsigned = function(lX, lY) {
                    var lX4, lY4, lX8, lY8, lResult;
                    lX8 = (lX & 0x80000000);
                    lY8 = (lY & 0x80000000);
                    lX4 = (lX & 0x40000000);
                    lY4 = (lY & 0x40000000);
                    lResult = (lX & 0x3FFFFFFF) + (lY & 0x3FFFFFFF);
                    if (lX4 & lY4) {
                        return (lResult ^ 0x80000000 ^ lX8 ^ lY8);
                    }
                    if (lX4 | lY4) {
                        if (lResult & 0x40000000) {
                            return (lResult ^ 0xC0000000 ^ lX8 ^ lY8);
                        } else {
                            return (lResult ^ 0x40000000 ^ lX8 ^ lY8);
                        }
                    } else {
                        return (lResult ^ lX8 ^ lY8);
                    }
                };

                var _F = function(x, y, z) {
                    return (x & y) | ((~x) & z);
                };
                var _G = function(x, y, z) {
                    return (x & z) | (y & (~z));
                };
                var _H = function(x, y, z) {
                    return (x ^ y ^ z);
                };
                var _I = function(x, y, z) {
                    return (y ^ (x | (~z)));
                };

                var _FF = function(a, b, c, d, x, s, ac) {
                    a = addUnsigned(a, addUnsigned(addUnsigned(_F(b, c, d), x), ac));
                    return addUnsigned(rotateLeft(a, s), b);
                };

                var _GG = function(a, b, c, d, x, s, ac) {
                    a = addUnsigned(a, addUnsigned(addUnsigned(_G(b, c, d), x), ac));
                    return addUnsigned(rotateLeft(a, s), b);
                };

                var _HH = function(a, b, c, d, x, s, ac) {
                    a = addUnsigned(a, addUnsigned(addUnsigned(_H(b, c, d), x), ac));
                    return addUnsigned(rotateLeft(a, s), b);
                };

                var _II = function(a, b, c, d, x, s, ac) {
                    a = addUnsigned(a, addUnsigned(addUnsigned(_I(b, c, d), x), ac));
                    return addUnsigned(rotateLeft(a, s), b);
                };

                var convertToWordArray = function(str) {
                    var lWordCount;
                    var lMessageLength = str.length;
                    var lNumberOfWords_temp1 = lMessageLength + 8;
                    var lNumberOfWords_temp2 = (lNumberOfWords_temp1 - (lNumberOfWords_temp1 % 64)) / 64;
                    var lNumberOfWords = (lNumberOfWords_temp2 + 1) * 16;
                    var lWordArray = new Array(lNumberOfWords - 1);
                    var lBytePosition = 0;
                    var lByteCount = 0;
                    while (lByteCount < lMessageLength) {
                        lWordCount = (lByteCount - (lByteCount % 4)) / 4;
                        lBytePosition = (lByteCount % 4) * 8;
                        lWordArray[lWordCount] = (lWordArray[lWordCount] | (str.charCodeAt(lByteCount) << lBytePosition));
                        lByteCount++;
                    }
                    lWordCount = (lByteCount - (lByteCount % 4)) / 4;
                    lBytePosition = (lByteCount % 4) * 8;
                    lWordArray[lWordCount] = lWordArray[lWordCount] | (0x80 << lBytePosition);
                    lWordArray[lNumberOfWords - 2] = lMessageLength << 3;
                    lWordArray[lNumberOfWords - 1] = lMessageLength >>> 29;
                    return lWordArray;
                };

                var wordToHex = function(lValue) {
                    var wordToHexValue = "",
                        wordToHexValue_temp = "",
                        lByte,
                        lCount;
                    for (lCount = 0; lCount <= 3; lCount++) {
                        lByte = (lValue >>> (lCount * 8)) & 255;
                        wordToHexValue_temp = "0" + lByte.toString(16);
                        wordToHexValue = wordToHexValue + wordToHexValue_temp.substr(wordToHexValue_temp.length - 2, 2);
                    }
                    return wordToHexValue;
                };

                var x = [],
                    k,
                    AA,
                    BB,
                    CC,
                    DD,
                    a,
                    b,
                    c,
                    d,
                    S11 = 7,
                    S12 = 12,
                    S13 = 17,
                    S14 = 22,
                    S21 = 5,
                    S22 = 9,
                    S23 = 14,
                    S24 = 20,
                    S31 = 4,
                    S32 = 11,
                    S33 = 16,
                    S34 = 23,
                    S41 = 6,
                    S42 = 10,
                    S43 = 15,
                    S44 = 21;

                str = mainSelf.utf8_encode(str);
                x = convertToWordArray(str);
                a = 0x67452301;
                b = 0xEFCDAB89;
                c = 0x98BADCFE;
                d = 0x10325476;

                xl = x.length;
                for (k = 0; k < xl; k += 16) {
                    AA = a;
                    BB = b;
                    CC = c;
                    DD = d;
                    a = _FF(a, b, c, d, x[k + 0], S11, 0xD76AA478);
                    d = _FF(d, a, b, c, x[k + 1], S12, 0xE8C7B756);
                    c = _FF(c, d, a, b, x[k + 2], S13, 0x242070DB);
                    b = _FF(b, c, d, a, x[k + 3], S14, 0xC1BDCEEE);
                    a = _FF(a, b, c, d, x[k + 4], S11, 0xF57C0FAF);
                    d = _FF(d, a, b, c, x[k + 5], S12, 0x4787C62A);
                    c = _FF(c, d, a, b, x[k + 6], S13, 0xA8304613);
                    b = _FF(b, c, d, a, x[k + 7], S14, 0xFD469501);
                    a = _FF(a, b, c, d, x[k + 8], S11, 0x698098D8);
                    d = _FF(d, a, b, c, x[k + 9], S12, 0x8B44F7AF);
                    c = _FF(c, d, a, b, x[k + 10], S13, 0xFFFF5BB1);
                    b = _FF(b, c, d, a, x[k + 11], S14, 0x895CD7BE);
                    a = _FF(a, b, c, d, x[k + 12], S11, 0x6B901122);
                    d = _FF(d, a, b, c, x[k + 13], S12, 0xFD987193);
                    c = _FF(c, d, a, b, x[k + 14], S13, 0xA679438E);
                    b = _FF(b, c, d, a, x[k + 15], S14, 0x49B40821);
                    a = _GG(a, b, c, d, x[k + 1], S21, 0xF61E2562);
                    d = _GG(d, a, b, c, x[k + 6], S22, 0xC040B340);
                    c = _GG(c, d, a, b, x[k + 11], S23, 0x265E5A51);
                    b = _GG(b, c, d, a, x[k + 0], S24, 0xE9B6C7AA);
                    a = _GG(a, b, c, d, x[k + 5], S21, 0xD62F105D);
                    d = _GG(d, a, b, c, x[k + 10], S22, 0x2441453);
                    c = _GG(c, d, a, b, x[k + 15], S23, 0xD8A1E681);
                    b = _GG(b, c, d, a, x[k + 4], S24, 0xE7D3FBC8);
                    a = _GG(a, b, c, d, x[k + 9], S21, 0x21E1CDE6);
                    d = _GG(d, a, b, c, x[k + 14], S22, 0xC33707D6);
                    c = _GG(c, d, a, b, x[k + 3], S23, 0xF4D50D87);
                    b = _GG(b, c, d, a, x[k + 8], S24, 0x455A14ED);
                    a = _GG(a, b, c, d, x[k + 13], S21, 0xA9E3E905);
                    d = _GG(d, a, b, c, x[k + 2], S22, 0xFCEFA3F8);
                    c = _GG(c, d, a, b, x[k + 7], S23, 0x676F02D9);
                    b = _GG(b, c, d, a, x[k + 12], S24, 0x8D2A4C8A);
                    a = _HH(a, b, c, d, x[k + 5], S31, 0xFFFA3942);
                    d = _HH(d, a, b, c, x[k + 8], S32, 0x8771F681);
                    c = _HH(c, d, a, b, x[k + 11], S33, 0x6D9D6122);
                    b = _HH(b, c, d, a, x[k + 14], S34, 0xFDE5380C);
                    a = _HH(a, b, c, d, x[k + 1], S31, 0xA4BEEA44);
                    d = _HH(d, a, b, c, x[k + 4], S32, 0x4BDECFA9);
                    c = _HH(c, d, a, b, x[k + 7], S33, 0xF6BB4B60);
                    b = _HH(b, c, d, a, x[k + 10], S34, 0xBEBFBC70);
                    a = _HH(a, b, c, d, x[k + 13], S31, 0x289B7EC6);
                    d = _HH(d, a, b, c, x[k + 0], S32, 0xEAA127FA);
                    c = _HH(c, d, a, b, x[k + 3], S33, 0xD4EF3085);
                    b = _HH(b, c, d, a, x[k + 6], S34, 0x4881D05);
                    a = _HH(a, b, c, d, x[k + 9], S31, 0xD9D4D039);
                    d = _HH(d, a, b, c, x[k + 12], S32, 0xE6DB99E5);
                    c = _HH(c, d, a, b, x[k + 15], S33, 0x1FA27CF8);
                    b = _HH(b, c, d, a, x[k + 2], S34, 0xC4AC5665);
                    a = _II(a, b, c, d, x[k + 0], S41, 0xF4292244);
                    d = _II(d, a, b, c, x[k + 7], S42, 0x432AFF97);
                    c = _II(c, d, a, b, x[k + 14], S43, 0xAB9423A7);
                    b = _II(b, c, d, a, x[k + 5], S44, 0xFC93A039);
                    a = _II(a, b, c, d, x[k + 12], S41, 0x655B59C3);
                    d = _II(d, a, b, c, x[k + 3], S42, 0x8F0CCC92);
                    c = _II(c, d, a, b, x[k + 10], S43, 0xFFEFF47D);
                    b = _II(b, c, d, a, x[k + 1], S44, 0x85845DD1);
                    a = _II(a, b, c, d, x[k + 8], S41, 0x6FA87E4F);
                    d = _II(d, a, b, c, x[k + 15], S42, 0xFE2CE6E0);
                    c = _II(c, d, a, b, x[k + 6], S43, 0xA3014314);
                    b = _II(b, c, d, a, x[k + 13], S44, 0x4E0811A1);
                    a = _II(a, b, c, d, x[k + 4], S41, 0xF7537E82);
                    d = _II(d, a, b, c, x[k + 11], S42, 0xBD3AF235);
                    c = _II(c, d, a, b, x[k + 2], S43, 0x2AD7D2BB);
                    b = _II(b, c, d, a, x[k + 9], S44, 0xEB86D391);
                    a = addUnsigned(a, AA);
                    b = addUnsigned(b, BB);
                    c = addUnsigned(c, CC);
                    d = addUnsigned(d, DD);
                }

                var temp = wordToHex(a) + wordToHex(b) + wordToHex(c) + wordToHex(d);

                return temp.toLowerCase();
            };

            mainSelf.IsJsonString = function(str) {
                try {
                    JSON.parse(str);
                } catch (e) {
                    return false;
                }
                return true;
            };

            mainSelf.transRequest = function(data, headers) {
                // Normaliser le request
                if (mainSelf.IsUndefinedOrNull(data))
                    return null;
               // headers = { 'Content-Type': 'application/x-www-form-urlencoded' };
                // Récupérer l'id de l'utilisateur en cours
                var user = window.sessionStorage["currentUser"];
                headers = { 'Content-Type': 'application/x-www-form-urlencoded' };
                if (!mainSelf.IsUndefinedOrNull(user)) {

                    user = JSON.parse(user);

                    // renseigner les informations générales pour une requète 
                    if (data.request) {
                        data.request.IdCurrentTenant = user.tenantId;
                        data.request.IdCurrentUser = user.id;
                        data.request.CurrentUserToken = user.token;
                    } else {
                        data.IdCurrentTenant = user.tenantId;
                        data.IdCurrentUser = user.id;
                        data.CurrentUserToken = user.token;
                    }
                } else {
                    // Interrompre l'opération
                }

                /*if (data.request) {
                    if (mainSelf.IsUndefinedOrNull(data.request.CanFilterByStruct))
                        data.request.CanFilterByStruct = true;
                } else {
                    if (mainSelf.IsUndefinedOrNull(data.CanFilterByStruct))
                        data.CanFilterByStruct = true;
                }*/

                // Vérifier qu'on veut faire un enregistrement
                if ((!mainSelf.IsUndefinedOrNull(data.request) && !mainSelf.IsUndefinedOrNull(data.request.ItemsToSave)) || (!mainSelf.IsUndefinedOrNull(data) && !mainSelf.IsUndefinedOrNull(data.ItemsToSave))) {

                }

                // Vérifier qu'on veut faire une recherche.
                if ((!mainSelf.IsUndefinedOrNull(data) && (!mainSelf.IsUndefinedOrNull(data.ItemToSearch) || !mainSelf.IsUndefinedOrNull(data.ItemsToSearch))) || (!mainSelf.IsUndefinedOrNull(data.request) && (!mainSelf.IsUndefinedOrNull(data.request.ItemToSearch) || !mainSelf.IsUndefinedOrNull(data.request.ItemsToSearch)))) {
                    var itemsToSearch = [];

                    if (data.ItemToSearch)
                        itemsToSearch.push(angular.copy(data.ItemToSearch));
                    else if (data.request && data.request.ItemToSearch)
                        itemsToSearch.push(angular.copy(data.request.ItemToSearch));

                    if (data.ItemsToSearch) {
                        for (var i = 0; i < data.ItemsToSearch.length; i++) {
                            itemsToSearch.push(angular.copy(data.ItemsToSearch[i]));
                        }
                    } else if (data.request && data.request.ItemsToSearch) {
                        for (var i = 0; i < data.request.ItemsToSearch.length; i++) {
                            itemsToSearch.push(angular.copy(data.request.ItemsToSearch[i]));
                        }
                    }

                    for (var j = 0; j < itemsToSearch.length; j++) {
                        var item = itemsToSearch[j];

                        for (var key in item) {
                            if (!item.hasOwnProperty(key)) {
                                continue;
                            }

                            var infoSearchKey = key.indexOf('InfoSearch') === -1 ? 'InfoSearch' + key : key;
                            var infoSearch = item[infoSearchKey] || {};

                            //verifier si la proprieté a une valeur et la considérer
                            if (key.indexOf('InfoSearch') !== 0 && item[key] !== undefined)
                                infoSearch.Consider = true;

                            if ((item[key] === undefined && infoSearch.Intervalle == undefined) || infoSearch.IsOrderByField == true || infoSearch.IsSumField == true) {
                                // Ne pas considérer la propriété dans la recherche
                                infoSearch.Consider = (infoSearch.Consider !== undefined) ? infoSearch.Consider : false;
                            } else {
                                // Considérer la propriété dans la recherche
                                infoSearch.Consider = true;
                            }

                            item[infoSearchKey] = infoSearch;
                        }
                    }

                    if (data.ItemToSearch)
                        data.ItemToSearch = itemsToSearch[0];
                    else if (data.request && data.request.ItemToSearch)
                        data.request.ItemToSearch = itemsToSearch[0];

                    if (data.ItemsToSearch) {
                        if (data.ItemToSearch) {
                            itemsToSearch.splice(0, 1); // retirer le premier élément
                            data.ItemsToSearch = itemsToSearch;
                        } else {
                            data.ItemsToSearch = itemsToSearch;
                        }
                    } else if (data.request && data.request.ItemsToSearch) {
                        if (data.request.ItemToSearch) {
                            itemsToSearch.splice(0, 1); // retirer le premier élément
                            data.request.ItemsToSearch = itemsToSearch;
                        } else {
                            data.request.ItemsToSearch = itemsToSearch;
                        }
                    }
                }

                return data;
            };

            mainSelf.transResponse = function(data, headers) {
                // Normaliser le response

                if (mainSelf.IsUndefinedOrNull(data))
                    return null;

                // vérifier que data est de type Json - condition non vérifiée au chargement de l'application (data = contenu html page login)
                if (!mainSelf.IsJsonString(data))
                    return data;

                var dataParsed = JSON.parse(data);
                // Déterminer dynamiquement le champ des résultats
                var idResponse = null;

                var dataUsed = {};
                for (var id in dataParsed) {
                    var position = id.lastIndexOf("Result");

                    /* vérifier que le mot Result est en dernière position */
                    if (position != -1 && id.length == position + 6) {
                        idResponse = id;
                        break;
                    }
                }

                var result = idResponse == null ? angular.copy(dataParsed) : dataParsed[idResponse];
                //var result = angular.copy(dataParsed);
                var response = null;
                if (result != null) {
                    for (var id1 in result) {
                        // regrouper les données utiles dans un object
                        if (id1 === "IndexDebut" || id1 === "IndexFin" || id1 === "Count" || id1 === "Message" || id1 === "HasError")
                            continue;

                        dataUsed[id1] = result[id1];
                    }

                    response = new mainSelf.ResponseSw(dataUsed, result.IndexDebut, result.IndexFin, result.Count, result.Message, result.HasError);
                } else {
                    response = new mainSelf.ResponseSw(null, 0, 0, 0, "Une erreur s'est produite!", true);
                }

                response.WebServiceName = idResponse;

                return response;
            };

            //mainSelf.transResponse = function (data, headers) {
            //    // Normaliser le response

            //    if (mainSelf.IsUndefinedOrNull(data))
            //        return null;

            //    // vérifier que data est de type Json - condition non vérifiée au chargement de l'application (data = contenu html page login)
            //    if (!mainSelf.IsJsonString(data))
            //        return data;

            //    var dataParsed = JSON.parse(data);
            //    // Déterminer dynamiquement le champ des résultats
            //    var idResponse = null;

            //    var dataUsed = {};
            //    for (var id in dataParsed) {
            //        var position = id.lastIndexOf("Result");

            //        /* vérifier que le mot Result est en dernière position */
            //        if (position != -1 && id.length == position + 6) {
            //            idResponse = id;
            //            break;
            //        }
            //    }

            //    var result = idResponse == null ? null : dataParsed[idResponse];
            //    var response = null;
            //    if (result != null) {
            //        for (var id1 in result) {
            //            // regrouper les données utiles dans un object
            //            if (id1 == "IndexDebut" || id1 == "IndexFin" || id1 == "Count" || id1 == "Message" || id1 == "HasError")
            //                continue;

            //            dataUsed[id1] = result[id1];
            //        }

            //        response = new mainSelf.ResponseSw(dataUsed, result.IndexDebut, result.IndexFin, result.Count, result.Message, result.HasError);
            //    }
            //    else {
            //        response = new mainSelf.ResponseSw(null, 0, 0, 0, "Une erreur s'est produite!", true);
            //    }

            //    response.WebServiceName = idResponse;

            //    return response;
            //};

            mainSelf.ShowMessage = function(titre, message, imageLinked, type) {
                //pinesNotifications.notify({
                //    // (string | mandatory) the heading of the notification
                //    title: titre,
                //    // (string | mandatory) the text inside the notification
                //    text: message,
                //    // (string | optional) the image to display on the left
                //    image: imageLinked,
                //    // (bool | optional) if you want it to fade out on its own or just sit there
                //    sticky: false,
                //    // (int | optional) the time you want it to be alive for before fading out
                //    time: "",
                //    type: type || 'success'
                //});
                $.gritter.add({
                    // (string | mandatory) the heading of the notification
                    title: titre,
                    // (string | mandatory) the text inside the notification
                    text: message,
                    // (string | optional) the image to display on the left
                    image: imageLinked,
                    // (bool | optional) if you want it to fade out on its own or just sit there
                    sticky: false,
                    // (int | optional) the time you want it to be alive for before fading out
                    time: ""
                });

                return false;
            };

            mainSelf.clone = function(srcInstance) {

                //var copy = null;

                //try {
                //    copy = JSON.parse(JSON.stringify(obj));
                //} catch(ex) {
                //    alert("SVP, Utilisez un navigateur IE > 7 pour la bonne exécution du programme!");
                //}

                //return copy;

                /*Si l'instance source n'est pas un objet ou qu'elle ne vaut rien c'est une feuille donc on la retourne*/
                if (typeof (srcInstance) != "object" || srcInstance == null) {
                    return srcInstance;
                }

                /*On appel le constructeur de l'instance source pour crée une nouvelle instance de la même classe*/
                var newInstance = new srcInstance.constructor();
                /*On parcourt les propriétés de l'objet et on les recopies dans la nouvelle instance*/
                for (var i in srcInstance) {
                    newInstance[i] = mainSelf.clone(srcInstance[i]);
                }
                /*On retourne la nouvelle instance*/
                return newInstance;
            };
            // fin définition


            mainSelf.ToArray = function(objClass, arrayToConvert) {
                if (mainSelf.IsUndefinedOrNull(arrayToConvert) || mainSelf.IsUndefinedOrNull(objClass))
                    return [];
                var arrayResponse = new Array();
                try {
                    for (var i = 0; i < arrayToConvert.length; i++) {
                        var item = new objClass(arrayToConvert[i]);
                        arrayResponse.push(item);
                    }
                } catch (e) {
                    //console.log(e.message);
                }
                ////console.log(arrayResponse);
                return arrayResponse;
            };

            mainSelf.getExtension = function(filename) {
                var parts = filename.split(".");
                return (parts[(parts.length - 1)]);
            };

            // vérifie l'extension d'un fichier uploadé
            // champ : id du champ type file
            // listeExt : liste des extensions autorisées
            mainSelf.verifFileExtension = function(fileName, listeExt) {
                var fileExt = mainSelf.getExtension(fileName);
                for (var i = 0; i < listeExt.length; i++) {
                    if (fileExt == listeExt[i]) {

                        return (true);
                    }
                }

                return (false);
            };

            //#region modal
            //mainSelf.ShowError = function(msg) {
            //    $dialogs.error(msg);
            //}

            //mainSelf.ShowAlert = function(msg, title) {
            //    dialogs.notify(title, msg);
            //};

            //mainSelf.Confirm = function (msg, title) {

            //    var response = false;
            //    var dlg = dialogs.confirm(title, msg);
            //    dlg.result.then(function() {
            //        response = true;
            //    }, function() {
            //        response = false;
            //    });

            //    return response;
            //}

            //#endregion

            //mainSelf.displayReport = function(reportName, parameters) {

            //    if (mainSelf.IsUndefinedOrNull(parameters) || mainSelf.IsUndefinedOrNull(reportName))
            //        return;

            //    //var baseUrl = "http://-dev-3/ReportServer_MSSQLSERVER/Pages/ReportViewer.aspx?%2fEVALUATION_SGI_REPORT%2f";
            //    //var baseUrl = "http://localhost/Reports/Pages/ReportViewer.aspx?%2fEVALUATION_SGI_REPORT%2f";
            //    //var baseUrl = "http://-dev-0947:8070/Reports/Pages/Report.aspx?ItemPath=%2fEVALUATION_ERP_V3%2f";

            //    var baseUrl = "http://localhost:8070/ReportServer/Pages/ReportViewer.aspx?%2fEVALUATION_ERP_v3%2f";

            //    var url = baseUrl + reportName + "&rs:Command=Render&" + parameters;

            //    window.open(url);

            //};
            
            mainSelf.downloadFile = function (file, fileName) {
                if (mainSelf.IsUndefinedOrNull(file))
                    return;
                var link = document.createElement("a");
                link.download = !mainSelf.IsUndefinedOrNull(fileName) ? fileName : 'fichier';
                link.href = file;
                link.click();
            };

            // entrée date (Coordinated Universal Time) - resultat en format yyyy/mm/dd
            // à utiliser pour les formats de date en html5
            mainSelf.dateToFormatDDMMYYYY = function (value) {
                if (mainSelf.IsUndefinedOrNull(value))
                    return null;

                var valueInDate = (new Date(value));
                var d = valueInDate.getDate();
                var m = (valueInDate.getMonth() + 1).toString();
                if (m.length == 1)
                    m = "0" + m;
                var y = valueInDate.getFullYear();
                return d + "/" + m + "/" + y;

                //return (new Date(value)).getDate();
            };

            // format millier
            mainSelf.format = function (valeur, decimal, separateur) {
                // formate un chiffre avec 'decimal' chiffres après la virgule et un separateur
                var deci = Math.round(Math.pow(10, decimal) * (Math.abs(valeur) - Math.floor(Math.abs(valeur))));
                var val = Math.floor(Math.abs(valeur));
                if ((decimal === 0) || (deci === Math.pow(10, decimal))) { val = Math.floor(Math.abs(valeur.trim().replace(" ", ""))); deci = 0; }
                var val_format = val + "";
                var nb = val_format.length;
                for (var i = 1; i < 4; i++) {
                    if (val >= Math.pow(10, (3 * i))) {
                        val_format = val_format.substring(0, nb - (3 * i)) + separateur + val_format.substring(nb - (3 * i));
                    }
                }
                if (decimal > 0) {
                    var decim = "";
                    for (var j = 0; j < (decimal - deci.toString().length) ; j++) { decim += "0"; }
                    deci = decim + deci.toString();
                    val_format = val_format + "." + deci;
                }
                if (parseFloat(valeur) < 0) { val_format = "-" + val_format; }
                return val_format;
            };

            mainSelf.formatageMillier = function (nombre, decimal, elementId) {
                var separateur = " ";
                var deci = decimal;
                var input = document.getElementById(elementId); //"nombre_format"
                var nombreAfficher = mainSelf.format(nombre, deci, separateur);
                if (nombreAfficher === "NaN") nombreAfficher = 0;
                input.value = nombreAfficher;
            }

            mainSelf.formatMonetaire = function (nombre, elementId) {
                var input = document.getElementById(elementId); //"nombre_format"
                input.value = nombre.toLocaleString();
                
            }

        }
    ]);
});