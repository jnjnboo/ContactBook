var common = angular.module('contactBookApp.common');

common.controller('commonController', ['$scope', '$rootScope', '$route', '$routeParams', '$location', 'alertService',
    function ($scope, $rootScope, $route, $routeParams, $location, alertService) {
        var commonCtrl = this;

        $scope.Title = 'Common Controller';
        $scope.$route = $route;
        $scope.$routeParams = $routeParams;
        $rootScope.referrer = $location.$$path;
        $rootScope.closeAlert = alertService.closeAlert;

        //** INIT **//
        $scope.init = function () {

        };
    }]);