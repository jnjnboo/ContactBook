var lookup = angular.module('contactBookApp.lookup');

lookup.factory('lookupFactory', ['$http', 'CommonConstants', function ($http, CommonConstants) {
    var url = CommonConstants.apiUrl;

    return {
        getAddressTypes: function () {
            return $http.get(url + 'Lookup/AddressTypes').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("error", "Requested data for Address Types was not found.");
                console.log(error, 'Unable to retrieve Address Types from the server.');
                if (status === 404)
                    return null;
            });
        },
        getEmailTypes: function () {
            return $http.get(url + 'Lookup/EmailTypes').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("error", "Requested data for Address Types was not found.");
                console.log(error, 'Unable to retrieve Address Types from the server.');
                if (status === 404)
                    return null;
            });
        },
        getEventTypes: function () {
            return $http.get(url + 'Lookup/EventTypes').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("error", "Requested data for Address Types was not found.");
                console.log(error, 'Unable to retrieve Address Types from the server.');
                if (status === 404)
                    return null;
            });
        },
        getPhoneTypes: function () {
            return $http.get(url + 'Lookup/PhoneTypes').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("error", "Requested data for Address Types was not found.");
                console.log(error, 'Unable to retrieve Address Types from the server.');
                if (status === 404)
                    return null;
            });
        },
        getWebsiteTypes: function () {
            return $hhtp.get(url + 'Lookup/WebsiteTypes').then(function (response) {
                return response.data;
            }, function (error) {
                alertService.add("error", "Requested data for Address Types was not found.");
                console.log(error, 'Unable to retrieve Address Types from the server.');
                if (status === 404)
                    return null;
            });
        }
    };
}]);