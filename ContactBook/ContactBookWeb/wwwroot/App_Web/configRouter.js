angular.module('contactBookApp.routes', ['ngRoute'])

    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider

            .when('/', {
                controller: 'contactController',
                title: 'Contact Book',
                templateUrl: 'App_Web/mod_contact/vw_contact.html',
            })
            .otherwise({ redirectTo: '/' });

        ///TODO: Cannot get this working with multiple paths
        //if (window.history && window.history.pushState) {
        //    // setting base URL: https://docs.angularjs.org/error/$location/nobase
        //    $locationProvider.html5Mode({
        //        enabled: true,
        //        requireBase: false
        //    });
        //}
    }]);