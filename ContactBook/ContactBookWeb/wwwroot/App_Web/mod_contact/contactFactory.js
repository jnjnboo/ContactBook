var contact = angular.module('contactBookApp.contact');

contact.factory('contactFactory', ['$http', 'CommonConstants', 'alertService', function ($http, CommonConstants, alertService) {
    var url = CommonConstants.apiUrl;

    return {
        getContacts: function () {
            return $http.get(url + 'Contacts').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("warning", "Requested data for all contacts was not found.");
                console.log(error, 'Unable to retrieve list of contacts from the server.');
            });
        },
        getContact: function (contactId) {
            return $http.get(url + 'Contacts/' + contactId).then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("warning", "Requested data for the selected contact was not found.");
                console.log(error, 'Unable to retrieve contact from the server.');
            });
        },
        getDefault: function () {
            return $http.get(url + 'Contacts/Default').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("warning", "Requested data was not found.");
                console.log(error, 'Unable to retrieve default contact from the server.');
            });
        },
        postContact: function (contact) {
            return $http.post(url + 'Contacts', contact).then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("warning", "Unable to save new contact, please try again.");
                console.log(error, 'Unable to retrieve data from the server.');
            });
        },
        putContact: function (contact) {
            return $http.put(url + 'Contacts/' + contact.contactId, contact).then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("warning", "Unable to save recent contact edit, please try again.");
                console.log(error, 'Unable to retrieve data from the server.');
            });
        },
       deleteContact : function (contact) {
           return $http.delete(url + 'Contacts/' + contact.contactId, contact).then(function (response) {
               return response.data;
           }, function (error) {
               alertService.add("warning", "Unable to delete the contact, please try again.");
               console.log(error, 'Unable to retrieve data from the server.');
           });
        }
    };
}]);