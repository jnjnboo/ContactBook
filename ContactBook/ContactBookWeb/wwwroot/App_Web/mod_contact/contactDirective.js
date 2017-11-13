var contact = angular.module('contactBookApp.contact');

contact.directive('contactItem', function () {
    return {
        restrict: 'EA',
        scope: {
            item: '=contactItem'
        },
        templateUrl: 'App_Web/mod_contact/contacts_Item.html'
    };
});


contact.directive('emailItem', function () {
    return {
        restrict: 'EA',
        scope: {
            item: '=emailItem'
        },
        templateUrl: 'App_Web/mod_contact/collection/contact_Email.html',
        link: function (scope, $scope) {
            scope.item.dropdown = scope.item.emailTypeId - 1;
            scope.item.controlId = "email" + scope.item.emailId;
        }
    };
});

contact.directive('phoneItem', function () {
    return {
        restrict: 'EA',
        scope: {
            item: '=phoneItem'
        },
        templateUrl: 'App_Web/mod_contact/collection/contact_Phone.html',
        link: function (scope, $scope) {
            scope.item.dropdown = scope.item.phoneTypeId - 1;
            scope.item.controlId = "phone" + scope.item.phoneId;
        }
    };
});