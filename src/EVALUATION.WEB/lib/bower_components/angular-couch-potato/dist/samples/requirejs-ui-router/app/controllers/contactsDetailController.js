define(['/lib/bower_components/angular-couch-potato/dist/samples/requirejs-ui-router/app/app.js', '/lib/bower_components/angular-couch-potato/dist/samples/requirejs-ui-router/app/services/findById.js'], function (app) {
  app.registerController(
    'contactsDetailController',
    [        '$scope', '$stateParams', 'something', 'findById',
    function ($scope,   $stateParams,   something, findById) {
      $scope.something = something;
      $scope.contact = findById.find($scope.contacts, $stateParams.contactId);
    }]
  );
});
