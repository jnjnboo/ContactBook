angular.module('contactBookApp', ['ui.bootstrap', 'ngCookies', 'ngAnimate']);
angular.module('contactBookApp.routes', []);
angular.module('contactBookApp.services', []);
angular.module('contactBookApp.common', []);
angular.module('contactBookApp.contact', []);
angular.module('contactBookApp.lookup', []);


var searchApp = angular.module('contactBookApp',
    [
        'ngRoute',
        'contactBookApp',
        'contactBookApp.routes',
        'contactBookApp.services',
        'contactBookApp.contact',
        'contactBookApp.common',
        'contactBookApp.lookup',
        'ui.bootstrap'
    ]);

searchApp.run(function ($rootScope) {
    $rootScope.name = 'contactBookApp';
    $rootScope.$on('$routeChangeSuccess', function (event, currentRoute, previousRoute) {
        if (typeof currentRoute.title !== 'undefined') {
            $rootScope.title = currentRoute.title;
        } else {
            $rootScope.title = 'contactBookApp';
        }
    });
});