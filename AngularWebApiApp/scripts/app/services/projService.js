'use strict';
app.factory('projService', ['$http','$q', 'ngAuthSettings', function ($http, $q, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var projServiceFactory = {};

    var _getProjects = function () {
        var deferred = $q.defer();
        var responsePromise = $http.get(serviceBase + 'api/proj');
        responsePromise.success(function (data, status, headers, config) { deferred.resolve(data); });
        responsePromise.error(function (data, status, headers, config) { deferred.reject({ error: "Ajax Failed", errorInfo: data }); });
        return (deferred.promise);
    };

    projServiceFactory.getProjects = _getProjects;

    return projServiceFactory;

}]);