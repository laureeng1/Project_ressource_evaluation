'use strict';

/* Search input */

/* properties of element of searchOptions : fieldResult; fieldSearch; label; isCriteria; type */

(function () {

    var generatePlaceholderText = function(label) {
        return "Rechercher par " + label;
    };
    
    Polymer('search-input-core', {
        created: function () {
            this.criteriasName = this.criteriasName || [];
            this.propertiesShowed = this.propertiesShowed || [];
            this.searchOptions = this.searchOptions || [];

            this.criteriaNameSelected = this.criteriaNameSelected || {};
            this.criteriaNameSelected.label = 'Critère';
            this.placeHolderSearchInput = '';
            this.searchInputValue = undefined;
            this.isDetailsHidden = true;
            this.results = this.results || [];
            this.doSearch = true;
            this.isDeleteTextHidden = true;
            this.isMonoCriteria = false;
            this.currentItem = null;
            this.isInitialing = true;
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
        criteriasNameChanged: function (oldValue, newValue) {
            if (newValue.length > 0) {
                var hasDefaultFieldSearch = false;
                for (var i = 0; i < newValue.length; i++) {
                    if (newValue[i].defaultFieldSearch) {
                        this.criteriaNameSelected = newValue[i];
                        hasDefaultFieldSearch = true;
                        break;
                    }
                }
                if (!hasDefaultFieldSearch)
                    this.criteriaNameSelected = newValue[0];
					
				this.placeholder = generatePlaceholderText(this.criteriaNameSelected.label);
            }
        },
        selectCurrentCriteria: function (event, detail, sender) {
            this.criteriaNameSelected = event.target.templateInstance.model.criteria;

            //this.doSearch = false;
            this.placeholder = generatePlaceholderText(this.criteriaNameSelected.label);
            this.searchInputValue = undefined;
        },
        searchInputValueChanged: function (oldValue, newValue) {
            this.isDeleteTextHidden = (newValue == '' || newValue == null);

            if (this.isInitialing)
                return;

            this.job('job1', function () {
                this.fire('done');

                if (this.doSearch == true) {
                    this.fire('search-is-launched-core', { msg: { searchWord: newValue, criteriaName: this.criteriaNameSelected } });
                } else {
                    this.doSearch = true;
                }
            }, 500);
        },
        resultsChanged: function (oldValue, newValue) {
            this.isDetailsHidden = (newValue == null || newValue.length == 0);
        },
        rowSelected: function (e, detail, sender) {

            this.isInitialing = true;

            this.setCurrentItem(e.target.templateInstance.model.item);

            this.isInitialing = false;
        },
        setCurrentItem: function (item, autoLoading) {
            autoLoading = Utilities.IsUndefinedOrNull(autoLoading) ? true : autoLoading;
            
            this.isDetailsHidden = true;

            this.currentItem = item;

            this.doSearch = false;
            this.searchInputValue = this.currentItem[this.criteriaNameSelected.fieldResult];
            this.isDeleteTextHidden = false;
            
            if (autoLoading) {
                this.fire('item-selected-core', { msg: { item: this.currentItem } });
            }            
        },        
        searchOptionsChanged: function (oldValue, newValue) {

            this.isInitialing = true;

            if (newValue.length > 0) {
                var criterias = [];
                var properties = [];

                for (var i = 0; i < newValue.length; i++) {
                    var option = newValue[i];

                    if (option.isCriteria == true) {
                        criterias.push(option);
                    }

                    if (option.isValueShown == true) {
                        properties.push(option);
                    }
                }

                this.isMonoCriteria = criterias.length == 1;// && (criterias[0].label == "" || criterias[0].label == null);
                this.criteriasName = criterias;
                this.propertiesShowed = properties;
                
                //if(criterias.length > 0)
                //    this.placeholder = generatePlaceholderText(criterias[0].label);
            }

            this.isInitialing = false;
        },
        focusLost: function (event, detail, sender) {
            this.searchInputValue = undefined;
        },
        textDeleteClicked: function (event, detail, sender) {
            this.searchInputValue = undefined;
        },
        initSearchInput: function () {
            this.searchInputValue = undefined;
            this.isDetailsHidden = true;
        },
        reset: function() {
            this.initSearchInput();
        }
    });
})();