'use strict';

/* Search input */

/* properties of element of searchOptions : fieldResult; fieldSearch; label; isCriteria; type */

(function () {

    var generatePlaceholderText = function (label) {
        return "Rechercher par " + label;
    };

    var DEFAULT_MAX_SIZE = 10;
    var id = -1;
    var ADDICON = "add";
    var MODIFYICON = "create";
    var PREFIX = "SEARCH-INPUT";
    Polymer('search-input', {
        publish: {
            disabled: {
                value: false,
                reflect: true
            }
        },
        created: function () {

            this.criteriasName = this.criteriasName || [];
            this.propertiesShowed = this.propertiesShowed || [];
            
            this.searchOptions = {
                sizeItemsToSearchMax: DEFAULT_MAX_SIZE,
                enabledAddNewItem: false,
                enabledAdvancedSearch: false,
                columns: []
            };

            this.criteriaNameSelected = this.criteriaNameSelected || {};
            this.criteriaNameSelected.label = 'Critère';
            this.placeHolderSearchInput = '';
            this.searchInputValue = undefined;
            this.isDetailsHidden = true;
            this.results = this.results || [];
            this.resultsToDisplay = this.resultsToDisplay || [];
            this.doSearch = true;
            this.isDeleteTextHidden = true;
            this.isMonoCriteria = false;
            this.currentItem = null;
            this.isInitialing = true;
            this.nbTotalItems = 0;
            this.advancedItemSelected = false;
            this.isDropDownVisible = false;
            this.iconSave = ADDICON;
            id++;
            
            this.idInstance = PREFIX + String(id + 1);           
        },
        ready: function () {

        },
        domReady: function () {
            
        },
        attached: function () {
            Utilities.PreventDomPolymer(this, 'loaded');                        
        },
        detached: function () {
            Utilities.PreventDomPolymer(this, 'removed');
        },
        showDropDown: function(event, detail, sender){
            this.isDropDownVisible = true;
        },
        dropDownFocusLost: function (event, detail, sender)
        {
            this.job('job4', function () {
                this.fire('done');

                this.isDropDownVisible = false;
            }, 500);            
        },
        criteriasNameChanged: function (oldValue, newValue) {
            if (newValue.length > 0) {
                this.criteriaNameSelected = newValue[0];
            }
        },
        selectCurrentCriteria: function (event, detail, sender) {           
            
            this.criteriaNameSelected = event.target.templateInstance.model.criteria;

            //this.doSearch = false;
            this.placeholder = generatePlaceholderText(this.criteriaNameSelected.label);
            this.searchInputValue = undefined;
            this.isDropDownVisible = false;
        },
        searchInputValueChanged: function (oldValue, newValue) {
                        
            this.isDeleteTextHidden = (newValue == '' || newValue == null);
                
            if (this.isInitialing)
                return;

            this.job('job1', function () {
                this.fire('done');

                if (this.doSearch == true) {
                    if (this.isDeleteTextHidden) {
                        /* Ne pas initier une recherche si chaine vide */
                        this.initSearchInput();
                        return;
                    } 

                    this.fire('search-is-launched', { msg: { searchWord: newValue, criteriaName: this.criteriaNameSelected, idInstance: this.idInstance } });
                } else {
                    this.doSearch = true;
                }
            }, 500);
        },
        resultsChanged: function (oldValue, newValue) {

            if (!Array.isArray(newValue))
                return;

            this.isDetailsHidden = ((newValue == null || newValue.length == 0) && (!this.searchOptions.enabledAdvancedSearch && !this.searchOptions.enabledAddNewItem))
                                    || (!(this.searchOptions.enabledAdvancedSearch || this.searchOptions.enabledAddNewItem) && this.results.length == 0);

            var resultsToDisplay = [];
            for (var i = 0; i < this.searchOptions.sizeItemsToSearchMax; i++) {

                if (i + 1 > this.results.length)
                    break;
                
                resultsToDisplay.push(this.results[i]);
            }

            this.resultsToDisplay = resultsToDisplay;
        },
        rowSelected: function (e, detail, sender) {           
            
            this.isInitialing = true;
            this.setCurrentItem(e.target.templateInstance.model.item);         
            this.isInitialing = false;
        },
        setCurrentItem: function(item) {
            this.isDetailsHidden = true;

            this.currentItem = item;

            this.doSearch = false;
            this.searchInputValue = this.currentItem[this.criteriaNameSelected.fieldResult];
            this.isDeleteTextHidden = false;
            this.iconSave = MODIFYICON;
            this.fire('item-selected', { msg: { item: this.currentItem, idInstance: this.idInstance } });
        },
        searchOptionsChanged: function (oldValue, newValue) {

            if (newValue == "")
                return;
            
            this.isInitialing = true;

            if (Array.isArray(newValue)) {
                
                // modèle config 1
                var newValue1 = {};
                newValue1.columns = Utilities.clone(newValue);
                this.searchOptions = newValue1;
                return;
            } else {
                
                // modèle config 2
                //newValue = Utilities.clone(newValue);
            }

            if (newValue.sizeItemsToSearchMax == undefined) {
                newValue.sizeItemsToSearchMax = DEFAULT_MAX_SIZE;
            }
            
            if (newValue.displayLabel == undefined) {
                newValue.displayLabel = true;
            }
            
            if (newValue.enabledAddNewItem == undefined) {
                newValue.enabledAddNewItem = false;
            }
            
            if (newValue.enabledAdvancedSearch == undefined) {
                newValue.enabledAdvancedSearch = false;
            }
            
            var columns = newValue.columns;
            
            if (columns.length > 0) {
                var criterias = [];
                var properties = [];

                for (var i = 0; i < columns.length; i++) {
                    var option = columns[i];

                    if (option.isCriteria == true) {
                        criterias.push(option);
                    }

                    if (option.isValueShown == true) {
                        properties.push(option);
                    }
                }

                this.isMonoCriteria = criterias.length == 1 && !criterias[0].displayLabel;
                this.criteriasName = criterias;
                this.propertiesShowed = properties;

                if (criterias.length > 0)
                    this.placeholder = generatePlaceholderText(criterias[0].label);
            }
            
            /* Configuration du tableaux détails */            
            var advanceTable = this.$.advancedTable;

            var columnsTable = [];
            for (var j = 0; j < this.searchOptions.columns.length; j++) {

                var colOfSi = this.searchOptions.columns[j];

                var col = {
                    title: colOfSi.label,
                    fieldSearch: colOfSi.fieldSearch,
                    fieldResult: colOfSi.fieldResult,
                    defaultFieldSearch: true,
                    isCriteria: colOfSi.isCriteria,
                    defaultSort: true,
                    type: colOfSi.type,
                    visible: colOfSi.isValueShown                    
                };

                columnsTable.push(col);
            }

            advanceTable.tableOptions = {
                tableIsSimple: true,
                tableIsBasic: false,
                enableColModify: false,
                enableColDelete: false,
                paginationParams: {
                    perPage: 5,
                    currentPage: 1
                },
                columns: columnsTable
            };
            
            /* Fin configuration détails */

            this.isInitialing = false;
        },
        focusLost: function (event, detail, sender) {

            if (this.isInitialing)
                return;

            if (this.currentItem == null || !this.isDetailsHidden) {
                this.searchInputValue = undefined;
                this.currentItem = null;
            }                
        },
        textDeleteClicked: function (event, detail, sender) {
            this.reset();            
        },
        initSearchInput: function () {
            this.searchInputValue = undefined;
            this.isDetailsHidden = true;
            this.iconSave = ADDICON;            

            this.fire('remove-current-item', { msg: { item: this.currentItem, idInstance: this.idInstance } });

            this.currentItem = null;
        },
        showAllResults: function (event, detail, sender) {           
            this.isDetailsHidden = true;
            this.$.dialogDetails.toggle();
        },
        searchAdvanced: function (event, detail, sender) {
            this.fire('search-is-launched-advanced', { msg: event.detail.msg });
        },
        factorRequest: function(obj, criteriasName) {
            var advancedTable = this.$.advancedTable;
            return advancedTable.factorRequest(obj, criteriasName);
        },
        setItemsAdvanced: function (data, countTotal) {
            var advancedTable = this.$.advancedTable;
            return advancedTable.setItems(data, countTotal);
        },
        setItems: function (data, countTotal) {
            this.results = data;
            this.nbTotalItems = countTotal;
        },
        setAdvancedItemSelected: function (event, detail, sender) {
            
            this.isInitialing = true;
            var advancedTable = this.$.advancedTable;

            var selectedItems = advancedTable.GetItemsSelected();            
            var item = selectedItems[0];           
            this.setCurrentItem(item);            
            
            advancedTable.reset();
            this.advancedItemSelected = false;

            // attendre un peu pour la fin de l'initialisation
            var self = this;
            this.job('job2', function () {
                this.fire('done');

                self.isInitialing = false;
               
            }, 500);            
        },
        doAdvancedItemSelected: function(event, detail, sender) {
            this.advancedItemSelected = true;
        },
        createNewItem: function (event, detail, sender) {

            this.job('job3', function () {
                this.fire('done');

                if (this.iconSave == ADDICON) {
                    this.fire('create-new-item', { msg: { idInstance: this.idInstance } });
                } else {
                    this.fire('modify-current-item', { msg: { item: this.currentItem, idInstance: this.idInstance } });
                }
            }, 500);
            
        },
        reset: function() {
            this.initSearchInput();
        },
        getCurrentItem: function () {
            return Utilities.clone(this.currentItem);
        },
        getPropertyValue: function (value, propertyName) {
            return Utilities.GetPropertyValueOfObject(value, propertyName);
        },
        textToImage: function(value) {
            return Utilities.textToImage(value);
        },
        jsonToDate: function (input, format) {
            return Utilities.jsonToDate(input, format);
        },
        toDate: function (input, format) {

            var dateJson = "\/Date(" + (Utilities.formatUTCDate(input)) + ")\/";
            return Utilities.jsonToDate(dateJson, format);
        }
    });
})();