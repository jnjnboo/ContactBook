﻿angular.module('contactBookApp', ['ui.bootstrap']);
angular.module('contactBookApp.routes', []);
angular.module('contactBookApp.common', []);
angular.module('contactBookApp.contact', []);


var searchApp = angular.module('contactBookApp',
    [
        'ngRoute',
        'contactBookApp',
        'contactBookApp.routes',
        'contactBookApp.contact',
        'contactBookApp.common',
        'ui.bootstrap'
    ]);

searchApp.run(function ($rootScope) {
    $rootScope.name = 'contactBookApp';
    $rootScope.$on('$routeChangeSuccess', function (event, currentRoute, previousRoute) {
        if (typeof (currentRoute.title) != 'undefined') {
            $rootScope.title = currentRoute.title;
        } else {
            $rootScope.title = 'contactBookApp';
        }
    });
});