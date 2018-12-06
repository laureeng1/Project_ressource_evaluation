'use strict';

/* Advanced table */

/* properties of element of Advanced table : tableOptions; data; */

(function() {
    var REAL_TIME_PERIOD_TOLERANCE = 15; // 15 secondes de latence
    var imageUrlOpen = null;
    var imageUrlClose = null;
    var PREFIX = "ADVANCED-TABLE";
    var idRow = -1;
    var columnsInitCount = 5;
    var searchParamsInit = {
        criterias: [],
        paginationParams: { positionDebut: 0 }
    };

    var adaptItem = function(item) {
        item.imageUrl = imageUrlOpen;
        item.isDetailsVisible = false;
        item.selected = false;
    };

    var closeDetails = function(item) {
        item.imageUrl = imageUrlOpen;
        item.isDetailsVisible = false;
    };

    var openDetails = function(item) {
        item.imageUrl = imageUrlClose;
        item.isDetailsVisible = true;
    };

    var getInfoSearch = function (field) {
        return "InfoSearch" + field;
    }

    var faSortAsc = null;
    var faSortDesc = null;

    Polymer('advanced-table', {
        created: function() {
            imageUrlOpen = this.resolvePath("images/details_open.png");
            imageUrlClose = this.resolvePath("images/details_close.png");
            faSortAsc = "fa fa-sort-asc";
            faSortDesc = "fa fa-sort-desc";
            this.urlIconSearch = this.resolvePath("images/icon_rech.png");
            this.isSearchBarHidden = true;
            this.perPages = [5, 10, 25, 50, 100];
            this.sortColumn = '';
            this.IsRefreshing = false;
            this.itemSelected = null;
            this.backgroundColor = 'white';
            this.columnsCount = columnsInitCount;
            this.propIsKey = null;
            this.itemsSelected = [];
            this.autoLoading = true;
            idRow++;

            this.idInstance = PREFIX + String(idRow + 1);

            this.searchParamsSelected = Utilities.clone(searchParamsInit);
            this.isAlreadyLoaded = false;

            this.tableOptions = {
                showIDColumn: true,
                tableIsSimple: false,
                tableIsBasic: false,
                showHeader: true,
                showFooter: true,
                sortDescending: true,
                enableColModify: false,
                enableColDelete: false,
                enableColVisualize: false,
                multiChecked: false,
                showCountSelector: false,
                isRealTime: false,
                realTimePeriod: 0,
                paginationParams: {
                    perPage: 5,
                    currentPage: 1,
                    count: 0
                },
                columns: []
            };

            this.paramsSearchInput = [];

            this.data = [];

            this.orderByParams = {              

                sortOrder: "Descending",
                orderByField: "",
                infoSearchField: "",
                isDefaultOrderByField: false
            }

            this.sumFields = [];

            this.sumData = {};
        },
        ready: function() {
            this.pagination = this.$.pagination;
        },
        attached: function() {
            //alert(this.name + " attached");

            /*this.job('job-attached-adv', function () {
                this.fire('done');

                Utilities.PreventDomPolymer(this, 'loaded');
            }, 500);*/

            Utilities.PreventDomPolymer(this, 'loaded');
        },
        detached: function() {

            //alert(this.name + " detached");
            Utilities.PreventDomPolymer(this, 'removed');
            this.stopRealTimeMode();
        },
        hideSearchBar: function() {
            this.isSearchBarHidden = !this.isSearchBarHidden;

            if (this.isSearchBarHidden) {
                for (var i = 0; i < this.searchParamsSelected.criterias.length; i++) {
                    var col = this.searchParamsSelected.criterias[i];
                    if (col.isCriteria) {
                        col.fieldSearchValue = undefined;
                    }
                }

                if (this.searchParamsSelected.criterias.length > 0)
                    this.loadItems(this.searchParamsSelected);
            }
        },
        dataChanged: function(oldValue, newValue) {
            if (this.data instanceof Array) {
                var itemSelectedCopie = null;

                for (var i = 0; i < this.data.length; i++) {
                    this.data[i].idRow = i;
                    adaptItem(this.data[i]);

                    if (!Utilities.IsUndefinedOrNull(this.propIsKey) && !Utilities.IsUndefinedOrNull(this.itemSelected) && (this.itemSelected[this.propIsKey.fieldResult] == this.data[i][this.propIsKey.fieldResult]) && this.IsRefreshing) {
                        itemSelectedCopie = this.data[i];
                    }
                }

                if (itemSelectedCopie != null) {
                    this.showDetails(itemSelectedCopie);
                }

                this.IsRefreshing = false;

                this.sumData = this.data[0];
            }
        },
        tableOptionsChanged: function(oldValue, newValue) {

            this.sortColumn = '';

            newValue.paginationParams.count = 0;
            newValue.paginationParams.positionDebut = 1;
            newValue.paginationParams.positionFin = 1;

            var columns = newValue.columns;

            if (newValue.isRealTime == undefined) {
                newValue.isRealTime = false;
            }

            if (newValue.realTimePeriod == undefined) {
                newValue.realTimePeriod = 0;
            }

            if (newValue.multiChecked == undefined) {
                newValue.multiChecked = false;
            }

            if (newValue.enableColModify == undefined) {
                newValue.enableColModify = false;
            }

            if (newValue.enableColDelete == undefined) {
                newValue.enableColDelete = false;
            }

            if (newValue.showIDColumn == undefined) {
                newValue.showIDColumn = true;
            }

            if (newValue.showHeader == undefined) {
                newValue.showHeader = true;
            }

            if (newValue.showFooter == undefined) {
                newValue.showFooter = true;
            }

            if (newValue.showCountSelector == undefined) {
                newValue.showCountSelector = true;
            }

            if (newValue.showSumRow == undefined) {
                newValue.showSumRow = false;
            }

            // configurer search-input
            var params = [];

            this.sumFields = [];

            var anyIsKey = false;
            this.columnsCount = columnsInitCount;
            for (var i = 0; i < columns.length; i++) {
                var elt = columns[i];
                elt.idRow = 'col' + i;

                // définir les champs utiles non spécifiés
                elt.fieldSearchValue = undefined;

                if (elt.width == undefined) {
                    elt.width = null;
                }

                if (elt.type == undefined) {
                    elt.type = 'text';
                }

                if (elt.visible == undefined) {
                    elt.visible = true;
                }

                if (elt.isKey == undefined) {
                    elt.isKey = false;
                }

                if (elt.isSumField == undefined) {
                    elt.isSumField = false;
                }
                // fin définition

                if (elt.isKey === true && !anyIsKey) {
                    this.propIsKey = elt;
                    anyIsKey = true;
                }

                if (elt.visible)
                    this.columnsCount++;

                if (elt.isCriteria) {
                    var p = {
                        fieldResult: elt.fieldResult,
                        fieldSearch: elt.fieldSearch,
                        label: elt.title,
                        isValueShown: false,
                        isCriteria: true,
                        type: elt.type,
						defaultFieldSearch: elt.defaultFieldSearch
                    };

                    params.push(p);

                    if (p.defaultSort) {
                        this.sortColumn = p.fieldResult;
                    }
                }

                if (elt.defaultSort) {
                    this.orderByParams = {
                        orderByField: elt.fieldSearch,
                        infoSearchField: getInfoSearch(elt.fieldSearch)
                    }
                }

                if (elt.isSumField && elt.type === "money") {
                    var o = { field: elt.fieldSearch, infoSearchField: getInfoSearch(elt.fieldSearch) }
                    this.sumFields.push(o);
                }
            }

            // prendre la première colonne comme clé par défaut si aucune clé précisée
            if (!anyIsKey && columns.length > 0) {
                columns[0].isKey = true;
                this.propIsKey = columns[0];
            }

            this.paramsSearchInput = params;
        },
        showCurrentDetails: function(event, detail, sender) {
            var item = event.target.templateInstance.model.item;
            this.showDetails(item);
        },
        showDetails: function(item) {
            // fermer l'item ouvert précédent
            if (this.itemSelected != null && this.itemSelected.idRow != item.idRow) {
                closeDetails(this.itemSelected);
                this.itemSelected = null;
            }

            if (item.imageUrl === imageUrlClose) {
                closeDetails(item);
                this.itemSelected = null;
            } else {
                this.fire('show-details', { msg: { idInstance: this.idInstance, currentItem: item } });
                openDetails(item);
                this.itemSelected = item;
            }
        },
        loadItems: function(searchParams) {
            var values = [];

            if (Utilities.IsUndefinedOrNull(searchParams)) {
                this.tableOptions.paginationParams.positionDebut = 1;
            } else {
                if (searchParams.criterias instanceof Array) {
                    for (var i = 0; i < searchParams.criterias.length; i++) {
                        if (searchParams.criterias[i].isCriteria)
                            values.push(searchParams.criterias[i]);
                    }
                }

                if (searchParams.paginationParams.positionDebut > 0)
                    this.tableOptions.paginationParams.positionDebut = searchParams.paginationParams.positionDebut;
                else
                    this.tableOptions.paginationParams.positionDebut = 1;
            }

            if (this.autoLoading) {
                this.fire('load-items', { msg: { idInstance: this.idInstance, takeAll: this.tableOptions.tableIsBasic, criterias: values, paginationParams: this.tableOptions.paginationParams, loadSilent: this.IsRefreshing, sortOrder: this.orderByParams.sortOrder } });
            }

            this.autoLoading = true;

        },
        doOrderItems: function (event, detail, sender) {

            var col = event.target.templateInstance.model.col;

            var orderByField = col.fieldSearch;

            if (orderByField === "")
                return;

            this.orderItems(col);
        },
        orderItems: function(column) {

            if (this.orderByParams !== null && this.orderByParams.field != null && this.orderByParams.field !== column.fieldSearch) {
                for (var i = 0; i < this.tableOptions.columns.length; i++) {
                    if (this.tableOptions.columns[i].fieldSearch === this.orderByParams.field) {
                        this.tableOptions.columns[i].faSort = undefined;
                    }
                }

                column.faSort = undefined;
                this.orderByParams.sortOrder = "Ascending";
            }

            if (column.faSort === undefined) {
                column.faSort = (this.orderByParams.sortOrder === "Ascending") ? faSortAsc : faSortDesc;
            }
            else if (column.faSort === faSortAsc) {
                column.faSort = faSortDesc;
            } else {
                column.faSort = faSortAsc;
            }

            this.orderByParams.field = column.fieldSearch;
            this.orderByParams.infoSearchField = getInfoSearch(column.fieldSearch);

            if (this.orderByParams.sortOrder === "Ascending")
                this.orderByParams.sortOrder = "Descending";
            else
                this.orderByParams.sortOrder = "Ascending";

            this.loadItems(this.searchParamsSelected);
        },
        isCurrentOrderByField: function(orderByField) {
            return (this.orderByParams.field === orderByField) ? true : false;
        },
        orderByParamsChanged: function(oldValue, newValue) {

        },
        refreshItems: function() {
            this.IsRefreshing = true;
            this.loadItems(this.searchParamsSelected);
        },
        getPropertyValue: function(value, propertyName) {
            return Utilities.GetPropertyValueOfObject(value, propertyName);
        },
        getPropertyFontSize: function(value) {
            return (value !== null && value !== undefined) ? value : 13;
        },
        valuePerPageChanged: function(event, detail, sender) {
            this.pagination.setPerPage(parseInt(sender.value));
        },
        launchSearch: function(event, detail, sender) {
            //this.tableOptions.paginationParams.positionDebut = detail.msg.positionDebut;
            //this.tableOptions.paginationParams.positionFin = detail.msg.positionFin;
            //this.tableOptions.paginationParams.currentPage = detail.msg.numPage;

            if (detail.msg.idInstance !== this.$.pagination.idInstance)
                return;

            this.searchParamsSelected.paginationParams.positionDebut = detail.msg.positionDebut;
            this.loadItems(this.searchParamsSelected);
        },
        setItems: function(data, countTotal) {
            this.itemsSelected = [];

            if (data instanceof Array) {
                this.pagination.setTotalItems(countTotal);
                this.data = data;
            }

            this.restartRealTimeMode();
        },
        addItem: function(item) {
            //this.pagination.setTotalItems(this.pagination.totalItems + 1);
            //this.data.unshift(item);

            //this.searchParamsSelected = Utilities.clone(searchParamsInit)
            this.loadItems();
        },
        modifyItem: function(item, index, showDetails) {

            if (index >= 0 && index < this.data.length) {
                this.data[index] = item;
            //    if (showDetails == true || showDetails == undefined) {
            //        this.showDetails(item);
            //    }
            }
            this.IsRefreshing = true;
            //this.refreshItems();
        },
        removeItem: function(index) {
            if (index >= 0 && index < this.data.length) {
                this.data.splice(index, 1);

                this.restartRealTimeMode();
            }
            //if (index >= 0 && index < this.data.length) {
            //    this.data[index] = item;
            //    if (showDetails == true || showDetails == undefined) {
            //        this.showDetails(item);
            //    }
            //}

            this.IsRefreshing = true;
            //this.refreshItems();
        },
        doMonoSearchOfItems: function(event, detail, sender) {

            var criteria; // = detail.msg.criteriaName;

            for (var i = 0; i < this.tableOptions.columns.length; i++) {
                if (this.tableOptions.columns[i].isCriteria && (this.tableOptions.columns[i].fieldSearch == detail.msg.criteriaName.fieldSearch)) {
                    criteria = this.tableOptions.columns[i];
                    break;
                }
            }

            if (criteria) {
                criteria.fieldSearchValue = detail.msg.searchWord;
                this.searchParamsSelected.criterias = [criteria];
                this.searchParamsSelected.paginationParams.positionDebut = 1;
                this.loadItems(this.searchParamsSelected);
            }
        },
        doMultiSearchOfItems: function(event, detail, sender) {

            this.job('job1', function() {
                this.fire('done');

                var criterias = [];

                for (var i = 0; i < this.tableOptions.columns.length; i++) {
                    if (this.tableOptions.columns[i].isCriteria) {
                        var criteria = this.tableOptions.columns[i];
                        criterias.push(criteria);
                    }
                }

                this.searchParamsSelected.criterias = criterias;
                this.searchParamsSelected.paginationParams.positionDebut = 1;

                this.loadItems(this.searchParamsSelected);
            }, 500);
        },
        doRefreshItems: function(event, detail, sender) {
            this.refreshItems();
        },
        jsonToDate: function(input, format) {
            return Utilities.jsonToDate(input, format);
        },
        toDate: function(input, format) {

            var dateJson = "\/Date(" + (Utilities.formatUTCDate(input)) + ")\/";
            return Utilities.jsonToDate(dateJson, format);
        },
        factorRequest: function(obj, criteriasName) {
            if (!(criteriasName instanceof Array))
                return obj;

            var orderFieldAsCriteriaField = false;

            for (var i = 0; i < criteriasName.length; i++) {
                var ctx = criteriasName[i];

                if (ctx.fieldSearchValue === '' || ctx.fieldSearchValue == null) {
                    obj[ctx.fieldSearch] = undefined;
                } else {
                    if (ctx.type === 'date') {
                        var dateTrans = new Date(Date.parse(ctx.fieldSearchValue));

                        if (ctx.encoding === 'json') {
                            obj[ctx.fieldSearch] = Utilities.dateToJson(dateTrans);
                        } else {
                            obj[ctx.fieldSearch] = dateTrans;
                        }

                    } else {
                        obj[ctx.fieldSearch] = ctx.fieldSearchValue || undefined;
                    }
                }

                //create order by expression
                if (ctx.fieldSearch === this.orderByParams.field && ctx.fieldSearchValue !== "" && ctx.fieldSearchValue !== undefined) {
                    obj[this.orderByParams.infoSearchField] = { Consider: true, IsOrderByField: true };
                    orderFieldAsCriteriaField = true;
                }
            }

            if (!orderFieldAsCriteriaField && this.orderByParams.infoSearchField !== "")
                obj[this.orderByParams.infoSearchField] = { IsOrderByField: true };

            for (var k = 0; k < this.sumFields.length; k++) {
                var sumField = this.sumFields[k];

                var infoSearchObj = { IsSumField: true };

                if (obj[sumField.infoSearchField] != undefined) {
                    //verifier sil est critere de recherche
                    if (obj[sumField.infoSearchField].Consider) {
                        infoSearchObj.Consider = true;
                    }
                    //verifier sil est utilisé pour ordonner
                    if (obj[sumField.infoSearchField].IsOrderByField) {
                        infoSearchObj.IsOrderByField = true;
                    }
                }

                obj[sumField.infoSearchField] = infoSearchObj;
            }

            return obj;
        },
        sortByKey: function(array, key, desc) {
            return array.sort(function(a, b) {
                var x = a[key];
                var y = b[key];

                if (typeof x == "string") {
                    x = x.toLowerCase();
                    y = y.toLowerCase();
                }
                if (desc) {
                    return ((x < y) ? 1 : ((x > y) ? -1 : 0));
                } else {
                    return ((x < y) ? -1 : ((x > y) ? 1 : 0));
                }
            });
        },
        selectCurrentItem: function(event, detail, sender) {
            var itemValue = event.target.templateInstance.model.item;

            itemValue.idRow = parseInt(itemValue.idRow);

            this.itemsSelected = [];
            for (var i = 0; i < this.data.length; i++) {

                if (this.tableOptions.multiChecked) {
                    if (this.data[i].idRow === itemValue.idRow) {
                        this.data[i].selected = !this.data[i].selected;
                    }
                } else {
                    this.data[i].selected = this.data[i].idRow === itemValue.idRow;
                }

                if (this.data[i].selected) {
                    this.itemsSelected.push(this.data[i]);
                }
            }

            this.fire('item-selected', { msg: { idInstance: this.idInstance, item: itemValue } });
        },
        getColumnId: function(positionDebut, idRow) {
            return parseInt(positionDebut) + parseInt(idRow);
        },
        getFontColor: function(item, columns) {
			var val = this.evaluateExp(item, columns);
            var o = (val !== null && val !== undefined && val.isTrue) ? val.data.fontColor : 'black';
            return o;
        },
        getRowColor: function(a, b, item, columns) {
			var val = null;
			var o = null;
			//var secondColor = !Utilities.IsUndefinedOrNull(this.tableOptions.row2ndColor) ? this.tableOptions.row2ndColor : "#ECECEC";
			var secondColor = !Utilities.IsUndefinedOrNull(this.tableOptions.row2ndColor) ? this.tableOptions.row2ndColor : "white";
			val = this.evaluateExp(item, columns);
			if (!val){
				o = this.modulo(a, b) ? secondColor : 'white';
			}else {
				o = (val.isTrue) ? val.data.rowColor : this.modulo(a, b) ? secondColor : 'white';
			}
            
            return o;
        },
		evaluateExp: function(item, columns){
			
			var hasRowSep = false;
			var firstOperand = null;
			var secondOperand = null;
			var operator = null;
			var rowSpe = null;
			
			for (var i = 0; i < columns.length; i++){
				var col = columns[i];
				if (col.rowSpe != undefined){
					hasRowSep = true;
					firstOperand = item[col.fieldResult];
					secondOperand = col.rowSpe.operand;
					operator = col.rowSpe.operator;
					rowSpe = col.rowSpe;
					break;
				}
			}
			
			var resp = null;
			if (hasRowSep){
				var b = false;
				switch (operator) {
					case 'EQUAL':
						b = (firstOperand === secondOperand);
						break;
					case 'NOT EQUAL':
						b = (firstOperand !== secondOperand);
						break;
					case 'MORE':
						b = (firstOperand > secondOperand);
						break;
					case 'MORE OR EQUAL':
						b = (firstOperand >= secondOperand);
						break;
					case 'LESS':
						b = (firstOperand < secondOperand);
						break;
					case 'LESS OR EQUAL':
						b = (firstOperand <= secondOperand);
						break;
				}
				
				resp = { isTrue : b, data: rowSpe}
			}
			return resp;
		},
        getHeaderColor: function(color) {
            //var c = "lightgrey";
            //var c = "#3498db";
            var c = "#ecf0f1";
            if (!Utilities.IsUndefinedOrNull(color))
                c = color;
            return c;
        },
        getHeaderFontColor: function (color) {
            var c = "black";
            //var c = "white";
            if (!Utilities.IsUndefinedOrNull(color))
                c = color;
            return c;
        },
        getTextAlign: function(colType) {
            return (colType === 'money') ? 'right' : 'left';
        },
        modulo: function(a, b) {
            var c = a % b;
            return c;
        },
        formatMillier: function(input) {
            return Utilities.formatMillier(input);
        },
        GetItemsSelected: function() {
            return this.itemsSelected;
        },
        GetItems: function () {
            return this.data;
        },
        wantToModifyItem: function(event, detail, sender) {
            var itemValue = event.target.templateInstance.model.item;
            itemValue.isVisualization = false;

            this.job('do-modify-item', function() {
                this.fire('done');

                this.fire('modify-item', { msg: { idInstance: this.idInstance, item: itemValue } });
            }, 500);
        },
        wantToUpdateItemColumn: function(event, detail, sender) {
            var itemValue = event.target.templateInstance.model.item;
            itemValue.isVisualization = false;
            console.log(itemValue); 
            this.fire('update-item-row', { msg: { idInstance: this.idInstance, item: itemValue } });
        },
        wantToDeleteItem: function(event, detail, sender) {
            var itemValue = event.target.templateInstance.model.item;
            itemValue.isVisualization = false;

            this.fire('delete-item', { msg: { idInstance: this.idInstance, item: itemValue } });
        },
        wantToVisualizeItem: function(event, detail, sender) {
            var itemValue = event.target.templateInstance.model.item;
            itemValue.isVisualization = true;

            this.job('do-visualize-item', function() {
                this.fire('done');

                this.fire('visualize-item', { msg: { idInstance: this.idInstance, item: itemValue } });
            }, 500);
        },
        reset: function() {
            // cacher bar
            for (var i = 0; i < this.searchParamsSelected.criterias.length; i++) {
                var col = this.searchParamsSelected.criterias[i];
                if (col.isCriteria) {
                    col.fieldSearchValue = undefined;
                }
            }

            if (this.searchParamsSelected.criterias.length > 0)
                this.loadItems(this.searchParamsSelected);
            // fin cacher bar                        

            this.$.searchInput.reset();
            this.searchParamsSelected.paginationParams.positionDebut = 1;

            this.clear();
        },
        clear: function() {
            this.setItems([], 0);
        },
        restartRealTimeMode: function() {

            this.job('start-real-time', function() {
                this.fire('done');

                if (!this.tableOptions.isRealTime || this.tableOptions.realTimePeriod < 10)
                    return;

                this.refreshItems();

                // pour assurer le lancement automatiquement
                // si le chargement échoue
                // le temps auto est > realTimePeriod
                this.initAutoLaunch();

            }, this.tableOptions.realTimePeriod * 1000);
        },
        initAutoLaunch: function() {
            this.job('init-auto-launch', function() {
                this.fire('done');

                this.restartRealTimeMode();

            }, (this.tableOptions.realTimePeriod + REAL_TIME_PERIOD_TOLERANCE) * 1000);
        },
        stopRealTimeMode: function() {
            this.tableOptions.isRealTime = false;
        },
        startRealTimeMode: function() {
            this.tableOptions.isRealTime = true;
            this.restartRealTimeMode();
        },
        setCurrentCriteria: function(item, autoLoading) {
            this.autoLoading = Utilities.IsUndefinedOrNull(autoLoading) ? true : autoLoading;
            this.$.searchInput.setCurrentItem(item, true);
        },
        textToImage: function(value) {
            return Utilities.textToImage(value);
        }
    });
}());