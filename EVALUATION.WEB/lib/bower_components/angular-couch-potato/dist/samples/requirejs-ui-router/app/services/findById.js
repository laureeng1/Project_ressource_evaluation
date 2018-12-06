define(['/lib/bower_components/angular-couch-potato/dist/samples/requirejs-ui-router/app/app.js'], function (app) {
  app.registerService(
    'findById',
    function() {
      this.find = function(array, id) {
        for (var i=0; i<array.length; i++) {
          if (array[i].id == id) return array[i];
        }
      };
    }
  );
});
