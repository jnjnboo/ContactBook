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
                    if (angular.isDefined(selected)) {
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

        //** Collections **//
        contactCtrl.addEmail = function () {
            if (!angular.isDefined(contactCtrl.singleContact.email)) {
                contactCtrl.singleContact.email = [];
            }
            contactCtrl.singleContact.email.push({ emailAddress: '' });
        };

        contactCtrl.deleteEmail = function (item) {
            var index = contactCtrl.singleContact.email.indexOf(item);
            if (index > -1) {
                contactCtrl.singleContact.email.splice(index, 1);
            }
        };

        contactCtrl.addPhone = function () {
            if (!angular.isDefined(contactCtrl.singleContact.phone)) {
                contactCtrl.singleContact.phone = [];
            }
            contactCtrl.singleContact.phone.push({  number: '' });
        };

        contactCtrl.deletePhone = function (item) {
            var index = contactCtrl.singleContact.phone.indexOf(item);
            if (index > -1) {
                contactCtrl.singleContact.phone.splice(index, 1);
            }
        };
        //** SORT All Contacts table  **//
        contactCtrl.changeSort = function (column, sort) {
            contactCtrl.changeSort(column, sort);
        };

        contactCtrl.changeSort = function (column, sort) {
            if (sort.column === column) {
                sort.descending = !sort.descending;
            } else {
                sort.column = column;
                sort.descending = false;
            }
        };

        contactCtrl.sortClass = function (column, sort) {
            if (sort.column === column) {
                var direction = "up";
                if (!sort.descending)
                    direction = "down";
                return 'fa fa-arrow-' + direction;
            }
        };

        //** Single Contact **//
        contactCtrl.viewContact = function (contactId, selected) {
            if (angular.isDefined(selected)) {
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
                contactCtrl.viewContact(contactCtrl.singleContact.contactId);
            });
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
            contactCtrl.getDefault();
        };

        contactCtrl.getDefault = function () {
            contactFactory.getDefault().then(function (contact) {
                contact.singleContact = angular.copy(contact);
                contact.singleContact.contactId = undefined;
                contactCtrl.viewOnly = false;
                contactCtrl.showSingleContact = true;
                contactCtrl.singleContactIsLoaded = true;
            });
        };

        contactCtrl.saveNew = function () {
            if (angular.isDefined(contactCtrl.originalContact)) {
                contactCtrl.originalContact = {};
            }

            contactCtrl.singleContact.userId = 1; //update when we have new user

            contactFactory.postContact(contactCtrl.singleContact).then(function (contact) {
                if (angular.isDefined(contact)) {
                    contactCtrl.singleContact = angular.copy(contact);
                    contactCtrl.viewOnly = true;
                    contactCtrl.getAllContacts();
                }
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