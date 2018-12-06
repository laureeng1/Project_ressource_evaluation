define(['definitions', 'utilities'], function () {
    'use strict';

    /* Directives */
    CoreDirective.directive('hasPermission',
        [
            '$rootScope',
            '$location',
            '$timeout',
            'commonUtilities',
            'Security',
            function($rootScope, $location, timer, commonUtilities, security) {

                return {
                    require: '',

                    link: function(scope, element, attr) {
                        //<!--has-permission='{ "value" : "ok", "type" : "disabled" }'  or  has-permission="ok" or has-permission="!ok"-->
                        var init = function() {
                            try {
                                var permissionList = [];
                                if (commonUtilities.IsUndefinedOrNull(security.currentUser()))
                                    throw 'no user define'

                                if (commonUtilities.IsJsonString(attr.hasPermission)) {
                                    var elements = JSON.parse(attr.hasPermission);
                                    if (commonUtilities.IsUndefinedOrNull(elements.length)) {
                                        permissionList.push(elements);
                                    }
                                    else {
                                        permissionList = elements;
                                    }
                                }
                                else if (angular.isString(attr.hasPermission.trim())) {
                                    var current = {};
                                    current.value = attr.hasPermission.trim();
                                    current.type = "";
                                    permissionList.push(current);

                                }
                                else {
                                    throw 'hasPermission value must be a string or a json string'
                                }

                                var find = false;
                                var userClaims = security.currentUser().Permissions;
                                angular.forEach(permissionList, function (permissionListItem) {
                                    var permission = {};
                                    if (angular.isString(permissionListItem)) {
                                        permission.value = permissionListItem;
                                        permission.type = "";
                                    }
                                    else {
                                        permission = permissionListItem;
                                    }
                                    var notPermissionFlag = permission.value[0] === '!';
                                    if (notPermissionFlag) {
                                        permission.value = permission.value.slice(1).trim();
                                    }
                                    var hasPermission = Enumerable.From(userClaims).Where(function (x) {
                                        return x == permission.value;
                                    }).Any();

                                    if (notPermissionFlag) {
                                        hasPermission = !hasPermission;
                                    }
                                    if (hasPermission && !find) {
                                        find = true;
                                    }
                                   
                                },{});

                                if (!find) {
                                    switch (permissionList[0].type) {
                                        case 'hidden':
                                            $(element).hide();
                                            break;
                                        case 'disabled':
                                            element.attr("disabled", "disabled");
                                            break;
                                        default:
                                            $(element).remove();
                                            break;
                                    }
                                }
                               

                            } catch(e) {
                                //console.log(e.message);
                            } finally {
                            }

                        };

                        init();
                    }
                };
            }]);
    
  
});