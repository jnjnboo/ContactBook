var common = angular.module('contactBookApp.common');

common.controller('commonController', ['$scope', '$rootScope', '$route', '$routeParams', '$location', 'alertService',
    function ($scope, $rootScope, $route, $routeParams, $location, alertService) {
        var commonCtrl = this;

        $scope.Title = 'Common Controller';
        $scope.$route = $route;
        $scope.$routeParams = $routeParams;
        $rootScope.referrer = $location.$$path;
        $rootScope.closeAlert = alertService.closeAlert;

        //** TABLE SORT methods **//
        commonCtrl.changeSort = function (column, sort) {
            $scope.changeSort(column, sort);
        };

        $scope.changeSort = function (column, sort) {
            if (sort.column === column) {
                sort.descending = !sort.descending;
            } else {
                sort.column = column;
                sort.descending = false;
            }
        };

        $scope.sortClass = function (column, sort) {
            if (sort.column === column) {
                var direction = "up";
                if (!sort.descending)
                    direction = "down";
                return 'glyphicon glyphicon-arrow-' + direction;
            }
        };

        //** INIT **//
        $scope.init = function () {

        };
    }]);