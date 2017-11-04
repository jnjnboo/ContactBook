﻿var main = angular.module('contactBookApp.common');

main.controller('commonController', ['$scope', '$rootScope', '$route', '$routeParams', '$location', 
    function ($scope, $rootScope, $route, $routeParams, $location) {
        var commonCtrl = this;

        $scope.Title = 'Common Controller';
        $scope.$route = $route;
        $scope.$routeParams = $routeParams;
        $rootScope.referrer = $location.$$path;


        //** ALERTS**//
        commonCtrl.showAlert = function (message, type) {
            commonCtrl.message = message;
            commonCtrl.type = type;
            commonCtrl.alertVisible = true;
        };
    
        //** TABLE SORT methods **//
        commonCtrl.changeSort = function (column, sort) {
            $scope.changeSort(column, sort);
        };

        $scope.changeSort = function (column, sort) {
            if (sort.column == column) {
                sort.descending = !sort.descending;
            } else {
                sort.column = column;
                sort.descending = false;
            }
        };

        $scope.sortClass = function (column, sort) {
            if (sort.column == column) {
                var direction = "up";
                if (!sort.descending)
                    direction = "down";
                return 'glyphicon glyphicon-arrow-' + direction;
            };
        };

        //** INIT **//
        $scope.init = function () {

        };
    }]);