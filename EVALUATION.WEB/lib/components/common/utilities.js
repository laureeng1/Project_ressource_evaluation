"use strict";

var domPolymer = null;

//var DEFAULT_VALUE_PROPERTY_POLYMER_INEXA = "Néant"; // pour rendre le nom de la variable unique
var DEFAULT_VALUE_PROPERTY_POLYMER_INEXA = ""; // pour rendre le nom de la variable unique

var Utilities = {
    getRandomColor: function (type) {
        var color = "";
        switch (type) {
            case "rgba":
                color =
                    Math.floor(Math.random() * 256) + "," +
                    Math.floor(Math.random() * 256) + "," +
                    Math.floor(Math.random() * 256);
                break;
            default:
                color = "#" + Math.random().toString(16).substring(4);
        }
        return color;
    },
    GetPropertyValueOfObject: function (obj, urlProperty) {
        var url = urlProperty || "";

        if (url === "")
            return defaultValue;

        var propertiesName = url.split(".");
        var value = obj;
        for (var i = 0; i < propertiesName.length; i++) {

            var propName = propertiesName[i];
            value = (value[propName] == null || value[propName] == undefined) ? DEFAULT_VALUE_PROPERTY_POLYMER_INEXA : value[propName];
        }

        if (typeof value == "boolean")
            value = (value === true) ? "Oui" : "Non";

        return value;
    },
    textToImage: function(text) {
        if (text === DEFAULT_VALUE_PROPERTY_POLYMER_INEXA)
            return null;

        return text;
    },
    IsUndefinedOrNull: function (object) {
        return object == null || object === "undefined";
    },
    formatUTCDate: function (d1) {
        //var str = Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds(), 0);
        var d = new Date(d1);
        var str = Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds(), 0);
        return str;
    },
    jsonToDate: function (value, format) {
        if (this.IsUndefinedOrNull(value))
            return null;

        var valueInDate = (new Date(parseInt(value.substr(6))));
        var d = valueInDate.getDate();
        var m = (valueInDate.getMonth() + 1).toString();
        if (m.length === 1)
            m = "0" + m;
        var y = valueInDate.getFullYear();
        return d + "/" + m + "/" + y;
    },
    dateToJson: function (input) {
        if (this.IsUndefinedOrNull(input))
            return null;

        return "\/Date(" + (this.formatUTCDate(input)) + ")\/";
    },
    formatMillier: function (nombre) {
        nombre += "";
        var sep = " ";
        var reg = /(\d+)(\d{3})/;

        while (reg.test(nombre)) {
            nombre = nombre.replace(reg, "$1" + sep + "$2");
        }

        return nombre;
    },
    formatMillierRec: function (nombre) {
        nombre += "";
        var reg = new RegExp("\\ ", "g");
        nombre = nombre.trim().replace(reg, "");

        return nombre;
    },
    clone: function (srcInstance) {

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
            newInstance[i] = this.clone(srcInstance[i]);
        }
        /*On retourne la nouvelle instance*/
        return newInstance;
    },
    PreventDomPolymer: function (component, eventName) {
        if (this.IsUndefinedOrNull(component))
            return null;

        /*switch (eventName) {
            case 'loaded':
                break;
            case 'removed':
                break;
            default:
                // do nothing
                break;
        }*/

        if (component.name == undefined || component.name == null) {
            var componentName = null;
            var componentType = component.nodeName.toLowerCase();

            for (var i = 0; i < component.attributes.length; i++) {
                var attr = component.attributes[i];
                if (attr.nodeName == "id") {
                    componentName = attr.value;
                    break;
                }
            }

            if (componentName == null)
                componentName = componentType;

            component.name = componentName;
        }

        if (this.IsUndefinedOrNull(domPolymer)) {
            document.addEventListener("polymer-elements-are-initialized", function (e) {
                //domPolymer.asyncFire('core-signal', { name: 'do-action', data: { componentName: component.name, eventName: eventName } });
                Utilities.fireDomPolymer(component.name, eventName);
            });
        } else {
            //domPolymer.asyncFire('core-signal', { name: 'do-action', data: { componentName: component.name, eventName: eventName } });
            Utilities.fireDomPolymer(component.name, eventName);
        }

        return component.name;
    },
    fireDomPolymer: function (componentName, eventName) {
        switch (eventName) {
            case "loaded":
                domPolymer.doLoaded(componentName, eventName);
                break;
            case "removed":
                domPolymer.doRemoved(componentName, eventName);
                break;
            default:
                // do nothing
                break;
        }
    }
}