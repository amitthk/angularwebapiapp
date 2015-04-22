'use strict';
app.controller('projController', ['$scope','$timeout', 'projService', function ($scope, $timeout, projService) {

    $scope.projects = [];

    $timeout(function () {
    projService.getProjects().then(function (results) {

        $scope.projects = results;

    }, function (error) {
        //alert(error.data.message);
    });
    }, 1);


}]);