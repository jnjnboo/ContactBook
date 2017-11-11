var contact = angular.module('contactBookApp.contact');

contact.controller('contactController', ['$scope', '$route', '$routeParams', '$rootScope', '$location', '$filter', 'contactFactory',
    function ($scope, $route, $routeParams, $rootScope, $location, $filter, contactFactory) {
        var contactCtrl = this;
        var commonCtrl = $scope.commonCtrl;
        contactCtrl.contacts = [];
        contactCtrl.selectedContact = {};

        $scope.Title = 'Contact Controller';

        //** All Contacts **//
        contactCtrl.getAllContacts = function (selected) {
            contactCtrl.contacts = [];
            contactCtrl.contactsAreLoaded = false;

            contactFactory.getContacts().then(function (contacts) {
                if (angular.isDefined(contacts)) {
                    contactCtrl.contacts = angular.copy(contacts);
                    if (angular.isDefined(selected)){
                        var found = $filter('filter')(contactCtrl.contacts, { contactId: selected.contactId }, true);
                        if (found.length) {
                            contactCtrl.selectedContact = found[0];
                        }
                    }
                }

                contactCtrl.contactsAreLoaded = true;
            });
        };

        contactCtrl.resetAndLoadScopes = function () {
            contactCtrl.searchContacts = "";
            contactCtrl.getAllContacts();
        };

        //** SORT All Contacts table  **//
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
                return 'fa fa-arrow-' + direction;
            }
        };

        //** Single Contact **//
        contactCtrl.viewContact = function (contactId, selected) {
            if (angular.isDefined(selected)){
                contactCtrl.selectedContact = selected;
            }
            contactCtrl.singleContact = {};
            contactCtrl.singleContactIsLoaded = false;
            contactCtrl.showSingleContact = true;
            contactCtrl.viewOnly = true;

            contactFactory.getContact(contactId).then(function (contact) {
                if (angular.isDefined(contact)) {
                    contactCtrl.singleContact = angular.copy(contact);
                } else {
                    contactCtrl.singleContact = {};
                }

                contactCtrl.singleContactIsLoaded = true;
            });
        };

        contactCtrl.closeContact = function () {
            contactCtrl.singleContact = {};
            contactCtrl.selectedContact = {};
            contactCtrl.originalContact = {};
            contactCtrl.deleteContactConfirmation = false;
            contactCtrl.showSingleContact = false;
        };

        //** Edit **//
        contactCtrl.editContact = function (contactId, selected) {
            if (angular.isDefined(selected)) {
                contactCtrl.selectedContact = selected;
            }

            if (angular.isDefined(contactId)) {
                contactFactory.getContact(contactId).then(function (contact) {
                    if (angular.isDefined(contact)) {
                        contactCtrl.singleContact = angular.copy(contact);
                        contactCtrl.originalContact = angular.copy(contact);
                        contactCtrl.singleContactIsLoaded = true;
                    } else {
                        contactCtrl.closeContact();
                    }

                    contactCtrl.showSingleContact = true;
                    contactCtrl.originalContact = angular.copy(contactCtrl.singleContact);
                    contactCtrl.viewOnly = false;
                });
            } else {
                contactCtrl.showSingleContact = true;
                contactCtrl.originalContact = angular.copy(contactCtrl.singleContact);
                contactCtrl.viewOnly = false;
            }
        };

        contactCtrl.saveEdit = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.originalContact = {};
            }

            contactFactory.putContact(contactCtrl.singleContact).then(function () {
                contactCtrl.getAllContacts(contactCtrl.selectedContact);
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
            contactCtrl.selectedContact = {};
            contactCtrl.viewOnly = false;
            contactCtrl.showSingleContact = true;
            contactCtrl.getDefault();
        };

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
                contactCtrl.getAllContacts();
            });
        };

        contactCtrl.cancelSaveNew = function () {
            contactCtrl.closeContact();
            contactCtrl.getAllContacts();
        };

        //** Delete **//
        contactCtrl.deleteContact = function (contact) {
            contactFactory.deleteContact(contact).then(function (contact) {
                contactCtrl.closeContact();
                contactCtrl.getAllContacts();
            });
        };

        $scope.init = function () {
            contactCtrl.singleContact = {};
            contactCtrl.getAllContacts();

            if (commonCtrl.addNewContact) {
                commonCtrl.addNewContact = false;
                contactCtrl.addNewContact();
            }

            contactCtrl.sortContacts = {
                column: '', descending: false
            };
        };
    }]);