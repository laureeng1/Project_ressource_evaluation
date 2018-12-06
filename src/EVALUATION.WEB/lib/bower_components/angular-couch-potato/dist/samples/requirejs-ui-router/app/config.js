// Anything required here wil by default be combined/minified by r.js
// if you use it.
define(['/lib/bower_components/angular-couch-potato/dist/samples/requirejs-ui-router/app/app.js', '/lib/bower_components/angular-couch-potato/dist/samples/requirejs-ui-router/app/routeDefs.js'], function (app) {

  app.config(['routeDefsProvider', function(routeDefsProvider) {

    // in large applications, you don't want to clutter up app.config
    // with routing particulars.  You probably have enough going on here.
    // Use a service provider to manage your routing.

  }]);

});
