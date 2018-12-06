'use strict';

/* Search input */

/* properties of element of searchOptions : fieldResult; fieldSearch; label; isCriteria; type */

(function() {

    var self = null;

    var initKendoTreeView = function(treeObj, treeDataSource, onSelect, onChange, onCheck) {
        treeObj.kendoTreeView({
            checkboxes: {
                checkChildren: true
            },
            dataSource: treeDataSource,
            select: onSelect,
            change: onChange,
            //collapse: onCollapse,
            //expand: onExpand,
            //dragAndDrop: true,
            ///* drag & drop events */
            //dragstart: onDragStart,
            //drag: onDrag,
            //drop: onDrop,
            //dragend: onDragEnd,
            //navigate: onNavigate
        });
        treeObj.data("kendoTreeView").dataSource.bind('change', onCheck);
    };

    // function that gathers IDs of checked nodes
     var checkedNodeIds = function (nodes, checkedNodes, objClass) {
        for (var i = 0; i < nodes.length; i++) {
            var currentNode = nodes[i];
            if (currentNode.checked) {
                var original = new objClass(currentNode.orignalData);
                checkedNodes.push(original);
            }

            if (currentNode.hasChildren) {
                var chNodes = currentNode.children.view();
                checkedNodeIds(chNodes, checkedNodes, objClass);
            }
        }
     };


     var unCheckedNodeIds = function (nodes, unCheckedNodes, objClass) {
        for (var i = 0; i < nodes.length; i++) {
            var currentNode = nodes[i];
            if (!currentNode.checked) {
                var original = new objClass(currentNode.orignalData);
                unCheckedNodes.push(original);
            }

            if (currentNode.hasChildren) {
                var chNodes = currentNode.children.view();
                unCheckedNodeIds(chNodes, unCheckedNodes, objClass);
            }
        }
     };

    var modelFactory = null;

    Polymer('tree-view', {
        created: function () {
            self = this;

            this.treeview = null;

            self.treeOptions = {
                checkChildren: true,
                key: '',
                parentKey: '',
                foreignKey: '',
                displayProperty: '',
                modelFactory: null,
                dataSource: []
            };
        },
        ready: function () {
            self = this;

            this.treeview = $(this.$.treeview);           
        },
        attached: function () {
            Utilities.PreventDomPolymer(this, 'loaded');
        },
        detached: function () {
            Utilities.PreventDomPolymer(this, 'removed');
        },
        domReady: function() {
            //self.treeOptions.dataSource = this.toListHierachic(self.treeOptions.dataSource, self.treeOptions.key, self.treeOptions.parentKey, self.treeOptions.displayProperty);
            //initKendoTreeView(this.treeview, self.treeOptions.dataSource, this.selectCurrentItem, this.itemsChecked, this.itemsChecked);
        },
        selectItem: function (e) {
            //e.preventDefault();
            //var node = $(e.node);
            //var checkbox = node.find(":checkbox");
            //var checked = checkbox.prop("checked");
            //checkbox.prop("checked", !checked);

        },
        selectionChange: function() {
        },
        checkItems: function () {
            var checkedNodes = [];
            checkedNodeIds(this.view(), checkedNodes, self.treeOptions.modelFactory);

            self.fire('get-items-checked', { msg: { items: checkedNodes } });
        },
        unCheckItems: function () {
            var unCheckedNodes = [];
            unCheckedNodeIds(this.view(), unCheckedNodes, self.treeOptions.modelFactory);

            self.fire('get-items-unchecked', { msg: { items: unCheckedNodes } });
        },
        treeOptionsChanged: function (oldValue, newValue) {
            modelFactory = this.treeOptions.modelFactory;
            self.treeOptions.dataSource =
                this.toListHierachic(self.treeOptions.dataSource,
                    self.treeOptions.key,
                    self.treeOptions.parentKey,
                    self.treeOptions.displayProperty);
            initKendoTreeView(this.treeview, self.treeOptions.dataSource, this.selectItem, this.selectionChange, this.checkItems);
        },
        setItemsChecked: function (defaultCheckedItems) {
            var data = self.treeOptions.dataSource;
            var idObj = self.treeOptions.key;
            var fkObj = self.treeOptions.foreignKey;
            if (data == null || defaultCheckedItems == null) return;
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < defaultCheckedItems.length; j++) {
                    if (data[i].hasOwnProperty(idObj) && defaultCheckedItems[j].hasOwnProperty(fkObj)) {
                        if (data[i][idObj] === defaultCheckedItems[j][fkObj]) {
                            data[i].id = defaultCheckedItems[j].id;
                            data[i].checked = 'checked';
                        }
                    }
                }
            }
            //this.checkItems();
        },
        toListHierachic: function(data, idObj, idObjParent, libelleObj) {
            if (data == null) return null;
            

            for (var j = 0; j < data.length; j++) {
                var currData = data[j];
                if (currData.hasOwnProperty('orignalData')) {
                    return data;
                }
            }
            // flatten to object with string keys that can be easily referenced later
            var flat = {};
            var i;
            for (i = 0; i < data.length; i++) {
                var currentData = data[i];
                var obj = {};

                //obj.checked = 'checked';

                obj.orignalData = currentData;
                
                if (currentData.hasOwnProperty(idObjParent))
                    obj[idObjParent] = currentData[idObjParent];
                if (currentData.hasOwnProperty('spriteCssClass'))
                    obj.spriteCssClass = currentData['spriteCssClass'];
                if (currentData.hasOwnProperty('checked'))
                    obj.checked = currentData['checked'];

                if (currentData.hasOwnProperty('isChecked'))
                    obj.checked = currentData.isChecked;
               // console.log(obj);
                if (currentData.hasOwnProperty(libelleObj)) {
                    //currentData.text = currentData[libelleObj];
                    obj.text = currentData[libelleObj];
                }
                if (currentData.hasOwnProperty(idObj)) {
                    //currentData.idDefault = currentData[idObj];
                    obj.idDefault = currentData[idObj];
                    obj[idObj] = currentData[idObj];
                    var key = 'key_' + currentData[idObj];
                    //flat[key] = currentData;
                    flat[key] = obj;
                }
            }
            // add child container array to each node
            for (i in flat) {
                flat[i].items = []; // add children container
            }
            // populate the child container arrays
            var parentkey = '';
            i = 0;
            for (i in flat) {
                if (flat[i].hasOwnProperty(idObjParent)) {
                    parentkey = 'key_' + flat[i][idObjParent];
                    if (flat[parentkey]) {
                        flat[parentkey].items.push(flat[i]);
                        //console.log(flat[i]);
                    }
                }
            }
            // find the root nodes (no parent found) and create the hierarchy tree from them
            parentkey = '';
            i = 0;
            var root = [];
            for (i in flat) {
                var currFlat = flat[i];
                parentkey = 'key_' + currFlat[idObjParent];
                var flatParent = flat[parentkey];
                if (flatParent == undefined) {
                    flat[i].expanded = true;
                    root.push(flat[i]);
                }
            }
            return root;
        }
    });
})();

// sample : getHierachicList(data, 'Id', 'IdParent')
//var getHierachicList = function (data, idObj, idObjParent, libelleObj) {
//    if (data == null || data == undefine) return null;
//    // flatten to object with string keys that can be easily referenced later
//    var flat = {};
//    var i;
//    for (i = 0; i < data.length; i++) {

//        var currentData = data[i];
//        var obj = {};
//        //data[i].expanded = true;

//        if (data[i].hasOwnProperty(libelleObj)) {
//            data[i].text = data[i][libelleObj];
//        }
//        if (data[i].hasOwnProperty(idObj)) {
//            data[i].idDefault = data[i][idObj];

//            var key = 'key_' + data[i][idObj];
//            flat[key] = data[i];
//        }
        
//    }

//    // add child container array to each node
//    for (i in flat) {
//        flat[i].items = []; // add children container
//    }

//    // populate the child container arrays
//    var parentkey = '';
//    i = 0;
//    for (i in flat) {
//        if (flat[i].hasOwnProperty(idObjParent)) {
//            parentkey = 'key_' + flat[i][idObjParent];
//            if (flat[parentkey]) {
//                flat[parentkey].items.push(flat[i]);
//            }
//        }
//    }

//    // find the root nodes (no parent found) and create the hierarchy tree from them
//    parentkey = '';
//    i = 0;
//    var root = [];
//    for (i in flat) {
//        if (flat[i].hasOwnProperty(idObjParent)) {
//            parentkey = 'key_' + flat[i][idObjParent];
//            if (!flat[parentkey]) {
//                root.push(flat[i]);
//            }
//        }
//    }
//    return root;
//};