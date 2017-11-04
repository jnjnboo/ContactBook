angular.module('contactBookApp.routes', ['ngRoute'])

    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider

            .when('/', {
                controller: 'contactController',
                title: 'Contact Book',
                templateUrl: 'App_Web/mod_contact/vw_contact.html',
            })
            .otherwise({ redirectTo: '' });

    //Removes # tag from URL - breaking routing, not sure why
    //$locationProvider.html5Mode(true);
}]);