var common = angular.module('contactBookApp.common');

common.controller('commonController', ['$scope', '$rootScope', '$route', '$routeParams', '$location', 'alertService', 'lookupFactory',
    function ($scope, $rootScope, $route, $routeParams, $location, alertService, lookupFactory) {
        var commonCtrl = this;

        $scope.Title = 'Common Controller';
        $scope.$route = $route;
        $scope.$routeParams = $routeParams;
        $rootScope.referrer = $location.$$path;
        $rootScope.closeAlert = alertService.closeAlert;
        
        commonCtrl.isNavCollapsed = true;

        commonCtrl.getAllLookups = function () {
            lookupFactory.getAddressTypes().then(function (addressTypes) {
                if (angular.isDefined(addressTypes)) {
                    commonCtrl.addressTypes = angular.copy(addressTypes);
                } else {
                    commonCtrl.addressTypes = [];
                }
            });

            lookupFactory.getEmailTypes().then(function (emailTypes) {
                if (angular.isDefined(emailTypes)) {
                    commonCtrl.emailTypes = angular.copy(emailTypes);
                } else {
                    commonCtrl.emailTypes = [];
                }
            });

            lookupFactory.getPhoneTypes().then(function (phoneTypes) {
                if (angular.isDefined(phoneTypes)) {
                    commonCtrl.phoneTypes = angular.copy(phoneTypes);
                } else {
                    commonCtrl.phoneTypes = [];
                }
            });
        };

        //** INIT **//
        $scope.init = function () {
            commonCtrl.getAllLookups();
            //TODO: update with real UserID when Auth in place
            commonCtrl.user = { userId: 1 };
        };
    }]);