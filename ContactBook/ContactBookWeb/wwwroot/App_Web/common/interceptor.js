(function () {
    "use strict";
    var common = angular.module("contactBookApp.common");

    common.factory('MyHttpInterceptor', ['$q', '$location', '$cookies', function ($q, $location, $cookies) {
        return {
            'request': function (config) {
                config.headers = config.headers || {};

                //var token = $cookies.get('token');

                //if (token) {
                //    config.headers.Authorization = 'Bearer ' + token;
                //}

                return config || $q.when(config);
            },
            'requestError': function (rejection) {
                return $q.reject(rejection);
            },
            'response': function (response) {
                return response || $q.when(response);
            },
            'responseError': function (response) {
                if (response.status === 401 || response.status === 419) {
                    //$location.path('/signIn');
                    $location.path('/');
                }
                else {
                    return $q.reject(response, response.status);
                }
            }
        };
    }]);

    common.config(['$httpProvider', '$cookiesProvider', function ($httpProvider, $cookiesProvider) {
        //Registers the interceptor in the httpProvider's interceptors array during configuration of app
        $httpProvider.interceptors.push('MyHttpInterceptor');

        $cookiesProvider.defaults = {
            path: 'contactBook',
            domain: 'rawlins',
            secure: true
        };
    }]);
})();