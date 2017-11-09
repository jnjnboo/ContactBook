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