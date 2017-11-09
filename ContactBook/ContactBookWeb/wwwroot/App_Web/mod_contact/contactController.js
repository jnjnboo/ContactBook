var contact = angular.module('contactBookApp.contact');

contact.controller('contactController', ['$scope', '$route', '$rootScope', '$routeParams', '$location', 'contactFactory',
    function ($scope, $route, $rootScope, $routeParams, $location, contactFactory) {
        var contactCtrl = this;
        var commonCtrl = $scope.commonCtrl;

        $scope.Title = 'Contact Controller';

        //** All Contacts **//
        contactCtrl.getAllScopes = function () {
        };

        //** Single Contact **//
        contactCtrl.getSingleContact = function (userId, contactId) {
            contactCtrl.singleContact = {};
            contactCtrl.singleContactIsLoaded = false;

            contactFactory.getContact(contactId).then(function (contact) {
                if (angular.isDefined(contact)) {
                    contactCtrl.singleContact = contact;
                } else {
                    contactCtrl.singleContact = {};
                }

                contactCtrl.singleContactIsLoaded = true;
            });
        };

        contactCtrl.editContact = function () {
            contactCtrl.showSingleContact = true;
            contactCtrl.originalContact = angular.copy(contactCtrl.singleContact);
            contactCtrl.viewOnly = false;
        };

        contactCtrl.cancelEdit = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.singleContact = angular.copy(contactCtrl.originalContact);
                contactCtrl.viewOnly = true;
            } else {
                contactCtrl.closeContact();
            }
        };

        contactCtrl.saveEdit = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.originalContact = {};
            }

            contactFactory.putContact(contactCtrl.singleContact).then(function () {
                contactCtrl.getAllScopes();
            });
            contactCtrl.viewOnly = true;
        };

        contactCtrl.getDefault = function () {
            contactFactory.getDefault().then(function (contact) { 
                contact.singleContact = angular.copy(contact);
                contact.singleContact.contactId = undefined;
            });
        };

        contactCtrl.saveNew = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.originalContact = {};
            }

            contactFactory.postContact(contactCtrl.singleContact).then(function () {
                contactCtrl.getAllScopes();
            });
            contactCtrl.viewOnly = true;
        };

        contactCtrl.deleteContact = function () {
            contactFactory.deleteContact(contactCtrl.singleContact);
            contactCtrl.singleContact = {};
            contactCtrl.showSingleContact = false;
        };

        contactCtrl.closeContact = function () {
            contactCtrl.singleContact = {};
            contactCtrl.showSingleContact = false;
        };

        $scope.init = function () {
            contactCtrl.allLoaded = true;

            if ($route.current.$$route.addNew) {
                contactCtrl.showSingleContact = true;
            }

            contactCtrl.showSingleContact = true;
            contactCtrl.viewOnly = true;
            contactCtrl.getSingleContact(1, 5);
        };
    }]);