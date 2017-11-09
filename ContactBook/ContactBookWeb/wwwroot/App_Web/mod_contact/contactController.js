var contact = angular.module('contactBookApp.contact');

contact.controller('contactController', ['$scope', '$route', '$routeParams', '$rootScope', '$location', 'contactFactory',
    function ($scope, $route, $routeParams, $rootScope, $location, contactFactory) {
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

        contactCtrl.closeContact = function () {
            contactCtrl.singleContact = {};
            contactCtrl.showSingleContact = false;
        }
        //** Edit **//
        contactCtrl.editContact = function () {
            contactCtrl.showSingleContact = true;
            contactCtrl.originalContact = angular.copy(contactCtrl.singleContact);
            contactCtrl.viewOnly = false;
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

        contactCtrl.cancelEdit = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.singleContact = angular.copy(contactCtrl.originalContact);
                contactCtrl.viewOnly = true;
            } else {
                contactCtrl.closeContact();
            }
        };

        //** Add **//
        contactCtrl.addNewContact = function () {
            contactCtrl.singleContact = {};
            contactCtrl.viewOnly = false;
            contactCtrl.showSingleContact = true;
            contactCtrl.getDefault();
        }
        contactCtrl.getDefault = function () {
            contactFactory.getDefault().then(function (contact) {
                contact.singleContact = angular.copy(contact);
                contact.singleContact.contactId = undefined;
                contactCtrl.singleContactIsLoaded = true;
            });
        };

        contactCtrl.saveNew = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.originalContact = {};
            }

            contactFactory.postContact(contactCtrl.singleContact).then(function (contact) {
                contactCtrl.singleContact = angular.copy(contact);
                contactCtrl.viewOnly = true;
                contactCtrl.getAllScopes();
            });
        };

        contactCtrl.cancelSaveNew = function () {
            contactCtrl.singleContact = {};
            contactCtrl.showSingleContact = false;
        };

        //** Delete **//
        contactCtrl.deleteContact = function () {
            contactFactory.deleteContact(contactCtrl.singleContact);
        };

        $scope.init = function () {
            contactCtrl.allLoaded = true;
            contactCtrl.singleContact = {};

            if (commonCtrl.addNewContact) {
                commonCtrl.addNewContact = false;
                contactCtrl.addNewContact();
            }
            else {
                contactCtrl.showSingleContact = true;
                contactCtrl.viewOnly = true;
                contactCtrl.getSingleContact(1, 5);
            }
        };
    }]);