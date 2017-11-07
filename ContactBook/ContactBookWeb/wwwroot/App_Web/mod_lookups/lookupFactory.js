var lookup = angular.module('contactBookApp.lookup');

lookup.factory('lookupFactory', ['$http', 'CommonConstants', function ($http, CommonConstants) {
    var url = CommonConstants.apiUrl

    return {
        getAddressTypes: function () {
            return $hhtp.get(url + 'Lookup/AddressTypes')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        getEmailTypes: function () {
            return $hhtp.get(url + 'Lookup/EmailTypes')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        getEventTypes: function () {
            return $hhtp.get(url + 'Lookup/EventTypes')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        getPhoneTypes: function () {
            return $hhtp.get(url + 'Lookup/PhoneTypes')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
        getWebsiteTypes: function () {
            return $hhtp.get(url + 'Lookup/WebsiteTypes')
                .success(function (response) {
                    return response.data;
                }).error(function (data, status, headers, config) {
                    if (status === 404)
                        return null;
                });
        },
    };
}]);