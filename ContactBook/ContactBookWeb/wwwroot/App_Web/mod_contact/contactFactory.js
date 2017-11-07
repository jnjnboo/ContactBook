var contact = angular.module('contactBookApp.contact');

contact.factory('contactFactory', ['$http', 'CommonConstants', function ($http, CommonConstants) {
    var url = CommonConstants.apiUrl

    return {
        //** Contacts **//
        getContacts: function () {
            return $hhtp.get(url + 'Contacts')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        getContact: function (contactId) {
            return $hhtp.get(url + 'Contacts?contactId' + contactId)
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        postContact: function (contact) {
            return $http.post(url + 'Contacts=', contact)
                .success(function (response) {
                    return response;
                }).error(function (data, status, headers, config) {
                });
        },
        putContact: function (contact, contactId) {
            return $http.put(url + 'Contacts?contactId=' + contactId, contact)
                .success(function (response) {
                    return response;
                }).error(function (data, status, headers, config) {
                    return data;
                });
        },
        deleteRuleScope: function (ruleID, scopeID) {
            return $http.delete(url + 'RuleScope?ruleID=' + ruleID + '&scopeID=' + scopeID)
                .success(function (response) {
                    return response;
                }).error(function (data, status, headers, config) {
                    return data;
                });
        },
    };
}]);