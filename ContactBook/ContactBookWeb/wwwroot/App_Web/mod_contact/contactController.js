var app = angular.module('contactBookApp.contact');

app.controller('contactController', ['$scope', '$rootScope', '$routeParams', '$location', 
    function ($scope, $rootScope, $routeParams, $location) {
        var contactCtrl = this;
        var commonCtrl = $scope.commonCtrl;

        $scope.Title = 'Contact Controller';

        $scope.init = function () {
            contactCtrl.allLoaded = true;
        };
    }]);